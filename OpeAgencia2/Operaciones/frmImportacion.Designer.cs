﻿namespace OpeAgencia2.Operaciones
{
    partial class frmImportacion
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
            this.button1 = new System.Windows.Forms.Button();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.dgFacturas = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.btnSeleccionarTodo = new System.Windows.Forms.Button();
            this.chkBultos = new System.Windows.Forms.CheckedListBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturas)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.DateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Buscar Facturas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.Location = new System.Drawing.Point(62, 27);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.DateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha:";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.dgFacturas);
            this.GroupBox2.Location = new System.Drawing.Point(12, 112);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(464, 107);
            this.GroupBox2.TabIndex = 14;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Facturas";
            // 
            // dgFacturas
            // 
            this.dgFacturas.AllowUserToAddRows = false;
            this.dgFacturas.AllowUserToDeleteRows = false;
            this.dgFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFacturas.Location = new System.Drawing.Point(3, 16);
            this.dgFacturas.Name = "dgFacturas";
            this.dgFacturas.ReadOnly = true;
            this.dgFacturas.Size = new System.Drawing.Size(458, 88);
            this.dgFacturas.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Button2);
            this.groupBox3.Controls.Add(this.btnSeleccionarTodo);
            this.groupBox3.Controls.Add(this.chkBultos);
            this.groupBox3.Location = new System.Drawing.Point(15, 281);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(458, 195);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Guias";
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(124, 161);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(115, 23);
            this.Button2.TabIndex = 2;
            this.Button2.Text = "Limpiar seleccion";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnSeleccionarTodo
            // 
            this.btnSeleccionarTodo.Location = new System.Drawing.Point(3, 161);
            this.btnSeleccionarTodo.Name = "btnSeleccionarTodo";
            this.btnSeleccionarTodo.Size = new System.Drawing.Size(115, 23);
            this.btnSeleccionarTodo.TabIndex = 1;
            this.btnSeleccionarTodo.Text = "Seleccionar todos";
            this.btnSeleccionarTodo.UseVisualStyleBackColor = true;
            this.btnSeleccionarTodo.Click += new System.EventHandler(this.btnSeleccionarTodo_Click);
            // 
            // chkBultos
            // 
            this.chkBultos.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkBultos.FormattingEnabled = true;
            this.chkBultos.Location = new System.Drawing.Point(3, 16);
            this.chkBultos.Name = "chkBultos";
            this.chkBultos.Size = new System.Drawing.Size(452, 139);
            this.chkBultos.TabIndex = 0;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(91, 255);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(148, 20);
            this.TextBox1.TabIndex = 20;
            this.TextBox1.Leave += new System.EventHandler(this.TextBox1_Leave);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(14, 255);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 13);
            this.Label2.TabIndex = 19;
            this.Label2.Text = "Codigo Barra:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 222);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Buscar Manifiesto";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(313, 497);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(395, 497);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(75, 23);
            this.btnProcesar.TabIndex = 21;
            this.btnProcesar.Text = "Importar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(15, 88);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(35, 13);
            this.lblMensaje.TabIndex = 23;
            this.lblMensaje.Text = "label3";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.Color.Red;
            this.lbltotal.Location = new System.Drawing.Point(331, 242);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(0, 26);
            this.lbltotal.TabIndex = 24;
            // 
            // frmImportacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 546);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmImportacion";
            this.Text = "frmImportacion";
            this.Load += new System.EventHandler(this.frmImportacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker DateTimePicker1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.DataGridView dgFacturas;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button btnSeleccionarTodo;
        internal System.Windows.Forms.CheckedListBox chkBultos;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lbltotal;
    }
}