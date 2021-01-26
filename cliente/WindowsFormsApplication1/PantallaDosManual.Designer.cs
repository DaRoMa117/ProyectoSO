namespace WindowsFormsApplication1
{
    partial class PantallaDosManual
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
            this.vidasLabel = new System.Windows.Forms.Label();
            this.caraEncontrada = new System.Windows.Forms.PictureBox();
            this.distraccionesBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chatGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caraEncontrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distraccionesBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textChat
            // 
            this.textChat.Location = new System.Drawing.Point(32, 625);
            this.textChat.Name = "textChat";
            this.textChat.Size = new System.Drawing.Size(240, 22);
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
            this.botonEnviar.Location = new System.Drawing.Point(100, 660);
            this.botonEnviar.Name = "botonEnviar";
            this.botonEnviar.Size = new System.Drawing.Size(100, 50);
            this.botonEnviar.TabIndex = 3;
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
            this.chatGrid.Location = new System.Drawing.Point(32, 110);
            this.chatGrid.Name = "chatGrid";
            this.chatGrid.ReadOnly = true;
            this.chatGrid.RowHeadersVisible = false;
            this.chatGrid.RowTemplate.Height = 24;
            this.chatGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chatGrid.Size = new System.Drawing.Size(240, 497);
            this.chatGrid.TabIndex = 4;
            // 
            // vidasLabel
            // 
            this.vidasLabel.AutoSize = true;
            this.vidasLabel.BackColor = System.Drawing.Color.Transparent;
            this.vidasLabel.Font = new System.Drawing.Font("Courier New", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vidasLabel.Location = new System.Drawing.Point(1051, 38);
            this.vidasLabel.Name = "vidasLabel";
            this.vidasLabel.Size = new System.Drawing.Size(0, 37);
            this.vidasLabel.TabIndex = 5;
            this.vidasLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // caraEncontrada
            // 
            this.caraEncontrada.BackColor = System.Drawing.Color.Transparent;
            this.caraEncontrada.Cursor = System.Windows.Forms.Cursors.No;
            this.caraEncontrada.Location = new System.Drawing.Point(1139, 625);
            this.caraEncontrada.Name = "caraEncontrada";
            this.caraEncontrada.Size = new System.Drawing.Size(100, 50);
            this.caraEncontrada.TabIndex = 6;
            this.caraEncontrada.TabStop = false;
            this.caraEncontrada.MouseEnter += new System.EventHandler(this.caraEncontrada_MouseEnter);
            this.caraEncontrada.MouseLeave += new System.EventHandler(this.caraEncontrada_MouseLeave);
            // 
            // distraccionesBox
            // 
            this.distraccionesBox.BackColor = System.Drawing.Color.Transparent;
            this.distraccionesBox.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.dsitracciones;
            this.distraccionesBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.distraccionesBox.Location = new System.Drawing.Point(1048, 459);
            this.distraccionesBox.Name = "distraccionesBox";
            this.distraccionesBox.Size = new System.Drawing.Size(160, 160);
            this.distraccionesBox.TabIndex = 7;
            this.distraccionesBox.TabStop = false;
            // 
            // PantallaDosManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.PantallaDosManual2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1311, 730);
            this.Controls.Add(this.distraccionesBox);
            this.Controls.Add(this.caraEncontrada);
            this.Controls.Add(this.vidasLabel);
            this.Controls.Add(this.chatGrid);
            this.Controls.Add(this.botonEnviar);
            this.Controls.Add(this.textChat);
            this.Name = "PantallaDosManual";
            this.Text = "PantallaDosManual";
            this.Load += new System.EventHandler(this.PantallaDosManual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chatGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caraEncontrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distraccionesBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textChat;
        private System.Windows.Forms.Button botonEnviar;
        private System.Windows.Forms.DataGridView chatGrid;
        private System.Windows.Forms.Label vidasLabel;
        private System.Windows.Forms.PictureBox caraEncontrada;
        private System.Windows.Forms.PictureBox distraccionesBox;
    }
}