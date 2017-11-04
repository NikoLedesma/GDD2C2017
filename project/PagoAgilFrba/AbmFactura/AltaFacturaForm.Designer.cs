namespace PagoAgilFrba.AbmFactura
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
            this.txtNroFact = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dateTimePickerAlta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerVencimiento = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MontoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.radioBtnDeshabilitado = new System.Windows.Forms.RadioButton();
            this.radioBtnHabilitado = new System.Windows.Forms.RadioButton();
            this.groupBoxHabilitacion = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxHabilitacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente DNI:";
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
            this.MontoName,
            this.CantidadN});
            this.dataGridView1.Location = new System.Drawing.Point(169, 287);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(243, 134);
            this.dataGridView1.TabIndex = 14;
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
            this.button1.Location = new System.Drawing.Point(292, 573);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 39);
            this.button1.TabIndex = 15;
            this.button1.Text = "ALTA DE FACTURA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(154, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(166, 84);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 17;
            // 
            // radioBtnDeshabilitado
            // 
            this.radioBtnDeshabilitado.AutoSize = true;
            this.radioBtnDeshabilitado.Location = new System.Drawing.Point(250, 29);
            this.radioBtnDeshabilitado.Name = "radioBtnDeshabilitado";
            this.radioBtnDeshabilitado.Size = new System.Drawing.Size(89, 17);
            this.radioBtnDeshabilitado.TabIndex = 1;
            this.radioBtnDeshabilitado.TabStop = true;
            this.radioBtnDeshabilitado.Text = "Deshabilitado";
            this.radioBtnDeshabilitado.UseVisualStyleBackColor = true;
            // 
            // radioBtnHabilitado
            // 
            this.radioBtnHabilitado.AutoSize = true;
            this.radioBtnHabilitado.Location = new System.Drawing.Point(134, 29);
            this.radioBtnHabilitado.Name = "radioBtnHabilitado";
            this.radioBtnHabilitado.Size = new System.Drawing.Size(72, 17);
            this.radioBtnHabilitado.TabIndex = 0;
            this.radioBtnHabilitado.TabStop = true;
            this.radioBtnHabilitado.Text = "Habilitado";
            this.radioBtnHabilitado.UseVisualStyleBackColor = true;
            // 
            // groupBoxHabilitacion
            // 
            this.groupBoxHabilitacion.Controls.Add(this.radioBtnDeshabilitado);
            this.groupBoxHabilitacion.Controls.Add(this.radioBtnHabilitado);
            this.groupBoxHabilitacion.Location = new System.Drawing.Point(93, 475);
            this.groupBoxHabilitacion.Name = "groupBoxHabilitacion";
            this.groupBoxHabilitacion.Size = new System.Drawing.Size(492, 54);
            this.groupBoxHabilitacion.TabIndex = 18;
            this.groupBoxHabilitacion.TabStop = false;
            this.groupBoxHabilitacion.Text = "Habilitacion de factura";
            // 
            // AltaFacturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 624);
            this.Controls.Add(this.groupBoxHabilitacion);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePickerVencimiento);
            this.Controls.Add(this.dateTimePickerAlta);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtNroFact);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AltaFacturaForm";
            this.Text = "Alta Factura";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AltaFacturaForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxHabilitacion.ResumeLayout(false);
            this.groupBoxHabilitacion.PerformLayout();
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
        private System.Windows.Forms.TextBox txtNroFact;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DateTimePicker dateTimePickerAlta;
        private System.Windows.Forms.DateTimePicker dateTimePickerVencimiento;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadN;
        private System.Windows.Forms.RadioButton radioBtnDeshabilitado;
        private System.Windows.Forms.RadioButton radioBtnHabilitado;
        private System.Windows.Forms.GroupBox groupBoxHabilitacion;
    }
}