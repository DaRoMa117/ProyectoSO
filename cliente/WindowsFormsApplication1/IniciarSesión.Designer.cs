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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.registrarseLabel = new System.Windows.Forms.Label();
            this.botonIniciar = new System.Windows.Forms.Button();
            this.contraseñaBox = new System.Windows.Forms.TextBox();
            this.usuarioBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.botonSalir = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.titol1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(517, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.red;
            this.panel2.Controls.Add(this.botonSalir);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.registrarseLabel);
            this.panel2.Controls.Add(this.botonIniciar);
            this.panel2.Controls.Add(this.contraseñaBox);
            this.panel2.Controls.Add(this.usuarioBox);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(517, 117);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(475, 412);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Iniciar Sesión";
            // 
            // registrarseLabel
            // 
            this.registrarseLabel.AutoSize = true;
            this.registrarseLabel.BackColor = System.Drawing.Color.Transparent;
            this.registrarseLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registrarseLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.registrarseLabel.Location = new System.Drawing.Point(132, 299);
            this.registrarseLabel.Name = "registrarseLabel";
            this.registrarseLabel.Size = new System.Drawing.Size(253, 17);
            this.registrarseLabel.TabIndex = 6;
            this.registrarseLabel.Text = "¿Todavía no tienes cuenta? Regístrate";
            this.registrarseLabel.Click += new System.EventHandler(this.registrarseLabel_Click);
            this.registrarseLabel.MouseEnter += new System.EventHandler(this.registrarseLabel_MouseEnter);
            this.registrarseLabel.MouseLeave += new System.EventHandler(this.registrarseLabel_MouseLeave);
            // 
            // botonIniciar
            // 
            this.botonIniciar.Location = new System.Drawing.Point(340, 142);
            this.botonIniciar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonIniciar.Name = "botonIniciar";
            this.botonIniciar.Size = new System.Drawing.Size(96, 30);
            this.botonIniciar.TabIndex = 4;
            this.botonIniciar.Text = "Iniciar";
            this.botonIniciar.UseVisualStyleBackColor = true;
            this.botonIniciar.Click += new System.EventHandler(this.botonIniciar_Click);
            // 
            // contraseñaBox
            // 
            this.contraseñaBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.contraseñaBox.Location = new System.Drawing.Point(136, 230);
            this.contraseñaBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contraseñaBox.Name = "contraseñaBox";
            this.contraseñaBox.Size = new System.Drawing.Size(166, 22);
            this.contraseñaBox.TabIndex = 3;
            this.contraseñaBox.Text = "Contraseña";
            this.contraseñaBox.Enter += new System.EventHandler(this.contraseñaBox_Enter);
            this.contraseñaBox.Leave += new System.EventHandler(this.contraseñaBox_Leave);
            // 
            // usuarioBox
            // 
            this.usuarioBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.usuarioBox.Location = new System.Drawing.Point(136, 146);
            this.usuarioBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(166, 22);
            this.usuarioBox.TabIndex = 2;
            this.usuarioBox.Text = "Usuario";
            this.usuarioBox.Enter += new System.EventHandler(this.usuarioBox_Enter);
            this.usuarioBox.Leave += new System.EventHandler(this.usuarioBox_Leave);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.usuario;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(64, 126);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(67, 60);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.candadoo;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(64, 208);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(67, 60);
            this.panel3.TabIndex = 0;
            // 
            // botonSalir
            // 
            this.botonSalir.Location = new System.Drawing.Point(340, 220);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(96, 32);
            this.botonSalir.TabIndex = 7;
            this.botonSalir.Text = "Salir";
            this.botonSalir.UseVisualStyleBackColor = true;
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // IniciarSesión
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.DwYheL;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1078, 551);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "IniciarSesión";
            this.Text = "IniciarSesión";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IniciarSesión_FormClosing);
            this.Load += new System.EventHandler(this.IniciarSesión_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label registrarseLabel;
        private System.Windows.Forms.Button botonIniciar;
        private System.Windows.Forms.TextBox contraseñaBox;
        private System.Windows.Forms.TextBox usuarioBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonSalir;
    }
}