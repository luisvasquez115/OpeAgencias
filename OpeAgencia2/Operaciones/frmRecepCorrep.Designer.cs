﻿namespace OpeAgencia2.Operaciones
{
    partial class frmRecepCorrep
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
            this.txtNumeroEPS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPesoCorr = new clsUtils.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPiezaNormal = new clsUtils.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblEps = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNumeroEPS
            // 
            this.txtNumeroEPS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroEPS.Location = new System.Drawing.Point(100, 19);
            this.txtNumeroEPS.Name = "txtNumeroEPS";
            this.txtNumeroEPS.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroEPS.TabIndex = 4;
            this.txtNumeroEPS.Leave += new System.EventHandler(this.txtNumeroEPS_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Número de EPS:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEps);
            this.groupBox1.Controls.Add(this.txtNumeroEPS);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 74);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtPesoCorr);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtPiezaNormal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(8, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 101);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // txtPesoCorr
            // 
            this.txtPesoCorr.AllowSpace = false;
            this.txtPesoCorr.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPesoCorr.IntValue = 0;
            this.txtPesoCorr.Location = new System.Drawing.Point(100, 52);
            this.txtPesoCorr.Name = "txtPesoCorr";
            this.txtPesoCorr.Size = new System.Drawing.Size(47, 21);
            this.txtPesoCorr.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Peso Normal:";
            // 
            // txtPiezaNormal
            // 
            this.txtPiezaNormal.AllowSpace = false;
            this.txtPiezaNormal.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPiezaNormal.IntValue = 0;
            this.txtPiezaNormal.Location = new System.Drawing.Point(100, 16);
            this.txtPiezaNormal.Name = "txtPiezaNormal";
            this.txtPiezaNormal.Size = new System.Drawing.Size(47, 21);
            this.txtPiezaNormal.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Piezas Normal:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblEps
            // 
            this.lblEps.AutoSize = true;
            this.lblEps.Location = new System.Drawing.Point(17, 49);
            this.lblEps.Name = "lblEps";
            this.lblEps.Size = new System.Drawing.Size(0, 13);
            this.lblEps.TabIndex = 5;
            // 
            // frmRecepCorrep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 213);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRecepCorrep";
            this.Text = "frmRecepCorrep";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumeroEPS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private clsUtils.NumericTextBox txtPesoCorr;
        private System.Windows.Forms.Label label1;
        private clsUtils.NumericTextBox txtPiezaNormal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEps;
    }
}