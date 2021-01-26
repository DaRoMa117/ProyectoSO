namespace WindowsFormsApplication1
{
    partial class PantallaFinal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaFinal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.playBox = new System.Windows.Forms.PictureBox();
            this.stopBox = new System.Windows.Forms.PictureBox();
            this.chatGrid = new System.Windows.Forms.DataGridView();
            this.textChat = new System.Windows.Forms.TextBox();
            this.botonEnviar = new System.Windows.Forms.Button();
            this.vidasLabel = new System.Windows.Forms.Label();
            this.pasoUno = new System.Windows.Forms.CheckBox();
            this.pasoDos = new System.Windows.Forms.CheckBox();
            this.pasoTres = new System.Windows.Forms.CheckBox();
            this.pasoCuatro = new System.Windows.Forms.CheckBox();
            this.pasoCinco = new System.Windows.Forms.CheckBox();
            this.botonResolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(47, 149);
            this.player.MaximumSize = new System.Drawing.Size(480, 270);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(480, 270);
            this.player.TabIndex = 0;
            // 
            // playBox
            // 
            this.playBox.BackColor = System.Drawing.Color.Transparent;
            this.playBox.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.play_pause;
            this.playBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playBox.Location = new System.Drawing.Point(205, 466);
            this.playBox.Name = "playBox";
            this.playBox.Size = new System.Drawing.Size(75, 75);
            this.playBox.TabIndex = 1;
            this.playBox.TabStop = false;
            this.playBox.Click += new System.EventHandler(this.playBox_Click);
            // 
            // stopBox
            // 
            this.stopBox.BackColor = System.Drawing.Color.Transparent;
            this.stopBox.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.stop;
            this.stopBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stopBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopBox.Location = new System.Drawing.Point(300, 466);
            this.stopBox.Name = "stopBox";
            this.stopBox.Size = new System.Drawing.Size(75, 75);
            this.stopBox.TabIndex = 2;
            this.stopBox.TabStop = false;
            this.stopBox.Click += new System.EventHandler(this.stopBox_Click);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.chatGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.chatGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.chatGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.chatGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.chatGrid.Location = new System.Drawing.Point(893, 138);
            this.chatGrid.Name = "chatGrid";
            this.chatGrid.ReadOnly = true;
            this.chatGrid.RowHeadersVisible = false;
            this.chatGrid.RowTemplate.Height = 24;
            this.chatGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chatGrid.Size = new System.Drawing.Size(240, 313);
            this.chatGrid.TabIndex = 3;
            // 
            // textChat
            // 
            this.textChat.Location = new System.Drawing.Point(893, 475);
            this.textChat.Name = "textChat";
            this.textChat.Size = new System.Drawing.Size(240, 22);
            this.textChat.TabIndex = 4;
            // 
            // botonEnviar
            // 
            this.botonEnviar.BackColor = System.Drawing.Color.White;
            this.botonEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonEnviar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botonEnviar.FlatAppearance.BorderSize = 5;
            this.botonEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonEnviar.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEnviar.Location = new System.Drawing.Point(970, 520);
            this.botonEnviar.Name = "botonEnviar";
            this.botonEnviar.Size = new System.Drawing.Size(100, 50);
            this.botonEnviar.TabIndex = 5;
            this.botonEnviar.Text = "ENVIAR";
            this.botonEnviar.UseVisualStyleBackColor = false;
            this.botonEnviar.Click += new System.EventHandler(this.botonEnviar_Click);
            // 
            // vidasLabel
            // 
            this.vidasLabel.AutoSize = true;
            this.vidasLabel.BackColor = System.Drawing.Color.Transparent;
            this.vidasLabel.Font = new System.Drawing.Font("Courier New", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vidasLabel.Location = new System.Drawing.Point(915, 22);
            this.vidasLabel.Name = "vidasLabel";
            this.vidasLabel.Size = new System.Drawing.Size(0, 37);
            this.vidasLabel.TabIndex = 6;
            this.vidasLabel.Tag = "";
            this.vidasLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pasoUno
            // 
            this.pasoUno.BackColor = System.Drawing.Color.Transparent;
            this.pasoUno.Font = new System.Drawing.Font("Courier New", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pasoUno.Location = new System.Drawing.Point(630, 140);
            this.pasoUno.Name = "pasoUno";
            this.pasoUno.Size = new System.Drawing.Size(175, 50);
            this.pasoUno.TabIndex = 7;
            this.pasoUno.Text = "PASO 1";
            this.pasoUno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pasoUno.UseVisualStyleBackColor = false;
            this.pasoUno.CheckedChanged += new System.EventHandler(this.pasoUno_CheckedChanged);
            // 
            // pasoDos
            // 
            this.pasoDos.BackColor = System.Drawing.Color.Transparent;
            this.pasoDos.Font = new System.Drawing.Font("Courier New", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pasoDos.Location = new System.Drawing.Point(630, 210);
            this.pasoDos.Name = "pasoDos";
            this.pasoDos.Size = new System.Drawing.Size(175, 50);
            this.pasoDos.TabIndex = 8;
            this.pasoDos.Text = "PASO 2";
            this.pasoDos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pasoDos.UseVisualStyleBackColor = false;
            this.pasoDos.CheckedChanged += new System.EventHandler(this.pasoDos_CheckedChanged);
            // 
            // pasoTres
            // 
            this.pasoTres.BackColor = System.Drawing.Color.Transparent;
            this.pasoTres.Font = new System.Drawing.Font("Courier New", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pasoTres.Location = new System.Drawing.Point(630, 280);
            this.pasoTres.Name = "pasoTres";
            this.pasoTres.Size = new System.Drawing.Size(175, 50);
            this.pasoTres.TabIndex = 9;
            this.pasoTres.Text = "PASO 3";
            this.pasoTres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pasoTres.UseVisualStyleBackColor = false;
            this.pasoTres.CheckedChanged += new System.EventHandler(this.pasoTres_CheckedChanged);
            // 
            // pasoCuatro
            // 
            this.pasoCuatro.BackColor = System.Drawing.Color.Transparent;
            this.pasoCuatro.Font = new System.Drawing.Font("Courier New", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pasoCuatro.Location = new System.Drawing.Point(630, 350);
            this.pasoCuatro.Name = "pasoCuatro";
            this.pasoCuatro.Size = new System.Drawing.Size(175, 50);
            this.pasoCuatro.TabIndex = 10;
            this.pasoCuatro.Text = "PASO 4";
            this.pasoCuatro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pasoCuatro.UseVisualStyleBackColor = false;
            this.pasoCuatro.CheckedChanged += new System.EventHandler(this.pasoCuatro_CheckedChanged);
            // 
            // pasoCinco
            // 
            this.pasoCinco.BackColor = System.Drawing.Color.Transparent;
            this.pasoCinco.Font = new System.Drawing.Font("Courier New", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pasoCinco.Location = new System.Drawing.Point(630, 420);
            this.pasoCinco.Name = "pasoCinco";
            this.pasoCinco.Size = new System.Drawing.Size(175, 50);
            this.pasoCinco.TabIndex = 11;
            this.pasoCinco.Text = "PASO 5";
            this.pasoCinco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pasoCinco.UseVisualStyleBackColor = false;
            this.pasoCinco.CheckedChanged += new System.EventHandler(this.pasoCinco_CheckedChanged);
            // 
            // botonResolver
            // 
            this.botonResolver.BackColor = System.Drawing.Color.White;
            this.botonResolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonResolver.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botonResolver.FlatAppearance.BorderSize = 5;
            this.botonResolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonResolver.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonResolver.ForeColor = System.Drawing.Color.Black;
            this.botonResolver.Location = new System.Drawing.Point(651, 476);
            this.botonResolver.Name = "botonResolver";
            this.botonResolver.Size = new System.Drawing.Size(130, 50);
            this.botonResolver.TabIndex = 12;
            this.botonResolver.Text = "RESOLVER";
            this.botonResolver.UseVisualStyleBackColor = false;
            this.botonResolver.Click += new System.EventHandler(this.botonResolver_Click);
            // 
            // PantallaFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.PantallaFinal2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1145, 589);
            this.Controls.Add(this.botonResolver);
            this.Controls.Add(this.pasoCinco);
            this.Controls.Add(this.pasoCuatro);
            this.Controls.Add(this.pasoTres);
            this.Controls.Add(this.pasoDos);
            this.Controls.Add(this.pasoUno);
            this.Controls.Add(this.vidasLabel);
            this.Controls.Add(this.botonEnviar);
            this.Controls.Add(this.textChat);
            this.Controls.Add(this.chatGrid);
            this.Controls.Add(this.stopBox);
            this.Controls.Add(this.playBox);
            this.Controls.Add(this.player);
            this.Name = "PantallaFinal";
            this.Text = "PantallaFinal";
            this.Load += new System.EventHandler(this.PantallaFinal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer player;
        private System.Windows.Forms.PictureBox playBox;
        private System.Windows.Forms.PictureBox stopBox;
        private System.Windows.Forms.DataGridView chatGrid;
        private System.Windows.Forms.TextBox textChat;
        private System.Windows.Forms.Button botonEnviar;
        private System.Windows.Forms.Label vidasLabel;
        private System.Windows.Forms.CheckBox pasoUno;
        private System.Windows.Forms.CheckBox pasoDos;
        private System.Windows.Forms.CheckBox pasoTres;
        private System.Windows.Forms.CheckBox pasoCuatro;
        private System.Windows.Forms.CheckBox pasoCinco;
        private System.Windows.Forms.Button botonResolver;
    }
}