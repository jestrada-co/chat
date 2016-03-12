namespace Chat
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPuertoServidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConversacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtPuertoCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtIPCliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP No";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(53, 9);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 0;
            // 
            // txtPuertoServidor
            // 
            this.txtPuertoServidor.Location = new System.Drawing.Point(98, 35);
            this.txtPuertoServidor.Name = "txtPuertoServidor";
            this.txtPuertoServidor.Size = new System.Drawing.Size(55, 20);
            this.txtPuertoServidor.TabIndex = 1;
            this.txtPuertoServidor.Text = "9001";
            this.txtPuertoServidor.TextChanged += new System.EventHandler(this.txtPuertoServidor_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Puerto Servidor";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(15, 139);
            this.btnConectar.Margin = new System.Windows.Forms.Padding(1);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(138, 23);
            this.btnConectar.TabIndex = 5;
            this.btnConectar.Text = "Iniciar Servidor";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txtNick
            // 
            this.txtNick.Location = new System.Drawing.Point(53, 115);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(100, 20);
            this.txtNick.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nick";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(15, 477);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(394, 44);
            this.txtMensaje.TabIndex = 6;
            this.txtMensaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMensaje_KeyPress);
            this.txtMensaje.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMensaje_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 461);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mensaje";
            // 
            // txtConversacion
            // 
            this.txtConversacion.Enabled = false;
            this.txtConversacion.Location = new System.Drawing.Point(15, 185);
            this.txtConversacion.Multiline = true;
            this.txtConversacion.Name = "txtConversacion";
            this.txtConversacion.Size = new System.Drawing.Size(462, 269);
            this.txtConversacion.TabIndex = 10;
            this.txtConversacion.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Conversación";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(419, 475);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(1);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 46);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtPuertoCliente
            // 
            this.txtPuertoCliente.Location = new System.Drawing.Point(98, 89);
            this.txtPuertoCliente.Name = "txtPuertoCliente";
            this.txtPuertoCliente.Size = new System.Drawing.Size(55, 20);
            this.txtPuertoCliente.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Puerto Cliente";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(417, 9);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(1);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 46);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtIPCliente
            // 
            this.txtIPCliente.Location = new System.Drawing.Point(53, 61);
            this.txtIPCliente.Name = "txtIPCliente";
            this.txtIPCliente.Size = new System.Drawing.Size(100, 20);
            this.txtIPCliente.TabIndex = 2;
            this.txtIPCliente.TextChanged += new System.EventHandler(this.txtIPCliente_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "IP No";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 533);
            this.Controls.Add(this.txtIPCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtPuertoCliente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtConversacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNick);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txtPuertoServidor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPuertoServidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConversacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtPuertoCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtIPCliente;
        private System.Windows.Forms.Label label7;
    }
}

