namespace OpeAgencia2.Facturacion
{
    partial class frmFactMercancia
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoFact = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dFechaVenc = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtEPS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCorres = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabDetalle = new System.Windows.Forms.TabControl();
            this.tabPaq = new System.Windows.Forms.TabPage();
            this.dgPaq = new System.Windows.Forms.DataGridView();
            this.tabCorr = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.dgCorr = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaq = new System.Windows.Forms.TextBox();
            this.lblPaquetes = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabDetalle.SuspendLayout();
            this.tabPaq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPaq)).BeginInit();
            this.tabCorr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCorr)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipoFact);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dFechaVenc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblNombres);
            this.groupBox1.Controls.Add(this.txtEPS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbTipoFact
            // 
            this.cmbTipoFact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFact.Enabled = false;
            this.cmbTipoFact.FormattingEnabled = true;
            this.cmbTipoFact.Items.AddRange(new object[] {
            "Contado",
            "Crédito"});
            this.cmbTipoFact.Location = new System.Drawing.Point(380, 58);
            this.cmbTipoFact.Name = "cmbTipoFact";
            this.cmbTipoFact.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoFact.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tipo Fact:";
            // 
            // dFechaVenc
            // 
            this.dFechaVenc.Enabled = false;
            this.dFechaVenc.Location = new System.Drawing.Point(90, 52);
            this.dFechaVenc.Name = "dFechaVenc";
            this.dFechaVenc.Size = new System.Drawing.Size(200, 20);
            this.dFechaVenc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Venc.:";
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(196, 28);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(55, 13);
            this.lblNombres.TabIndex = 2;
            this.lblNombres.Text = "[Nombres]";
            // 
            // txtEPS
            // 
            this.txtEPS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEPS.Location = new System.Drawing.Point(90, 25);
            this.txtEPS.Name = "txtEPS";
            this.txtEPS.Size = new System.Drawing.Size(100, 20);
            this.txtEPS.TabIndex = 1;
            this.txtEPS.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtEPS.Leave += new System.EventHandler(this.txtEPS_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "EPS:";
            // 
            // btnCorres
            // 
            this.btnCorres.Location = new System.Drawing.Point(8, 5);
            this.btnCorres.Name = "btnCorres";
            this.btnCorres.Size = new System.Drawing.Size(96, 23);
            this.btnCorres.TabIndex = 5;
            this.btnCorres.Text = "Agregar";
            this.btnCorres.UseVisualStyleBackColor = true;
            this.btnCorres.Click += new System.EventHandler(this.btnCorres_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabDetalle);
            this.groupBox2.Location = new System.Drawing.Point(12, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 313);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // tabDetalle
            // 
            this.tabDetalle.Controls.Add(this.tabPaq);
            this.tabDetalle.Controls.Add(this.tabCorr);
            this.tabDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetalle.Location = new System.Drawing.Point(3, 16);
            this.tabDetalle.Name = "tabDetalle";
            this.tabDetalle.SelectedIndex = 0;
            this.tabDetalle.Size = new System.Drawing.Size(554, 294);
            this.tabDetalle.TabIndex = 0;
            // 
            // tabPaq
            // 
            this.tabPaq.Controls.Add(this.dgPaq);
            this.tabPaq.Location = new System.Drawing.Point(4, 22);
            this.tabPaq.Name = "tabPaq";
            this.tabPaq.Padding = new System.Windows.Forms.Padding(3);
            this.tabPaq.Size = new System.Drawing.Size(546, 268);
            this.tabPaq.TabIndex = 0;
            this.tabPaq.Text = "Paquetes";
            this.tabPaq.UseVisualStyleBackColor = true;
            // 
            // dgPaq
            // 
            this.dgPaq.AllowUserToAddRows = false;
            this.dgPaq.AllowUserToDeleteRows = false;
            this.dgPaq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPaq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPaq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPaq.Location = new System.Drawing.Point(3, 3);
            this.dgPaq.Name = "dgPaq";
            this.dgPaq.ReadOnly = true;
            this.dgPaq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPaq.Size = new System.Drawing.Size(540, 262);
            this.dgPaq.TabIndex = 0;
            this.dgPaq.SelectionChanged += new System.EventHandler(this.dgPaq_SelectionChanged);
            // 
            // tabCorr
            // 
            this.tabCorr.Controls.Add(this.splitContainer1);
            this.tabCorr.Location = new System.Drawing.Point(4, 22);
            this.tabCorr.Name = "tabCorr";
            this.tabCorr.Padding = new System.Windows.Forms.Padding(3);
            this.tabCorr.Size = new System.Drawing.Size(546, 268);
            this.tabCorr.TabIndex = 1;
            this.tabCorr.Text = "Correspondencia";
            this.tabCorr.UseVisualStyleBackColor = true;
            this.tabCorr.Click += new System.EventHandler(this.tabCargos_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnCorres);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgCorr);
            this.splitContainer1.Size = new System.Drawing.Size(540, 262);
            this.splitContainer1.SplitterDistance = 33;
            this.splitContainer1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dgCorr
            // 
            this.dgCorr.AllowUserToAddRows = false;
            this.dgCorr.AllowUserToDeleteRows = false;
            this.dgCorr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCorr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCorr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCorr.Location = new System.Drawing.Point(0, 0);
            this.dgCorr.Name = "dgCorr";
            this.dgCorr.ReadOnly = true;
            this.dgCorr.Size = new System.Drawing.Size(540, 225);
            this.dgCorr.TabIndex = 1;
            this.dgCorr.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCorr_CellEndEdit);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFacturar);
            this.groupBox3.Controls.Add(this.btnCancelar);
            this.groupBox3.Controls.Add(this.txtMontoTotal);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtPaq);
            this.groupBox3.Controls.Add(this.lblPaquetes);
            this.groupBox3.Location = new System.Drawing.Point(15, 428);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(550, 61);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(459, 20);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(75, 23);
            this.btnFacturar.TabIndex = 5;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(378, 20);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Enabled = false;
            this.txtMontoTotal.Location = new System.Drawing.Point(241, 20);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.Size = new System.Drawing.Size(100, 20);
            this.txtMontoTotal.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Monto:";
            // 
            // txtPaq
            // 
            this.txtPaq.Enabled = false;
            this.txtPaq.Location = new System.Drawing.Point(73, 20);
            this.txtPaq.Name = "txtPaq";
            this.txtPaq.Size = new System.Drawing.Size(100, 20);
            this.txtPaq.TabIndex = 1;
            // 
            // lblPaquetes
            // 
            this.lblPaquetes.AutoSize = true;
            this.lblPaquetes.Location = new System.Drawing.Point(12, 20);
            this.lblPaquetes.Name = "lblPaquetes";
            this.lblPaquetes.Size = new System.Drawing.Size(55, 13);
            this.lblPaquetes.TabIndex = 0;
            this.lblPaquetes.Text = "Paquetes:";
            // 
            // frmFactMercancia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 512);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFactMercancia";
            this.Text = "Facturacion de Mercancía";
            this.Load += new System.EventHandler(this.frmFactMercancia_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabDetalle.ResumeLayout(false);
            this.tabPaq.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPaq)).EndInit();
            this.tabCorr.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCorr)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEPS;
        private System.Windows.Forms.DateTimePicker dFechaVenc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabDetalle;
        private System.Windows.Forms.TabPage tabPaq;
        private System.Windows.Forms.TabPage tabCorr;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaq;
        private System.Windows.Forms.Label lblPaquetes;
        private System.Windows.Forms.Button btnCorres;
        private System.Windows.Forms.DataGridView dgPaq;
        private System.Windows.Forms.DataGridView dgCorr;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbTipoFact;
        private System.Windows.Forms.Label label4;
    }
}