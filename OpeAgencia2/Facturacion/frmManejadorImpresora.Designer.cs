namespace OpeAgencia2.Facturacion
{
    partial class frmManejadorImpresora
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtModoOperacion = new System.Windows.Forms.TextBox();
            this.txtModeloImpresora = new System.Windows.Forms.TextBox();
            this.txtNombreImpresora = new System.Windows.Forms.TextBox();
            this.lblPuerto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtModoOperacion
            // 
            this.txtModoOperacion.Location = new System.Drawing.Point(107, 53);
            this.txtModoOperacion.Name = "txtModoOperacion";
            this.txtModoOperacion.Size = new System.Drawing.Size(170, 20);
            this.txtModoOperacion.TabIndex = 1;
            // 
            // txtModeloImpresora
            // 
            this.txtModeloImpresora.Location = new System.Drawing.Point(107, 79);
            this.txtModeloImpresora.Name = "txtModeloImpresora";
            this.txtModeloImpresora.Size = new System.Drawing.Size(170, 20);
            this.txtModeloImpresora.TabIndex = 2;
            // 
            // txtNombreImpresora
            // 
            this.txtNombreImpresora.Location = new System.Drawing.Point(107, 105);
            this.txtNombreImpresora.Name = "txtNombreImpresora";
            this.txtNombreImpresora.Size = new System.Drawing.Size(170, 20);
            this.txtNombreImpresora.TabIndex = 3;
            // 
            // lblPuerto
            // 
            this.lblPuerto.Location = new System.Drawing.Point(107, 134);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(170, 20);
            this.lblPuerto.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Modo Operacion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Modelo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Puerto";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(104, 29);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(13, 13);
            this.lblEstado.TabIndex = 9;
            this.lblEstado.Text = "[]";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(12, 165);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 10;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // frmManejadorImpresora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 439);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPuerto);
            this.Controls.Add(this.txtNombreImpresora);
            this.Controls.Add(this.txtModeloImpresora);
            this.Controls.Add(this.txtModoOperacion);
            this.Controls.Add(this.button1);
            this.Name = "frmManejadorImpresora";
            this.Text = "frmManejadorImpresora";
            this.Load += new System.EventHandler(this.frmManejadorImpresora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtModoOperacion;
        private System.Windows.Forms.TextBox txtModeloImpresora;
        private System.Windows.Forms.TextBox txtNombreImpresora;
        private System.Windows.Forms.TextBox lblPuerto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnDisconnect;
    }
}