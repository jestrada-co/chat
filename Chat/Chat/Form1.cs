using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading; // para usar hilos en mi aplicación
using System.Net.NetworkInformation;

namespace Chat
{
    public partial class frmMain : Form
    {
        private TcpListener servidor;           // servidor escucha a través de un socket
        private TcpClient cliente;              // conexion con el cliente

        Byte[] bytesCliente;                    // bytesCliente es un flujo de bytes

        NetworkStream streamCliente;            // definir un stream de bytes que viene desde el cliente
  
        NetworkStream streamServidor;
        TcpClient clienteEnviar;

        Thread escuchar;
        
        private bool tecla = false;
        private bool estadoServidor = false;
        bool sw = true;
        private int cantMensajes = 0;
        private string mensaje;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtIP.Text = obtenerIPLocal().ToString();
            txtIPCliente.Text = obtenerIPLocal().ToString();
            txtIPCliente.Focus();
        }

        private IPAddress obtenerIPLocal()
        {
            IPHostEntry host;
            IPAddress localIP = null;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip;
                }
            }
            return localIP;
        }


        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (btnConectar.Text == "Iniciar Servidor")
            {
                if (ValidarCampos("iniciarServidor"))
                {
                    iniciarServidor(true);
                    habilitarCampos(false,"iniciarServidor");
                    btnConectar.Text = "Detener Servidor";
                }
            }
            else
            {
                iniciarServidor(false);
                habilitarCampos(true, "iniciarServidor");
                btnConectar.Text = "Iniciar Servidor";
            }
        }

        private bool iniciarServidor(bool estado)
        {
            if (estado)
            {
                escuchar = new Thread(servidorEscucha);
                escuchar.Start();
                estadoServidor = true;
                return true;
            }
            else
            {
                if (estadoServidor)
                {
                    try
                    {
                        servidor.Stop();
                        escuchar.Abort();
                        estadoServidor = false;
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.HResult.ToString());
                    }
                }
                return false;
            }
        }

        private void habilitarCampos(bool estado, string proceso)
        {
            if (proceso == "iniciarServidor")
            {
                txtIP.Enabled = estado;
                txtPuertoServidor.Enabled = estado;
            }
            else
            {
                if(proceso == "enviarMensaje")
                {
                    txtIPCliente.Enabled = estado;
                    txtPuertoCliente.Enabled = estado;
                    txtNick.Enabled = estado;
                }
            }
        }

        private Boolean ValidarCampos(string proceso)
        {
            Boolean sw = true;
            String mensajeError="";

            if (proceso == "iniciarServidor")
            {
                mensajeError = "Error al iniciar el servior FTP. Favor validar los siguientes campos: ";
                if (txtIP.Text == "")
                {
                    mensajeError = ", la Dirección IP Local";
                    sw = false;
                }
                if (txtPuertoServidor.Text == "")
                {
                    mensajeError = mensajeError + ", el Puerto Local";
                    sw = false;
                }
            }
            else
            {
                if (proceso == "enviarMensaje")
                {
                    mensajeError = "Error al iniciar el enviar mensaje vía FTP. Favor Validar los siguientes campos: ";
                    if (txtIPCliente.Text == "")
                    {
                        mensajeError = "la Dirección IP Destino";
                        sw = false;
                    }
                    if (txtPuertoCliente.Text == "")
                    {
                        mensajeError = mensajeError + ", el Puerto Destino";
                        sw = false;
                    }
                    if (txtNick.Text == "")
                    {
                        mensajeError = mensajeError + ", el NickName";
                        sw = false;
                    }
                    if (string.IsNullOrWhiteSpace(txtMensaje.Text))
                    {
                        mensajeError = mensajeError + ", el mensaje a enviar";
                        sw = false;
                    }
                }
            }
            if (!sw)
            {
                mensajeError = mensajeError + ".";
                MessageBox.Show(mensajeError, "Error en Diligenciamiento de Campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return sw;
        }

        private void servidorEscucha()
        {
            try
            {
                servidor = new TcpListener(IPAddress.Parse(txtIP.Text), int.Parse(txtPuertoServidor.Text));
                servidor.Start();
                estadoServidor = true;

                while (true)
                {
                    cliente = servidor.AcceptTcpClient();
                    cantMensajes = 0;
                    bytesCliente = new byte[256];
                    streamCliente = cliente.GetStream();
                    streamCliente.Read(bytesCliente, 0, bytesCliente.Length);
                    mensaje = Encoding.ASCII.GetString(bytesCliente, 0, bytesCliente.Length);
                    txtConversacion.Invoke(new EventHandler(imprimirMensaje));
                }
            }
            catch (Exception error)
            {
                //iniciarServidor(false);
                if (error.HResult.ToString() == "-2147467259")
                {
                    MessageBox.Show("El equipo " + txtIP.Text + " a través del Puerto " + txtPuertoServidor.Text + " no permitió la conexión. Por favor valide la dirección IP y Puerto del equipo para recibir por TCP.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitarCampos(true, "iniciarServidor");
                }
                else
                {
                    if(error.HResult.ToString()== "-2146233040")
                    {
                        MessageBox.Show("El equipo " + txtIP.Text + " a través del Puerto " + txtPuertoServidor.Text + " ha detenido el servidor TCP.", "Servidor Detenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        habilitarCampos(true, "iniciarServidor");
                    }
                    else
                    {
                        MessageBox.Show("Error no manejado ------- " + error.ToString());

                    }
                }
            }
        }

        private void imprimirMensaje(object sender, EventArgs e)
        {
            if (mensaje.CompareTo("zumbido")==0)
            {
                timer1.Enabled = true;
            }
            else
            {
                if (string.IsNullOrEmpty(txtConversacion.Text))
                {
                    if (mensaje.CompareTo(":)") == 0)
                    {
                        if (Clipboard.ContainsImage())
                        {
                            Clipboard.Clear();
                        }
                        Clipboard.SetImage(imgList.Images[0]);
                        txtConversacion.ScrollToCaret();
                        txtConversacion.Paste();
                    }
                    else
                    {
                        if (mensaje.CompareTo(":(") == 0)
                        {
                            if (Clipboard.ContainsImage())
                            {
                                Clipboard.Clear();
                            }
                            Clipboard.SetImage(imgList.Images[1]);
                            txtConversacion.ScrollToCaret();
                            txtConversacion.Paste();
                        }
                        else
                        {
                            txtConversacion.Text = mensaje;
                        }
                    }
                }
                else
                {
                    if (mensaje.CompareTo(":)") == 0)
                    {
                        //if (Clipboard.ContainsImage())
                        //{
                        //    Clipboard.Clear();
                        //}
                        Clipboard.SetImage(imgList.Images[0]);
                        txtConversacion.ScrollToCaret();
                        txtConversacion.Paste();
                    }
                    else
                    {
                        if (mensaje.CompareTo(":(") == 0)
                        {
                            //if (Clipboard.ContainsImage())
                            //{
                            //    Clipboard.Clear();
                            //}
                            Clipboard.SetImage(imgList.Images[1]);
                            txtConversacion.ScrollToCaret();
                            txtConversacion.Paste();
                        }
                        else
                        {
                            txtConversacion.Text = txtConversacion.Text + mensaje;
                        }
                    }
                }
                txtConversacion.ScrollToCaret();
            }

        }

        private void zumbido(int constante)
        {

        }

        private void enviarMensaje()
        {
            try
            {
                clienteEnviar = new TcpClient(txtIPCliente.Text, int.Parse(txtPuertoCliente.Text));
                streamServidor = clienteEnviar.GetStream();
                mensaje = txtNick.Text + " @ " + txtMensaje.Text;
                Byte[] datos = Encoding.ASCII.GetBytes(mensaje);
                streamServidor.Write(datos, 0, datos.Length);
                streamServidor.Flush();
                imprimirMensaje(null, null);
                alistarTexbox(null, null);
            }
            catch (Exception error)
            {
                cantMensajes = cantMensajes - 1;
                if (error.HResult.ToString() == "-2147467259")
                {
                    MessageBox.Show("El equipo " + txtIPCliente.Text + " a través del Puerto " + txtPuertoCliente.Text + " no permitió la conexión. Por favor valide la dirección IP y Puerto del equipo Cliente.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitarCampos(true, "enviarMensaje");
                }
                else
                {
                    MessageBox.Show(error.Message.ToString());
                }
            }
        }

        private void enviarZumbido()
        {
            try
            {
                clienteEnviar = new TcpClient(txtIPCliente.Text, int.Parse(txtPuertoCliente.Text));
                streamServidor = clienteEnviar.GetStream();
                mensaje = "zumbido";
                Byte[] datos = Encoding.ASCII.GetBytes(mensaje);
                streamServidor.Write(datos, 0, datos.Length);
                streamServidor.Flush();
                imprimirMensaje(null, null);
                alistarTexbox(null, null);
            }
            catch (Exception error)
            {
                if (error.HResult.ToString() == "-2147467259")
                {
                    MessageBox.Show("El equipo " + txtIPCliente.Text + " a través del Puerto " + txtPuertoCliente.Text + " no permitió la conexión. Por favor valide la dirección IP y Puerto del equipo Cliente.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitarCampos(true, "enviarMensaje");
                }
                else
                {
                    MessageBox.Show(error.Message.ToString());
                }
            }
        }


        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (cantMensajes < 10)
            {
                if (estadoServidor == true)
                {
                    if (ValidarCampos("iniciarServidor"))
                    {
                        if (ValidarCampos("enviarMensaje"))
                        {
                            enviarMensaje();
                            cantMensajes = cantMensajes + 1;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha iniciado el Servidor FTP.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Mensaje no enviado. Debe esperar que el otro usuario responda un mensaje para continuar la conversación.", "Política Anti SPAM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        private void alistarTexbox(object sender, EventArgs e)
        {
            txtMensaje.Text = "";
            txtMensaje.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            iniciarServidor(false);
            Application.Exit();
        }

        private void txtMensaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnEnviar_Click(null, null);
                tecla = true;
            }
        }

        private void txtMensaje_KeyUp(object sender, KeyEventArgs e)
        {
            if (tecla)
            {
                alistarTexbox(null, null);
                tecla = false;
            }
        }

        private void txtConversacion_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = 10;
            int y = 10;
            int constante = 10;
            //constante = constante + Convert.ToInt16(ActiveForm.Location.X);
            // MessageBox.Show(frmMain.ActiveForm.Left.ToString());
            //  ActiveForm.Location = new Point();
            frmMain.ActiveForm.Location = new Point(x, y);
            x = x + constante;
            constante = constante * -1;
            if (timer1.Interval == 2000)
            {
                timer1.Enabled = false;
                MessageBox.Show("finish");
            }
        }

        private void btnZumbido_Click(object sender, EventArgs e)
        {
            enviarZumbido();
        }

        private void btnFeliz_Click(object sender, EventArgs e)
        {
            enviarCarita(":)");
        }

        private void enviarCarita(string estado)
        {
            try
            {
                clienteEnviar = new TcpClient(txtIPCliente.Text, int.Parse(txtPuertoCliente.Text));
                streamServidor = clienteEnviar.GetStream();
                mensaje = estado;
                Byte[] datos = Encoding.ASCII.GetBytes(mensaje);
                streamServidor.Write(datos, 0, datos.Length);
                streamServidor.Flush();
                imprimirMensaje(null, null);
                alistarTexbox(null, null);
            }
            catch (Exception error)
            {
                if (error.HResult.ToString() == "-2147467259")
                {
                    MessageBox.Show("El equipo " + txtIPCliente.Text + " a través del Puerto " + txtPuertoCliente.Text + " no permitió la conexión. Por favor valide la dirección IP y Puerto del equipo Cliente.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitarCampos(true, "enviarMensaje");
                }
                else
                {
                    MessageBox.Show(error.Message.ToString());
                }
            }
        }

        private void btnTriste_Click(object sender, EventArgs e)
        {
            enviarCarita(":(");
        }
        
    }
}
