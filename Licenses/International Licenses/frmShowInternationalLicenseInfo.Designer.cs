namespace DVLD
{
    partial class frmShowInternationalLicenseInfo
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
            this.ctrlDriverLicenceInfo1 = new DVLD.ctrlDriverLicenceInfo();
            this.ctrlInternationalLicenseApplicationInfo1 = new DVLD.ctrlInternationalLicenseApplicationInfo();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F,
                System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitle.Location = new System.Drawing.Point(285, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(332, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "International License Info";
            // 
            // ctrlDriverLicenceInfo1
            // 
            this.ctrlDriverLicenceInfo1.Location = new System.Drawing.Point(10, 75);
            this.ctrlDriverLicenceInfo1.Name = "ctrlDriverLicenceInfo1";
            this.ctrlDriverLicenceInfo1.Size = new System.Drawing.Size(880, 330);
            this.ctrlDriverLicenceInfo1.TabIndex = 1;
            // 
            // ctrlInternationalLicenseApplicationInfo1
            // 
            this.ctrlInternationalLicenseApplicationInfo1.Location = new System.Drawing.Point(25, 415);
            this.ctrlInternationalLicenseApplicationInfo1.Name = "ctrlInternationalLicenseApplicationInfo1";
            this.ctrlInternationalLicenseApplicationInfo1.Size = new System.Drawing.Size(850, 176);
            this.ctrlInternationalLicenseApplicationInfo1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(750, 605);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowInternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(900, 655);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlInternationalLicenseApplicationInfo1);
            this.Controls.Add(this.ctrlDriverLicenceInfo1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowInternationalLicenseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "International License Info";
            this.Load += new System.EventHandler(this.frmShowInternationalLicenseInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private ctrlDriverLicenceInfo ctrlDriverLicenceInfo1;
        private ctrlInternationalLicenseApplicationInfo ctrlInternationalLicenseApplicationInfo1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}
