using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID = -1;

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
            btnSave.Enabled = !isLocked;

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

    }
}
