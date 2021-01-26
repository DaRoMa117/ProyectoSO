namespace WindowsFormsApplication1
{
    partial class DarseBaja
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
            this.botonBaja = new System.Windows.Forms.Button();
            this.iniciarLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usuarioBox
            // 
            this.usuarioBox.Location = new System.Drawing.Point(174, 200);
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(164, 22);
            this.usuarioBox.TabIndex = 0;
            // 
            // contraseñaBox
            // 
            this.contraseñaBox.Location = new System.Drawing.Point(174, 286);
            this.contraseñaBox.Name = "contraseñaBox";
            this.contraseñaBox.Size = new System.Drawing.Size(164, 22);
            this.contraseñaBox.TabIndex = 1;
            // 
            // botonBaja
            // 
            this.botonBaja.BackColor = System.Drawing.Color.White;
            this.botonBaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonBaja.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botonBaja.FlatAppearance.BorderSize = 5;
            this.botonBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBaja.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBaja.Location = new System.Drawing.Point(154, 350);
            this.botonBaja.Name = "botonBaja";
            this.botonBaja.Size = new System.Drawing.Size(120, 50);
            this.botonBaja.TabIndex = 2;
            this.botonBaja.Text = "ACEPTAR";
            this.botonBaja.UseVisualStyleBackColor = false;
            this.botonBaja.Click += new System.EventHandler(this.botonBaja_Click);
            // 
            // iniciarLabel
            // 
            this.iniciarLabel.AutoSize = true;
            this.iniciarLabel.BackColor = System.Drawing.Color.Transparent;
            this.iniciarLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iniciarLabel.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iniciarLabel.ForeColor = System.Drawing.Color.Black;
            this.iniciarLabel.Location = new System.Drawing.Point(105, 415);
            this.iniciarLabel.Name = "iniciarLabel";
            this.iniciarLabel.Size = new System.Drawing.Size(200, 32);
            this.iniciarLabel.TabIndex = 7;
            this.iniciarLabel.Text = "¿Ya te has dado de baja?\r\nInicia sesión";
            this.iniciarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iniciarLabel.Click += new System.EventHandler(this.iniciarLabel_Click);
            this.iniciarLabel.MouseEnter += new System.EventHandler(this.iniciarLabel_MouseEnter);
            this.iniciarLabel.MouseLeave += new System.EventHandler(this.iniciarLabel_MouseLeave);
            // 
            // DarseBaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.darseBaja;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(425, 496);
            this.Controls.Add(this.iniciarLabel);
            this.Controls.Add(this.botonBaja);
            this.Controls.Add(this.contraseñaBox);
            this.Controls.Add(this.usuarioBox);
            this.Name = "DarseBaja";
            this.Text = "DarseBaja";
            this.Load += new System.EventHandler(this.DarseBaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usuarioBox;
        private System.Windows.Forms.TextBox contraseñaBox;
        private System.Windows.Forms.Button botonBaja;
        private System.Windows.Forms.Label iniciarLabel;
    }
}