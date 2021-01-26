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
    public partial class PantallaDosPrincipal : Form
    {
        Socket server;
        int numSegundaPantalla;
        int numPartida;

        delegate void delegadoDatagrid(string mensaje);
        delegate void delegadoCerrar();

        // Se recibe la conexión con el servidor, la posicion en el que esta guardado en la lista y el numero correspondiente a la partida.
        public PantallaDosPrincipal(Socket server, int numPartida)
        {
            InitializeComponent();
            this.server = server;
            this.numSegundaPantalla = numPartida;
            this.numPartida = numPartida;
        }

        private void PantallaDosPrincipal_Load(object sender, EventArgs e)
        {
            this.chatGrid.DataError += new DataGridViewDataErrorEventHandler(chatGrid_DataError);
            this.chatGrid.ColumnCount = 1;
            this.chatGrid.RowHeadersVisible = false;
            this.chatGrid.Columns[0].HeaderText = "CHAT";
            this.chatGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            pistaBox.Visible = false;
            botonEncontrado.Visible = false;
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

        // Se cierra el Form.
        public void cerrarForm()
        {
            this.Close();
        }

        public void dameCerrarForm()
        {
            delegadoCerrar delegado2 = new delegadoCerrar(cerrarForm); // Cerramos el Form al abrir el nuevo.
            this.Invoke(delegado2);
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
                string mensajeChat = "9/" + numSegundaPantalla + "/" + numPartida + "/" + text + "/segunda/" + numSegundaPantalla;
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

        private void abrirPantallas_Click(object sender, EventArgs e)
        {
            string mensajeChat = "11/" + numSegundaPantalla + "/" + numPartida;
            // Enviamos al servidor el mensaje.
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeChat);
            server.Send(msg);
        }

        private void abrirPantallas_MouseEnter(object sender, EventArgs e)
        {
            botonEncontrado.Visible = true;
        }

        private void abrirPantallas_MouseLeave(object sender, EventArgs e)
        {
            botonEncontrado.Visible = false;
        }

        private void pistaEncontrada_MouseEnter(object sender, EventArgs e)
        {
            pistaBox.Visible = true;
        }

        private void pistaEncontrada_MouseLeave(object sender, EventArgs e)
        {
            pistaBox.Visible = false;
        }
    }
}
