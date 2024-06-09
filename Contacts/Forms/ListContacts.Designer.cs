namespace Contacts
{
    partial class ListContacts
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
            this.grd_list = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grd_list)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_list
            // 
            this.grd_list.AllowUserToAddRows = false;
            this.grd_list.AllowUserToDeleteRows = false;
            this.grd_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_list.Location = new System.Drawing.Point(0, 0);
            this.grd_list.MultiSelect = false;
            this.grd_list.Name = "grd_list";
            this.grd_list.ReadOnly = true;
            this.grd_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd_list.Size = new System.Drawing.Size(937, 259);
            this.grd_list.TabIndex = 0;
            this.grd_list.DoubleClick += new System.EventHandler(this.grd_list_DoubleClick);
            // 
            // ListContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 259);
            this.Controls.Add(this.grd_list);
            this.Name = "ListContacts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kişileri Listele";
            this.Load += new System.EventHandler(this.ListContacts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_list)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grd_list;
    }
}