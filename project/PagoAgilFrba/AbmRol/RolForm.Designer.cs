namespace PagoAgilFrba.AbmRol
{
    partial class RolForm
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
            this.rolTreeView = new System.Windows.Forms.TreeView();
            this.funcionalidadTreeView = new System.Windows.Forms.TreeView();
            this.btnRemoveFromRol = new System.Windows.Forms.Button();
            this.btnAddToRol = new System.Windows.Forms.Button();
            this.btnDeleteRol = new System.Windows.Forms.Button();
            this.btnAddRol = new System.Windows.Forms.Button();
            this.btnAgreeRol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rolTreeView
            // 
            this.rolTreeView.Location = new System.Drawing.Point(56, 46);
            this.rolTreeView.Name = "rolTreeView";
            this.rolTreeView.Size = new System.Drawing.Size(324, 369);
            this.rolTreeView.TabIndex = 0;
            this.rolTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.rolTreeView_BeforeSelect);
            this.rolTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.rolTreeView_AfterSelect);
            // 
            // funcionalidadTreeView
            // 
            this.funcionalidadTreeView.Location = new System.Drawing.Point(440, 46);
            this.funcionalidadTreeView.Name = "funcionalidadTreeView";
            this.funcionalidadTreeView.Size = new System.Drawing.Size(320, 369);
            this.funcionalidadTreeView.TabIndex = 1;
            this.funcionalidadTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.funcionalidadTreeView_AfterSelect);
            // 
            // btnRemoveFromRol
            // 
            this.btnRemoveFromRol.Location = new System.Drawing.Point(382, 118);
            this.btnRemoveFromRol.Name = "btnRemoveFromRol";
            this.btnRemoveFromRol.Size = new System.Drawing.Size(52, 45);
            this.btnRemoveFromRol.TabIndex = 2;
            this.btnRemoveFromRol.Text = ">";
            this.btnRemoveFromRol.UseVisualStyleBackColor = true;
            this.btnRemoveFromRol.Click += new System.EventHandler(this.btnRemoveFromRol_Click);
            // 
            // btnAddToRol
            // 
            this.btnAddToRol.Location = new System.Drawing.Point(382, 320);
            this.btnAddToRol.Name = "btnAddToRol";
            this.btnAddToRol.Size = new System.Drawing.Size(52, 45);
            this.btnAddToRol.TabIndex = 3;
            this.btnAddToRol.Text = "<";
            this.btnAddToRol.UseVisualStyleBackColor = true;
            this.btnAddToRol.Click += new System.EventHandler(this.btnAddToRol_Click);
            // 
            // btnDeleteRol
            // 
            this.btnDeleteRol.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteRol.Location = new System.Drawing.Point(166, 430);
            this.btnDeleteRol.Name = "btnDeleteRol";
            this.btnDeleteRol.Size = new System.Drawing.Size(104, 41);
            this.btnDeleteRol.TabIndex = 4;
            this.btnDeleteRol.Text = "Dar De Baja";
            this.btnDeleteRol.UseVisualStyleBackColor = false;
            this.btnDeleteRol.Click += new System.EventHandler(this.btnDeleteRol_Click);
            // 
            // btnAddRol
            // 
            this.btnAddRol.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddRol.Location = new System.Drawing.Point(276, 430);
            this.btnAddRol.Name = "btnAddRol";
            this.btnAddRol.Size = new System.Drawing.Size(104, 41);
            this.btnAddRol.TabIndex = 5;
            this.btnAddRol.Text = "Dar De Alta";
            this.btnAddRol.UseVisualStyleBackColor = false;
            this.btnAddRol.Click += new System.EventHandler(this.btnAddRol_Click);
            // 
            // btnAgreeRol
            // 
            this.btnAgreeRol.Location = new System.Drawing.Point(56, 430);
            this.btnAgreeRol.Name = "btnAgreeRol";
            this.btnAgreeRol.Size = new System.Drawing.Size(104, 41);
            this.btnAgreeRol.TabIndex = 6;
            this.btnAgreeRol.Text = "++Agregar Nuevo Rol";
            this.btnAgreeRol.UseVisualStyleBackColor = true;
            this.btnAgreeRol.Click += new System.EventHandler(this.btnAgreeRol_Click);
            // 
            // RolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 512);
            this.Controls.Add(this.btnAgreeRol);
            this.Controls.Add(this.btnAddRol);
            this.Controls.Add(this.btnDeleteRol);
            this.Controls.Add(this.btnAddToRol);
            this.Controls.Add(this.btnRemoveFromRol);
            this.Controls.Add(this.funcionalidadTreeView);
            this.Controls.Add(this.rolTreeView);
            this.Name = "RolForm";
            this.Text = "RolForm";
            this.ResumeLayout(false);



            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RolForm_FormClosing);

        }

        #endregion

        private System.Windows.Forms.TreeView rolTreeView;
        private System.Windows.Forms.TreeView funcionalidadTreeView;
        private System.Windows.Forms.Button btnRemoveFromRol;
        private System.Windows.Forms.Button btnAddToRol;
        private System.Windows.Forms.Button btnDeleteRol;
        private System.Windows.Forms.Button btnAddRol;
        private System.Windows.Forms.Button btnAgreeRol;

    }
}