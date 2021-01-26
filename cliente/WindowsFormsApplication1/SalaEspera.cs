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
    public partial class SalaEspera : Form
    {
        Socket server;
        int numSala;
        string usuario;
        string mensajeInvitacion;
        int nPartida;
        List<PantallaUno> primeras = new List<PantallaUno>(); // Lista para guardar los Forms "PantallaUno".
        List<PantallaDosPrincipal> segundas = new List<PantallaDosPrincipal>(); // Lista para guardar los Forms "PantallaDosPrinicipal".
        List<PantallaDosPrimera> segundasPrimera = new List<PantallaDosPrimera>(); // Lista para guardar los Forms "PantallaDosPrimera".
        List<PantallaDosManual> segundasManual = new List<PantallaDosManual>(); // Lista para guardar los Forms "PantallaDosManual".
        List<PantallaTres> terceras = new List<PantallaTres>(); // Lista para guardar los Forms "PantallaTres".
        List<PantallaFinal> finales = new List<PantallaFinal>(); // Lista para guardar los Forms "PantallaFinal".
        List<Consultas> consultas = new List<Consultas>(); // Lista para guardar los Forms "Consultas".
        List<int> vidas = new List<int>();
        List<bool> pantallaSuperada = new List<bool>();
        List<string> tipoPantallaDos = new List<string>();
        List<string> comprobacionPantallaTres = new List<string>();
        List<string> miembros = new List<string>();

        DataTable tabla = new DataTable();// Tabla para implementar los usuarios conectados en la datagridview.
        
        delegate void delegadoDatagrid(DataTable table);

        // Se recibe la conexión con el servidor, la posicion en el que esta guardado en la lista y usuario conectado.
        public SalaEspera(Socket server, int numSala, string usuario)
        {
            InitializeComponent();
            this.server = server;
            this.numSala = numSala;
            this.usuario = usuario;
        }

        // Se inicializa la datagridview.
        private void SalaEspera_Load(object sender, EventArgs e)
        {
            this.conectadosGrid.DataError += new DataGridViewDataErrorEventHandler(conectadosGrid_DataError);
            this.tabla.Columns.Add("Usuarios conectados");
            this.conectadosGrid.DataSource = this.tabla;
        }

        // Se controla cualquier error de la datagridview.
        private void conectadosGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("CustomerID value must be unique.");
            }
        }

        // Se actualiza la datagridview con la nueva información de las datatable con los usuarios conectados.
        public void dataGrid(DataTable table)
        {
            this.conectadosGrid.DataSource = null;
            this.conectadosGrid.Update();
            this.conectadosGrid.Refresh();
            this.conectadosGrid.DataSource = table;
            this.conectadosGrid.ClearSelection();
            this.conectadosGrid.Update();
            this.conectadosGrid.Refresh();
        }

        // Se les envia una invitacion a los usuarios seleccionados en la datagridview por el cliente.
        private void botonInvitar_Click(object sender, EventArgs e)
        {
            if (this.conectadosGrid.SelectedRows.Count < 5)
            {
                if (this.conectadosGrid.SelectedRows.Count > 0)
                {
                    mensajeInvitacion = "7/";
                    foreach (DataGridViewRow fila in conectadosGrid.SelectedRows)
                    {
                        if (fila.Cells[0].Value.ToString() != usuario)
                        {
                            mensajeInvitacion = string.Format("{0}{1}/", mensajeInvitacion, fila.Cells[0].Value.ToString());
                        }
                        else
                        {
                            // Si se selecciona a el mismo se le excluye de la invitación.
                            MessageBox.Show("Te has seleccionado a ti mismo, tú nombre no se tendrá en cuenta a la hora de enviar las invitaciones");
                        }
                    }
                    // Si sólo se selecciona a el mismo no se envia invitación.
                    if ((this.conectadosGrid.SelectedRows.Count == 1) && (this.conectadosGrid.SelectedRows[0].Cells[0].Value.ToString() == usuario))
                    {
                        MessageBox.Show("Sólo te has seleccionado a ti mismo. No se envía invitación.");
                    }
                    else
                    {
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeInvitacion);
                        server.Send(msg);
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado a nadie");
                }
            }
            else
            {
                MessageBox.Show("Sólo puedes invitar a 4 jugadores como máximo.");
            }
        }

        // Al presionar la label "README" se abre un formulario con las instrucciones iniciales.
        private void readmeLabel_Click(object sender, EventArgs e)
        {
            Instrucciones instrucciones = new Instrucciones();
            instrucciones.ShowDialog();
        }

        // Se obtiene la tabla con los usuarios conectados y se actualiza la datagridview a través del delegado.
        public void dameTabla(DataTable tabla)
        {
            delegadoDatagrid delegado = new delegadoDatagrid(dataGrid);
            conectadosGrid.Invoke(delegado, new object[] { tabla });
        }

        // Se recibe la invitación y se contesta con si o no.
        public void dameInvitacion(string anfitrion, string pregunta)
        {
            var invitacion = MessageBox.Show(pregunta, "Invitación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (invitacion == DialogResult.Yes)
            {
                string respuesta = "8/" + anfitrion + "/si";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(respuesta);
                server.Send(msg);
            }

            else
            {
                string respuesta = "8/" + anfitrion + "/no";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(respuesta);
                server.Send(msg);
            }
        }

        // Se recibe la confirmacion de la partida.
        // Si la respuesta es "si" se abre un Form con la primera  pantalla de la partida.
        // Si la respuesta es "no" se muestra un MessageBox con el mensaje de "Partida rechazada".
        public void dameConfirmacion(string numPartida, string confirmacion, string miembros)
        {
            if (confirmacion == "si")
            {
                this.nPartida = Convert.ToInt32(numPartida);
                for (int i = this.miembros.Count; i <= nPartida; i++)
                {
                        this.miembros.Add(miembros);
                }
                ThreadStart ts = new ThreadStart(delegate { iniciarPantallas(); });
                Thread pantallasJuego = new Thread(ts);
                pantallasJuego.Start();
            }
            else
            {
                MessageBox.Show("PARTIDA RECHAZADA");
            }
        }

        // Se inicia el juego.
        private void iniciarPantallas()
        {
            // FECHA Y HORA DE INICIO.
            string fecha = DateTime.Now.ToShortDateString();
            string hora = DateTime.Now.ToShortTimeString();

            // PANTALLA UNO.
            for (int i = primeras.Count; i <= nPartida; i++)
            {
                PantallaUno p1 = new PantallaUno(server, nPartida);
                this.primeras.Add(p1);
                this.vidas.Add(3);
                this.pantallaSuperada.Add(false);
            }
            // PANTALLA DOS PRINCIPAL.
            for (int i = segundas.Count; i <= nPartida; i++)
            {
                PantallaDosPrincipal p2 = new PantallaDosPrincipal(server, nPartida);
                this.segundas.Add(p2);
                this.tipoPantallaDos.Add("");
            }
            // PANTALLA DOS PRIMERA.
            for (int i = segundasPrimera.Count; i <= nPartida; i++)
            {
                PantallaDosPrimera p3 = new PantallaDosPrimera(server, nPartida);
                this.segundasPrimera.Add(p3);
            }
            // PANTALLA DOS MANUAL.
            for (int i = segundasManual.Count; i <= nPartida; i++)
            {
                PantallaDosManual p4 = new PantallaDosManual(server, nPartida);
                this.segundasManual.Add(p4);
            }
            // PANTALLA TRES.
            for (int i = terceras.Count; i <= nPartida; i++)
            {
                this.comprobacionPantallaTres.Add("");
                PantallaTres p5 = new PantallaTres(server, nPartida);
                this.terceras.Add(p5);
            }
            // PANTALLA FINAL.
            Program.s.Invoke((MethodInvoker)delegate
            {
                for (int i = finales.Count; i <= nPartida; i++)
                {
                    PantallaFinal p6 = new PantallaFinal(server, nPartida);
                    this.finales.Add(p6);
                }
            });
            
            // INICIO PARTIDA.
            this.primeras[nPartida].ShowDialog();
            if (vidas[nPartida] == 0)
            {
                string respuesta = "18/" + fecha + "," + hora + "," + this.miembros[nPartida] + ",DERROTA,";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(respuesta);
                server.Send(msg);

                GameOver gameOver = new GameOver();
                gameOver.ShowDialog();
            }

            // PANTALLA DOS PRINCIPAL.
            if (pantallaSuperada[nPartida] == true)
            {
                vidas[nPartida] = 3;
                pantallaSuperada[nPartida] = false;
                
                this.segundas[nPartida].ShowDialog();

                // PANTALLA DOS PRIMERA
                if (tipoPantallaDos[nPartida] == "segundaPrimera")
                {
                    
                    this.segundasPrimera[nPartida].ShowDialog();

                    if (vidas[nPartida] == 0)
                    {
                        string respuesta = "18/" + fecha + "," + hora + "," + this.miembros[nPartida] + ",DERROTA,";
                        // Enviamos al servidor el mensaje.
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(respuesta);
                        server.Send(msg);

                        GameOver gameOver = new GameOver();
                        gameOver.ShowDialog();
                    }

                    if (pantallaSuperada[nPartida] == true)
                    {
                        pantallaSuperada[nPartida] = false;
                        
                        this.terceras[nPartida].ShowDialog();
                        if (comprobacionPantallaTres[nPartida] == "incorrecto")
                        {
                            string respuesta = "18/" + fecha + "," + hora + "," + this.miembros[nPartida] + ",DERROTA,";
                            // Enviamos al servidor el mensaje.
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(respuesta);
                            server.Send(msg);

                            GameOver gameOver = new GameOver();
                            gameOver.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Tercera pantalla superada");
                            vidas[nPartida] = 3;

                            Program.s.Invoke((MethodInvoker)delegate
                            {
                                
                                this.finales[nPartida].ShowDialog();
                            });

                            if (pantallaSuperada[nPartida] == true)
                            {
                                string respuesta = "18/" + fecha + "," + hora + "," + this.miembros[nPartida] + ",VICTORIA,";
                                // Enviamos al servidor el mensaje.
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(respuesta);
                                server.Send(msg);

                                PartidaCompletada enhorabuena = new PartidaCompletada();
                                enhorabuena.ShowDialog();
                            }
                            else
                            {
                                string respuesta = "18/" + fecha + "," + hora + "," + this.miembros[nPartida] + ",DERROTA,";
                                // Enviamos al servidor el mensaje.
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(respuesta);
                                server.Send(msg);

                                GameOver gameOver = new GameOver();
                                gameOver.ShowDialog();
                            }
                        }
                    }
                }

                // PANTALLA DOS MANUAL
                else if (tipoPantallaDos[nPartida] == "segundaManual")
                {
                    
                    this.segundasManual[nPartida].ShowDialog();

                    if (vidas[nPartida] == 0)
                    {
                        string respuesta = "18/" + fecha + "," + hora + "," + this.miembros[nPartida] + ",DERROTA,";
                        // Enviamos al servidor el mensaje.
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(respuesta);
                        server.Send(msg);

                        GameOver gameOver = new GameOver();
                        gameOver.ShowDialog();
                    }

                    if (pantallaSuperada[nPartida] == true)
                    {
                        pantallaSuperada[nPartida] = false;
                        
                        this.terceras[nPartida].ShowDialog();
                        if (comprobacionPantallaTres[nPartida] == "incorrecto")
                        {
                            string respuesta = "18/" + fecha + "," + hora + "," + this.miembros[nPartida] + ",DERROTA,";
                            // Enviamos al servidor el mensaje.
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(respuesta);
                            server.Send(msg);

                            GameOver gameOver = new GameOver();
                            gameOver.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Tercera pantalla superada");
                            vidas[nPartida] = 3;
                            Program.s.Invoke((MethodInvoker)delegate
                            {
                                
                                this.finales[nPartida].ShowDialog();
                            });

                            if (pantallaSuperada[nPartida] == true)
                            {
                                string respuesta = "18/" + fecha + "," + hora + "," + this.miembros[nPartida] + ",VICTORIA,";
                                // Enviamos al servidor el mensaje.
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(respuesta);
                                server.Send(msg);

                                PartidaCompletada enhorabuena = new PartidaCompletada();
                                enhorabuena.ShowDialog();
                            }
                            else
                            {
                                string respuesta = "18/" + fecha + "," + hora + "," + this.miembros[nPartida] + ",DERROTA,";
                                // Enviamos al servidor el mensaje.
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(respuesta);
                                server.Send(msg);

                                GameOver gameOver = new GameOver();
                                gameOver.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        // Se recibe un nuevo mensaje para el chat y se pasa al form que le corresponde en cada momento.
        public void dameChat(string mensajeChat)
        {
            string[] chat = mensajeChat.Split(',');
            if (chat[2] == "primera")
            {
                this.primeras[Convert.ToInt32(chat[0])].dameMensaje(chat[1]);
            }

            else if (chat[2] == "segunda")
            {
                if (tipoPantallaDos[Convert.ToInt32(chat[3])] == "segundaPrimera")
                {
                    this.segundasPrimera[Convert.ToInt32(chat[0])].dameMensaje(chat[1]);
                }
                else if (tipoPantallaDos[Convert.ToInt32(chat[3])] == "segundaManual")
                {
                    this.segundasManual[Convert.ToInt32(chat[0])].dameMensaje(chat[1]);
                }
                else
                {
                    this.segundas[Convert.ToInt32(chat[0])].dameMensaje(chat[1]);
                }
            }

            else if (chat[2] == "tercera")
            {
                this.terceras[Convert.ToInt32(chat[0])].dameMensaje(chat[1]);
            }

            else if (chat[2] == "final")
            {
                this.finales[Convert.ToInt32(chat[0])].dameMensaje(chat[1]);
            }
        }

        // Se recibe la respuesta de la primera pantalla y se informa al Form "PantallaUno" al que corresponde.
        public void dameRespuestaPantallaUno(string mensajePantallaUno)
        {
            string[] pantallaUno = mensajePantallaUno.Split(',');
            nPartida = Convert.ToInt32(pantallaUno[0]);
            this.primeras[Convert.ToInt32(pantallaUno[0])].dameRespuesta(pantallaUno[1]);
            if (pantallaUno[1] != "11:45")
            {
                vidas[Convert.ToInt32(pantallaUno[0])] = vidas[Convert.ToInt32(pantallaUno[0])] - 1;
            }
            else
            {
                pantallaSuperada[Convert.ToInt32(pantallaUno[0])] = true;
            }
        }

        public void dameAbrirManual(string mensajeAbrirManual)
        {
            string[] segundaManual = mensajeAbrirManual.Split(',');
            nPartida = Convert.ToInt32(segundaManual[0]);
            this.tipoPantallaDos[Convert.ToInt32(segundaManual[0])] = segundaManual[1];
            this.segundas[Convert.ToInt32(segundaManual[0])].dameCerrarForm();
        }

        public void dameRespuestaPantallaDos(string mensajePantallaDos)
        {
            string[] pantallaDos = mensajePantallaDos.Split(',');
            nPartida = Convert.ToInt32(Convert.ToInt32(pantallaDos[0]));
            if (this.tipoPantallaDos[Convert.ToInt32(pantallaDos[2])] == "segundaManual")
            {
                this.segundasManual[Convert.ToInt32(pantallaDos[0])].dameRespuesta(pantallaDos[3]);
            }

            if (pantallaDos[3] != "correcta")
            {
                vidas[Convert.ToInt32(pantallaDos[1])] = vidas[Convert.ToInt32(pantallaDos[1])] - 1;
            }
            else
            {
                pantallaSuperada[Convert.ToInt32(pantallaDos[1])] = true;
            }
        }

        public void dameMovimientoPantallaTres(string movimientoPieza)
        {
            string[] puzzle = movimientoPieza.Split(',');
            nPartida = Convert.ToInt32(puzzle[0]);
            this.terceras[Convert.ToInt32(puzzle[0])].dameMovimiento(puzzle[1]);
        }

        public void dameRespuestaPantallaTres(string mensajePantallaTres)
        {
            string[] comprobacion = mensajePantallaTres.Split(',');
            nPartida = Convert.ToInt32(comprobacion[0]);
            this.comprobacionPantallaTres[Convert.ToInt32(comprobacion[0])] = comprobacion[1];
            this.terceras[Convert.ToInt32(comprobacion[0])].dameComprobacion();
        }

        public void dameRespuestaPantallaFinal(string mensajePantallaFinal)
        {
            string[] pantallaFinal = mensajePantallaFinal.Split(',');
            nPartida = Convert.ToInt32(pantallaFinal[0]);
            this.finales[Convert.ToInt32(pantallaFinal[0])].dameRespuesta(pantallaFinal[1]);
            if (pantallaFinal[1] != "correcta")
            {
                vidas[Convert.ToInt32(pantallaFinal[2])] = vidas[Convert.ToInt32(pantallaFinal[2])] - 1;
            }
            else
            {
                pantallaSuperada[Convert.ToInt32(pantallaFinal[2])] = true;
            }
        }

        private void botonConsultas_Click(object sender, EventArgs e)
        {
            Consultas cons = new Consultas(server, usuario);
            this.consultas.Add(cons);
            cons.ShowDialog();
            this.consultas.Clear();
        }

        public void dameConsultaUno(string resultado)
        {
            this.consultas[0].damePrimeraConsulta(resultado);
        }

        public void dameConsultaDos(string resultado)
        {
            this.consultas[0].dameSegundaConsulta(resultado);
        }

        public void dameConsultaTres(string resultado)
        {
            this.consultas[0].dameTerceraConsulta(resultado);
        }

        public void dameConsultaCuatro(string fecha, string hora)
        {
            this.consultas[0].dameCuartaConsulta(fecha, hora);
        }
    }
}
