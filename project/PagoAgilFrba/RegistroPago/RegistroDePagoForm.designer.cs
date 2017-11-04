namespace PagoAgilFrba.RegistroPago
{
    partial class RegistroDePagoForm
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
            this.dataGridViewFacturas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddFactura = new System.Windows.Forms.Button();
            this.comboBoxFormaDePago = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdPago = new System.Windows.Forms.TextBox();
            this.EliminarColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFacturas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewFacturas
            // 
            this.dataGridViewFacturas.AllowUserToAddRows = false;
            this.dataGridViewFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EliminarColumn});
            this.dataGridViewFacturas.Location = new System.Drawing.Point(6, 28);
            this.dataGridViewFacturas.Name = "dataGridViewFacturas";
            this.dataGridViewFacturas.Size = new System.Drawing.Size(854, 217);
            this.dataGridViewFacturas.TabIndex = 0;
            this.dataGridViewFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFacturas_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Forma de Pago:";
            // 
            // btnAddFactura
            // 
            this.btnAddFactura.Location = new System.Drawing.Point(6, 251);
            this.btnAddFactura.Name = "btnAddFactura";
            this.btnAddFactura.Size = new System.Drawing.Size(133, 33);
            this.btnAddFactura.TabIndex = 2;
            this.btnAddFactura.Text = "Agregar Factura +";
            this.btnAddFactura.UseVisualStyleBackColor = true;
            this.btnAddFactura.Click += new System.EventHandler(this.btnAddFactura_Click);
            // 
            // comboBoxFormaDePago
            // 
            this.comboBoxFormaDePago.FormattingEnabled = true;
            this.comboBoxFormaDePago.Location = new System.Drawing.Point(97, 423);
            this.comboBoxFormaDePago.Name = "comboBoxFormaDePago";
            this.comboBoxFormaDePago.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFormaDePago.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtImporte);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAddFactura);
            this.groupBox1.Controls.Add(this.dataGridViewFacturas);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(866, 304);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facturas a pagar";
            // 
            // txtImporte
            // 
            this.txtImporte.Enabled = false;
            this.txtImporte.Location = new System.Drawing.Point(633, 258);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(178, 20);
            this.txtImporte.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Importe Total ($):";
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(415, 451);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(77, 45);
            this.btnPagar.TabIndex = 5;
            this.btnPagar.Text = "Registrar Pago";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Identificacion de pago:";
            // 
            // txtIdPago
            // 
            this.txtIdPago.Location = new System.Drawing.Point(130, 51);
            this.txtIdPago.Name = "txtIdPago";
            this.txtIdPago.Size = new System.Drawing.Size(135, 20);
            this.txtIdPago.TabIndex = 7;
            // 
            // EliminarColumn
            // 
            this.EliminarColumn.HeaderText = "Eliminar";
            this.EliminarColumn.Name = "EliminarColumn";
            this.EliminarColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EliminarColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // RegistroDePagoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 508);
            this.Controls.Add(this.txtIdPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxFormaDePago);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RegistroDePagoForm";
            this.Text = "Registro de pago";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistroDePagoForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFacturas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFacturas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddFactura;
        private System.Windows.Forms.ComboBox comboBoxFormaDePago;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdPago;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewButtonColumn EliminarColumn;

    }
}