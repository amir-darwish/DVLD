using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        private readonly int _LocalDrivingLicenseApplicationID;

        public bool LicenseIssued { get; private set; }
        public int LicenseID { get; private set; } = -1;

        public frmIssueDriverLicenseFirstTime(int localDrivingLicenseApplicationID)
        {
            if (localDrivingLicenseApplicationID <= 0)
                throw new ArgumentOutOfRangeException(nameof(localDrivingLicenseApplicationID));

            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            ctrlLocalDrivingLicenseApplicationInfo1.ViewPersonInfoRequested +=
                ctrlLocalDrivingLicenseApplicationInfo1_ViewPersonInfoRequested;
            ctrlLocalDrivingLicenseApplicationInfo1.ShowLicenseInfoRequested +=
                ctrlLocalDrivingLicenseApplicationInfo1_ShowLicenseInfoRequested;
        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            bool loaded = ctrlLocalDrivingLicenseApplicationInfo1
                .LoadApplicationInfo(_LocalDrivingLicenseApplicationID);
            btnIssue.Enabled = loaded;

            if (!loaded)
                return;

            try
            {
                clsLicense.enFirstTimeLicenseIssueResult validationResult =
                    clsLicense.ValidateFirstTimeLicenseIssue(
                    _LocalDrivingLicenseApplicationID);

                if (validationResult != clsLicense.enFirstTimeLicenseIssueResult.Eligible)
                {
                    btnIssue.Enabled = false;
                    MessageBox.Show(GetIssueResultMessage(validationResult),
                        "Issue License", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (SqlException)
            {
                btnIssue.Enabled = false;
                MessageBox.Show("The application eligibility could not be checked. Please try again.",
                    "Issue License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlLocalDrivingLicenseApplicationInfo1_ViewPersonInfoRequested(
            object sender, EventArgs e)
        {
            int personID = ctrlLocalDrivingLicenseApplicationInfo1.ApplicantPersonID;
            if (personID <= 0)
                return;

            using (frmShowPersonInfo frm = new frmShowPersonInfo(personID))
            {
                frm.ShowDialog(this);
            }
        }

        private void ctrlLocalDrivingLicenseApplicationInfo1_ShowLicenseInfoRequested(
            object sender, EventArgs e)
        {
            int licenseID = ctrlLocalDrivingLicenseApplicationInfo1.LicenseID;
            if (licenseID <= 0)
                return;

            using (frmShowDriverLicenceInfo frm =
                new frmShowDriverLicenceInfo(licenseID))
            {
                frm.ShowDialog(this);
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser == null ||
                !clsGlobal.CurrentUser.IsActive ||
                clsGlobal.CurrentUser.UserID <= 0)
            {
                MessageBox.Show("A valid active user must be signed in to issue a license.",
                    "Issue License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int licenseID;
                clsLicense.enFirstTimeLicenseIssueResult issueResult =
                    clsLicense.IssueFirstTimeLicense(
                    _LocalDrivingLicenseApplicationID,
                    txtNotes.Text,
                    clsGlobal.CurrentUser.UserID,
                    out licenseID);

                if (issueResult != clsLicense.enFirstTimeLicenseIssueResult.Success ||
                    licenseID <= 0)
                {
                    MessageBox.Show(GetIssueResultMessage(issueResult),
                        "Issue License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LicenseID = licenseID;
                LicenseIssued = true;
                btnIssue.Enabled = false;
                txtNotes.ReadOnly = true;
                ctrlLocalDrivingLicenseApplicationInfo1
                    .LoadApplicationInfo(_LocalDrivingLicenseApplicationID);

                MessageBox.Show("License issued successfully. License ID: " + LicenseID,
                    "Issue License", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException)
            {
                MessageBox.Show("The license could not be issued because of a database error. Please try again.",
                    "Issue License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetIssueResultMessage(
            clsLicense.enFirstTimeLicenseIssueResult result)
        {
            switch (result)
            {
                case clsLicense.enFirstTimeLicenseIssueResult.InvalidLocalApplicationID:
                    return "The local driving license application ID is invalid.";
                case clsLicense.enFirstTimeLicenseIssueResult.InvalidUser:
                    return "The current user is invalid.";
                case clsLicense.enFirstTimeLicenseIssueResult.NotesTooLong:
                    return "Notes cannot exceed 1000 characters.";
                case clsLicense.enFirstTimeLicenseIssueResult.ApplicationNotFound:
                    return "Application details were not found.";
                case clsLicense.enFirstTimeLicenseIssueResult.ApplicationIsNotNew:
                    return "Only a New application can be used to issue a first-time license.";
                case clsLicense.enFirstTimeLicenseIssueResult.LicenseAlreadyIssued:
                    return "A license has already been issued for this application.";
                case clsLicense.enFirstTimeLicenseIssueResult.TestsNotPassed:
                    return "The applicant must pass the vision, written, and street tests first.";
                case clsLicense.enFirstTimeLicenseIssueResult.DriverCreationFailed:
                    return "The driver record could not be created.";
                case clsLicense.enFirstTimeLicenseIssueResult.LicenseCreationFailed:
                    return "The license could not be created.";
                case clsLicense.enFirstTimeLicenseIssueResult.ApplicationCompletionFailed:
                    return "The application status could not be completed.";
                default:
                    return "The license could not be issued.";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
