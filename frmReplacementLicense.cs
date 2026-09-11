using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmReplacementLicense : Form
    {
        private const int LostReplacementApplicationTypeID = 3;
        private const int DamagedReplacementApplicationTypeID = 4;

        private bool _isReplaced;
        private bool _applicationTypeAvailable;
        private int _replacementApplicationID = -1;
        private int _replacedLicenseID = -1;

        public frmReplacementLicense()
        {
            InitializeComponent();
            ctrlLicenseIdFilter1.LicenseSelected += ctrlLicenseIdFilter1_LicenseSelected;
        }

        private enLicenseReplacementType SelectedReplacementType
        {
            get
            {
                return rbLost.Checked
                    ? enLicenseReplacementType.Lost
                    : enLicenseReplacementType.Damaged;
            }
        }

        private int SelectedApplicationTypeID
        {
            get
            {
                return rbLost.Checked
                    ? LostReplacementApplicationTypeID
                    : DamagedReplacementApplicationTypeID;
            }
        }

        private void frmReplacementLicense_Load(object sender, EventArgs e)
        {
            string currentUserName = clsGlobal.CurrentUser?.UserName ?? "Unknown User";
            ctrlReplacementLicenseApplicationInfo1.SetDefaultInfo(DateTime.Now, currentUserName);
            UpdateReplacementTypeInfo();
        }

        private void ReplacementType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;
            if (selectedRadioButton == null || !selectedRadioButton.Checked || _isReplaced)
                return;

            UpdateReplacementTypeInfo();
        }

        private void UpdateReplacementTypeInfo()
        {
            string replacementReason = rbLost.Checked ? "Lost" : "Damaged";
            Text = "Replacement for " + replacementReason + " License";
            lblTitle.Text = Text;

            _applicationTypeAvailable = false;
            btnIssueReplacement.Enabled = false;
            ctrlReplacementLicenseApplicationInfo1.ClearLicenseSelection();

            try
            {
                decimal? applicationFees = clsApplicationType.GetApplicationFees(
                    SelectedApplicationTypeID);

                if (!applicationFees.HasValue)
                {
                    MessageBox.Show("The selected replacement application type was not found.",
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _applicationTypeAvailable = true;
                ctrlReplacementLicenseApplicationInfo1.SetApplicationFees(applicationFees.Value);

                if (IsSelectedLicenseEligible(false))
                {
                    ctrlReplacementLicenseApplicationInfo1.SetOldLicenseID(
                        ctrlDriverLicenceInfo1.LicenseID);
                    btnIssueReplacement.Enabled = true;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("The replacement fees could not be loaded because of a database error.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlLicenseIdFilter1_LicenseSelected(object sender, EventArgs e)
        {
            ResetReplacementSelection();

            if (!ctrlDriverLicenceInfo1.LoadLicenseInfo(
                ctrlLicenseIdFilter1.SelectedLicenseID))
                return;

            if (!IsSelectedLicenseEligible(true))
                return;

            ctrlReplacementLicenseApplicationInfo1.SetOldLicenseID(
                ctrlDriverLicenceInfo1.LicenseID);
            btnIssueReplacement.Enabled = _applicationTypeAvailable;
        }

        private void ResetReplacementSelection()
        {
            btnIssueReplacement.Enabled = false;
            ctrlReplacementLicenseApplicationInfo1.ClearLicenseSelection();
        }

        private bool IsSelectedLicenseEligible(bool showMessage)
        {
            if (ctrlDriverLicenceInfo1.LicenseID <= 0)
                return false;

            if (!ctrlDriverLicenceInfo1.IsActive)
                return RejectLicense("The selected license is not active.", showMessage);

            if (ctrlDriverLicenceInfo1.IsDetained)
                return RejectLicense(
                    "The selected license is detained and cannot be replaced.", showMessage);

            if (ctrlDriverLicenceInfo1.ExpirationDate.Date <= DateTime.Today)
                return RejectLicense(
                    "The selected license is expired and cannot be replaced. Renew it instead.",
                    showMessage);

            return true;
        }

        private bool RejectLicense(string message, bool showMessage)
        {
            if (showMessage)
            {
                MessageBox.Show(message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            return false;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (_isReplaced)
                return;

            if (!_applicationTypeAvailable || !IsSelectedLicenseEligible(true))
            {
                btnIssueReplacement.Enabled = false;
                return;
            }

            if (clsGlobal.CurrentUser == null || !clsGlobal.CurrentUser.IsActive ||
                clsGlobal.CurrentUser.UserID <= 0)
            {
                MessageBox.Show(
                    "A valid active user must be signed in to replace a license.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            enReplaceLicenseResult result;

            try
            {
                result = clsLicense.ReplaceLicense(
                    ctrlDriverLicenceInfo1.LicenseID,
                    SelectedReplacementType,
                    clsGlobal.CurrentUser.UserID,
                    out _replacementApplicationID,
                    out _replacedLicenseID);
            }
            catch (SqlException)
            {
                MessageBox.Show(
                    "The license could not be replaced because of a database error. Please try again.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result != enReplaceLicenseResult.Success ||
                _replacementApplicationID <= 0 || _replacedLicenseID <= 0)
            {
                btnIssueReplacement.Enabled = false;
                MessageBox.Show(GetReplacementResultMessage(result), Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int oldLicenseID = ctrlDriverLicenceInfo1.LicenseID;
            _isReplaced = true;
            btnIssueReplacement.Enabled = false;
            ctrlLicenseIdFilter1.Enabled = false;
            gbReplacementFor.Enabled = false;
            llShowNewLicenseInfo.Enabled = true;

            try
            {
                ctrlDriverLicenceInfo1.LoadLicenseInfo(oldLicenseID);

                if (!LoadReplacementResultInfo(oldLicenseID))
                {
                    ShowReplacementSucceededButDetailsFailed();
                    return;
                }
            }
            catch (SqlException)
            {
                ShowReplacementSucceededButDetailsFailed();
                return;
            }

            MessageBox.Show("License replaced successfully. New License ID: " +
                _replacedLicenseID, Text, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ShowReplacementSucceededButDetailsFailed()
        {
            MessageBox.Show(
                "The license was replaced successfully, but its details could not be loaded. New License ID: " +
                _replacedLicenseID, Text, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private bool LoadReplacementResultInfo(int oldLicenseID)
        {
            DataTable replacementInfo = clsLicense.GetReplacedLicenseInfo(_replacedLicenseID);
            if (replacementInfo.Rows.Count == 0)
                return false;

            DataRow row = replacementInfo.Rows[0];
            ctrlReplacementLicenseApplicationInfo1.LoadInfo(
                Convert.ToInt32(row["ApplicationID"]),
                Convert.ToInt32(row["ReplacedLicenseID"]),
                oldLicenseID,
                Convert.ToDateTime(row["ApplicationDate"]),
                Convert.ToDecimal(row["ApplicationFees"]),
                row["CreatedBy"].ToString());

            return true;
        }

        private string GetReplacementResultMessage(enReplaceLicenseResult result)
        {
            switch (result)
            {
                case enReplaceLicenseResult.InvalidLicenseID:
                    return "Please find a valid license before replacing.";
                case enReplaceLicenseResult.InvalidUser:
                    return "The current user is invalid or inactive.";
                case enReplaceLicenseResult.InvalidReplacementType:
                    return "The selected replacement type is invalid.";
                case enReplaceLicenseResult.LicenseNotFound:
                    return "The selected license was not found.";
                case enReplaceLicenseResult.LicenseInactive:
                    return "The selected license is not active.";
                case enReplaceLicenseResult.LicenseDetained:
                    return "The selected license is detained and cannot be replaced.";
                case enReplaceLicenseResult.LicenseExpired:
                    return "The selected license is expired and cannot be replaced. Renew it instead.";
                case enReplaceLicenseResult.ApplicationTypeNotFound:
                    return "The replacement application type was not found.";
                case enReplaceLicenseResult.ApplicationCreationFailed:
                    return "The replacement application could not be created.";
                case enReplaceLicenseResult.LicenseCreationFailed:
                    return "The replacement license could not be created.";
                case enReplaceLicenseResult.OldLicenseDeactivationFailed:
                    return "The old license could not be deactivated.";
                default:
                    return "The replacement application could not be completed.";
            }
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            if (_replacedLicenseID <= 0)
                return;

            using (frmShowDriverLicenceInfo frm =
                new frmShowDriverLicenceInfo(_replacedLicenseID))
            {
                frm.ShowDialog(this);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
