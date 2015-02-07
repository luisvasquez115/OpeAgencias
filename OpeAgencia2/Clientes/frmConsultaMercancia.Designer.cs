namespace OpeAgencia2.Clientes
{
    partial class frmConsultaMercancia
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGenerales = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTracking = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigoBarra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGuiaMadre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEPS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dg = new System.Windows.Forms.DataGridView();
            this.tabTransacc = new System.Windows.Forms.TabPage();
            this.tabReclamo = new System.Windows.Forms.TabPage();
            this.tabAudit = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGenerales);
            this.tabControl1.Controls.Add(this.tabTransacc);
            this.tabControl1.Controls.Add(this.tabReclamo);
            this.tabControl1.Controls.Add(this.tabAudit);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(678, 488);
            this.tabControl1.TabIndex = 0;
            // 
            // tabGenerales
            // 
            this.tabGenerales.Controls.Add(this.splitContainer1);
            this.tabGenerales.Location = new System.Drawing.Point(4, 22);
            this.tabGenerales.Name = "tabGenerales";
            this.tabGenerales.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerales.Size = new System.Drawing.Size(670, 462);
            this.tabGenerales.TabIndex = 0;
            this.tabGenerales.Text = "Generales";
            this.tabGenerales.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dg);
            this.splitContainer1.Size = new System.Drawing.Size(664, 456);
            this.splitContainer1.SplitterDistance = 142;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTracking);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCodigoBarra);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtGuiaMadre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEPS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(483, 79);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(402, 79);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 10;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Recibida",
            "Entregada",
            "Fuera de inventario"});
            this.cmbEstado.Location = new System.Drawing.Point(351, 45);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(207, 21);
            this.cmbEstado.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Estatus:";
            // 
            // txtTracking
            // 
            this.txtTracking.Location = new System.Drawing.Point(351, 19);
            this.txtTracking.Name = "txtTracking";
            this.txtTracking.Size = new System.Drawing.Size(207, 20);
            this.txtTracking.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tracking Number:";
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.Location = new System.Drawing.Point(111, 76);
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Size = new System.Drawing.Size(117, 20);
            this.txtCodigoBarra.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Código barra:";
            // 
            // txtGuiaMadre
            // 
            this.txtGuiaMadre.Location = new System.Drawing.Point(111, 50);
            this.txtGuiaMadre.Name = "txtGuiaMadre";
            this.txtGuiaMadre.Size = new System.Drawing.Size(117, 20);
            this.txtGuiaMadre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Guía madre:";
            // 
            // txtEPS
            // 
            this.txtEPS.Location = new System.Drawing.Point(111, 24);
            this.txtEPS.Name = "txtEPS";
            this.txtEPS.Size = new System.Drawing.Size(117, 20);
            this.txtEPS.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "EPS:";
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg.Location = new System.Drawing.Point(0, 0);
            this.dg.Name = "dg";
            this.dg.ReadOnly = true;
            this.dg.Size = new System.Drawing.Size(664, 310);
            this.dg.TabIndex = 0;
            this.dg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellContentClick);
            this.dg.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dg_DataBindingComplete);
            // 
            // tabTransacc
            // 
            this.tabTransacc.Location = new System.Drawing.Point(4, 22);
            this.tabTransacc.Name = "tabTransacc";
            this.tabTransacc.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransacc.Size = new System.Drawing.Size(670, 462);
            this.tabTransacc.TabIndex = 1;
            this.tabTransacc.Text = "Transacciones";
            this.tabTransacc.UseVisualStyleBackColor = true;
            // 
            // tabReclamo
            // 
            this.tabReclamo.Location = new System.Drawing.Point(4, 22);
            this.tabReclamo.Name = "tabReclamo";
            this.tabReclamo.Padding = new System.Windows.Forms.Padding(3);
            this.tabReclamo.Size = new System.Drawing.Size(670, 462);
            this.tabReclamo.TabIndex = 2;
            this.tabReclamo.Text = "Reclamaciones";
            this.tabReclamo.UseVisualStyleBackColor = true;
            // 
            // tabAudit
            // 
            this.tabAudit.Location = new System.Drawing.Point(4, 22);
            this.tabAudit.Name = "tabAudit";
            this.tabAudit.Padding = new System.Windows.Forms.Padding(3);
            this.tabAudit.Size = new System.Drawing.Size(670, 462);
            this.tabAudit.TabIndex = 3;
            this.tabAudit.Text = "Auditoria";
            this.tabAudit.UseVisualStyleBackColor = true;
            // 
            // frmConsultaMercancia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 488);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmConsultaMercancia";
            this.Text = "frmConsultaMercancia";
            this.Load += new System.EventHandler(this.frmConsultaMercancia_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGenerales.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGenerales;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabTransacc;
        private System.Windows.Forms.TabPage tabReclamo;
        private System.Windows.Forms.TabPage tabAudit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCodigoBarra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGuiaMadre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEPS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTracking;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dg;
    }
}