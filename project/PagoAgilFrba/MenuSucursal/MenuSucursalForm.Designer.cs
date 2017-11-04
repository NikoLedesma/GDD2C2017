namespace PagoAgilFrba.MenuSucursal
{
    partial class MenuSucursalForm
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
            this.sucursalMenuListBox = new System.Windows.Forms.ListBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sucursalMenuListBox
            // 
            this.sucursalMenuListBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.sucursalMenuListBox.FormattingEnabled = true;
            this.sucursalMenuListBox.Location = new System.Drawing.Point(82, 48);
            this.sucursalMenuListBox.Name = "sucursalMenuListBox";
            this.sucursalMenuListBox.Size = new System.Drawing.Size(120, 95);
            this.sucursalMenuListBox.TabIndex = 3;
            // 
            // btnAccept
            // 
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAccept.Location = new System.Drawing.Point(100, 190);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // MenuSucursalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.sucursalMenuListBox);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MenuSucursalForm";
            this.Text = "Menu de sucursal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuSucursalForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox sucursalMenuListBox;
        private System.Windows.Forms.Button btnAccept;
    }
}