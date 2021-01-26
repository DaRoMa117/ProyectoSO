namespace WindowsFormsApplication1
{
    partial class Consultas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.consultaUno = new System.Windows.Forms.CheckBox();
            this.botonConsultar = new System.Windows.Forms.Button();
            this.botonVolver = new System.Windows.Forms.Button();
            this.respuestaLabel = new System.Windows.Forms.Label();
            this.consultaDos = new System.Windows.Forms.CheckBox();
            this.consultaTres = new System.Windows.Forms.CheckBox();
            this.consultaCuatro = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // consultaUno
            // 
            this.consultaUno.AutoSize = true;
            this.consultaUno.BackColor = System.Drawing.Color.Transparent;
            this.consultaUno.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultaUno.Location = new System.Drawing.Point(160, 140);
            this.consultaUno.Name = "consultaUno";
            this.consultaUno.Size = new System.Drawing.Size(341, 24);
            this.consultaUno.TabIndex = 0;
            this.consultaUno.Text = "Resultado de tu última partida.";
            this.consultaUno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.consultaUno.UseVisualStyleBackColor = false;
            this.consultaUno.CheckedChanged += new System.EventHandler(this.consultaUno_CheckedChanged);
            // 
            // botonConsultar
            // 
            this.botonConsultar.BackColor = System.Drawing.Color.White;
            this.botonConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonConsultar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botonConsultar.FlatAppearance.BorderSize = 5;
            this.botonConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonConsultar.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonConsultar.Location = new System.Drawing.Point(193, 429);
            this.botonConsultar.Name = "botonConsultar";
            this.botonConsultar.Size = new System.Drawing.Size(150, 50);
            this.botonConsultar.TabIndex = 1;
            this.botonConsultar.Text = "CONSULTAR";
            this.botonConsultar.UseVisualStyleBackColor = false;
            this.botonConsultar.Click += new System.EventHandler(this.botonConsultar_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.BackColor = System.Drawing.Color.White;
            this.botonVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonVolver.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botonVolver.FlatAppearance.BorderSize = 5;
            this.botonVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonVolver.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.Location = new System.Drawing.Point(577, 429);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(150, 50);
            this.botonVolver.TabIndex = 2;
            this.botonVolver.Text = "VOLVER";
            this.botonVolver.UseVisualStyleBackColor = false;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // respuestaLabel
            // 
            this.respuestaLabel.AutoSize = true;
            this.respuestaLabel.BackColor = System.Drawing.Color.Transparent;
            this.respuestaLabel.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.respuestaLabel.Location = new System.Drawing.Point(160, 360);
            this.respuestaLabel.Name = "respuestaLabel";
            this.respuestaLabel.Size = new System.Drawing.Size(0, 20);
            this.respuestaLabel.TabIndex = 3;
            this.respuestaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // consultaDos
            // 
            this.consultaDos.AutoSize = true;
            this.consultaDos.BackColor = System.Drawing.Color.Transparent;
            this.consultaDos.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultaDos.Location = new System.Drawing.Point(160, 190);
            this.consultaDos.Name = "consultaDos";
            this.consultaDos.Size = new System.Drawing.Size(371, 24);
            this.consultaDos.TabIndex = 4;
            this.consultaDos.Text = "Número de partidas que has ganado.";
            this.consultaDos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.consultaDos.UseVisualStyleBackColor = false;
            this.consultaDos.CheckedChanged += new System.EventHandler(this.consultaDos_CheckedChanged);
            // 
            // consultaTres
            // 
            this.consultaTres.AutoSize = true;
            this.consultaTres.BackColor = System.Drawing.Color.Transparent;
            this.consultaTres.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultaTres.Location = new System.Drawing.Point(160, 240);
            this.consultaTres.Name = "consultaTres";
            this.consultaTres.Size = new System.Drawing.Size(381, 24);
            this.consultaTres.TabIndex = 5;
            this.consultaTres.Text = "Número de partidas que has perdido.";
            this.consultaTres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.consultaTres.UseVisualStyleBackColor = false;
            this.consultaTres.CheckedChanged += new System.EventHandler(this.consultaTres_CheckedChanged);
            // 
            // consultaCuatro
            // 
            this.consultaCuatro.AutoSize = true;
            this.consultaCuatro.BackColor = System.Drawing.Color.Transparent;
            this.consultaCuatro.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultaCuatro.Location = new System.Drawing.Point(160, 290);
            this.consultaCuatro.Name = "consultaCuatro";
            this.consultaCuatro.Size = new System.Drawing.Size(371, 24);
            this.consultaCuatro.TabIndex = 6;
            this.consultaCuatro.Text = "Fecha y hora de tu última partida.";
            this.consultaCuatro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.consultaCuatro.UseVisualStyleBackColor = false;
            this.consultaCuatro.CheckedChanged += new System.EventHandler(this.consultaCuatro_CheckedChanged);
            // 
            // Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.consultas2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.consultaCuatro);
            this.Controls.Add(this.consultaTres);
            this.Controls.Add(this.consultaDos);
            this.Controls.Add(this.respuestaLabel);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonConsultar);
            this.Controls.Add(this.consultaUno);
            this.Name = "Consultas";
            this.Text = "Consultas";
            this.Load += new System.EventHandler(this.Consultas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox consultaUno;
        private System.Windows.Forms.Button botonConsultar;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Label respuestaLabel;
        private System.Windows.Forms.CheckBox consultaDos;
        private System.Windows.Forms.CheckBox consultaTres;
        private System.Windows.Forms.CheckBox consultaCuatro;
    }
}