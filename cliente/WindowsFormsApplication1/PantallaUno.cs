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
    // Primera pantalla de nuestro juego.
    public partial class PantallaUno : Form
    {
        Socket server;
        int numPrimeraPantalla;
        int numPartida;

        delegate void delegadoDatagrid(string mensaje);

        // Se recibe la conexión con el servidor, la posicion en el que esta guardado en la lista y el numero correspondiente a la partida.
        public PantallaUno(Socket server, int numPrimeraPantalla, int numPartida)
        {
            InitializeComponent();
            this.server = server;
            this.numPrimeraPantalla = numPrimeraPantalla;
            this.numPartida = numPartida;
        }

        private void PantallaUno_Load(object sender, EventArgs e)
        {
            this.chatGrid.DataError += new DataGridViewDataErrorEventHandler(chatGrid_DataError);
            this.chatGrid.ColumnCount = 1;
            this.chatGrid.RowHeadersVisible = false;
            this.chatGrid.Columns[0].HeaderText = "CHAT";
            this.chatGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
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
                string mensajeChat = "9/" + numPrimeraPantalla + "/" + numPartida + "/" + text + "/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensajeChat);
                server.Send(msg);
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

        // Se recibe el mensaje y se muestra en un MessageBox provisionalmente.
        public void dameMensaje(string mensaje)
        {
            //MessageBox.Show(mensaje);
            delegadoDatagrid delegado = new delegadoDatagrid(conversacionGrid);
            chatGrid.Invoke(delegado, new object[] { mensaje });
        }  
    }
}
