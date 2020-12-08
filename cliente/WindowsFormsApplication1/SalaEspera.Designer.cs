namespace WindowsFormsApplication1
{
    partial class SalaEspera
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
            this.conectadosGrid = new System.Windows.Forms.DataGridView();
            this.botonInvitar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.readmeLabel = new System.Windows.Forms.Label();
            this.jugarPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.conectadosGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conectadosGrid
            // 
            this.conectadosGrid.AllowUserToAddRows = false;
            this.conectadosGrid.AllowUserToDeleteRows = false;
            this.conectadosGrid.AllowUserToResizeColumns = false;
            this.conectadosGrid.AllowUserToResizeRows = false;
            this.conectadosGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.conectadosGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(181)))), ((int)(((byte)(126)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(181)))), ((int)(((byte)(126)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.conectadosGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.conectadosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(181)))), ((int)(((byte)(126)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.conectadosGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.conectadosGrid.Location = new System.Drawing.Point(474, 150);
            this.conectadosGrid.Name = "conectadosGrid";
            this.conectadosGrid.ReadOnly = true;
            this.conectadosGrid.RowHeadersVisible = false;
            this.conectadosGrid.RowTemplate.Height = 28;
            this.conectadosGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.conectadosGrid.Size = new System.Drawing.Size(169, 158);
            this.conectadosGrid.TabIndex = 0;
            // 
            // botonInvitar
            // 
            this.botonInvitar.Location = new System.Drawing.Point(514, 313);
            this.botonInvitar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonInvitar.Name = "botonInvitar";
            this.botonInvitar.Size = new System.Drawing.Size(82, 25);
            this.botonInvitar.TabIndex = 1;
            this.botonInvitar.Text = "Invitar";
            this.botonInvitar.UseVisualStyleBackColor = true;
            this.botonInvitar.Click += new System.EventHandler(this.botonInvitar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.papel;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.readmeLabel);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(672, 181);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 99);
            this.panel1.TabIndex = 2;
            // 
            // readmeLabel
            // 
            this.readmeLabel.AutoSize = true;
            this.readmeLabel.Font = new System.Drawing.Font("MV Boli", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readmeLabel.Location = new System.Drawing.Point(48, 10);
            this.readmeLabel.Name = "readmeLabel";
            this.readmeLabel.Size = new System.Drawing.Size(250, 79);
            this.readmeLabel.TabIndex = 0;
            this.readmeLabel.Text = "Readme";
            this.readmeLabel.Click += new System.EventHandler(this.readmeLabel_Click);
            // 
            // jugarPanel
            // 
            this.jugarPanel.BackColor = System.Drawing.Color.Transparent;
            this.jugarPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jugarPanel.Location = new System.Drawing.Point(189, 122);
            this.jugarPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jugarPanel.Name = "jugarPanel";
            this.jugarPanel.Size = new System.Drawing.Size(94, 34);
            this.jugarPanel.TabIndex = 3;
            // 
            // SalaEspera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.escape_room_en_casa_696x392;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1060, 517);
            this.Controls.Add(this.jugarPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botonInvitar);
            this.Controls.Add(this.conectadosGrid);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SalaEspera";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.SalaEspera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.conectadosGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView conectadosGrid;
        private System.Windows.Forms.Button botonInvitar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label readmeLabel;
        private System.Windows.Forms.Panel jugarPanel;
    }
}