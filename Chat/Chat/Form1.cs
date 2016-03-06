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

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            // Thread es una clase que permite definir hilos
            Thread tarea = new Thread(hilo);
            // Comienza el hilo
            tarea.Start();
        }

        private void hilo()
        {
            try
            {
                // instanciamos un TcpListener
                servidor = new TcpListener(IPAddress.Parse(txtIP.Text), int.Parse(txtPuerto.Text));
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
            txtConversacion.Text = mensaje;
        }

    }
}
