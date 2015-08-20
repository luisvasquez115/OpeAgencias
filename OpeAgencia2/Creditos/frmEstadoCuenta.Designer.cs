namespace OpeAgencia2.Creditos
{
    partial class frmEstadoCuenta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEpsHasta = new System.Windows.Forms.Label();
            this.lblEps = new System.Windows.Forms.Label();
            this.txtEpsHasta = new System.Windows.Forms.TextBox();
            this.txtEpsDesde = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "GENERACIÓN DE ESTADOS DE CUENTAS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEpsHasta);
            this.groupBox1.Controls.Add(this.lblEps);
            this.groupBox1.Controls.Add(this.txtEpsHasta);
            this.groupBox1.Controls.Add(this.txtEpsDesde);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 66);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lblEpsHasta
            // 
            this.lblEpsHasta.AutoSize = true;
            this.lblEpsHasta.Location = new System.Drawing.Point(261, 42);
            this.lblEpsHasta.Name = "lblEpsHasta";
            this.lblEpsHasta.Size = new System.Drawing.Size(35, 13);
            this.lblEpsHasta.TabIndex = 5;
            this.lblEpsHasta.Text = "label5";
            // 
            // lblEps
            // 
            this.lblEps.AutoSize = true;
            this.lblEps.Location = new System.Drawing.Point(78, 42);
            this.lblEps.Name = "lblEps";
            this.lblEps.Size = new System.Drawing.Size(28, 13);
            this.lblEps.TabIndex = 4;
            this.lblEps.Text = "EPS";
            // 
            // txtEpsHasta
            // 
            this.txtEpsHasta.Location = new System.Drawing.Point(264, 19);
            this.txtEpsHasta.Name = "txtEpsHasta";
            this.txtEpsHasta.Size = new System.Drawing.Size(100, 20);
            this.txtEpsHasta.TabIndex = 3;
            this.txtEpsHasta.Leave += new System.EventHandler(this.txtEpsHasta_Leave);
            // 
            // txtEpsDesde
            // 
            this.txtEpsDesde.Location = new System.Drawing.Point(81, 19);
            this.txtEpsDesde.Name = "txtEpsDesde";
            this.txtEpsDesde.Size = new System.Drawing.Size(100, 20);
            this.txtEpsDesde.TabIndex = 2;
            this.txtEpsDesde.Leave += new System.EventHandler(this.txtEpsDesde_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Hasta EPS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Desde EPS:";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(118, 104);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(199, 104);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmEstadoCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 140);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmEstadoCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estado de cuenta";
            this.Load += new System.EventHandler(this.frmEstadoCuenta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblEpsHasta;
        private System.Windows.Forms.Label lblEps;
        private System.Windows.Forms.TextBox txtEpsHasta;
        private System.Windows.Forms.TextBox txtEpsDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}