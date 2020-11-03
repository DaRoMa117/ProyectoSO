namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.usuarioRegistrar = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonIniciar = new System.Windows.Forms.Button();
            this.botonRegistro = new System.Windows.Forms.Button();
            this.ContraseñaFecha = new System.Windows.Forms.TextBox();
            this.UsuarioPerdidas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.contrasenaIniciar = new System.Windows.Forms.TextBox();
            this.usuarioIniciar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FechaContraseña = new System.Windows.Forms.RadioButton();
            this.contraseñaRegistrar = new System.Windows.Forms.TextBox();
            this.PartidasPerdidas = new System.Windows.Forms.RadioButton();
            this.mas1hora = new System.Windows.Forms.RadioButton();
            this.conectar = new System.Windows.Forms.Button();
            this.desconectar = new System.Windows.Forms.Button();
            this.dameConectados = new System.Windows.Forms.Button();
            this.conectadosLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Registrar";
            // 
            // usuarioRegistrar
            // 
            this.usuarioRegistrar.Location = new System.Drawing.Point(155, 91);
            this.usuarioRegistrar.Margin = new System.Windows.Forms.Padding(4);
            this.usuarioRegistrar.Name = "usuarioRegistrar";
            this.usuarioRegistrar.Size = new System.Drawing.Size(178, 19);
            this.usuarioRegistrar.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(37, 454);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.botonIniciar);
            this.groupBox1.Controls.Add(this.botonRegistro);
            this.groupBox1.Controls.Add(this.ContraseñaFecha);
            this.groupBox1.Controls.Add(this.UsuarioPerdidas);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.contrasenaIniciar);
            this.groupBox1.Controls.Add(this.usuarioIniciar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FechaContraseña);
            this.groupBox1.Controls.Add(this.contraseñaRegistrar);
            this.groupBox1.Controls.Add(this.PartidasPerdidas);
            this.groupBox1.Controls.Add(this.mas1hora);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.usuarioRegistrar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 89);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(834, 521);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            // 
            // botonIniciar
            // 
            this.botonIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonIniciar.Location = new System.Drawing.Point(600, 213);
            this.botonIniciar.Margin = new System.Windows.Forms.Padding(4);
            this.botonIniciar.Name = "botonIniciar";
            this.botonIniciar.Size = new System.Drawing.Size(125, 28);
            this.botonIniciar.TabIndex = 23;
            this.botonIniciar.Text = "Iniciar sesión";
            this.botonIniciar.UseVisualStyleBackColor = true;
            this.botonIniciar.Click += new System.EventHandler(this.botonIniciar_Click);
            // 
            // botonRegistro
            // 
            this.botonRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRegistro.Location = new System.Drawing.Point(155, 213);
            this.botonRegistro.Margin = new System.Windows.Forms.Padding(4);
            this.botonRegistro.Name = "botonRegistro";
            this.botonRegistro.Size = new System.Drawing.Size(115, 28);
            this.botonRegistro.TabIndex = 22;
            this.botonRegistro.Text = "Registrarme";
            this.botonRegistro.UseVisualStyleBackColor = true;
            this.botonRegistro.Click += new System.EventHandler(this.botonRegistro_Click);
            // 
            // ContraseñaFecha
            // 
            this.ContraseñaFecha.Location = new System.Drawing.Point(516, 404);
            this.ContraseñaFecha.Margin = new System.Windows.Forms.Padding(4);
            this.ContraseñaFecha.Name = "ContraseñaFecha";
            this.ContraseñaFecha.Size = new System.Drawing.Size(178, 19);
            this.ContraseñaFecha.TabIndex = 21;
            // 
            // UsuarioPerdidas
            // 
            this.UsuarioPerdidas.Location = new System.Drawing.Point(355, 353);
            this.UsuarioPerdidas.Margin = new System.Windows.Forms.Padding(4);
            this.UsuarioPerdidas.Name = "UsuarioPerdidas";
            this.UsuarioPerdidas.Size = new System.Drawing.Size(178, 19);
            this.UsuarioPerdidas.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(475, 160);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Contraseña";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(507, 93);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Usuario";
            // 
            // contrasenaIniciar
            // 
            this.contrasenaIniciar.Location = new System.Drawing.Point(600, 160);
            this.contrasenaIniciar.Name = "contrasenaIniciar";
            this.contrasenaIniciar.Size = new System.Drawing.Size(178, 19);
            this.contrasenaIniciar.TabIndex = 17;
            // 
            // usuarioIniciar
            // 
            this.usuarioIniciar.Location = new System.Drawing.Point(600, 93);
            this.usuarioIniciar.Margin = new System.Windows.Forms.Padding(4);
            this.usuarioIniciar.Name = "usuarioIniciar";
            this.usuarioIniciar.Size = new System.Drawing.Size(178, 19);
            this.usuarioIniciar.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 156);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(473, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "Iniciar sesión";
            // 
            // FechaContraseña
            // 
            this.FechaContraseña.AutoSize = true;
            this.FechaContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaContraseña.Location = new System.Drawing.Point(37, 400);
            this.FechaContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.FechaContraseña.Name = "FechaContraseña";
            this.FechaContraseña.Size = new System.Drawing.Size(471, 24);
            this.FechaContraseña.TabIndex = 10;
            this.FechaContraseña.TabStop = true;
            this.FechaContraseña.Text = "Dime fecha y hora del jugador que tenga como contraseña:";
            this.FechaContraseña.UseVisualStyleBackColor = true;
            // 
            // contraseñaRegistrar
            // 
            this.contraseñaRegistrar.Location = new System.Drawing.Point(155, 158);
            this.contraseñaRegistrar.Name = "contraseñaRegistrar";
            this.contraseñaRegistrar.Size = new System.Drawing.Size(178, 19);
            this.contraseñaRegistrar.TabIndex = 9;
            // 
            // PartidasPerdidas
            // 
            this.PartidasPerdidas.AutoSize = true;
            this.PartidasPerdidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartidasPerdidas.Location = new System.Drawing.Point(37, 349);
            this.PartidasPerdidas.Margin = new System.Windows.Forms.Padding(4);
            this.PartidasPerdidas.Name = "PartidasPerdidas";
            this.PartidasPerdidas.Size = new System.Drawing.Size(310, 24);
            this.PartidasPerdidas.TabIndex = 7;
            this.PartidasPerdidas.TabStop = true;
            this.PartidasPerdidas.Text = "Dime ID de las partidas perdidas por:";
            this.PartidasPerdidas.UseVisualStyleBackColor = true;
            // 
            // mas1hora
            // 
            this.mas1hora.AutoSize = true;
            this.mas1hora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mas1hora.Location = new System.Drawing.Point(37, 301);
            this.mas1hora.Margin = new System.Windows.Forms.Padding(4);
            this.mas1hora.Name = "mas1hora";
            this.mas1hora.Size = new System.Drawing.Size(497, 24);
            this.mas1hora.TabIndex = 8;
            this.mas1hora.TabStop = true;
            this.mas1hora.Text = "Dime usuarios que hayan jugado una partida de mas de 1 hora";
            this.mas1hora.UseVisualStyleBackColor = true;
            // 
            // conectar
            // 
            this.conectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conectar.Location = new System.Drawing.Point(39, 33);
            this.conectar.Name = "conectar";
            this.conectar.Size = new System.Drawing.Size(156, 49);
            this.conectar.TabIndex = 7;
            this.conectar.Text = "CONECTAR";
            this.conectar.UseVisualStyleBackColor = true;
            this.conectar.Click += new System.EventHandler(this.conectar_Click);
            // 
            // desconectar
            // 
            this.desconectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desconectar.Location = new System.Drawing.Point(39, 617);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(156, 63);
            this.desconectar.TabIndex = 10;
            this.desconectar.Text = "DESCONECTAR";
            this.desconectar.UseVisualStyleBackColor = true;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // dameConectados
            // 
            this.dameConectados.Location = new System.Drawing.Point(912, 86);
            this.dameConectados.Name = "dameConectados";
            this.dameConectados.Size = new System.Drawing.Size(181, 71);
            this.dameConectados.TabIndex = 11;
            this.dameConectados.Text = "CONECTADOS";
            this.dameConectados.UseVisualStyleBackColor = true;
            this.dameConectados.Click += new System.EventHandler(this.dameConectados_Click);
            // 
            // conectadosLabel
            // 
            this.conectadosLabel.Location = new System.Drawing.Point(912, 194);
            this.conectadosLabel.Name = "conectadosLabel";
            this.conectadosLabel.Size = new System.Drawing.Size(181, 416);
            this.conectadosLabel.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 692);
            this.Controls.Add(this.conectadosLabel);
            this.Controls.Add(this.dameConectados);
            this.Controls.Add(this.desconectar);
            this.Controls.Add(this.conectar);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usuarioRegistrar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton PartidasPerdidas;
        private System.Windows.Forms.RadioButton mas1hora;
        private System.Windows.Forms.Button conectar;
        private System.Windows.Forms.TextBox contraseñaRegistrar;
        private System.Windows.Forms.Button desconectar;
        private System.Windows.Forms.RadioButton FechaContraseña;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox contrasenaIniciar;
        private System.Windows.Forms.TextBox usuarioIniciar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ContraseñaFecha;
        private System.Windows.Forms.TextBox UsuarioPerdidas;
        private System.Windows.Forms.Button botonIniciar;
        private System.Windows.Forms.Button botonRegistro;
        private System.Windows.Forms.Button dameConectados;
        private System.Windows.Forms.Label conectadosLabel;
    }
}

