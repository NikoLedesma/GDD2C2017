namespace PagoAgilFrba.AbmRol
{
    partial class AltaRolForm
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
            this.btnAddRol = new System.Windows.Forms.Button();
            this.txtRolName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.funcionalidadesListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddRol
            // 
            this.btnAddRol.Location = new System.Drawing.Point(158, 260);
            this.btnAddRol.Name = "btnAddRol";
            this.btnAddRol.Size = new System.Drawing.Size(105, 47);
            this.btnAddRol.TabIndex = 0;
            this.btnAddRol.Text = "Agregar Rol";
            this.btnAddRol.UseVisualStyleBackColor = true;
            this.btnAddRol.Click += new System.EventHandler(this.btnAddRol_Click);
            // 
            // txtRolName
            // 
            this.txtRolName.Location = new System.Drawing.Point(189, 68);
            this.txtRolName.Name = "txtRolName";
            this.txtRolName.Size = new System.Drawing.Size(190, 20);
            this.txtRolName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de Rol:";
            // 
            // funcionalidadesListBox
            // 
            this.funcionalidadesListBox.FormattingEnabled = true;
            this.funcionalidadesListBox.Location = new System.Drawing.Point(189, 128);
            this.funcionalidadesListBox.Name = "funcionalidadesListBox";
            this.funcionalidadesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.funcionalidadesListBox.Size = new System.Drawing.Size(190, 95);
            this.funcionalidadesListBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seleccionar funcionalidades:";
            // 
            // AltaRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 319);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.funcionalidadesListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRolName);
            this.Controls.Add(this.btnAddRol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AltaRolForm";
            this.Text = "Creacion de rol";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AltaRolForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRol;
        private System.Windows.Forms.TextBox txtRolName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox funcionalidadesListBox;
        private System.Windows.Forms.Label label2;
    }
}