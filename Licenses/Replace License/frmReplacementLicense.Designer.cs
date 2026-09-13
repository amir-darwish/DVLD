namespace DVLD
{
    partial class frmReplacementLicense
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
            this.gbReplacementFor = new System.Windows.Forms.GroupBox();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.llShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.llShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnIssueReplacement = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlReplacementLicenseApplicationInfo1 = new DVLD.ctrlReplacementLicenseApplicationInfo();
            this.ctrlDriverLicenceInfo1 = new DVLD.ctrlDriverLicenceInfo();
            this.ctrlLicenseIdFilter1 = new DVLD.ctrlLicenseIdFilter();
            this.gbReplacementFor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitle.Location = new System.Drawing.Point(234, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(454, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Replacement for Lost License";
            // 
            // gbReplacementFor
            // 
            this.gbReplacementFor.Controls.Add(this.rbLost);
            this.gbReplacementFor.Controls.Add(this.rbDamaged);
            this.gbReplacementFor.Location = new System.Drawing.Point(646, 55);
            this.gbReplacementFor.Name = "gbReplacementFor";
            this.gbReplacementFor.Size = new System.Drawing.Size(262, 90);
            this.gbReplacementFor.TabIndex = 2;
            this.gbReplacementFor.TabStop = false;
            this.gbReplacementFor.Text = "Replacement For";
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Checked = true;
            this.rbLost.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.rbLost.Location = new System.Drawing.Point(17, 55);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(104, 22);
            this.rbLost.TabIndex = 1;
            this.rbLost.TabStop = true;
            this.rbLost.Text = "Lost License";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.ReplacementType_CheckedChanged);
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.rbDamaged.Location = new System.Drawing.Point(17, 25);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(138, 22);
            this.rbDamaged.TabIndex = 0;
            this.rbDamaged.Text = "Damaged License";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.ReplacementType_CheckedChanged);
            // 
            // llShowLicensesHistory
            // 
            this.llShowLicensesHistory.AutoSize = true;
            this.llShowLicensesHistory.Enabled = false;
            this.llShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.llShowLicensesHistory.Location = new System.Drawing.Point(22, 623);
            this.llShowLicensesHistory.Name = "llShowLicensesHistory";
            this.llShowLicensesHistory.Size = new System.Drawing.Size(153, 18);
            this.llShowLicensesHistory.TabIndex = 5;
            this.llShowLicensesHistory.TabStop = true;
            this.llShowLicensesHistory.Text = "Show Licenses History";
            // 
            // llShowNewLicenseInfo
            // 
            this.llShowNewLicenseInfo.AutoSize = true;
            this.llShowNewLicenseInfo.Enabled = false;
            this.llShowNewLicenseInfo.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.llShowNewLicenseInfo.Location = new System.Drawing.Point(203, 623);
            this.llShowNewLicenseInfo.Name = "llShowNewLicenseInfo";
            this.llShowNewLicenseInfo.Size = new System.Drawing.Size(157, 18);
            this.llShowNewLicenseInfo.TabIndex = 6;
            this.llShowNewLicenseInfo.TabStop = true;
            this.llShowNewLicenseInfo.Text = "Show New License Info";
            this.llShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowNewLicenseInfo_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.BorderColor = System.Drawing.Color.Gray;
            this.btnClose.BorderThickness = 1;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnClose.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(650, 650);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.BorderColor = System.Drawing.Color.Gray;
            this.btnIssueReplacement.BorderThickness = 1;
            this.btnIssueReplacement.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueReplacement.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueReplacement.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnIssueReplacement.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnIssueReplacement.Enabled = false;
            this.btnIssueReplacement.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnIssueReplacement.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnIssueReplacement.ForeColor = System.Drawing.Color.Black;
            this.btnIssueReplacement.Location = new System.Drawing.Point(780, 650);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(128, 36);
            this.btnIssueReplacement.TabIndex = 8;
            this.btnIssueReplacement.Text = "Issue Replacement";
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
            // 
            // ctrlReplacementLicenseApplicationInfo1
            // 
            this.ctrlReplacementLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 470);
            this.ctrlReplacementLicenseApplicationInfo1.Name = "ctrlReplacementLicenseApplicationInfo1";
            this.ctrlReplacementLicenseApplicationInfo1.Size = new System.Drawing.Size(896, 140);
            this.ctrlReplacementLicenseApplicationInfo1.TabIndex = 4;
            // 
            // ctrlDriverLicenceInfo1
            // 
            this.ctrlDriverLicenceInfo1.Location = new System.Drawing.Point(12, 151);
            this.ctrlDriverLicenceInfo1.Name = "ctrlDriverLicenceInfo1";
            this.ctrlDriverLicenceInfo1.Size = new System.Drawing.Size(896, 313);
            this.ctrlDriverLicenceInfo1.TabIndex = 3;
            // 
            // ctrlLicenseIdFilter1
            // 
            this.ctrlLicenseIdFilter1.Location = new System.Drawing.Point(12, 55);
            this.ctrlLicenseIdFilter1.Name = "ctrlLicenseIdFilter1";
            this.ctrlLicenseIdFilter1.Size = new System.Drawing.Size(628, 90);
            this.ctrlLicenseIdFilter1.TabIndex = 1;
            // 
            // frmReplacementLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 698);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.llShowNewLicenseInfo);
            this.Controls.Add(this.llShowLicensesHistory);
            this.Controls.Add(this.ctrlReplacementLicenseApplicationInfo1);
            this.Controls.Add(this.ctrlDriverLicenceInfo1);
            this.Controls.Add(this.gbReplacementFor);
            this.Controls.Add(this.ctrlLicenseIdFilter1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplacementLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replacement for Lost License";
            this.Load += new System.EventHandler(this.frmReplacementLicense_Load);
            this.gbReplacementFor.ResumeLayout(false);
            this.gbReplacementFor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private ctrlLicenseIdFilter ctrlLicenseIdFilter1;
        private System.Windows.Forms.GroupBox gbReplacementFor;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.RadioButton rbDamaged;
        private ctrlDriverLicenceInfo ctrlDriverLicenceInfo1;
        private ctrlReplacementLicenseApplicationInfo ctrlReplacementLicenseApplicationInfo1;
        private System.Windows.Forms.LinkLabel llShowLicensesHistory;
        private System.Windows.Forms.LinkLabel llShowNewLicenseInfo;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnIssueReplacement;
    }
}
