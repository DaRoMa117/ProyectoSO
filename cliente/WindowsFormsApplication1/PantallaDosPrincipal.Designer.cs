namespace WindowsFormsApplication1
{
    partial class PantallaDosPrincipal
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
            this.chatGrid = new System.Windows.Forms.DataGridView();
            this.textChat = new System.Windows.Forms.TextBox();
            this.botonEnviar = new System.Windows.Forms.Button();
            this.abrirPantallas = new System.Windows.Forms.PictureBox();
            this.botonEncontrado = new System.Windows.Forms.PictureBox();
            this.pistaEncontrada = new System.Windows.Forms.PictureBox();
            this.pistaBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chatGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abrirPantallas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.botonEncontrado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pistaEncontrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pistaBox)).BeginInit();
            this.SuspendLayout();
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.chatGrid.Location = new System.Drawing.Point(1181, 103);
            this.chatGrid.Name = "chatGrid";
            this.chatGrid.ReadOnly = true;
            this.chatGrid.RowHeadersVisible = false;
            this.chatGrid.RowTemplate.Height = 24;
            this.chatGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chatGrid.Size = new System.Drawing.Size(253, 502);
            this.chatGrid.TabIndex = 0;
            // 
            // textChat
            // 
            this.textChat.Location = new System.Drawing.Point(1181, 615);
            this.textChat.Name = "textChat";
            this.textChat.Size = new System.Drawing.Size(253, 22);
            this.textChat.TabIndex = 2;
            // 
            // botonEnviar
            // 
            this.botonEnviar.BackColor = System.Drawing.Color.White;
            this.botonEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonEnviar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botonEnviar.FlatAppearance.BorderSize = 5;
            this.botonEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonEnviar.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEnviar.Location = new System.Drawing.Point(1258, 660);
            this.botonEnviar.Name = "botonEnviar";
            this.botonEnviar.Size = new System.Drawing.Size(100, 50);
            this.botonEnviar.TabIndex = 3;
            this.botonEnviar.Text = "ENVIAR";
            this.botonEnviar.UseVisualStyleBackColor = false;
            this.botonEnviar.Click += new System.EventHandler(this.botonEnviar_Click);
            // 
            // abrirPantallas
            // 
            this.abrirPantallas.BackColor = System.Drawing.Color.Transparent;
            this.abrirPantallas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.abrirPantallas.Location = new System.Drawing.Point(738, 191);
            this.abrirPantallas.Name = "abrirPantallas";
            this.abrirPantallas.Size = new System.Drawing.Size(30, 30);
            this.abrirPantallas.TabIndex = 4;
            this.abrirPantallas.TabStop = false;
            this.abrirPantallas.Click += new System.EventHandler(this.abrirPantallas_Click);
            this.abrirPantallas.MouseEnter += new System.EventHandler(this.abrirPantallas_MouseEnter);
            this.abrirPantallas.MouseLeave += new System.EventHandler(this.abrirPantallas_MouseLeave);
            // 
            // botonEncontrado
            // 
            this.botonEncontrado.BackColor = System.Drawing.Color.Transparent;
            this.botonEncontrado.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.brillo;
            this.botonEncontrado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonEncontrado.Location = new System.Drawing.Point(614, 85);
            this.botonEncontrado.Name = "botonEncontrado";
            this.botonEncontrado.Size = new System.Drawing.Size(132, 115);
            this.botonEncontrado.TabIndex = 5;
            this.botonEncontrado.TabStop = false;
            // 
            // pistaEncontrada
            // 
            this.pistaEncontrada.BackColor = System.Drawing.Color.Transparent;
            this.pistaEncontrada.Location = new System.Drawing.Point(713, 567);
            this.pistaEncontrada.Name = "pistaEncontrada";
            this.pistaEncontrada.Size = new System.Drawing.Size(75, 75);
            this.pistaEncontrada.TabIndex = 6;
            this.pistaEncontrada.TabStop = false;
            this.pistaEncontrada.MouseEnter += new System.EventHandler(this.pistaEncontrada_MouseEnter);
            this.pistaEncontrada.MouseLeave += new System.EventHandler(this.pistaEncontrada_MouseLeave);
            // 
            // pistaBox
            // 
            this.pistaBox.BackColor = System.Drawing.Color.Transparent;
            this.pistaBox.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.pista2;
            this.pistaBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pistaBox.Location = new System.Drawing.Point(767, 311);
            this.pistaBox.Name = "pistaBox";
            this.pistaBox.Size = new System.Drawing.Size(275, 250);
            this.pistaBox.TabIndex = 7;
            this.pistaBox.TabStop = false;
            // 
            // PantallaDosPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.PantallaDosPrincipal;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1446, 730);
            this.Controls.Add(this.pistaBox);
            this.Controls.Add(this.pistaEncontrada);
            this.Controls.Add(this.botonEncontrado);
            this.Controls.Add(this.abrirPantallas);
            this.Controls.Add(this.botonEnviar);
            this.Controls.Add(this.textChat);
            this.Controls.Add(this.chatGrid);
            this.Name = "PantallaDosPrincipal";
            this.Text = "PantallaDosPrincipal";
            this.Load += new System.EventHandler(this.PantallaDosPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chatGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abrirPantallas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.botonEncontrado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pistaEncontrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pistaBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView chatGrid;
        private System.Windows.Forms.TextBox textChat;
        private System.Windows.Forms.Button botonEnviar;
        private System.Windows.Forms.PictureBox abrirPantallas;
        private System.Windows.Forms.PictureBox botonEncontrado;
        private System.Windows.Forms.PictureBox pistaEncontrada;
        private System.Windows.Forms.PictureBox pistaBox;
    }
}