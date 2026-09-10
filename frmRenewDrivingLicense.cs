using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmRenewDrivingLicense : Form
    {
        private bool _isRenewed;
        private int _renewalApplicationID = -1;
        private int _renewedLicenseID = -1;

        public frmRenewDrivingLicense()
        {
            InitializeComponent();
            ctrlLicenseIdFilter1.LicenseSelected += ctrlLicenseIdFilter1_LicenseSelected;
        }

        private void frmRenewDrivingLicense_Load(object sender, EventArgs e)
        {
            string currentUserName = clsGlobal.CurrentUser?.UserName ?? "Unknown User";
            DateTime currentDateTime = DateTime.Now;
            ctrlRenewLicenseApplicationInfo1.SetDefaultInfo(currentDateTime, currentUserName);
            ctrlRenewLicenseApplicationInfo1.SetApplicationFees(clsApplicationType.GetApplicationFees(2) ?? 0); // Assuming 2 is the ApplicationTypeID for renewal TODO: Add ApplaicationTypeID for renewal in a constant or enum for better readability
        }

        private void ctrlLicenseIdFilter1_LicenseSelected(object sender, EventArgs e)
        {
            ResetRenewalSelection();

            int selectedLicenseID = ctrlLicenseIdFilter1.SelectedLicenseID;
            bool licenseLoaded = ctrlDriverLicenceInfo1.LoadLicenseInfo(selectedLicenseID);

            if (!licenseLoaded || !IsSelectedLicenseEligibleForRenewal())
                return;

            ctrlRenewLicenseApplicationInfo1.SetOldLicenseID(ctrlDriverLicenceInfo1.LicenseID);
            ctrlRenewLicenseApplicationInfo1.SetLicenseRenewalInfo(
                ctrlDriverLicenceInfo1.ClassFees,
                ctrlDriverLicenceInfo1.DefaultValidityLength);
            btnRenew.Enabled = true;
        }

        private void ResetRenewalSelection()
        {
            btnRenew.Enabled = false;
            ctrlRenewLicenseApplicationInfo1.ClearLicenseRenewalInfo();
        }

        private bool IsSelectedLicenseEligibleForRenewal()
        {
            if (!ctrlDriverLicenceInfo1.IsActive)
            {
                MessageBox.Show("The selected license is not active.",
                    "Renew License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ctrlDriverLicenceInfo1.IsDetained)
            {
                MessageBox.Show("The selected license is detained and cannot be renewed.",
                    "Renew License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ctrlDriverLicenceInfo1.ExpirationDate.Date > DateTime.Today)
            {
                MessageBox.Show("The selected license has not expired yet.",
                    "Renew License", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (_isRenewed)
                return;

            if (ctrlDriverLicenceInfo1.LicenseID <= 0 ||
                !IsSelectedLicenseEligibleForRenewal())
            {
                btnRenew.Enabled = false;
                return;
            }

            if (clsGlobal.CurrentUser == null ||
                !clsGlobal.CurrentUser.IsActive ||
                clsGlobal.CurrentUser.UserID <= 0)
            {
                MessageBox.Show("A valid active user must be signed in to renew a license.",
                    "Renew License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            enRenewLicenseResult result;
            try
            {
                result = clsLicense.RenewLicense(
                    ctrlDriverLicenceInfo1.LicenseID,
                    ctrlRenewLicenseApplicationInfo1.Notes,
                    clsGlobal.CurrentUser.UserID,
                    out _renewalApplicationID,
                    out _renewedLicenseID);
            }
            catch (SqlException)
            {
                MessageBox.Show("The license could not be renewed because of a database error. Please try again.",
                    "Renew License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result != enRenewLicenseResult.Success ||
                _renewalApplicationID <= 0 || _renewedLicenseID <= 0)
            {
                btnRenew.Enabled = false;
                MessageBox.Show(GetRenewalResultMessage(result),
                    "Renew License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int oldLicenseID = ctrlDriverLicenceInfo1.LicenseID;
            _isRenewed = true;
            btnRenew.Enabled = false;
            ctrlLicenseIdFilter1.Enabled = false;

            try
            {
                ctrlDriverLicenceInfo1.LoadLicenseInfo(oldLicenseID);

                if (!LoadRenewalResultInfo(oldLicenseID))
                {
                    MessageBox.Show("The license was renewed successfully, but its details could not be loaded.",
                        "Renew License", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("The license was renewed successfully, but its details could not be loaded.",
                    "Renew License", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("License renewed successfully. New License ID: " +
                _renewedLicenseID, "Renew License",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool LoadRenewalResultInfo(int oldLicenseID)
        {
            DataTable renewalInfo = clsLicense.GetRenewedLicenseInfo(_renewedLicenseID);
            if (renewalInfo.Rows.Count == 0)
                return false;

            DataRow row = renewalInfo.Rows[0];
            ctrlRenewLicenseApplicationInfo1.LoadInfo(
                Convert.ToInt32(row["ApplicationID"]),
                Convert.ToInt32(row["RenewedLicenseID"]),
                oldLicenseID,
                Convert.ToDateTime(row["ApplicationDate"]),
                Convert.ToDateTime(row["IssueDate"]),
                Convert.ToDateTime(row["ExpirationDate"]),
                Convert.ToDecimal(row["ApplicationFees"]),
                Convert.ToDecimal(row["LicenseFees"]),
                row["CreatedBy"].ToString());

            return true;
        }

        private string GetRenewalResultMessage(enRenewLicenseResult result)
        {
            switch (result)
            {
                case enRenewLicenseResult.InvalidLicenseID:
                    return "Please find a valid license before renewing.";
                case enRenewLicenseResult.InvalidUser:
                    return "The current user is invalid or inactive.";
                case enRenewLicenseResult.NotesTooLong:
                    return "Notes cannot exceed 1000 characters.";
                case enRenewLicenseResult.LicenseNotFound:
                    return "The selected license was not found.";
                case enRenewLicenseResult.LicenseInactive:
                    return "The selected license is not active.";
                case enRenewLicenseResult.LicenseDetained:
                    return "The selected license is detained and cannot be renewed.";
                case enRenewLicenseResult.LicenseNotExpired:
                    return "The selected license has not expired yet.";
                case enRenewLicenseResult.ApplicationTypeNotFound:
                    return "The renewal application type was not found.";
                case enRenewLicenseResult.ApplicationCreationFailed:
                    return "The renewal application could not be created.";
                case enRenewLicenseResult.LicenseCreationFailed:
                    return "The renewed license could not be created.";
                case enRenewLicenseResult.OldLicenseDeactivationFailed:
                    return "The old license could not be deactivated.";
                default:
                    return "The renewal application could not be completed.";
            }
        }

    }
}
