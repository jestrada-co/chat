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

namespace Chat
{
    public partial class frmMain : Form
    {
        // tcplistener objeto para hacer escucha a través de un socket
        private TcpListener servidor;
        // conexion con el cliente
        private TcpClient cliente;
        // definir un flujo de bytes
        Byte[] bytesCliente;
        // definir un stream de bytes que viene desde el cliente
        NetworkStream streamCliente;
        // cadena de caracteres
        string mensaje;
        NetworkStream streamServidor;
        TcpClient clienteEnviar;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            Thread tarea = new Thread(hilo);
            if (btnConectar.Text == "Iniciar Servidor")
            {
                if (ValidarCampos())
                {
                    // Thread es una clase que permite definir hilos
                    // Comienza el hilo
                    tarea.Start();
                    txtIP.Enabled = false;
                    txtPuertoCliente.Enabled = false;
                    txtPuertoServidor.Enabled = false;
                    txtNick.Enabled = false;
                    btnConectar.Text = "Detener Servidor";
                }
                else
                {
                    MessageBox.Show("Debe diligenciar los campos anteriores!");
                }

            }
            else
            {
                tarea.Abort();
                txtIP.Enabled = true;
                txtPuertoCliente.Enabled = true;
                txtPuertoServidor.Enabled = true;
                txtNick.Enabled = true;
                btnConectar.Text = "Iniciar Servidor";
            }

        }

        private Boolean ValidarCampos()
        {
            Boolean sw = true;
            if (txtIP.Text == "")
            {
                sw = false;
            }
            if (txtPuertoCliente.Text == "")
            {
                sw = false;
            }
            if (txtPuertoServidor.Text == "")
            {
                sw = false;
            }
            if (txtNick.Text == "")
            {
                sw = false;
            }
            return sw;
        }

        private void hilo()
        {
            try
            {
                // instanciamos un TcpListener
                servidor = new TcpListener(IPAddress.Parse(txtIP.Text), int.Parse(txtPuertoServidor.Text));
                // empieza la escucha
                servidor.Start();
                // ciclo infinito de escucha
                while (true)
                {
                    cliente = servidor.AcceptTcpClient();
                    bytesCliente = new byte[256];
                    streamCliente = cliente.GetStream();
                    // aquí hemos colocado en la variable bytesCliente el 
                    // flujo de datos que viene del cliente
                    streamCliente.Read(bytesCliente, 0, bytesCliente.Length);
                    // convertimos el clujo de bytes en cadena de texto
                    mensaje = Encoding.ASCII.GetString(bytesCliente, 0, bytesCliente.Length);
                    // invocando al hilo principal
                    txtConversacion.Invoke(new EventHandler(ImprimirMensaje));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ImprimirMensaje(object sender, EventArgs e)
        {
            if (txtConversacion.Text != "")
            {
                mensaje = txtConversacion.Text + "\r\n" + mensaje;
            }
            txtConversacion.Text = mensaje;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                clienteEnviar = new TcpClient(txtIP.Text, int.Parse(txtPuertoCliente.Text));
                streamServidor = clienteEnviar.GetStream();
                Byte[] datos = Encoding.ASCII.GetBytes(txtNick.Text + " @ " + txtMensaje.Text);
                streamServidor.Write(datos, 0, datos.Length);
                streamServidor.Flush();
                //txtMensaje.Text = "";
                txtMensaje.ResetText();
                txtMensaje.Focus();
            }
            catch (Exception ex)
            {
                txtMensaje.Text = ex.ToString();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtMensaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnEnviar_Click(null, null);
            }
        }

        private void txtMensaje_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
