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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
        string nombre;
        Boolean conectado = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
        }

        //private void conectar_Click(object sender, EventArgs e)
        //{
        //    //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
        //    //al que deseamos conectarnos
        //    IPAddress direc = IPAddress.Parse("192.168.56.102");
        //    IPEndPoint ipep = new IPEndPoint(direc, 9000);

        //    //Creamos el socket 
        //    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    try
        //    {
        //        server.Connect(ipep);//Intentamos conectar el socket
        //        this.BackColor = Color.Green;
        //        MessageBox.Show("Conectado");
        //    }
        //    catch (SocketException)
        //    {
        //        //Si hay excepcion imprimimos error y salimos del programa con return 
        //        MessageBox.Show("No se ha podido conectar con el servidor");
        //        return;
        //    }
        //}

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

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show(mensaje);
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
                    IPEndPoint ipep = new IPEndPoint(direc, 9000);

                    //Creamos el socket 
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep);//Intentamos conectar el socket
                        this.BackColor = Color.Green;
                        MessageBox.Show("Conectado");
                    }
                    catch (SocketException)
                    {
                        //Si hay excepcion imprimimos error y salimos del programa con return 
                        MessageBox.Show("No se ha podido conectar con el servidor");
                        return;
                    }

                    string usuario = usuarioIniciar.Text.Trim(); //el método TrimEnd elimina los espacios en blanco tanto al principio como al final
                    string contrasena = contrasenaIniciar.Text.Trim();
                    string mensaje = "2/" + usuario + "/" + contrasena;

                    // Enviamos al servidor el mensaje
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    if (mensaje == "error1")
                    {
                        MessageBox.Show("El usuario no existe => desconectado");
                        this.BackColor = Color.Gray;
                        server.Shutdown(SocketShutdown.Both);
                        server.Close();
                    }
                    else if (mensaje == "error2")
                    {
                        MessageBox.Show("Contraseña incorrecta => desconectado");
                        this.BackColor = Color.Gray;
                        server.Shutdown(SocketShutdown.Both);
                        server.Close();
                    }
                    else
                    {
                        nombre = usuario;
                        conectado = true;
                        MessageBox.Show(mensaje);
                    }
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
                string mensaje = "3/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show(mensaje);

            }

            else if (PartidasPerdidas.Checked)
            {
                if ((UsuarioPerdidas.Text.Trim() != string.Empty))
                {
                    string usuario = UsuarioPerdidas.Text.Trim();
                    string mensaje = "4/" + usuario;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show("Las partidas perdidas son: " + mensaje);
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
                    string mensaje = "5/" + password;
                    // Enviamos al servidor el mensaje
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show(mensaje);
                }
                else
                {
                    MessageBox.Show("Introduce la contraseña que quieres comparar");
                }
            }
        }

        private void dameConectados_Click(object sender, EventArgs e)
        {
            string mensaje = "6/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            conectadosLabel.Text = mensaje;
        }

        private void desconectar_Click(object sender, EventArgs e)
        {           
            if (usuarioIniciar.Text.Trim() != string.Empty)
            {
                string mensaje = "0/" + nombre;

                // Enviamos al servidor el mensaje
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                conectado = false;
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            else
            {
                MessageBox.Show("El usuario y/o la contraseña estan vacios");
            }
        }
    }
}
