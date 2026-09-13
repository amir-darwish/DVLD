namespace DVLD
{
    partial class frmRenewDrivingLicense
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
            this.ctrlLicenseIdFilter1 = new DVLD.ctrlLicenseIdFilter();
            this.ctrlDriverLicenceInfo1 = new DVLD.ctrlDriverLicenceInfo();
            this.ctrlRenewLicenseApplicationInfo1 = new DVLD.ctrlRenewLicenseApplicationInfo();
            this.btnRenew = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // ctrlLicenseIdFilter1
            // 
            this.ctrlLicenseIdFilter1.Location = new System.Drawing.Point(12, 12);
            this.ctrlLicenseIdFilter1.Name = "ctrlLicenseIdFilter1";
            this.ctrlLicenseIdFilter1.Size = new System.Drawing.Size(903, 90);
            this.ctrlLicenseIdFilter1.TabIndex = 0;
            // 
            // ctrlDriverLicenceInfo1
            // 
            this.ctrlDriverLicenceInfo1.Location = new System.Drawing.Point(12, 124);
            this.ctrlDriverLicenceInfo1.Name = "ctrlDriverLicenceInfo1";
            this.ctrlDriverLicenceInfo1.Size = new System.Drawing.Size(903, 306);
            this.ctrlDriverLicenceInfo1.TabIndex = 1;
            //
            // ctrlRenewLicenseApplicationInfo1
            //
            this.ctrlRenewLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 436);
            this.ctrlRenewLicenseApplicationInfo1.Name = "ctrlRenewLicenseApplicationInfo1";
            this.ctrlRenewLicenseApplicationInfo1.Size = new System.Drawing.Size(903, 265);
            this.ctrlRenewLicenseApplicationInfo1.TabIndex = 2;
            //
            // btnRenew
            //
            this.btnRenew.Enabled = false;
            this.btnRenew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRenew.ForeColor = System.Drawing.Color.White;
            this.btnRenew.Location = new System.Drawing.Point(795, 707);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(120, 36);
            this.btnRenew.TabIndex = 3;
            this.btnRenew.Text = "Renew";
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // frmRenewDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 747);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.ctrlRenewLicenseApplicationInfo1);
            this.Controls.Add(this.ctrlDriverLicenceInfo1);
            this.Controls.Add(this.ctrlLicenseIdFilter1);
            this.Name = "frmRenewDrivingLicense";
            this.Text = "frmRenewDrivingLicense";
            this.Load += new System.EventHandler(this.frmRenewDrivingLicense_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlLicenseIdFilter ctrlLicenseIdFilter1;
        private ctrlDriverLicenceInfo ctrlDriverLicenceInfo1;
        private ctrlRenewLicenseApplicationInfo ctrlRenewLicenseApplicationInfo1;
        private Guna.UI2.WinForms.Guna2Button btnRenew;
    }
}
