using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Registro : Form
    {
        Socket server;
        Thread atender;
        Boolean conectado = false;
        int puerto;

        public Registro(int puerto)
        {
            InitializeComponent();
            this.puerto = puerto;
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        // Recibe las respuestas del servidor a las consultas hechas por el cliente.
        private void atenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];

                switch (codigo)
                {
                    case 1: // Registro usuario.
                        MessageBox.Show(mensaje);
                        atender.Abort();
                        server.Shutdown(SocketShutdown.Both);
                        server.Close();
                        break;
                }
            }
        }

        // Se inicia la conexión con el servidor.
        // Se registra el nuevo usuario.
        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            if (!conectado)
            {
                if ((usuarioBox.Text.Trim() != string.Empty) && (contraseñaBox.Text.Trim() != string.Empty))
                {
                    // Conexión con la máquina virtual.
                    IPAddress direc = IPAddress.Parse("192.168.56.102");
                    IPEndPoint ipep = new IPEndPoint(direc, puerto);
                    // Conexión con el entorno de producción.
                    //IPAddress direc = IPAddress.Parse("147.83.117.22");
                    //IPEndPoint ipep = new IPEndPoint(direc, 50069);

                    // Creamos el socket.
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep); //Intentamos conectar el socket.
                        MessageBox.Show("Conectado");
                    }
                    catch (SocketException)
                    {
                        // Si hay excepcion imprimimos error y salimos del programa con return.
                        MessageBox.Show("No se ha podido conectar con el servidor");
                        return;
                    }

                    // Iniciamos el threat.
                    ThreadStart ts = delegate { atenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();

                    string usuario = usuarioBox.Text.Trim();
                    string contraseña = contraseñaBox.Text.Trim();
                    string mensaje = "1/" + usuario + "/" + contraseña + "/";

                    // Enviamos al servidor el mensaje.
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    usuarioBox.Text = null;
                    contraseñaBox.Text = null;
                }
                else
                {
                    MessageBox.Show("El usuario y/o la contraseña estan vacios");
                }
            }

            else
            {
                MessageBox.Show("Ya estás conectado con un usuario");
            }
        }

        // Se cierra este Form y se vuelve al Form de "IniciarSesión".
        private void iniciarLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Decoración.
        private void iniciarLabel_MouseEnter(object sender, EventArgs e)
        {
            iniciarLabel.ForeColor = Color.DarkRed;
        }

        // Decoración.
        private void iniciarLabel_MouseLeave(object sender, EventArgs e)
        {
            iniciarLabel.ForeColor = Color.Black;
        }
    }
}
