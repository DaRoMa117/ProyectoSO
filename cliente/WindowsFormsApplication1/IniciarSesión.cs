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
    public partial class IniciarSesión : Form
    {
        Socket server;
        Thread atender;
        string usuario;
        string contraseña;
        int puerto = 7557;
        Boolean conectado = false;
        List<SalaEspera> salas = new List<SalaEspera>(); // Lista para guardas los Forms "SalaEspera".
        DataTable tabla = new DataTable(); // Tabla para implementar los usuarios conectados en la datagridview.

        delegate void delegadoAmagar();
        delegate void delegadoMostrar();

        public IniciarSesión()
        {
            InitializeComponent();
        }

        private void IniciarSesión_Load(object sender, EventArgs e)
        {
            this.tabla.Columns.Add("Usuarios conectados");
        }

        public void amagarForm()
        {
            this.Hide();
        }

        public void mostrarForm()
        {
            this.Show();
        }

        // Recibe las respuestas del servidor a las consultas hechas por el cliente.
        private void atenderServidor()
        {
            int i;
            while (true)
            {
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                if (codigo == 19)
                {
                    trozos = Encoding.ASCII.GetString(msg2).Split(',');
                }
                string mensaje = trozos[1].Split('\0')[0];

                switch (codigo)
                {
                    case 0:
                        if (conectado == false)
                        {
                            MessageBox.Show("Desconectado correctamente");
                            salas.Clear();
                            atender.Abort();
                            server.Shutdown(SocketShutdown.Both);
                            server.Close();
                        }
                        break;
                    case 2: // Iniciar sesión.
                        if (mensaje == "error1")
                        {
                            MessageBox.Show("El usuario no existe => desconectado");
                            atender.Abort();
                            server.Shutdown(SocketShutdown.Both);
                            server.Close();
                        }
                        else if (mensaje == "error2")
                        {
                            MessageBox.Show("Contraseña incorrecta => desconectado");
                            atender.Abort();
                            server.Shutdown(SocketShutdown.Both);
                            server.Close();
                        }
                        else if (mensaje == "error3")
                        {
                            MessageBox.Show("El usuario introducido ya esta siendo utilizado por otro cliente.");
                            atender.Abort();
                            server.Shutdown(SocketShutdown.Both);
                            server.Close();
                        }
                        // Usuario se inicia correctamente y se pasa al Form "SalaEspera".
                        else
                        {
                            conectado = true;
                            MessageBox.Show(mensaje);
                            ThreadStart ts = delegate { iniciarSalaEspera(); };
                            Thread salaEspera = new Thread(ts);
                            salaEspera.Start();
                        }
                        Thread.Sleep(500);
                        break;

                    case 3: // Resultado última partida jugada por el usuario.
                        this.salas[0].dameConsultaUno(trozos[1]);
                        break;

                    case 4: // Número de victorias del usuario.
                        this.salas[0].dameConsultaDos(trozos[1]);
                        break;

                    case 5: // Número de derrotas del usuario.
                        this.salas[0].dameConsultaTres(trozos[1]);
                        break;

                    case 6: // Actualización lista de conectados.
                        string[] conectados = trozos[1].Split(',');
                        this.tabla.Rows.Clear();
                        for (i = 0; i < (conectados.Length - 1); i++)
                        {
                            this.tabla.Rows.Add(conectados[i]);
                        }
                        this.salas[0].dameTabla(this.tabla);
                        break;

                    case 7: // Recibe la invitación.
                        string[] anfitrion = trozos[1].Split(',');
                        string pregunta = string.Format("{0} quiere colaborar contigo. ¿Aceptas?", anfitrion[0]);
                        this.salas[0].dameInvitacion(anfitrion[1], pregunta);
                        break;

                    case 8: // Recibe la respuesta a la invitación.
                        string[] partida = trozos[1].Split(',');
                        this.salas[0].dameConfirmacion(partida[0], partida[1], trozos[2]);
                        break;

                    case 9: // Chat.
                        this.salas[0].dameChat(trozos[1]);
                        break;

                    case 10:
                        this.salas[0].dameRespuestaPantallaUno(trozos[1]);
                        break;

                    case 11:
                        this.salas[0].dameAbrirManual(trozos[1]);
                        break;

                    case 12:
                        this.salas[0].dameRespuestaPantallaDos(trozos[1]);
                        break;

                    case 14:
                        this.salas[0].dameMovimientoPantallaTres(trozos[1]);
                        break;

                    case 15:
                        this.salas[0].dameRespuestaPantallaTres(trozos[1]);
                        break;

                    case 16:
                        this.salas[0].dameRespuestaPantallaFinal(trozos[1]);
                        break;

                    case 19: // Fecha y hora de la última partida jugada por el usuario.
                        this.salas[0].dameConsultaCuatro(trozos[1], trozos[2]);
                        break;
                }
            }
        }

        // Se abre el Form para que un usuario se pueda registrar.
        // Solo se puede registrar si aún no ha iniciado sesión.
        private void registrarseLabel_Click(object sender, EventArgs e)
        {
            if (conectado == false)
            {
                Registro cuenta = new Registro(puerto);
                cuenta.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ya estas conectado. No te puedes registrar.");
            }
        }

        // Se abre el Form para que un usuario se pueda dar de baja.
        // Solo se puede registrar si aún no ha iniciado sesión.
        private void darseBajaLabel_Click(object sender, EventArgs e)
        {
            if (conectado == false)
            {
                DarseBaja baja = new DarseBaja(puerto);
                baja.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ya estas conectado. No te puedes dar de baja.");
            }
        }

        // Se inicia la conexión con el servidor.
        // Se inicia la sesión.
        private void botonIniciar_Click(object sender, EventArgs e)
        {
            if (!conectado)
            {
                if ((usuarioBox.Text.Trim() != string.Empty) && (contraseñaBox.Text.Trim() != string.Empty)) //El método Trim elimina los espacios en blanco tanto al principio como al final
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

                    usuario = usuarioBox.Text.Trim(); 
                    contraseña = contraseñaBox.Text.Trim();
                    string mensaje = "2/" + usuario + "/" + contraseña;

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
                MessageBox.Show("Ya estás conectado");
            }
        }

        // Creamos un Form "SalaEspera" y lo añadimos a la lista salas.
        private void iniciarSalaEspera()
        {
            int numSala = this.salas.Count;
            SalaEspera s = new SalaEspera(server, numSala, usuario);
            this.salas.Add(s);
            delegadoAmagar delegado1 = new delegadoAmagar(amagarForm); // Amagamos el Form al abrir el nuevo.
            this.Invoke(delegado1);
            s.ShowDialog();
            delegadoMostrar delegado2 = new delegadoMostrar(mostrarForm);// Volvemos a mostrar el Form una vez se cierra el de "SalaEspera".
            this.Invoke(delegado2);
            string mensajeDesconectar = "0/" + usuario;
            // Enviamos al servidor el mensaje.
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeDesconectar);
            server.Send(msg);
            conectado = false;
        }

        // Decoración.
        private void usuarioBox_Enter(object sender, EventArgs e)
        {
            if (usuarioBox.Text == "Usuario")
            {
                usuarioBox.Text = "";
                usuarioBox.ForeColor = Color.Black;
            }
        }

        // Decoración.
        private void usuarioBox_Leave(object sender, EventArgs e)
        {
            if (usuarioBox.Text == "")
            {
                usuarioBox.Text = "Usuario";
                usuarioBox.ForeColor = Color.Silver;
            }
        }

        // Decoración.
        private void contraseñaBox_Enter(object sender, EventArgs e)
        {
            if (contraseñaBox.Text == "Contraseña")
            {
                contraseñaBox.Text = "";
                contraseñaBox.ForeColor = Color.Black;
            }
        }

        // Decoración.
        private void contraseñaBox_Leave(object sender, EventArgs e)
        {
            if (contraseñaBox.Text == "")
            {
                contraseñaBox.Text = "Contraseña";
                contraseñaBox.ForeColor = Color.Silver;
            }
        }

        // Decoración.
        private void registrarseLabel_MouseEnter(object sender, EventArgs e)
        {
            registrarseLabel.ForeColor = Color.DarkRed; 
        }

        // Decoración.
        private void registrarseLabel_MouseLeave(object sender, EventArgs e)
        {
            registrarseLabel.ForeColor = Color.Black;
        }

        // Decoración.
        private void darseBajaLabel_MouseEnter(object sender, EventArgs e)
        {
            darseBajaLabel.ForeColor = Color.DarkOrange;
        }

        // Decoración.
        private void darseBajaLabel_MouseLeave(object sender, EventArgs e)
        {
            darseBajaLabel.ForeColor = Color.Black;
        }

        // Se cierra la conexión con el servidor y se le envía el nombre del usuario a desconectar.
        // Se cierra la aplicación.
        private void botonSalir_Click(object sender, EventArgs e)
        {
            if (conectado == true)
            {
                string mensajeDesconectar = "0/" + usuario;
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeDesconectar);
                server.Send(msg);
                conectado = false;
                atender.Abort();
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            this.Close();
            Application.Exit();
        }

        // Se cierra la conexión con el servidor y se le envía el nombre del usuario a desconectar.
        // Se cierra la aplicación.
        private void IniciarSesión_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conectado == true)
            {
                string mensajeDesconectar = "0/" + usuario;
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeDesconectar);
                server.Send(msg);
                conectado = false;
                atender.Abort();
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            Application.Exit();
        }
    }
}