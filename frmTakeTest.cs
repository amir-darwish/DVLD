using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID = -1;
        private bool _CanSave = false;

        public frmTakeTest()
        {
            InitializeComponent();
            // Keep the result unselected when the form opens.
            ActiveControl = txtNotes;
        }

        public frmTakeTest(int testAppointmentID)
            : this()
        {
            if (testAppointmentID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(testAppointmentID));
            }

            _TestAppointmentID = testAppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            LoadTestInfo();
        }

        private void LoadTestInfo()
        {
            _CanSave = false;
            btnSave.Enabled = false;

            try
            {
                using (DataTable dtTakeTestInfo =
                    clsTests.GetTakeTestInfo(_TestAppointmentID))
                {
                    if (dtTakeTestInfo.Rows.Count == 0)
                    {
                        ShowDataNotFoundError();
                        return;
                    }

                    DataRow row = dtTakeTestInfo.Rows[0];
                    FillAppointmentInfo(row);

                    if (row.IsNull("TestID"))
                    {
                        PrepareForNewTest(Convert.ToBoolean(row["IsLocked"]));
                        return;
                    }

                    DisplaySavedTest(row);
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show(
                    "Test information could not be loaded. Please try again.",
                    "Take Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FillAppointmentInfo(DataRow row)
        {
            lbDLAppID.Text =
                row["LocalDrivingLicenseApplicationID"].ToString();

            lbDrivingClass.Text = row["ClassName"].ToString();
            lbApplicantName.Text = row["ApplicantName"].ToString();
            lbTrial.Text = row["Trial"].ToString();

            lbAppointmentDate.Text =
                Convert.ToDateTime(row["AppointmentDate"])
                .ToString("dd/MM/yyyy");

            lbTestFees.Text =
                Convert.ToDecimal(row["TestFees"])
                .ToString("0.##");

            string title = row["TestTypeTitle"] + " - Take Test";
            lbTitle.Text = title;
            Text = title;
        }

        private void PrepareForNewTest(bool isLocked)
        {
            lbTestID.Text = "Not taken yet";
            rbPass.Checked = false;
            rbFail.Checked = false;
            txtNotes.Clear();

            gbResult.Enabled = !isLocked;
            txtNotes.ReadOnly = isLocked;
            _CanSave = !isLocked;
            btnSave.Enabled = _CanSave;

            if (isLocked)
            {
                MessageBox.Show(
                    "This appointment is locked, but no test result was found.",
                    "Take Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void DisplaySavedTest(DataRow row)
        {
            lbTestID.Text = row["TestID"].ToString();

            bool passed = Convert.ToBoolean(row["TestResult"]);
            rbPass.Checked = passed;
            rbFail.Checked = !passed;

            txtNotes.Text = row.IsNull("Notes")
                ? string.Empty
                : row["Notes"].ToString();

            _CanSave = false;
            gbResult.Enabled = false;
            txtNotes.ReadOnly = true;
            btnSave.Enabled = false;
        }

        private void ShowDataNotFoundError()
        {
            MessageBox.Show(
                "Test appointment information was not found.",
                "Take Test",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.IsLoggedIn() || clsGlobal.CurrentUser.UserID <= 0)
            {
                MessageBox.Show(
                    "There is no logged-in user.",
                    "Take Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!TryGetSelectedResult(out bool testResult))
            {
                MessageBox.Show(
                    "Please select a test result (Pass or Fail) before saving.",
                    "Take Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                "The test result cannot be changed after saving. Do you want to continue?",
                "Confirm Test Result",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            _CanSave = false;
            btnSave.Enabled = false;

            try
            {
                int newTestID = clsTests.AddNewTest(
                    _TestAppointmentID,
                    testResult,
                    txtNotes.Text.Trim(),
                    clsGlobal.CurrentUser.UserID);

                if (newTestID <= 0)
                {
                    MessageBox.Show(
                        "The result was not saved. The appointment may already be locked or have a result.",
                        "Take Test",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    LoadTestInfo();
                    return;
                }

                lbTestID.Text = newTestID.ToString();

                MessageBox.Show(
                    "Test result saved successfully.",
                    "Take Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show(
                    "Test result could not be saved. Please refresh the appointment and try again.",
                    "Take Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                LoadTestInfo();
            }
            finally
            {
                if (!IsDisposed)
                {
                    btnSave.Enabled = _CanSave;
                }
            }
        }

        private bool TryGetSelectedResult(out bool testResult)
        {
            testResult = false;

            if (!rbPass.Checked && !rbFail.Checked)
            {
                return false;
            }

            testResult = rbPass.Checked;
            return true;
        }
    }
}
