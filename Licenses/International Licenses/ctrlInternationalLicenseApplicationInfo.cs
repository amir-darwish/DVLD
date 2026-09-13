using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlInternationalLicenseApplicationInfo : UserControl
    {
        public ctrlInternationalLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(
            int internationalApplicationID,
            int internationalLicenseID,
            int localLicenseID,
            DateTime applicationDate,
            DateTime issueDate,
            DateTime expirationDate,
            decimal fees,
            string createdBy)
        {
            lbInternationalApplicationID.Text =
                internationalApplicationID > 0 ? internationalApplicationID.ToString() : "[???]";

            lbInternationalLicenseID.Text =
                internationalLicenseID > 0 ? internationalLicenseID.ToString() : "[???]";

            lbLocalLicenseID.Text = localLicenseID.ToString();
            lbApplicationDate.Text = applicationDate.ToString("dd/MM/yyyy");
            lbIssueDate.Text = issueDate.ToString("dd/MM/yyyy");
            lbExpirationDate.Text = expirationDate.ToString("dd/MM/yyyy");
            lbFees.Text = fees.ToString("0.##");

            lbCreatedBy.Text = string.IsNullOrWhiteSpace(createdBy)
                ? "##"
                : createdBy;
        }
    }
}
