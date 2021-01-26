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
    public partial class PantallaTres : Form
    {
        Socket server;
        int numTerceraPantalla;
        int numPartida;
        string movimiento = "";
        bool activado = true;

        delegate void delegadoDatagrid(string mensaje);
        delegate void delegadoCerrar();
        delegate void delegadoMovimiento();

        public PantallaTres(Socket server, int numPartida)
        {
            InitializeComponent();
            this.server = server;
            this.numTerceraPantalla = numPartida;
            this.numPartida = numPartida;
        }

        private void PantallaTres_Load(object sender, EventArgs e)
        {
            this.chatGrid.DataError += new DataGridViewDataErrorEventHandler(chatGrid_DataError);
            this.chatGrid.ColumnCount = 1;
            this.chatGrid.RowHeadersVisible = false;
            this.chatGrid.Columns[0].HeaderText = "CHAT";
            this.chatGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            pictureBox1.BackColor = Color.Black;
            pictureBox2.BackColor = Color.Red;
            pictureBox3.BackColor = Color.DarkRed;
            pictureBox4.BackColor = Color.Orange;
            pictureBox5.BackColor = Color.DarkOrange;
            pictureBox6.BackColor = Color.DarkGreen;
            pictureBox7.BackColor = Color.Blue;
            pictureBox8.BackColor = Color.Gray;
            pictureBox9.BackColor = Color.DarkGray;
            pictureBox10.BackColor = Color.Green;
            pictureBox11.BackColor = Color.White;
            pictureBox12.BackColor = Color.DarkBlue;

            pictureBox1.BackgroundImage = Properties.Resources.Pieza_01;
            pictureBox2.BackgroundImage = Properties.Resources.Pieza_02;
            pictureBox3.BackgroundImage = Properties.Resources.Pieza_03;
            pictureBox4.BackgroundImage = Properties.Resources.Pieza_04;
            pictureBox5.BackgroundImage = Properties.Resources.Pieza_05;
            pictureBox6.BackgroundImage = Properties.Resources.Pieza_07;
            pictureBox7.BackgroundImage = Properties.Resources.Pieza_10;
            pictureBox8.BackgroundImage = Properties.Resources.Pieza_08;
            pictureBox9.BackgroundImage = Properties.Resources.Pieza_09;
            pictureBox10.BackgroundImage = Properties.Resources.Pieza_06;
            pictureBox11.BackgroundImage = Properties.Resources.Pieza_Blanca;
            pictureBox12.BackgroundImage = Properties.Resources.Pieza_11;
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

        public void activarMovimiento()
        {
            button1.PerformClick();
        }

        // Se cierra el Form.
        public void cerrarForm()
        {
            this.Close();
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
                string mensajeChat = "9/" + numTerceraPantalla + "/" + numPartida + "/" + text + "/tercera/";
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox2.BackColor == Color.White)
            {
                pictureBox2.BackgroundImage = pictureBox1.BackgroundImage;
                pictureBox2.BackColor = pictureBox1.BackColor;
                pictureBox1.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox1.BackColor = Color.White;
            }
            if (pictureBox5.BackColor == Color.White)
            {
                pictureBox5.BackgroundImage = pictureBox1.BackgroundImage;
                pictureBox5.BackColor = pictureBox1.BackColor;
                pictureBox1.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox1.BackColor = Color.White;
            }

            if (activado == true)
            {
                string movimientoPuzzle = "14/" + numTerceraPantalla + "/" + numPartida + "/botonUno/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
            else
            {
                activado = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.BackColor == Color.White)
            {
                pictureBox1.BackgroundImage = pictureBox2.BackgroundImage;
                pictureBox1.BackColor = pictureBox2.BackColor;
                pictureBox2.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox2.BackColor = Color.White;
            }
            if (pictureBox3.BackColor == Color.White)
            {
                pictureBox3.BackgroundImage = pictureBox2.BackgroundImage;
                pictureBox3.BackColor = pictureBox2.BackColor;
                pictureBox2.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox2.BackColor = Color.White;
            }
            if (pictureBox6.BackColor == Color.White)
            {
                pictureBox6.BackgroundImage = pictureBox2.BackgroundImage;
                pictureBox6.BackColor = pictureBox2.BackColor;
                pictureBox2.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox2.BackColor = Color.White;
            }

            if (activado == true)
            {
                string movimientoPuzzle = "14/" + numTerceraPantalla + "/" + numPartida + "/botonDos/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
            else
            {
                activado = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pictureBox2.BackColor == Color.White)
            {
                pictureBox2.BackgroundImage = pictureBox3.BackgroundImage;
                pictureBox2.BackColor = pictureBox3.BackColor;
                pictureBox3.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox3.BackColor = Color.White;
            }
            if (pictureBox4.BackColor == Color.White)
            {
                pictureBox4.BackgroundImage = pictureBox3.BackgroundImage;
                pictureBox4.BackColor = pictureBox3.BackColor;
                pictureBox3.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox3.BackColor = Color.White;
            }
            if (pictureBox7.BackColor == Color.White)
            {
                pictureBox7.BackgroundImage = pictureBox3.BackgroundImage;
                pictureBox7.BackColor = pictureBox3.BackColor;
                pictureBox3.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox3.BackColor = Color.White;
            }

            if (activado == true)
            {
                string movimientoPuzzle = "14/" + numTerceraPantalla + "/" + numPartida + "/botonTres/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
            else
            {
                activado = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pictureBox3.BackColor == Color.White)
            {
                pictureBox3.BackgroundImage = pictureBox4.BackgroundImage;
                pictureBox3.BackColor = pictureBox4.BackColor;
                pictureBox4.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox4.BackColor = Color.White;
            }
            if (pictureBox8.BackColor == Color.White)
            {
                pictureBox8.BackgroundImage = pictureBox4.BackgroundImage;
                pictureBox8.BackColor = pictureBox4.BackColor;
                pictureBox4.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox4.BackColor = Color.White;
            }

            if (activado == true)
            {
                string movimientoPuzzle = "14/" + numTerceraPantalla + "/" + numPartida + "/botonCuatro/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
            else
            {
                activado = true;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.BackColor == Color.White)
            {
                pictureBox1.BackgroundImage = pictureBox5.BackgroundImage;
                pictureBox1.BackColor = pictureBox5.BackColor;
                pictureBox5.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox5.BackColor = Color.White;
            }
            if (pictureBox6.BackColor == Color.White)
            {
                pictureBox6.BackgroundImage = pictureBox5.BackgroundImage;
                pictureBox6.BackColor = pictureBox5.BackColor;
                pictureBox5.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox5.BackColor = Color.White;
            }
            if (pictureBox9.BackColor == Color.White)
            {
                pictureBox9.BackgroundImage = pictureBox5.BackgroundImage;
                pictureBox9.BackColor = pictureBox5.BackColor;
                pictureBox5.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox5.BackColor = Color.White;
            }

            if (activado == true)
            {
                string movimientoPuzzle = "14/" + numTerceraPantalla + "/" + numPartida + "/botonCinco/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
            else
            {
                activado = true;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (pictureBox2.BackColor == Color.White)
            {
                pictureBox2.BackgroundImage = pictureBox6.BackgroundImage;
                pictureBox2.BackColor = pictureBox6.BackColor;
                pictureBox6.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox6.BackColor = Color.White;
            }
            if (pictureBox5.BackColor == Color.White)
            {
                pictureBox5.BackgroundImage = pictureBox6.BackgroundImage;
                pictureBox5.BackColor = pictureBox6.BackColor;
                pictureBox6.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox6.BackColor = Color.White;
            }
            if (pictureBox7.BackColor == Color.White)
            {
                pictureBox7.BackgroundImage = pictureBox6.BackgroundImage;
                pictureBox7.BackColor = pictureBox6.BackColor;
                pictureBox6.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox6.BackColor = Color.White;
            }
            if (pictureBox10.BackColor == Color.White)
            {
                pictureBox10.BackgroundImage = pictureBox6.BackgroundImage;
                pictureBox10.BackColor = pictureBox6.BackColor;
                pictureBox6.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox6.BackColor = Color.White;
            }

            if (activado == true)
            {
                string movimientoPuzzle = "14/" + numTerceraPantalla + "/" + numPartida + "/botonSeis/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
            else
            {
                activado = true;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (pictureBox3.BackColor == Color.White)
            {
                pictureBox3.BackgroundImage = pictureBox7.BackgroundImage;
                pictureBox3.BackColor = pictureBox7.BackColor;
                pictureBox7.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox7.BackColor = Color.White;
            }
            if (pictureBox6.BackColor == Color.White)
            {
                pictureBox6.BackgroundImage = pictureBox7.BackgroundImage;
                pictureBox6.BackColor = pictureBox7.BackColor;
                pictureBox7.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox7.BackColor = Color.White;
            }
            if (pictureBox8.BackColor == Color.White)
            {
                pictureBox8.BackgroundImage = pictureBox7.BackgroundImage;
                pictureBox8.BackColor = pictureBox7.BackColor;
                pictureBox7.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox7.BackColor = Color.White;
            }
            if (pictureBox11.BackColor == Color.White)
            {
                pictureBox11.BackgroundImage = pictureBox7.BackgroundImage;
                pictureBox11.BackColor = pictureBox7.BackColor;
                pictureBox7.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox7.BackColor = Color.White;
            }

            if (activado == true)
            {
                string movimientoPuzzle = "14/" + numTerceraPantalla + "/" + numPartida + "/botonSiete/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
            else
            {
                activado = true;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (pictureBox4.BackColor == Color.White)
            {
                pictureBox4.BackgroundImage = pictureBox8.BackgroundImage;
                pictureBox4.BackColor = pictureBox8.BackColor;
                pictureBox8.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox8.BackColor = Color.White;
            }
            if (pictureBox7.BackColor == Color.White)
            {
                pictureBox7.BackgroundImage = pictureBox8.BackgroundImage;
                pictureBox7.BackColor = pictureBox8.BackColor;
                pictureBox8.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox8.BackColor = Color.White;
            }
            if (pictureBox12.BackColor == Color.White)
            {
                pictureBox12.BackgroundImage = pictureBox8.BackgroundImage;
                pictureBox12.BackColor = pictureBox8.BackColor;
                pictureBox8.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox8.BackColor = Color.White;
            }

            if (activado == true)
            {
                string movimientoPuzzle = "14/" + numTerceraPantalla + "/" + numPartida + "/botonOcho/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
            else
            {
                activado = true;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (pictureBox5.BackColor == Color.White)
            {
                pictureBox5.BackgroundImage = pictureBox9.BackgroundImage;
                pictureBox5.BackColor = pictureBox9.BackColor;
                pictureBox9.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox9.BackColor = Color.White;
            }
            if (pictureBox10.BackColor == Color.White)
            {
                pictureBox10.BackgroundImage = pictureBox9.BackgroundImage;
                pictureBox10.BackColor = pictureBox9.BackColor;
                pictureBox9.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox9.BackColor = Color.White;
            }

            if (activado == true)
            {
                string movimientoPuzzle = "14/" + numTerceraPantalla + "/" + numPartida + "/botonNueve/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
            else
            {
                activado = true;
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (pictureBox6.BackColor == Color.White)
            {
                pictureBox6.BackgroundImage = pictureBox10.BackgroundImage;
                pictureBox6.BackColor = pictureBox10.BackColor;
                pictureBox10.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox10.BackColor = Color.White;
            }
            if (pictureBox9.BackColor == Color.White)
            {
                pictureBox9.BackgroundImage = pictureBox10.BackgroundImage;
                pictureBox9.BackColor = pictureBox10.BackColor;
                pictureBox10.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox10.BackColor = Color.White;
            }
            if (pictureBox11.BackColor == Color.White)
            {
                pictureBox11.BackgroundImage = pictureBox10.BackgroundImage;
                pictureBox11.BackColor = pictureBox10.BackColor;
                pictureBox10.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox10.BackColor = Color.White;
            }

            if (activado == true)
            {
                string movimientoPuzzle = "14/" + numTerceraPantalla + "/" + numPartida + "/botonDiez/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
            else
            {
                activado = true;
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (pictureBox7.BackColor == Color.White)
            {
                pictureBox7.BackgroundImage = pictureBox11.BackgroundImage;
                pictureBox7.BackColor = pictureBox11.BackColor;
                pictureBox11.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox11.BackColor = Color.White;
            }
            if (pictureBox10.BackColor == Color.White)
            {
                pictureBox10.BackgroundImage = pictureBox11.BackgroundImage;
                pictureBox10.BackColor = pictureBox11.BackColor;
                pictureBox11.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox11.BackColor = Color.White;
            }
            if (pictureBox12.BackColor == Color.White)
            {
                pictureBox12.BackgroundImage = pictureBox11.BackgroundImage;
                pictureBox12.BackColor = pictureBox11.BackColor;
                pictureBox11.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox11.BackColor = Color.White;
            }

            if (activado == true)
            {
                string movimientoPuzzle = "14/" + numTerceraPantalla + "/" + numPartida + "/botonOnce/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
            else
            {
                activado = true;
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (pictureBox8.BackColor == Color.White)
            {
                pictureBox8.BackgroundImage = pictureBox12.BackgroundImage;
                pictureBox8.BackColor = pictureBox12.BackColor;
                pictureBox12.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox12.BackColor = Color.White;
            }
            if (pictureBox11.BackColor == Color.White)
            {
                pictureBox11.BackgroundImage = pictureBox12.BackgroundImage;
                pictureBox11.BackColor = pictureBox12.BackColor;
                pictureBox12.BackgroundImage = Properties.Resources.Pieza_Blanca;
                pictureBox12.BackColor = Color.White;
            }

            if (activado == true)
            {
                string movimientoPuzzle = "14/" + numTerceraPantalla + "/" + numPartida + "/botonDoce/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
            else
            {
                activado = true;
            }
        }

        public void dameMovimiento(string movimiento)
        {
            this.movimiento = movimiento;
            delegadoMovimiento delegado2 = new delegadoMovimiento(activarMovimiento);
            this.button1.Invoke(delegado2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            activado = false;
            if (this.movimiento == "botonUno")
            {
                pictureBox1_Click(this.pictureBox1, e);
            }
            if (movimiento == "botonDos")
            {
                pictureBox2_Click(this.pictureBox2, e);
            }
            if (movimiento == "botonTres")
            {
                pictureBox3_Click(this.pictureBox3, e);
            }
            if (movimiento == "botonCuatro")
            {
                pictureBox4_Click(this.pictureBox4, e);
            }
            if (movimiento == "botonCinco")
            {
                pictureBox5_Click(this.pictureBox5, e);
            }
            if (movimiento == "botonSeis")
            {
                pictureBox6_Click(this.pictureBox6, e);
            }
            if (movimiento == "botonSiete")
            {
                pictureBox7_Click(this.pictureBox7, e);
            }
            if (movimiento == "botonOcho")
            {
                pictureBox8_Click(this.pictureBox8, e);
            }
            if (movimiento == "botonNueve")
            {
                pictureBox9_Click(this.pictureBox9, e);
            }
            if (movimiento == "botonDiez")
            {
                pictureBox10_Click(this.pictureBox10, e);
            }
            if (movimiento == "botonOnce")
            {
                pictureBox11_Click(this.pictureBox11, e);
            }
            if (movimiento == "botonDoce")
            {
                pictureBox12_Click(this.pictureBox12, e);
            }
        }

        private void botonComprobacion_Click(object sender, EventArgs e)
        {
            if ((pictureBox1.BackColor == Color.Black) && (pictureBox2.BackColor == Color.Red) && (pictureBox3.BackColor == Color.DarkRed) && (pictureBox4.BackColor == Color.Orange) && (pictureBox5.BackColor == Color.DarkOrange) && (pictureBox6.BackColor == Color.Green) && (pictureBox7.BackColor == Color.DarkGreen) && (pictureBox8.BackColor == Color.Gray) && (pictureBox9.BackColor == Color.DarkGray) && (pictureBox10.BackColor == Color.Blue) && (pictureBox11.BackColor == Color.DarkBlue) && (pictureBox12.BackColor == Color.White))
            {
                string movimientoPuzzle = "15/" + numTerceraPantalla + "/" + numPartida + "/correcto/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
            else 
            {
                string movimientoPuzzle = "15/" + numTerceraPantalla + "/" + numPartida + "/incorrecto/";
                // Enviamos al servidor el mensaje.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(movimientoPuzzle);
                server.Send(msg);
            }
        }

        public void dameComprobacion()
        {
            delegadoCerrar delegado3 = new delegadoCerrar(cerrarForm); // Cerramos el Form al acabar.
            this.Invoke(delegado3);
        }
    }
}
