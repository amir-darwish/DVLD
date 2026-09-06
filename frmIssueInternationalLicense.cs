using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmIssueInternationalLicense : Form
    {
        private bool _licenseIssued;

        public frmIssueInternationalLicense()
        {
            InitializeComponent();
            ctrlLicenseIdFilter1.LicenseSelected +=
                ctrlLicenseIdFilter1_LicenseSelected;
        }

        private void ctrlLicenseIdFilter1_LicenseSelected(object sender, EventArgs e)
        {
            bool licenseLoaded = ctrlDriverLicenceInfo1.LoadLicenseInfo(
                ctrlLicenseIdFilter1.SelectedLicenseID);

            btnIssue.Enabled = licenseLoaded && !_licenseIssued;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (ctrlDriverLicenceInfo1.LicenseID <= 0)
            {
                MessageBox.Show("Please find a valid local license before issuing.",
                    "Issue International License", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (clsGlobal.CurrentUser == null ||
                !clsGlobal.CurrentUser.IsActive ||
                clsGlobal.CurrentUser.UserID <= 0)
            {
                MessageBox.Show("A valid active user must be signed in to issue a license.",
                    "Issue International License", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int internationalLicenseID;
            clsInternationalLicense.enIssueInternationalLicenseResult result;

            try
            {
                result =
                    clsInternationalLicense.IssueInternationalLicense(
                        ctrlDriverLicenceInfo1.LicenseID,
                        clsGlobal.CurrentUser.UserID,
                        out internationalLicenseID);
            }
            catch (SqlException)
            {
                MessageBox.Show("The international license could not be issued because of a database error. Please try again.",
                    "Issue International License", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            if (result != clsInternationalLicense.enIssueInternationalLicenseResult.Success ||
                internationalLicenseID <= 0)
            {
                MessageBox.Show(GetIssueResultMessage(result),
                    "Issue International License", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _licenseIssued = true;
            btnIssue.Enabled = false;

            try
            {
                if (!LoadIssuedInternationalLicenseInfo(internationalLicenseID))
                {
                    MessageBox.Show("International license was issued successfully, but its details could not be loaded.",
                        "Issue International License", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("International license issued successfully. License ID: " +
                    internationalLicenseID, "Issue International License",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException)
            {
                MessageBox.Show("International license was issued successfully, but its details could not be loaded.",
                    "Issue International License", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private bool LoadIssuedInternationalLicenseInfo(int internationalLicenseID)
        {
            DataTable internationalLicenseInfo =
                clsInternationalLicense.GetInternationalLicenseInfo(internationalLicenseID);

            if (internationalLicenseInfo.Rows.Count == 0)
                return false;

            DataRow row = internationalLicenseInfo.Rows[0];
            ctrlInternationalLicenseApplicationInfo1.LoadInfo(
                Convert.ToInt32(row["ApplicationID"]),
                Convert.ToInt32(row["InternationalLicenseID"]),
                Convert.ToInt32(row["LicenseID"]),
                Convert.ToDateTime(row["ApplicationDate"]),
                Convert.ToDateTime(row["IssueDate"]),
                Convert.ToDateTime(row["ExpirationDate"]),
                Convert.ToDecimal(row["PaidFees"]),
                row["CreatedByUserName"].ToString());

            return true;
        }

        private string GetIssueResultMessage(
            clsInternationalLicense.enIssueInternationalLicenseResult result)
        {
            switch (result)
            {
                case clsInternationalLicense.enIssueInternationalLicenseResult.LocalLicenseNotFound:
                    return "The local license was not found.";
                case clsInternationalLicense.enIssueInternationalLicenseResult.LocalLicenseExpired:
                    return "The local license has expired.";
                case clsInternationalLicense.enIssueInternationalLicenseResult.LocalLicenseInactive:
                    return "The local license is not active.";
                case clsInternationalLicense.enIssueInternationalLicenseResult.ActiveInternationalLicenseAlreadyExists:
                    return "The driver already has an active international license.";
                case clsInternationalLicense.enIssueInternationalLicenseResult.ApplicationTypeNotFound:
                    return "The international license application type was not found.";
                case clsInternationalLicense.enIssueInternationalLicenseResult.ApplicationCreationFailed:
                    return "The international license application could not be created.";
                case clsInternationalLicense.enIssueInternationalLicenseResult.InternationalLicenseCreationFailed:
                    return "The international license record could not be created.";
                default:
                    return "The international license could not be issued.";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
