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
    public partial class PantallaDosPrimera : Form
    {
        Socket server;
        int numSegundaPrimera;
        int numPartida;
        int posicion;
        int numSegunda;
        int vidas = 3;

        delegate void delegadoDatagrid(string mensaje);
        delegate void delegadoVidas(int vidasRestantes);
        delegate void delegadoCerrar();

        public PantallaDosPrimera(Socket server, int numPartida)
        {
            InitializeComponent();
            this.server = server;
            this.numSegundaPrimera = numPartida;
            this.numPartida = numPartida;
            this.posicion = numPartida;
            this.numSegunda = numPartida;
        }

        private void PantallaDosPrimera_Load(object sender, EventArgs e)
        {
            this.chatGrid.DataError += new DataGridViewDataErrorEventHandler(chatGrid_DataError);
            this.chatGrid.ColumnCount = 1;
            this.chatGrid.RowHeadersVisible = false;
            this.chatGrid.Columns[0].HeaderText = "CHAT";
            this.chatGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            vidasLabel.Text = vidas.ToString();
            distraccionesBox.Visible = false;
        }

        // Se controla cualquier error de la datagridview.
        private void chatGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("CustomerID value must be unique.");
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

        // Se recibe el nuevo mensaje del chat.
        public void dameMensaje(string mensaje)
        {
            delegadoDatagrid delegado1 = new delegadoDatagrid(conversacionGrid);
            chatGrid.Invoke(delegado1, new object[] { mensaje });
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
                string mensajeChat = "9/" + numSegundaPrimera + "/" + numPartida + "/" + text + "/segunda/" + numSegunda;
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

        // Se actualiza el número de vidas restantes.
        public void ponVidas(int vidasRestantes)
        {
            vidasLabel.Text = vidasRestantes.ToString();
        }

        // Se cierra el Form.
        public void cerrarForm()
        {
            this.Close();
        }

        private void botonUno_Click(object sender, EventArgs e)
        {
            string mensajeChat = "12/" + numSegundaPrimera + "/" + numPartida + "/" + posicion + "/" + numSegunda + "/incorrecta/";
            // Enviamos al servidor el mensaje.
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeChat);
            server.Send(msg);

            vidas = vidas - 1;
            if (vidas > 0)
            {
                delegadoVidas delegado3 = new delegadoVidas(ponVidas);
                this.vidasLabel.Invoke(delegado3, new object[] { vidas });
            }
            else
            {
                delegadoCerrar delegado4 = new delegadoCerrar(cerrarForm); // Cerramos el Form al acabar.
                this.Invoke(delegado4);
            }
        }

        private void botonDos_Click(object sender, EventArgs e)
        {
            string mensajeChat = "12/" + numSegundaPrimera + "/" + numPartida + "/" + posicion + "/" + numSegunda + "/incorrecta/";
            // Enviamos al servidor el mensaje.
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeChat);
            server.Send(msg);

            vidas = vidas - 1;
            if (vidas > 0)
            {
                delegadoVidas delegado3 = new delegadoVidas(ponVidas);
                this.vidasLabel.Invoke(delegado3, new object[] { vidas });
            }
            else
            {
                delegadoCerrar delegado4 = new delegadoCerrar(cerrarForm); // Cerramos el Form al acabar.
                this.Invoke(delegado4);
            }
        }

        private void botonTres_Click(object sender, EventArgs e)
        {
            // RESPUESTA CORRECTA
            string mensajeChat = "12/" + numSegundaPrimera + "/" + numPartida + "/" + posicion + "/" + numSegunda + "/correcta/";
            // Enviamos al servidor el mensaje.
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeChat);
            server.Send(msg);

            MessageBox.Show("Segunda pantalla superada");
            delegadoCerrar delegado2 = new delegadoCerrar(cerrarForm); // Amagamos el Form al abrir el nuevo.
            this.Invoke(delegado2);

        }

        private void botonCuatro_Click(object sender, EventArgs e)
        {
            string mensajeChat = "12/" + numSegundaPrimera + "/" + numPartida + "/" + posicion + "/" + numSegunda + "/incorrecta/";
            // Enviamos al servidor el mensaje.
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeChat);
            server.Send(msg);

            vidas = vidas - 1;
            if (vidas > 0)
            {
                delegadoVidas delegado3 = new delegadoVidas(ponVidas);
                this.vidasLabel.Invoke(delegado3, new object[] { vidas });
            }
            else
            {
                delegadoCerrar delegado4 = new delegadoCerrar(cerrarForm); // Cerramos el Form al acabar.
                this.Invoke(delegado4);
            }
        }

        private void caraEncontrada_MouseEnter(object sender, EventArgs e)
        {
            distraccionesBox.Visible = true;
        }

        private void caraEncontrada_MouseLeave(object sender, EventArgs e)
        {
            distraccionesBox.Visible = false;
        }
    }
}