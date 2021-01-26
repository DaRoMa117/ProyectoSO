using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class PantallaFinal : Form
    {
        Socket server;
        int numPantallaFinal;
        int numPartida;
        int posicion;
        int vidas = 3;
        string estado = "pausa";

        delegate void delegadoDatagrid(string mensaje);
        delegate void delegadoVidas(int vidasRestantes);
        delegate void delegadoCerrar();

        public PantallaFinal(Socket server, int numPartida)
        {
            InitializeComponent();
            this.server = server;
            this.numPantallaFinal = numPartida;
            this.numPartida = numPartida;
            this.posicion = numPartida;
        }

        private void PantallaFinal_Load(object sender, EventArgs e)
        {
            this.chatGrid.DataError += new DataGridViewDataErrorEventHandler(chatGrid_DataError);
            this.chatGrid.ColumnCount = 1;
            this.chatGrid.RowHeadersVisible = false;
            this.chatGrid.Columns[0].HeaderText = "CHAT";
            this.chatGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            vidasLabel.Text = vidas.ToString();

            player.URL = Application.StartupPath + @"\video\pasos.mp4";
        }

        // Se controla cualquier error de la datagridview.
        private void chatGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("CustomerID value must be unique.");
            }
        }

        private void playBox_Click(object sender, EventArgs e)
        {
            if (estado == "pausa")
            {
                player.Ctlcontrols.play();
                estado = "play";
            }
            else if (estado == "play")
            {
                player.Ctlcontrols.pause();
                estado = "pausa";
            }
        }

        private void stopBox_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.stop();
        }

        private void botonEnviar_Click(object sender, EventArgs e)
        {
            if (textChat.Text.Trim() != string.Empty)
            {
                string text = textChat.Text.Trim();
                if (text.Length > 30)
                {
                    text = text.Remove(30);
                }
                string mensajeChat = "9/" + numPantallaFinal + "/" + numPartida + "/" + text + "/final/";
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
            if (respuesta == "correcta")
            {
                MessageBox.Show("Pantalla final superada");
                player.Ctlcontrols.stop();
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
                    player.Ctlcontrols.stop();
                    delegadoCerrar delegado4 = new delegadoCerrar(cerrarForm); // Cerramos el Form al acabar.
                    this.Invoke(delegado4);
                }
            }
        }

        private void botonResolver_Click(object sender, EventArgs e)
        {
            if (pasoUno.Checked == true)
            {
                string mensajeChat = "16/" + numPantallaFinal + "/" + numPartida + "/incorrecta/" + posicion + "/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeChat);
                server.Send(msg);

                pasoUno.Checked = false;
            }
            else if (pasoDos.Checked == true)
            {
                string mensajeChat = "16/" + numPantallaFinal + "/" + numPartida + "/incorrecta/" + posicion + "/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeChat);
                server.Send(msg);

                pasoDos.Checked = false;
            }
            else if (pasoTres.Checked == true)
            {
                string mensajeChat = "16/" + numPantallaFinal + "/" + numPartida + "/correcta/" + posicion + "/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeChat);
                server.Send(msg);

                pasoTres.Checked = false;
            }
            else if (pasoCuatro.Checked == true)
            {
                string mensajeChat = "16/" + numPantallaFinal + "/" + numPartida + "/incorrecta/" + posicion + "/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeChat);
                server.Send(msg);

                pasoCuatro.Checked = false;
            }
            else if (pasoCinco.Checked == true)
            {
                string mensajeChat = "16/" + numPantallaFinal + "/" + numPartida + "/incorrecta/" + posicion + "/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeChat);
                server.Send(msg);

                pasoCinco.Checked = false;
            }
            else
            {
                MessageBox.Show("Ninguna opción seleccionada.");
            }
        }

        private void pasoUno_CheckedChanged(object sender, EventArgs e)
        {
            if (pasoUno.Checked == true)
            {
                pasoDos.Visible = false;
                pasoTres.Visible = false;
                pasoCuatro.Visible = false;
                pasoCinco.Visible = false;
            }
            else
            {
                pasoDos.Visible = true;
                pasoTres.Visible = true;
                pasoCuatro.Visible = true;
                pasoCinco.Visible = true;
            }
        }

        private void pasoDos_CheckedChanged(object sender, EventArgs e)
        {
            if (pasoDos.Checked == true)
            {
                pasoUno.Visible = false;
                pasoTres.Visible = false;
                pasoCuatro.Visible = false;
                pasoCinco.Visible = false;
            }
            else
            {
                pasoUno.Visible = true;
                pasoTres.Visible = true;
                pasoCuatro.Visible = true;
                pasoCinco.Visible = true;
            }
        }

        private void pasoTres_CheckedChanged(object sender, EventArgs e)
        {
            if (pasoTres.Checked == true)
            {
                pasoUno.Visible = false;
                pasoDos.Visible = false;
                pasoCuatro.Visible = false;
                pasoCinco.Visible = false;
            }
            else
            {
                pasoUno.Visible =  true;
                pasoDos.Visible = true;
                pasoCuatro.Visible = true;
                pasoCinco.Visible = true;
            }
        }

        private void pasoCuatro_CheckedChanged(object sender, EventArgs e)
        {
            if (pasoCuatro.Checked == true)
            {
                pasoUno.Visible = false;
                pasoDos.Visible = false;
                pasoTres.Visible = false;
                pasoCinco.Visible = false;
            }
            else
            {
                pasoUno.Visible = true;
                pasoDos.Visible = true;
                pasoTres.Visible = true;
                pasoCinco.Visible = true;
            }
        }

        private void pasoCinco_CheckedChanged(object sender, EventArgs e)
        {
            if (pasoCinco.Checked == true)
            {
                pasoUno.Visible = false;
                pasoDos.Visible = false;
                pasoTres.Visible = false;
                pasoCuatro.Visible = false;
            }
            else
            {
                pasoUno.Visible = true;
                pasoDos.Visible = true;
                pasoTres.Visible = true;
                pasoCuatro.Visible = true;
            }
        }
    }
}
