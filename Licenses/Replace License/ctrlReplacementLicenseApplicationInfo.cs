using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlReplacementLicenseApplicationInfo : UserControl
    {
        private decimal _applicationFees;

        public ctrlReplacementLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void SetDefaultInfo(DateTime applicationDate, string createdBy)
        {
            lbApplicationDate.Text = applicationDate.ToString("dd/MM/yyyy");
            lbCreatedBy.Text = string.IsNullOrWhiteSpace(createdBy)
                ? "##"
                : createdBy;
        }

        public void SetApplicationFees(decimal applicationFees)
        {
            _applicationFees = applicationFees;
            lbApplicationFees.Text = applicationFees.ToString("0.##");
        }

        public void SetOldLicenseID(int licenseID)
        {
            lbOldLicenseID.Text = licenseID > 0
                ? licenseID.ToString()
                : "[???]";
        }

        public void ClearLicenseSelection()
        {
            lbReplacementApplicationID.Text = "[???]";
            lbReplacedLicenseID.Text = "[???]";
            lbOldLicenseID.Text = "[???]";
            lbApplicationFees.Text = _applicationFees.ToString("0.##");
        }

        public void LoadInfo(int replacementApplicationID, int replacedLicenseID,
            int oldLicenseID, DateTime applicationDate, decimal applicationFees,
            string createdBy)
        {
            _applicationFees = applicationFees;
            lbReplacementApplicationID.Text = replacementApplicationID > 0
                ? replacementApplicationID.ToString()
                : "[???]";
            lbReplacedLicenseID.Text = replacedLicenseID > 0
                ? replacedLicenseID.ToString()
                : "[???]";
            lbOldLicenseID.Text = oldLicenseID > 0
                ? oldLicenseID.ToString()
                : "[???]";
            lbApplicationDate.Text = applicationDate.ToString("dd/MM/yyyy");
            lbApplicationFees.Text = applicationFees.ToString("0.##");
            lbCreatedBy.Text = string.IsNullOrWhiteSpace(createdBy)
                ? "##"
                : createdBy;
        }
    }
}
