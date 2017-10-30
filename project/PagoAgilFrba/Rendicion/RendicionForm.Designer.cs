namespace PagoAgilFrba.Rendicion
{
    partial class RendicionForm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtPorcCom = new System.Windows.Forms.TextBox();
            this.txtComision = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRendir = new System.Windows.Forms.Button();
            this.txtSubTotal = new System.Windows.Forms.Label();
            this.txtImpCom = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantFact = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txtPorcCom);
            this.groupBox1.Controls.Add(this.txtComision);
            this.groupBox1.Controls.Add(this.txtEmpresa);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 108);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(464, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(142, 38);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // txtPorcCom
            // 
            this.txtPorcCom.Location = new System.Drawing.Point(142, 77);
            this.txtPorcCom.Name = "txtPorcCom";
            this.txtPorcCom.Size = new System.Drawing.Size(100, 20);
            this.txtPorcCom.TabIndex = 4;
            // 
            // txtComision
            // 
            this.txtComision.AutoSize = true;
            this.txtComision.Location = new System.Drawing.Point(80, 80);
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(63, 13);
            this.txtComision.TabIndex = 2;
            this.txtComision.Text = "% Comision:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.AutoSize = true;
            this.txtEmpresa.Location = new System.Drawing.Point(407, 41);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(51, 13);
            this.txtEmpresa.TabIndex = 1;
            this.txtEmpresa.Text = "Empresa:";
            // 
            // txtFecha
            // 
            this.txtFecha.AutoSize = true;
            this.txtFecha.Location = new System.Drawing.Point(96, 41);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(40, 13);
            this.txtFecha.TabIndex = 0;
            this.txtFecha.Text = "Fecha:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 166);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(665, 200);
            this.dataGridView1.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(602, 137);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "SubTotal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Importe por Comision:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total:";
            // 
            // btnRendir
            // 
            this.btnRendir.Location = new System.Drawing.Point(325, 492);
            this.btnRendir.Name = "btnRendir";
            this.btnRendir.Size = new System.Drawing.Size(86, 40);
            this.btnRendir.TabIndex = 9;
            this.btnRendir.Text = "Rendir Facturas";
            this.btnRendir.UseVisualStyleBackColor = true;
            this.btnRendir.Click += new System.EventHandler(this.btnRendir_Click);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.AutoSize = true;
            this.txtSubTotal.Location = new System.Drawing.Point(167, 421);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(0, 13);
            this.txtSubTotal.TabIndex = 10;
            // 
            // txtImpCom
            // 
            this.txtImpCom.AutoSize = true;
            this.txtImpCom.Location = new System.Drawing.Point(222, 459);
            this.txtImpCom.Name = "txtImpCom";
            this.txtImpCom.Size = new System.Drawing.Size(28, 13);
            this.txtImpCom.TabIndex = 11;
            this.txtImpCom.Text = "AAA";
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Location = new System.Drawing.Point(473, 441);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(35, 13);
            this.txtTotal.TabIndex = 12;
            this.txtTotal.Text = "label6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 386);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Cantidad de Facturas:";
            // 
            // txtCantFact
            // 
            this.txtCantFact.AutoSize = true;
            this.txtCantFact.Location = new System.Drawing.Point(222, 386);
            this.txtCantFact.Name = "txtCantFact";
            this.txtCantFact.Size = new System.Drawing.Size(35, 13);
            this.txtCantFact.TabIndex = 14;
            this.txtCantFact.Text = "label5";
            // 
            // RendicionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 544);
            this.Controls.Add(this.txtCantFact);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtImpCom);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.btnRendir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox1);
            this.Name = "RendicionForm";
            this.Text = "Rendicion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RendicionForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtPorcCom;
        private System.Windows.Forms.Label txtComision;
        private System.Windows.Forms.Label txtEmpresa;
        private System.Windows.Forms.Label txtFecha;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRendir;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label txtSubTotal;
        private System.Windows.Forms.Label txtImpCom;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtCantFact;
    }
}