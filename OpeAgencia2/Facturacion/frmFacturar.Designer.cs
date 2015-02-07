namespace OpeAgencia2.Facturacion
{
    partial class frmFacturar
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
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDevolucion = new clsUtils.NumericTextBox();
            this.txtOtros = new clsUtils.NumericTextBox();
            this.txtEfectivo = new clsUtils.NumericTextBox();
            this.txtTotal = new clsUtils.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtMontoPendiente = new clsUtils.NumericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbFormaPago);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta",
            "Cheque"});
            this.cmbFormaPago.Location = new System.Drawing.Point(139, 19);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(171, 21);
            this.cmbFormaPago.TabIndex = 1;
            this.cmbFormaPago.SelectedIndexChanged += new System.EventHandler(this.cmbFormaPago_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forma de pago:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMontoPendiente);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDevolucion);
            this.groupBox2.Controls.Add(this.txtOtros);
            this.groupBox2.Controls.Add(this.txtEfectivo);
            this.groupBox2.Controls.Add(this.txtTotal);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 163);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtDevolucion
            // 
            this.txtDevolucion.AllowSpace = false;
            this.txtDevolucion.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDevolucion.Enabled = false;
            this.txtDevolucion.IntValue = 0;
            this.txtDevolucion.Location = new System.Drawing.Point(139, 117);
            this.txtDevolucion.Name = "txtDevolucion";
            this.txtDevolucion.Size = new System.Drawing.Size(172, 21);
            this.txtDevolucion.TabIndex = 7;
            // 
            // txtOtros
            // 
            this.txtOtros.AllowSpace = false;
            this.txtOtros.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOtros.Enabled = false;
            this.txtOtros.IntValue = 0;
            this.txtOtros.Location = new System.Drawing.Point(139, 90);
            this.txtOtros.Name = "txtOtros";
            this.txtOtros.Size = new System.Drawing.Size(172, 21);
            this.txtOtros.TabIndex = 6;
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.AllowSpace = false;
            this.txtEfectivo.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtEfectivo.IntValue = 0;
            this.txtEfectivo.Location = new System.Drawing.Point(139, 63);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(172, 21);
            this.txtEfectivo.TabIndex = 5;
            this.txtEfectivo.Load += new System.EventHandler(this.txtEfectivo_Load);
            this.txtEfectivo.Leave += new System.EventHandler(this.txtEfectivo_Leave);
            // 
            // txtTotal
            // 
            this.txtTotal.AllowSpace = false;
            this.txtTotal.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotal.Enabled = false;
            this.txtTotal.IntValue = 0;
            this.txtTotal.Location = new System.Drawing.Point(139, 14);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(172, 21);
            this.txtTotal.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Devolución:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Entregado en otros:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Entregado en efectivo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total a Pagar:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(268, 260);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(187, 260);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtMontoPendiente
            // 
            this.txtMontoPendiente.AllowSpace = false;
            this.txtMontoPendiente.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoPendiente.Enabled = false;
            this.txtMontoPendiente.IntValue = 0;
            this.txtMontoPendiente.Location = new System.Drawing.Point(139, 38);
            this.txtMontoPendiente.Name = "txtMontoPendiente";
            this.txtMontoPendiente.Size = new System.Drawing.Size(172, 21);
            this.txtMontoPendiente.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Monto pendiente:";
            // 
            // frmFacturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 295);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFacturar";
            this.Text = "frmFacturar";
            this.Load += new System.EventHandler(this.frmFacturar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private clsUtils.NumericTextBox txtDevolucion;
        private clsUtils.NumericTextBox txtOtros;
        private clsUtils.NumericTextBox txtEfectivo;
        private clsUtils.NumericTextBox txtTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private clsUtils.NumericTextBox txtMontoPendiente;
        private System.Windows.Forms.Label label6;
    }
}