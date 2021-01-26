namespace WindowsFormsApplication1
{
    partial class IniciarSesión
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
            this.usuarioBox = new System.Windows.Forms.TextBox();
            this.contraseñaBox = new System.Windows.Forms.TextBox();
            this.botonIniciar = new System.Windows.Forms.Button();
            this.registrarseLabel = new System.Windows.Forms.Label();
            this.botonSalir = new System.Windows.Forms.Button();
            this.darseBajaLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usuarioBox
            // 
            this.usuarioBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.usuarioBox.Location = new System.Drawing.Point(474, 337);
            this.usuarioBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(170, 22);
            this.usuarioBox.TabIndex = 2;
            this.usuarioBox.Text = "Usuario";
            this.usuarioBox.Enter += new System.EventHandler(this.usuarioBox_Enter);
            this.usuarioBox.Leave += new System.EventHandler(this.usuarioBox_Leave);
            // 
            // contraseñaBox
            // 
            this.contraseñaBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.contraseñaBox.Location = new System.Drawing.Point(474, 436);
            this.contraseñaBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contraseñaBox.Name = "contraseñaBox";
            this.contraseñaBox.Size = new System.Drawing.Size(170, 22);
            this.contraseñaBox.TabIndex = 3;
            this.contraseñaBox.Text = "Contraseña";
            this.contraseñaBox.Enter += new System.EventHandler(this.contraseñaBox_Enter);
            this.contraseñaBox.Leave += new System.EventHandler(this.contraseñaBox_Leave);
            // 
            // botonIniciar
            // 
            this.botonIniciar.BackColor = System.Drawing.Color.White;
            this.botonIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonIniciar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botonIniciar.FlatAppearance.BorderSize = 5;
            this.botonIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonIniciar.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonIniciar.Location = new System.Drawing.Point(371, 535);
            this.botonIniciar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonIniciar.Name = "botonIniciar";
            this.botonIniciar.Size = new System.Drawing.Size(120, 50);
            this.botonIniciar.TabIndex = 4;
            this.botonIniciar.Text = "INICIAR";
            this.botonIniciar.UseVisualStyleBackColor = false;
            this.botonIniciar.Click += new System.EventHandler(this.botonIniciar_Click);
            // 
            // registrarseLabel
            // 
            this.registrarseLabel.AutoSize = true;
            this.registrarseLabel.BackColor = System.Drawing.Color.Transparent;
            this.registrarseLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registrarseLabel.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrarseLabel.ForeColor = System.Drawing.Color.Black;
            this.registrarseLabel.Location = new System.Drawing.Point(335, 500);
            this.registrarseLabel.Name = "registrarseLabel";
            this.registrarseLabel.Size = new System.Drawing.Size(312, 16);
            this.registrarseLabel.TabIndex = 6;
            this.registrarseLabel.Text = "¿Todavía no tienes cuenta? Regístrate.";
            this.registrarseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.registrarseLabel.Click += new System.EventHandler(this.registrarseLabel_Click);
            this.registrarseLabel.MouseEnter += new System.EventHandler(this.registrarseLabel_MouseEnter);
            this.registrarseLabel.MouseLeave += new System.EventHandler(this.registrarseLabel_MouseLeave);
            // 
            // botonSalir
            // 
            this.botonSalir.BackColor = System.Drawing.Color.White;
            this.botonSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botonSalir.FlatAppearance.BorderSize = 5;
            this.botonSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonSalir.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonSalir.Location = new System.Drawing.Point(538, 535);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(120, 50);
            this.botonSalir.TabIndex = 7;
            this.botonSalir.Text = "SALIR";
            this.botonSalir.UseVisualStyleBackColor = false;
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // darseBajaLabel
            // 
            this.darseBajaLabel.AutoSize = true;
            this.darseBajaLabel.BackColor = System.Drawing.Color.Transparent;
            this.darseBajaLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.darseBajaLabel.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darseBajaLabel.ForeColor = System.Drawing.Color.Black;
            this.darseBajaLabel.Location = new System.Drawing.Point(450, 610);
            this.darseBajaLabel.Name = "darseBajaLabel";
            this.darseBajaLabel.Size = new System.Drawing.Size(112, 16);
            this.darseBajaLabel.TabIndex = 9;
            this.darseBajaLabel.Text = "DARSE DE BAJA";
            this.darseBajaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.darseBajaLabel.Click += new System.EventHandler(this.darseBajaLabel_Click);
            this.darseBajaLabel.MouseEnter += new System.EventHandler(this.darseBajaLabel_MouseEnter);
            this.darseBajaLabel.MouseLeave += new System.EventHandler(this.darseBajaLabel_MouseLeave);
            // 
            // IniciarSesión
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.IniciarSesion1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(751, 758);
            this.Controls.Add(this.darseBajaLabel);
            this.Controls.Add(this.botonSalir);
            this.Controls.Add(this.registrarseLabel);
            this.Controls.Add(this.contraseñaBox);
            this.Controls.Add(this.usuarioBox);
            this.Controls.Add(this.botonIniciar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "IniciarSesión";
            this.Text = "IniciarSesión";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IniciarSesión_FormClosing);
            this.Load += new System.EventHandler(this.IniciarSesión_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usuarioBox;
        private System.Windows.Forms.TextBox contraseñaBox;
        private System.Windows.Forms.Button botonIniciar;
        private System.Windows.Forms.Label registrarseLabel;
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.Label darseBajaLabel;

    }
}