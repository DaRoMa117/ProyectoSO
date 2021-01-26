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
            this.usuarioBox = new System.Windows.Forms.TextBox();
            this.contraseñaBox = new System.Windows.Forms.TextBox();
            this.botonRegistrar = new System.Windows.Forms.Button();
            this.iniciarLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usuarioBox
            // 
            this.usuarioBox.Location = new System.Drawing.Point(229, 343);
            this.usuarioBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(160, 22);
            this.usuarioBox.TabIndex = 3;
            // 
            // contraseñaBox
            // 
            this.contraseñaBox.Location = new System.Drawing.Point(229, 440);
            this.contraseñaBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contraseñaBox.Name = "contraseñaBox";
            this.contraseñaBox.Size = new System.Drawing.Size(160, 22);
            this.contraseñaBox.TabIndex = 4;
            // 
            // botonRegistrar
            // 
            this.botonRegistrar.BackColor = System.Drawing.Color.White;
            this.botonRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonRegistrar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botonRegistrar.FlatAppearance.BorderSize = 5;
            this.botonRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonRegistrar.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRegistrar.Location = new System.Drawing.Point(250, 490);
            this.botonRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonRegistrar.Name = "botonRegistrar";
            this.botonRegistrar.Size = new System.Drawing.Size(120, 50);
            this.botonRegistrar.TabIndex = 5;
            this.botonRegistrar.Text = "ACEPTAR";
            this.botonRegistrar.UseVisualStyleBackColor = false;
            this.botonRegistrar.Click += new System.EventHandler(this.botonRegistrar_Click);
            // 
            // iniciarLabel
            // 
            this.iniciarLabel.AutoSize = true;
            this.iniciarLabel.BackColor = System.Drawing.Color.Transparent;
            this.iniciarLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iniciarLabel.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iniciarLabel.ForeColor = System.Drawing.Color.Black;
            this.iniciarLabel.Location = new System.Drawing.Point(93, 565);
            this.iniciarLabel.Name = "iniciarLabel";
            this.iniciarLabel.Size = new System.Drawing.Size(296, 16);
            this.iniciarLabel.TabIndex = 6;
            this.iniciarLabel.Text = "¿Ya te has registrado? Inicia sesión";
            this.iniciarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iniciarLabel.Click += new System.EventHandler(this.iniciarLabel_Click);
            this.iniciarLabel.MouseEnter += new System.EventHandler(this.iniciarLabel_MouseEnter);
            this.iniciarLabel.MouseLeave += new System.EventHandler(this.iniciarLabel_MouseLeave);
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Registro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(743, 762);
            this.Controls.Add(this.iniciarLabel);
            this.Controls.Add(this.botonRegistrar);
            this.Controls.Add(this.contraseñaBox);
            this.Controls.Add(this.usuarioBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Registro";
            this.Text = "Registro";
            this.Load += new System.EventHandler(this.Registro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usuarioBox;
        private System.Windows.Forms.TextBox contraseñaBox;
        private System.Windows.Forms.Button botonRegistrar;
        private System.Windows.Forms.Label iniciarLabel;
    }
}