namespace PagoAgilFrba.MenuRol
{
    partial class MenuRolForm
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.rolMenuListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(92, 206);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // rolMenuListBox
            // 
            this.rolMenuListBox.FormattingEnabled = true;
            this.rolMenuListBox.Location = new System.Drawing.Point(74, 64);
            this.rolMenuListBox.Name = "rolMenuListBox";
            this.rolMenuListBox.Size = new System.Drawing.Size(120, 95);
            this.rolMenuListBox.TabIndex = 1;
            // 
            // MenuRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.rolMenuListBox);
            this.Controls.Add(this.btnAccept);
            this.Name = "MenuRolForm";
            this.Text = "MenuRolForm";
            this.ResumeLayout(false);

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuRolForm_FormClosing);

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ListBox rolMenuListBox;
    }
}