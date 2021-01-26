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
    public partial class Consultas : Form
    {
        Socket server;
        string usuario;

        delegate void delegadoEscribir(string texto);

        public Consultas(Socket server, string usuario)
        {
            InitializeComponent();
            this.server = server;
            this.usuario = usuario;
        }

        private void Consultas_Load(object sender, EventArgs e)
        {

        }

        public void ponRespuesta(string texto)
        {
            respuestaLabel.Text = texto;
        }

        public void damePrimeraConsulta(string resultado)
        {
            string texto = string.Format("El resultado de tu última partidas es: {0}.", resultado);
            delegadoEscribir delegado1 = new delegadoEscribir(ponRespuesta);
            this.respuestaLabel.Invoke(delegado1, new object[] { texto });
        }

        public void dameSegundaConsulta(string resultado)
        {
            string texto = string.Format("Has ganado {0} partidas.", resultado);
            delegadoEscribir delegado1 = new delegadoEscribir(ponRespuesta);
            this.respuestaLabel.Invoke(delegado1, new object[] { texto });
        }

        public void dameTerceraConsulta(string resultado)
        {
            string texto = string.Format("Has perdido {0} partidas.", resultado);
            delegadoEscribir delegado1 = new delegadoEscribir(ponRespuesta);
            this.respuestaLabel.Invoke(delegado1, new object[] { texto });
        }

        public void dameCuartaConsulta(string fecha, string hora)
        {
            string texto = string.Format("Tú última partida fue el {0} a las {1}.", fecha, hora);
            delegadoEscribir delegado1 = new delegadoEscribir(ponRespuesta);
            this.respuestaLabel.Invoke(delegado1, new object[] { texto });
        }

        private void botonConsultar_Click(object sender, EventArgs e)
        {
            if (consultaUno.Checked == true)
            {
                string consulta = "3/" + usuario + "/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(consulta);
                server.Send(msg);

                consultaUno.Checked = false;
            }
            else if (consultaDos.Checked == true)
            {
                string consulta = "4/" + usuario + "/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(consulta);
                server.Send(msg);

                consultaDos.Checked = false;
            }
            else if (consultaTres.Checked == true)
            {
                string consulta = "5/" + usuario + "/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(consulta);
                server.Send(msg);

                consultaTres.Checked = false;
            }
            else if (consultaCuatro.Checked == true)
            {
                string consulta = "19/" + usuario + "/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(consulta);
                server.Send(msg);

                consultaCuatro.Checked = false;
            }
            else
            {
                string texto = "Selecciona una única consulta.";
                delegadoEscribir delegado1 = new delegadoEscribir(ponRespuesta);
                this.respuestaLabel.Invoke(delegado1, new object[] { texto });
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void consultaUno_CheckedChanged(object sender, EventArgs e)
        {
            if (consultaUno.Checked == true)
            {
                consultaDos.Visible = false;
                consultaTres.Visible = false;
                consultaCuatro.Visible = false;
            }
            else
            {
                consultaDos.Visible = true;
                consultaTres.Visible = true;
                consultaCuatro.Visible = true;
            }
        }

        private void consultaDos_CheckedChanged(object sender, EventArgs e)
        {
            if (consultaDos.Checked == true)
            {
                consultaUno.Visible = false;
                consultaTres.Visible = false;
                consultaCuatro.Visible = false;
            }
            else
            {
                consultaUno.Visible = true;
                consultaTres.Visible = true;
                consultaCuatro.Visible = true;
            }
        }

        private void consultaTres_CheckedChanged(object sender, EventArgs e)
        {
            if (consultaTres.Checked == true)
            {
                consultaUno.Visible = false;
                consultaDos.Visible = false;
                consultaCuatro.Visible = false;
            }
            else
            {
                consultaUno.Visible = true;
                consultaDos.Visible = true;
                consultaCuatro.Visible = true;
            }
        }

        private void consultaCuatro_CheckedChanged(object sender, EventArgs e)
        {
            if (consultaCuatro.Checked == true)
            {
                consultaUno.Visible = false;
                consultaDos.Visible = false;
                consultaTres.Visible = false;
            }
            else
            {
                consultaUno.Visible = true;
                consultaDos.Visible = true;
                consultaTres.Visible = true;
            }
        }
    }
}
