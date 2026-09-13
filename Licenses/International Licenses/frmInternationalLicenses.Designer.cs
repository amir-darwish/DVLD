namespace DVLD
{
    partial class frmInternationalLicenses
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvInternationalLicenses = new Guna.UI2.WinForms.Guna2DataGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlFilter1 = new DVLD.ctrlFilter();
            this.lblRecordsCaption = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F,
                System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitle.Location = new System.Drawing.Point(330, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(390, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "International Licenses";
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top |
            System.Windows.Forms.AnchorStyles.Bottom) |
            System.Windows.Forms.AnchorStyles.Left) |
            System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInternationalLicenses.ColumnHeadersHeight = 35;
            this.dgvInternationalLicenses.ContextMenuStrip = this.contextMenu;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(12, 145);
            this.dgvInternationalLicenses.MultiSelect = false;
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.RowHeadersVisible = false;
            this.dgvInternationalLicenses.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(1026, 360);
            this.dgvInternationalLicenses.TabIndex = 2;
            this.dgvInternationalLicenses.CellMouseDown +=
                new System.Windows.Forms.DataGridViewCellMouseEventHandler(
                    this.dgvInternationalLicenses_CellMouseDown);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(172, 26);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click +=
                new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // ctrlFilter1
            // 
            this.ctrlFilter1.Location = new System.Drawing.Point(12, 75);
            this.ctrlFilter1.Name = "ctrlFilter1";
            this.ctrlFilter1.Size = new System.Drawing.Size(430, 64);
            this.ctrlFilter1.TabIndex = 1;
            // 
            // lblRecordsCaption
            // 
            this.lblRecordsCaption.AutoSize = true;
            this.lblRecordsCaption.Font = new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);
            this.lblRecordsCaption.Location = new System.Drawing.Point(12, 522);
            this.lblRecordsCaption.Name = "lblRecordsCaption";
            this.lblRecordsCaption.Size = new System.Drawing.Size(57, 15);
            this.lblRecordsCaption.TabIndex = 3;
            this.lblRecordsCaption.Text = "Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Location = new System.Drawing.Point(75, 522);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(18, 13);
            this.lblRecordsCount.TabIndex = 4;
            this.lblRecordsCount.Text = "0";
            // 
            // frmInternationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 550);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.lblRecordsCaption);
            this.Controls.Add(this.ctrlFilter1);
            this.Controls.Add(this.dgvInternationalLicenses);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmInternationalLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "International Licenses";
            this.Load += new System.EventHandler(this.frmInternationalLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private ctrlFilter ctrlFilter1;
        private System.Windows.Forms.Label lblRecordsCaption;
        private System.Windows.Forms.Label lblRecordsCount;
    }
}
