namespace WindowsFormsApplication1
{
    partial class Instrucciones
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
            this.botonCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonCerrar
            // 
            this.botonCerrar.Location = new System.Drawing.Point(258, 470);
            this.botonCerrar.Name = "botonCerrar";
            this.botonCerrar.Size = new System.Drawing.Size(147, 35);
            this.botonCerrar.TabIndex = 0;
            this.botonCerrar.Text = "CERRAR";
            this.botonCerrar.UseVisualStyleBackColor = true;
            this.botonCerrar.Click += new System.EventHandler(this.botonCerrar_Click);
            // 
            // Instrucciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.image_2020_11_26T15_22_24_804Z;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(660, 551);
            this.Controls.Add(this.botonCerrar);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Instrucciones";
            this.Text = "Instrucciones";
            this.Load += new System.EventHandler(this.Instrucciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonCerrar;
    }
}