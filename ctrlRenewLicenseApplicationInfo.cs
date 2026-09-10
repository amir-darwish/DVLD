using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlRenewLicenseApplicationInfo : UserControl
    {
        private decimal _applicationFees;
        public string Notes
        {
            get { return txtNotes.Text.Trim(); }
        }

        public ctrlRenewLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(
            int renewalApplicationID,
            int renewedLicenseID,
            int oldLicenseID,
            DateTime applicationDate,
            DateTime issueDate,
            DateTime expirationDate,
            decimal applicationFees,
            decimal licenseFees,
            string createdBy)
        {
            _applicationFees = applicationFees;

            lbRenewApplicationID.Text = renewalApplicationID > 0
                ? renewalApplicationID.ToString()
                : "[???]";

            lbRenewedLicenseID.Text = renewedLicenseID > 0
                ? renewedLicenseID.ToString()
                : "[???]";

            lbOldLicenseID.Text = oldLicenseID > 0
                ? oldLicenseID.ToString()
                : "[???]";

            lbApplicationDate.Text = applicationDate.ToString("dd/MM/yyyy");
            lbIssueDate.Text = issueDate.ToString("dd/MM/yyyy");
            lbExpirationDate.Text = expirationDate.ToString("dd/MM/yyyy");
            lbApplicationFees.Text = applicationFees.ToString("0.##");
            lbLicenseFees.Text = licenseFees.ToString("0.##");
            lbTotalFees.Text = (applicationFees + licenseFees).ToString("0.##");
            lbCreatedBy.Text = string.IsNullOrWhiteSpace(createdBy)
                ? "##"
                : createdBy;
        }

        public void ClearInfo()
        {
            _applicationFees = 0;
            lbRenewApplicationID.Text = "[???]";
            lbRenewedLicenseID.Text = "[???]";
            lbOldLicenseID.Text = "[???]";
            lbApplicationDate.Text = "##";
            lbIssueDate.Text = "##";
            lbExpirationDate.Text = "##";
            lbApplicationFees.Text = "##";
            lbLicenseFees.Text = "##";
            lbTotalFees.Text = "##";
            lbCreatedBy.Text = "##";
            txtNotes.Clear();
        }

        private void gbApplicationInfo_Enter(object sender, EventArgs e)
        {

        }

        public void SetOldLicenseID(int licenseID)
        {
            lbOldLicenseID.Text = licenseID > 0
                ? licenseID.ToString()
                : "[???]";
        }
        public void SetDefaultInfo(DateTime currentDate, string createdBy)
        {
            lbCreatedBy.Text = string.IsNullOrWhiteSpace(createdBy)
                ? "##"
                : createdBy;
            lbApplicationDate.Text = currentDate.ToString("dd/MM/yyyy");
            lbIssueDate.Text = currentDate.ToString("dd/MM/yyyy");
        }
        public void SetApplicationFees(decimal applicationFees)
        {
            _applicationFees = applicationFees;
            lbApplicationFees.Text = applicationFees.ToString("0.##");
        }

        public void ClearLicenseRenewalInfo()
        {
            lbOldLicenseID.Text = "[???]";
            lbLicenseFees.Text = "##";
            lbExpirationDate.Text = "##";
            lbTotalFees.Text = _applicationFees.ToString("0.##");
        }

        public void SetLicenseRenewalInfo(decimal licenseFees, int validityYears)
        {
            DateTime expirationDate = DateTime.Now.AddYears(validityYears);
            decimal totalFees = licenseFees + _applicationFees;

            lbLicenseFees.Text = licenseFees.ToString("0.##");
           
            lbExpirationDate.Text = expirationDate.ToString("dd/MM/yyyy");

            lbTotalFees.Text = totalFees.ToString("0.##");

        }
    }
}
