namespace OpeAgencia2.Parametros
{
    partial class frmOrigen
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.usrbntMant1 = new OpeAgencia2.usrbntMant();
            this.tabMant = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dg = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtORI_EMS_GROUP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtORI_CODIGO = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDESCR = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.textORI_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtORI_APP_GROUP = new System.Windows.Forms.TextBox();
            this.txtORI_COURIER_GROUP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtORI_EQUIVALENTE = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtORI_CORREO_INT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabMant.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.usrbntMant1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabMant);
            this.splitContainer1.Size = new System.Drawing.Size(576, 411);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 4;
            // 
            // usrbntMant1
            // 
            this.usrbntMant1.bAdiciona = false;
            this.usrbntMant1.bExito = false;
            this.usrbntMant1.Location = new System.Drawing.Point(6, 4);
            this.usrbntMant1.Name = "usrbntMant1";
            this.usrbntMant1.Size = new System.Drawing.Size(479, 28);
            this.usrbntMant1.TabIndex = 0;
            // 
            // tabMant
            // 
            this.tabMant.Controls.Add(this.tabPage1);
            this.tabMant.Controls.Add(this.tabPage2);
            this.tabMant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMant.Location = new System.Drawing.Point(0, 0);
            this.tabMant.Name = "tabMant";
            this.tabMant.SelectedIndex = 0;
            this.tabMant.Size = new System.Drawing.Size(576, 371);
            this.tabMant.TabIndex = 0;
            this.tabMant.SelectedIndexChanged += new System.EventHandler(this.tabMant_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dg);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(568, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg.Location = new System.Drawing.Point(3, 3);
            this.dg.Name = "dg";
            this.dg.ReadOnly = true;
            this.dg.Size = new System.Drawing.Size(562, 339);
            this.dg.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtORI_CORREO_INT);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtORI_EQUIVALENTE);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtORI_COURIER_GROUP);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtORI_APP_GROUP);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.cmbEstado);
            this.tabPage2.Controls.Add(this.txtORI_EMS_GROUP);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtORI_CODIGO);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtDESCR);
            this.tabPage2.Controls.Add(this.lblDesc);
            this.tabPage2.Controls.Add(this.textORI_ID);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(568, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtORI_EMS_GROUP
            // 
            this.txtORI_EMS_GROUP.Location = new System.Drawing.Point(90, 88);
            this.txtORI_EMS_GROUP.Name = "txtORI_EMS_GROUP";
            this.txtORI_EMS_GROUP.Size = new System.Drawing.Size(100, 20);
            this.txtORI_EMS_GROUP.TabIndex = 19;
            this.txtORI_EMS_GROUP.Tag = "ORI_EMS_GROUP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Grupo EMS";
            // 
            // txtORI_CODIGO
            // 
            this.txtORI_CODIGO.Location = new System.Drawing.Point(88, 60);
            this.txtORI_CODIGO.Name = "txtORI_CODIGO";
            this.txtORI_CODIGO.Size = new System.Drawing.Size(261, 20);
            this.txtORI_CODIGO.TabIndex = 17;
            this.txtORI_CODIGO.Tag = "ORI_CODIGO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Código:";
            // 
            // txtDESCR
            // 
            this.txtDESCR.Location = new System.Drawing.Point(88, 227);
            this.txtDESCR.Multiline = true;
            this.txtDESCR.Name = "txtDESCR";
            this.txtDESCR.Size = new System.Drawing.Size(261, 67);
            this.txtDESCR.TabIndex = 3;
            this.txtDESCR.Tag = "ORI_DESCRIPCION";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(13, 227);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(63, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Descripción";
            // 
            // textORI_ID
            // 
            this.textORI_ID.Enabled = false;
            this.textORI_ID.Location = new System.Drawing.Point(88, 27);
            this.textORI_ID.Name = "textORI_ID";
            this.textORI_ID.Size = new System.Drawing.Size(100, 20);
            this.textORI_ID.TabIndex = 1;
            this.textORI_ID.Tag = "ORI_ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "A",
            "I"});
            this.cmbEstado.Location = new System.Drawing.Point(88, 300);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(132, 21);
            this.cmbEstado.TabIndex = 20;
            this.cmbEstado.Tag = "ORI_ESTADO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Estado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Grupo APP";
            // 
            // txtORI_APP_GROUP
            // 
            this.txtORI_APP_GROUP.Location = new System.Drawing.Point(90, 114);
            this.txtORI_APP_GROUP.Name = "txtORI_APP_GROUP";
            this.txtORI_APP_GROUP.Size = new System.Drawing.Size(100, 20);
            this.txtORI_APP_GROUP.TabIndex = 23;
            this.txtORI_APP_GROUP.Tag = "ORI_APP_GROUP";
            // 
            // txtORI_COURIER_GROUP
            // 
            this.txtORI_COURIER_GROUP.Location = new System.Drawing.Point(90, 140);
            this.txtORI_COURIER_GROUP.Name = "txtORI_COURIER_GROUP";
            this.txtORI_COURIER_GROUP.Size = new System.Drawing.Size(100, 20);
            this.txtORI_COURIER_GROUP.TabIndex = 25;
            this.txtORI_COURIER_GROUP.Tag = "ORI_COURIER_GROUP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Grupo Courier";
            // 
            // txtORI_EQUIVALENTE
            // 
            this.txtORI_EQUIVALENTE.Location = new System.Drawing.Point(90, 171);
            this.txtORI_EQUIVALENTE.Name = "txtORI_EQUIVALENTE";
            this.txtORI_EQUIVALENTE.Size = new System.Drawing.Size(100, 20);
            this.txtORI_EQUIVALENTE.TabIndex = 27;
            this.txtORI_EQUIVALENTE.Tag = "ORI_EQUIVALENTE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Equivalente";
            // 
            // txtORI_CORREO_INT
            // 
            this.txtORI_CORREO_INT.Location = new System.Drawing.Point(89, 197);
            this.txtORI_CORREO_INT.Name = "txtORI_CORREO_INT";
            this.txtORI_CORREO_INT.Size = new System.Drawing.Size(100, 20);
            this.txtORI_CORREO_INT.TabIndex = 29;
            this.txtORI_CORREO_INT.Tag = "ORI_CORREO_INT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Correo INT";
            // 
            // frmOrigen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 411);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmOrigen";
            this.Text = "frmOrigen";
            this.Load += new System.EventHandler(this.frmOrigen_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabMant.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private usrbntMant usrbntMant1;
        private System.Windows.Forms.TabControl tabMant;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtORI_EMS_GROUP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtORI_CODIGO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDESCR;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox textORI_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.TextBox txtORI_EQUIVALENTE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtORI_COURIER_GROUP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtORI_APP_GROUP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtORI_CORREO_INT;
        private System.Windows.Forms.Label label7;
    }
}