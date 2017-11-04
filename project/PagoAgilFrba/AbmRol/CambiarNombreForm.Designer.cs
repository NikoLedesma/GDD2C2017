namespace PagoAgilFrba.AbmRol
{
    partial class CambiarNombreForm
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
            this.btnCambiarNombreRol = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreRolActual = new System.Windows.Forms.TextBox();
            this.txtNombreRolNuevo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asegurese de que el  nuevo nombre de rol no exista,";
            // 
            // btnCambiarNombreRol
            // 
            this.btnCambiarNombreRol.Location = new System.Drawing.Point(101, 167);
            this.btnCambiarNombreRol.Name = "btnCambiarNombreRol";
            this.btnCambiarNombreRol.Size = new System.Drawing.Size(103, 45);
            this.btnCambiarNombreRol.TabIndex = 1;
            this.btnCambiarNombreRol.Text = "Cambiar nombre de rol";
            this.btnCambiarNombreRol.UseVisualStyleBackColor = true;
            this.btnCambiarNombreRol.Click += new System.EventHandler(this.btnCambiarNombreRol_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de rol actual:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nuevo nombre de rol:";
            // 
            // txtNombreRolActual
            // 
            this.txtNombreRolActual.Enabled = false;
            this.txtNombreRolActual.Location = new System.Drawing.Point(127, 19);
            this.txtNombreRolActual.Name = "txtNombreRolActual";
            this.txtNombreRolActual.ReadOnly = true;
            this.txtNombreRolActual.Size = new System.Drawing.Size(140, 20);
            this.txtNombreRolActual.TabIndex = 4;
            // 
            // txtNombreRolNuevo
            // 
            this.txtNombreRolNuevo.Location = new System.Drawing.Point(127, 56);
            this.txtNombreRolNuevo.Name = "txtNombreRolNuevo";
            this.txtNombreRolNuevo.Size = new System.Drawing.Size(140, 20);
            this.txtNombreRolNuevo.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNombreRolNuevo);
            this.groupBox1.Controls.Add(this.txtNombreRolActual);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 97);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nombre de rol";
            // 
            // CambiarNombreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 224);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCambiarNombreRol);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CambiarNombreForm";
            this.Text = "Cambio de nombre de rol";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CambiarNombreForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCambiarNombreRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreRolActual;
        private System.Windows.Forms.TextBox txtNombreRolNuevo;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}