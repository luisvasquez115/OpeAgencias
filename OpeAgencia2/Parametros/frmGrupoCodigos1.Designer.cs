﻿namespace OpeAgencia2.Parametros
{
    partial class frmGrupoCodigos1
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
            this.tabMant = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dg = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDESCR = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.textGRUPO_TIPO_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.usrbntMant1 = new OpeAgencia2.usrbntMant();
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
            this.splitContainer1.Size = new System.Drawing.Size(556, 346);
            this.splitContainer1.SplitterDistance = 30;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabMant
            // 
            this.tabMant.Controls.Add(this.tabPage1);
            this.tabMant.Controls.Add(this.tabPage2);
            this.tabMant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMant.Location = new System.Drawing.Point(0, 0);
            this.tabMant.Name = "tabMant";
            this.tabMant.SelectedIndex = 0;
            this.tabMant.Size = new System.Drawing.Size(556, 312);
            this.tabMant.TabIndex = 0;
            this.tabMant.SelectedIndexChanged += new System.EventHandler(this.tabMant_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dg);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(548, 286);
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
            this.dg.Size = new System.Drawing.Size(542, 280);
            this.dg.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtNombre);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtCodigo);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtDESCR);
            this.tabPage2.Controls.Add(this.lblDesc);
            this.tabPage2.Controls.Add(this.textGRUPO_TIPO_ID);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(548, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(88, 96);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(261, 20);
            this.txtNombre.TabIndex = 19;
            this.txtNombre.Tag = "NOMBRE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nombre";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(88, 60);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(261, 20);
            this.txtCodigo.TabIndex = 17;
            this.txtCodigo.Tag = "CODIGO";
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
            this.txtDESCR.Location = new System.Drawing.Point(88, 135);
            this.txtDESCR.Multiline = true;
            this.txtDESCR.Name = "txtDESCR";
            this.txtDESCR.Size = new System.Drawing.Size(261, 67);
            this.txtDESCR.TabIndex = 3;
            this.txtDESCR.Tag = "DESCR";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(13, 135);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(63, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Descripción";
            // 
            // textGRUPO_TIPO_ID
            // 
            this.textGRUPO_TIPO_ID.Enabled = false;
            this.textGRUPO_TIPO_ID.Location = new System.Drawing.Point(88, 27);
            this.textGRUPO_TIPO_ID.Name = "textGRUPO_TIPO_ID";
            this.textGRUPO_TIPO_ID.Size = new System.Drawing.Size(100, 20);
            this.textGRUPO_TIPO_ID.TabIndex = 1;
            this.textGRUPO_TIPO_ID.Tag = "GRUPO_COD_ID";
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
            // usrbntMant1
            // 
            this.usrbntMant1.bAdiciona = false;
            this.usrbntMant1.bExito = false;
            this.usrbntMant1.Location = new System.Drawing.Point(6, 4);
            this.usrbntMant1.Name = "usrbntMant1";
            this.usrbntMant1.Size = new System.Drawing.Size(479, 28);
            this.usrbntMant1.TabIndex = 0;
            // 
            // frmGrupoCodigos1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 346);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmGrupoCodigos1";
            this.Text = "frmGrupoCodigos1";
            this.Load += new System.EventHandler(this.frmGrupoCodigos1_Load);
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
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDESCR;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox textGRUPO_TIPO_ID;
        private System.Windows.Forms.Label label1;
    }
}