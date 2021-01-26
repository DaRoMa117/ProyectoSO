namespace WindowsFormsApplication1
{
    partial class PantallaUno
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textChat = new System.Windows.Forms.TextBox();
            this.botonEnviar = new System.Windows.Forms.Button();
            this.chatGrid = new System.Windows.Forms.DataGridView();
            this.respuestaBox = new System.Windows.Forms.TextBox();
            this.vidasLabel = new System.Windows.Forms.Label();
            this.infoBox = new System.Windows.Forms.PictureBox();
            this.pistaBox = new System.Windows.Forms.PictureBox();
            this.enviarRespuesta = new System.Windows.Forms.PictureBox();
            this.botonEncontrado = new System.Windows.Forms.PictureBox();
            this.sonidoBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chatGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pistaBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enviarRespuesta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.botonEncontrado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sonidoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textChat
            // 
            this.textChat.Location = new System.Drawing.Point(1140, 630);
            this.textChat.Name = "textChat";
            this.textChat.Size = new System.Drawing.Size(285, 22);
            this.textChat.TabIndex = 0;
            // 
            // botonEnviar
            // 
            this.botonEnviar.BackColor = System.Drawing.Color.White;
            this.botonEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonEnviar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botonEnviar.FlatAppearance.BorderSize = 5;
            this.botonEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonEnviar.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEnviar.Location = new System.Drawing.Point(1240, 670);
            this.botonEnviar.Name = "botonEnviar";
            this.botonEnviar.Size = new System.Drawing.Size(100, 50);
            this.botonEnviar.TabIndex = 1;
            this.botonEnviar.Text = "ENVIAR";
            this.botonEnviar.UseVisualStyleBackColor = false;
            this.botonEnviar.Click += new System.EventHandler(this.botonEnviar_Click);
            // 
            // chatGrid
            // 
            this.chatGrid.AllowUserToAddRows = false;
            this.chatGrid.AllowUserToDeleteRows = false;
            this.chatGrid.AllowUserToResizeColumns = false;
            this.chatGrid.AllowUserToResizeRows = false;
            this.chatGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.chatGrid.BackgroundColor = System.Drawing.Color.White;
            this.chatGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.chatGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.chatGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.chatGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.chatGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.chatGrid.Location = new System.Drawing.Point(1140, 164);
            this.chatGrid.Name = "chatGrid";
            this.chatGrid.ReadOnly = true;
            this.chatGrid.RowHeadersVisible = false;
            this.chatGrid.RowTemplate.Height = 24;
            this.chatGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chatGrid.Size = new System.Drawing.Size(285, 444);
            this.chatGrid.TabIndex = 2;
            // 
            // respuestaBox
            // 
            this.respuestaBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.respuestaBox.Location = new System.Drawing.Point(477, 725);
            this.respuestaBox.Name = "respuestaBox";
            this.respuestaBox.Size = new System.Drawing.Size(166, 22);
            this.respuestaBox.TabIndex = 3;
            this.respuestaBox.Text = "00:00";
            this.respuestaBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.respuestaBox.Enter += new System.EventHandler(this.respuestaBox_Enter);
            this.respuestaBox.Leave += new System.EventHandler(this.respuestaBox_Leave);
            // 
            // vidasLabel
            // 
            this.vidasLabel.AutoSize = true;
            this.vidasLabel.BackColor = System.Drawing.Color.Transparent;
            this.vidasLabel.Font = new System.Drawing.Font("Courier New", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vidasLabel.ForeColor = System.Drawing.Color.Black;
            this.vidasLabel.Location = new System.Drawing.Point(1160, 30);
            this.vidasLabel.Name = "vidasLabel";
            this.vidasLabel.Size = new System.Drawing.Size(0, 37);
            this.vidasLabel.TabIndex = 6;
            this.vidasLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoBox
            // 
            this.infoBox.BackColor = System.Drawing.Color.Transparent;
            this.infoBox.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.info1;
            this.infoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.infoBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.infoBox.Location = new System.Drawing.Point(649, 718);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(40, 40);
            this.infoBox.TabIndex = 7;
            this.infoBox.TabStop = false;
            this.infoBox.MouseEnter += new System.EventHandler(this.infoBox_MouseEnter);
            this.infoBox.MouseLeave += new System.EventHandler(this.infoBox_MouseLeave);
            // 
            // pistaBox
            // 
            this.pistaBox.BackColor = System.Drawing.Color.Transparent;
            this.pistaBox.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.pista12;
            this.pistaBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pistaBox.Location = new System.Drawing.Point(649, 525);
            this.pistaBox.Name = "pistaBox";
            this.pistaBox.Size = new System.Drawing.Size(235, 191);
            this.pistaBox.TabIndex = 8;
            this.pistaBox.TabStop = false;
            // 
            // enviarRespuesta
            // 
            this.enviarRespuesta.BackColor = System.Drawing.Color.Transparent;
            this.enviarRespuesta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enviarRespuesta.Location = new System.Drawing.Point(537, 127);
            this.enviarRespuesta.Name = "enviarRespuesta";
            this.enviarRespuesta.Size = new System.Drawing.Size(50, 50);
            this.enviarRespuesta.TabIndex = 9;
            this.enviarRespuesta.TabStop = false;
            this.enviarRespuesta.Click += new System.EventHandler(this.enviarRespuesta_Click);
            this.enviarRespuesta.MouseEnter += new System.EventHandler(this.enviarRespuesta_MouseEnter);
            this.enviarRespuesta.MouseLeave += new System.EventHandler(this.enviarRespuesta_MouseLeave);
            // 
            // botonEncontrado
            // 
            this.botonEncontrado.BackColor = System.Drawing.Color.Transparent;
            this.botonEncontrado.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.uy;
            this.botonEncontrado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonEncontrado.Location = new System.Drawing.Point(410, 12);
            this.botonEncontrado.Name = "botonEncontrado";
            this.botonEncontrado.Size = new System.Drawing.Size(125, 127);
            this.botonEncontrado.TabIndex = 10;
            this.botonEncontrado.TabStop = false;
            // 
            // sonidoBox
            // 
            this.sonidoBox.BackColor = System.Drawing.Color.Transparent;
            this.sonidoBox.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.sonido;
            this.sonidoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sonidoBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sonidoBox.Location = new System.Drawing.Point(715, 718);
            this.sonidoBox.Name = "sonidoBox";
            this.sonidoBox.Size = new System.Drawing.Size(40, 40);
            this.sonidoBox.TabIndex = 11;
            this.sonidoBox.TabStop = false;
            this.sonidoBox.Click += new System.EventHandler(this.sonidoBox_Click);
            // 
            // PantallaUno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.PantallaUno4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1438, 759);
            this.Controls.Add(this.sonidoBox);
            this.Controls.Add(this.botonEncontrado);
            this.Controls.Add(this.enviarRespuesta);
            this.Controls.Add(this.pistaBox);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.vidasLabel);
            this.Controls.Add(this.respuestaBox);
            this.Controls.Add(this.chatGrid);
            this.Controls.Add(this.botonEnviar);
            this.Controls.Add(this.textChat);
            this.Name = "PantallaUno";
            this.Text = "PantallaUno";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PantallaUno_FormClosing);
            this.Load += new System.EventHandler(this.PantallaUno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chatGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pistaBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enviarRespuesta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.botonEncontrado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sonidoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textChat;
        private System.Windows.Forms.Button botonEnviar;
        private System.Windows.Forms.DataGridView chatGrid;
        private System.Windows.Forms.TextBox respuestaBox;
        private System.Windows.Forms.Label vidasLabel;
        private System.Windows.Forms.PictureBox infoBox;
        private System.Windows.Forms.PictureBox pistaBox;
        private System.Windows.Forms.PictureBox enviarRespuesta;
        private System.Windows.Forms.PictureBox botonEncontrado;
        private System.Windows.Forms.PictureBox sonidoBox; 
    }
}