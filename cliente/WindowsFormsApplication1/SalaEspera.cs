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
        int numPartida;
        List<PantallaUno> primeras = new List<PantallaUno>(); // Lista para guardas los Forms "PantallaUno".
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
        public void dameConfirmacion(string numPartida, string confirmacion)
        {
            if (confirmacion == "si")
            {
                this.numPartida = Convert.ToInt32(numPartida);
                MessageBox.Show("PARTIDA ACEPTADA");
                ThreadStart ts = delegate { iniciarPantallaUno(); };
                Thread primeraPantalla = new Thread(ts);
                primeraPantalla.Start();
                Thread.Sleep(500);
            }
            else
            {
                MessageBox.Show("PARTIDA RECHAZADA");
            }
        }

        // Se inicia el Form "PrimeraUno".
        private void iniciarPantallaUno()
        {
            int numPantallaUno = this.primeras.Count;
            PantallaUno p1 = new PantallaUno(server, numPantallaUno, numPartida);
            this.primeras.Add(p1);
            p1.ShowDialog();
        }

        // Se recibe un nuevo mensaje para el chat y se pasa al Form "PantallaUno" al que corresponde.
        public void dameChat(string mensajeChat)
        {
            string[] chat = mensajeChat.Split(',');
            this.primeras[Convert.ToInt32(chat[0])].dameMensaje(chat[1]);
        }
    }
}
