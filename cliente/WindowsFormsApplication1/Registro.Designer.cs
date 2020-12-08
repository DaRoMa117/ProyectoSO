namespace WindowsFormsApplication1
{
    partial class Registro
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.usuarioBox = new System.Windows.Forms.TextBox();
            this.contraseñaBox = new System.Windows.Forms.TextBox();
            this.botonRegistrar = new System.Windows.Forms.Button();
            this.iniciarLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(78, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(78, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña";
            // 
            // usuarioBox
            // 
            this.usuarioBox.Location = new System.Drawing.Point(179, 161);
            this.usuarioBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(160, 22);
            this.usuarioBox.TabIndex = 3;
            // 
            // contraseñaBox
            // 
            this.contraseñaBox.Location = new System.Drawing.Point(179, 227);
            this.contraseñaBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contraseñaBox.Name = "contraseñaBox";
            this.contraseñaBox.Size = new System.Drawing.Size(160, 22);
            this.contraseñaBox.TabIndex = 4;
            // 
            // botonRegistrar
            // 
            this.botonRegistrar.Location = new System.Drawing.Point(171, 277);
            this.botonRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonRegistrar.Name = "botonRegistrar";
            this.botonRegistrar.Size = new System.Drawing.Size(77, 30);
            this.botonRegistrar.TabIndex = 5;
            this.botonRegistrar.Text = "Aceptar";
            this.botonRegistrar.UseVisualStyleBackColor = true;
            this.botonRegistrar.Click += new System.EventHandler(this.botonRegistrar_Click);
            // 
            // iniciarLabel
            // 
            this.iniciarLabel.AutoSize = true;
            this.iniciarLabel.BackColor = System.Drawing.Color.Transparent;
            this.iniciarLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iniciarLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iniciarLabel.Location = new System.Drawing.Point(93, 336);
            this.iniciarLabel.Name = "iniciarLabel";
            this.iniciarLabel.Size = new System.Drawing.Size(233, 17);
            this.iniciarLabel.TabIndex = 6;
            this.iniciarLabel.Text = "¿Ya te has registrado? Inicia sesión";
            this.iniciarLabel.Click += new System.EventHandler(this.iniciarLabel_Click);
            this.iniciarLabel.MouseEnter += new System.EventHandler(this.iniciarLabel_MouseEnter);
            this.iniciarLabel.MouseLeave += new System.EventHandler(this.iniciarLabel_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(73, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Crear cuenta";
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.maze;
            this.ClientSize = new System.Drawing.Size(415, 422);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iniciarLabel);
            this.Controls.Add(this.botonRegistrar);
            this.Controls.Add(this.contraseñaBox);
            this.Controls.Add(this.usuarioBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Registro";
            this.Text = "Registro";
            this.Load += new System.EventHandler(this.Registro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usuarioBox;
        private System.Windows.Forms.TextBox contraseñaBox;
        private System.Windows.Forms.Button botonRegistrar;
        private System.Windows.Forms.Label iniciarLabel;
    }
}