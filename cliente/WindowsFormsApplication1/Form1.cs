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
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        string nombre;
        string usuarioo;
        string contraseña;
        Boolean conectado = false;
        
        delegate void delegadoEscribir(string mensaje);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        public void mensajeLabel(string mensajee)
        {
            conectadosLabel.Text = mensajee;
        }

        private void atenderServidor()
        {
            int i;
            while (true)
            {
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string [] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];

                switch (codigo)
                {
                    case 1:
                        MessageBox.Show(mensaje);
                        break;

                    case 2:
                        if (mensaje == "error")
                        {
                            MessageBox.Show("El usuario no existe => desconectado");
                            this.BackColor = Color.Gray;
                            atender.Abort();
                            server.Shutdown(SocketShutdown.Both);
                            server.Close();
                        }
                        else if (mensaje == "errorr")
                        {
                            MessageBox.Show("Contraseña incorrecta => desconectado");
                            this.BackColor = Color.Gray;
                            atender.Abort();
                            server.Shutdown(SocketShutdown.Both);
                            server.Close();
                        }
                        else
                        {
                            nombre = usuarioo;
                            conectado = true;
                            MessageBox.Show(mensaje);
                        }
                        break;

                    case 3:
                        MessageBox.Show(mensaje);
                        break;

                    case 4:
                        MessageBox.Show("Las partidas perdidas son: " + mensaje);
                        break;

                    case 5:
                        string mensajeee = string.Format("{0}\n",trozos[1]);
                        for (i = 2; i < trozos.Length; i++)
                        {
                            mensajeee = string.Format("{0}{1}\n", mensajeee, trozos[i]);
                        }
                        MessageBox.Show(mensajeee);
                        break;

                    case 6:
                        //a,b,c
                        string[] conectados = trozos[1].Split(',');
                        string mensajee = string.Format("{0}\n",conectados[0]);
                        for (i = 1; i < conectados.Length; i++)
                        {
                            mensajee = string.Format("{0}{1}\n", mensajee, conectados[i]);
                        }
                        delegadoEscribir delegado = new delegadoEscribir(mensajeLabel);
                        conectadosLabel.Invoke(delegado, new object[] { mensajee });
                        break;
                }
            }
        }

        private void botonRegistro_Click(object sender, EventArgs e)
        {
            if ((usuarioRegistrar.Text.Trim() != string.Empty) && (contraseñaRegistrar.Text.Trim() != string.Empty))
            {
                string usuario = usuarioRegistrar.Text.Trim(); //el método Trim elimina los espacios en blanco tanto al principio como al final
                string contraseña = contraseñaRegistrar.Text.Trim();
                string mensaje = "1/" + usuario + "/" + contraseña;

                // Enviamos al servidor el mensaje
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("El usuario y/o la contraseña estan vacios");
            }
        }

        private void botonIniciar_Click(object sender, EventArgs e)
        {
            if (!conectado)
            {
                if ((usuarioIniciar.Text.Trim() != string.Empty) && (contrasenaIniciar.Text.Trim() != string.Empty))
                {
                    IPAddress direc = IPAddress.Parse("192.168.56.102");
                    IPEndPoint ipep = new IPEndPoint(direc, 5038);
                    //IPAddress direc = IPAddress.Parse("147.83.117.22");
                    //IPEndPoint ipep = new IPEndPoint(direc, 50069);

                    //Creamos el socket 
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep);//Intentamos conectar el socket
                        MessageBox.Show("Conectado");
                        this.BackColor = Color.Green;
                    }
                    catch (SocketException)
                    {
                        //Si hay excepcion imprimimos error y salimos del programa con return 
                        MessageBox.Show("No se ha podido conectar con el servidor");
                        return;
                    }

                    ThreadStart ts = delegate { atenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();

                    usuarioo = usuarioIniciar.Text.Trim(); //el método TrimEnd elimina los espacios en blanco tanto al principio como al final
                    contraseña = contrasenaIniciar.Text.Trim();
                    string mensaje = "2/" + usuarioo + "/" + contraseña;

                    // Enviamos al servidor el mensaje
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
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
   
        private void button2_Click(object sender, EventArgs e)
        {
            if (mas1hora.Checked)
            {
                string mensajeHora = "3/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeHora);
                server.Send(msg);
            }

            else if (PartidasPerdidas.Checked)
            {
                if ((UsuarioPerdidas.Text.Trim() != string.Empty))
                {
                    string usuario = UsuarioPerdidas.Text.Trim();
                    string mensajePartidas = "4/" + usuario;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajePartidas);
                    server.Send(msg);
                }
                else
                {
                    MessageBox.Show("Introduce el usuario que quieres comparar");
                }
            }

            else if (FechaContraseña.Checked)
            {
                if ((ContraseñaFecha.Text.Trim() != string.Empty))
                {
                    string password = ContraseñaFecha.Text.Trim();
                    string mensajeFecha = "5/" + password;
                    // Enviamos al servidor el mensaje
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeFecha);
                    server.Send(msg);
                }
                else
                {
                    MessageBox.Show("Introduce la contraseña que quieres comparar");
                }
            }
        }

        private void desconectar_Click(object sender, EventArgs e)
        {
            if (conectado == true)
            {
                this.BackColor = Color.Gray;
                string mensajeDesconectar = "0/" + nombre;

                // Enviamos al servidor el mensaje
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeDesconectar);
                server.Send(msg);

                conectado = false;
                atender.Abort();
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            else
            {
                MessageBox.Show("No hay nadie conectado");
            }
        }
    }
}
