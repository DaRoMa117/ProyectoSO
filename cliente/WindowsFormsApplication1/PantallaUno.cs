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
using WMPLib;

namespace WindowsFormsApplication1
{
    // Primera pantalla de nuestro juego.
    public partial class PantallaUno : Form
    {
        Socket server;
        int numPrimeraPantalla;
        int numPartida;
        int vidas = 3;
        bool reproduciendo = true;

        delegate void delegadoDatagrid(string mensaje);
        delegate void delegadoVidas(int vidasRestantes);
        delegate void delegadoCerrar();

        WindowsMediaPlayer sonido = new WindowsMediaPlayer();

        // Se recibe la conexión con el servidor, la posicion en el que esta guardado en la lista y el numero correspondiente a la partida.
        public PantallaUno(Socket server, int numPartida)
        {
            InitializeComponent();
            this.server = server;
            this.numPrimeraPantalla = numPartida;
            this.numPartida = numPartida;
        }

        private void PantallaUno_Load(object sender, EventArgs e)
        {
            this.chatGrid.DataError += new DataGridViewDataErrorEventHandler(chatGrid_DataError);
            this.chatGrid.ColumnCount = 1;
            this.chatGrid.RowHeadersVisible = false;
            this.chatGrid.Columns[0].HeaderText = "CHAT";
            this.chatGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            vidasLabel.Text = vidas.ToString();
            pistaBox.Visible = false;
            botonEncontrado.Visible = false;

            sonido.URL = Application.StartupPath + @"\sonido\pantallaUno.mp3";
            sonido.controls.play();
        }

        // Se controla cualquier error de la datagridview.
        private void chatGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("CustomerID value must be unique.");
            }
        }

        // Se envia el mensaje escrito por el cliente a todos los demás.
        private void botonEnviar_Click(object sender, EventArgs e)
        {
            if (textChat.Text.Trim() != string.Empty)
            {
                string text = textChat.Text.Trim();
                if (text.Length > 30)
                {
                    text = text.Remove(30);
                }
                string mensajeChat = "9/" + numPrimeraPantalla + "/" + numPartida + "/" + text + "/primera/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeChat);
                server.Send(msg);
                textChat.Text = null;
            }
            else
            {
                MessageBox.Show("Escribe el mensaje que quieres enviar");
            }
        }

        // Se actualiza la datagridview con los nuevos mensajes del chat.
        public void conversacionGrid(string mensaje)
        {
            this.chatGrid.Rows.Add(mensaje);
            this.chatGrid.ClearSelection();
            this.chatGrid.Update();
            this.chatGrid.Refresh();
        }

        // Se cierra el Form.
        public void cerrarForm()
        {
            this.Close();
        }

        // Se actualiza el número de vidas restantes.
        public void ponVidas(int vidasRestantes)
        {
            vidasLabel.Text = vidasRestantes.ToString();
        }

        // Se recibe el nuevo mensaje del chat.
        public void dameMensaje(string mensaje)
        {
            delegadoDatagrid delegado1 = new delegadoDatagrid(conversacionGrid);
            chatGrid.Invoke(delegado1, new object[] { mensaje });
        }

        // Se recibe la respuesta propuesta por los participantes.
        public void dameRespuesta(string respuesta)
        {
            
            if (respuesta == "11:45")
            {
                MessageBox.Show("Primera pantalla superada");
                sonido.controls.stop();
                reproduciendo = false;
                delegadoCerrar delegado2 = new delegadoCerrar(cerrarForm); // Amagamos el Form al abrir el nuevo.
                this.Invoke(delegado2);
            }
            else
            {
                vidas = vidas - 1;
                if (vidas > 0)
                {
                    delegadoVidas delegado3 = new delegadoVidas(ponVidas);
                    this.vidasLabel.Invoke(delegado3, new object[] { vidas });
                }
                else
                {
                    sonido.controls.stop();
                    reproduciendo = false;
                    delegadoCerrar delegado4 = new delegadoCerrar(cerrarForm); // Cerramos el Form al acabar.
                    this.Invoke(delegado4);
                }
            }
        }

        private void infoBox_MouseEnter(object sender, EventArgs e)
        {
            pistaBox.Visible = true;
        }

        private void infoBox_MouseLeave(object sender, EventArgs e)
        {
            pistaBox.Visible = false;
        }

        private void enviarRespuesta_Click(object sender, EventArgs e)
        {
            if (respuestaBox.Text.Trim() != string.Empty)
            {
                MessageBox.Show("Respuesta enviada.");
                string respuesta = respuestaBox.Text.Trim();
                string mensajeRespuesta = "10/" + numPrimeraPantalla + "/" + numPartida + "/" + respuesta + "/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeRespuesta);
                server.Send(msg);
                respuestaBox.Text = null;
            }
            else
            {
                MessageBox.Show("Enhorabuena habéis encontrado el botón de enviar respuesta. Ahora sólo falta adivinar cuál es la hora que marca el reloj.");
            }
        }

        private void enviarRespuesta_MouseEnter(object sender, EventArgs e)
        {
            botonEncontrado.Visible = true;
        }

        private void enviarRespuesta_MouseLeave(object sender, EventArgs e)
        {
            botonEncontrado.Visible = false;
        }

        private void respuestaBox_Enter(object sender, EventArgs e)
        {
            if (respuestaBox.Text == "00:00")
            {
                respuestaBox.Text = "";
                respuestaBox.ForeColor = Color.Black;
            }
        }

        private void respuestaBox_Leave(object sender, EventArgs e)
        {
            if (respuestaBox.Text == "")
            {
                respuestaBox.Text = "00:00";
                respuestaBox.ForeColor = Color.Silver;
            }
        }

        private void sonidoBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (reproduciendo == false)
                {
                    sonido.URL = Application.StartupPath + @"\sonido\pantallaUno.mp3";
                    sonido.controls.play();
                    reproduciendo = true;
                }
                else
                {
                    sonido.controls.stop();
                    reproduciendo = false;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void PantallaUno_FormClosing(object sender, FormClosingEventArgs e)
        {
            sonido.controls.stop();
            reproduciendo = false;
        }
    }
}