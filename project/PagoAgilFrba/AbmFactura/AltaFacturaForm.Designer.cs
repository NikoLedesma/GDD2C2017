﻿namespace PagoAgilFrba.AbmFactura
{
    partial class AltaFacturaForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.txtNroFact = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dateTimePickerAlta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerVencimiento = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Empresa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Número de Factura:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de Alta de la Factura:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha de Vencimiento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(138, 43);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCliente.TabIndex = 6;
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(147, 84);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(100, 20);
            this.txtEmpresa.TabIndex = 7;
            // 
            // txtNroFact
            // 
            this.txtNroFact.Location = new System.Drawing.Point(197, 129);
            this.txtNroFact.Name = "txtNroFact";
            this.txtNroFact.Size = new System.Drawing.Size(100, 20);
            this.txtNroFact.TabIndex = 8;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(131, 261);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 11;
            // 
            // dateTimePickerAlta
            // 
            this.dateTimePickerAlta.Location = new System.Drawing.Point(237, 171);
            this.dateTimePickerAlta.Name = "dateTimePickerAlta";
            this.dateTimePickerAlta.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerAlta.TabIndex = 12;
            // 
            // dateTimePickerVencimiento
            // 
            this.dateTimePickerVencimiento.Location = new System.Drawing.Point(212, 215);
            this.dateTimePickerVencimiento.Name = "dateTimePickerVencimiento";
            this.dateTimePickerVencimiento.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerVencimiento.TabIndex = 13;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Items,
            this.MontoName,
            this.CantidadN});
            this.dataGridView1.Location = new System.Drawing.Point(93, 298);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(423, 106);
            this.dataGridView1.TabIndex = 14;
            // 
            // Items
            // 
            this.Items.HeaderText = "ItemsHeader";
            this.Items.Name = "Items";
            // 
            // MontoName
            // 
            this.MontoName.HeaderText = "Monto";
            this.MontoName.Name = "MontoName";
            // 
            // CantidadN
            // 
            this.CantidadN.HeaderText = "Cantidad";
            this.CantidadN.Name = "CantidadN";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(305, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 39);
            this.button1.TabIndex = 15;
            this.button1.Text = "ALTA DE FACTURA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AltaFacturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 492);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePickerVencimiento);
            this.Controls.Add(this.dateTimePickerAlta);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtNroFact);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AltaFacturaForm";
            this.Text = "Alta Factura";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.TextBox txtNroFact;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DateTimePicker dateTimePickerAlta;
        private System.Windows.Forms.DateTimePicker dateTimePickerVencimiento;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Items;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadN;
        private System.Windows.Forms.Button button1;
    }
}