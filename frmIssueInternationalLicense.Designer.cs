namespace DVLD
{
    partial class frmIssueInternationalLicense
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.ctrlLicenseIdFilter1 = new DVLD.ctrlLicenseIdFilter();
            this.ctrlDriverLicenceInfo1 = new DVLD.ctrlDriverLicenceInfo();
            this.ctrlInternationalLicenseApplicationInfo1 = new DVLD.ctrlInternationalLicenseApplicationInfo();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnIssue = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F,
                System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitle.Location = new System.Drawing.Point(225, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(450, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "International License Application";
            // 
            // ctrlLicenseIdFilter1
            // 
            this.ctrlLicenseIdFilter1.Location = new System.Drawing.Point(45, 76);
            this.ctrlLicenseIdFilter1.Name = "ctrlLicenseIdFilter1";
            this.ctrlLicenseIdFilter1.Size = new System.Drawing.Size(807, 111);
            this.ctrlLicenseIdFilter1.TabIndex = 1;
            // 
            // ctrlDriverLicenceInfo1
            // 
            this.ctrlDriverLicenceInfo1.Location = new System.Drawing.Point(10, 195);
            this.ctrlDriverLicenceInfo1.Name = "ctrlDriverLicenceInfo1";
            this.ctrlDriverLicenceInfo1.Size = new System.Drawing.Size(880, 330);
            this.ctrlDriverLicenceInfo1.TabIndex = 2;
            // 
            // ctrlInternationalLicenseApplicationInfo1
            // 
            this.ctrlInternationalLicenseApplicationInfo1.Location = new System.Drawing.Point(25, 532);
            this.ctrlInternationalLicenseApplicationInfo1.Name = "ctrlInternationalLicenseApplicationInfo1";
            this.ctrlInternationalLicenseApplicationInfo1.Size = new System.Drawing.Size(850, 176);
            this.ctrlInternationalLicenseApplicationInfo1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(620, 720);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Enabled = false;
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnIssue.ForeColor = System.Drawing.Color.White;
            this.btnIssue.Location = new System.Drawing.Point(750, 720);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(120, 36);
            this.btnIssue.TabIndex = 5;
            this.btnIssue.Text = "Issue";
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // frmIssueInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(900, 770);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlInternationalLicenseApplicationInfo1);
            this.Controls.Add(this.ctrlDriverLicenceInfo1);
            this.Controls.Add(this.ctrlLicenseIdFilter1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIssueInternationalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New International License Application";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private ctrlLicenseIdFilter ctrlLicenseIdFilter1;
        private ctrlDriverLicenceInfo ctrlDriverLicenceInfo1;
        private ctrlInternationalLicenseApplicationInfo ctrlInternationalLicenseApplicationInfo1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnIssue;
    }
}
