using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmAddTestAppointment : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _TestTypeID = -1;
        private decimal _TestFees = 0;

        public frmAddTestAppointment()
        {
            InitializeComponent();
        }

        public frmAddTestAppointment(int localDrivingLicenseApplicationID, int testTypeID)
            : this()
        {
            if (localDrivingLicenseApplicationID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(localDrivingLicenseApplicationID));
            }

            if (testTypeID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(testTypeID));
            }

            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _TestTypeID = testTypeID;
        }

        private void frmAddTestAppointment_Load(object sender, EventArgs e)
        {
            guna2DateTimePicker1.Value = DateTime.Today;
            guna2DateTimePicker1.MinDate = DateTime.Today;

            gbRetakeTest.Enabled = false;
            lbRFees.Text = "0";
            lbRtotalFees.Text = "0";
            lbRAPPID.Text = "N/A";

            LoadApplicationInfo();
            LoadTestTypeInfo();
            LoadTrialsCount();
        }

        private void LoadApplicationInfo()
        {
            DataTable dtApplicationInfo = clsLocalDrivingLicenseApp
                .GetLocalDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);

            if (dtApplicationInfo.Rows.Count == 0)
            {
                MessageBox.Show("Application information was not found.", "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Enabled = false;
                return;
            }

            DataRow row = dtApplicationInfo.Rows[0];

            lbDLAPPID.Text = row["LocalDrivingLicenseApplicationID"].ToString();
            lbDClass.Text = row["ClassName"].ToString();
            lbName.Text = row["ApplicantName"].ToString();
        }

        private void LoadTestTypeInfo()
        {
            DataTable dtTestTypes = clsTestType.GetAllTestTypes();
            DataRow testTypeRow = null;

            foreach (DataRow row in dtTestTypes.Rows)
            {
                if (Convert.ToInt32(row["TestTypeID"]) == _TestTypeID)
                {
                    testTypeRow = row;
                    break;
                }
            }

            if (testTypeRow == null)
            {
                MessageBox.Show("Test type information was not found.", "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Enabled = false;
                return;
            }

            lbTitle.Text = testTypeRow["TestTypeTitle"].ToString();
            _TestFees = Convert.ToDecimal(testTypeRow["TestTypeFees"]);
            lbFees.Text = _TestFees.ToString("0.##");
            lbRtotalFees.Text = _TestFees.ToString("0.##");
            Text = lbTitle.Text + " Appointment";
        }

        private void LoadTrialsCount()
        {
            DataTable dtAppointments = clsTestAppointments.GetTestAppointments(
                _LocalDrivingLicenseApplicationID,
                _TestTypeID);

            label2.Text = dtAppointments.Rows.Count.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.IsLoggedIn() || clsGlobal.CurrentUser.UserID <= 0)
            {
                MessageBox.Show("There is no logged-in user.", "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (guna2DateTimePicker1.Value.Date < DateTime.Today)
            {
                MessageBox.Show("The appointment date cannot be in the past.", "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsTestAppointments.IsThereAnActiveTestAppointment(
                _LocalDrivingLicenseApplicationID,
                _TestTypeID))
            {
                MessageBox.Show("There is already an active appointment for this test.", "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtPreviousAppointments = clsTestAppointments.GetTestAppointments(
                _LocalDrivingLicenseApplicationID,
                _TestTypeID);

            if (dtPreviousAppointments.Rows.Count > 0)
            {
                MessageBox.Show("A previous appointment exists. Complete the test result and retake flow before adding another appointment.", "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newAppointmentID = clsTestAppointments.AddNewTestAppointment(
                _LocalDrivingLicenseApplicationID,
                _TestTypeID,
                guna2DateTimePicker1.Value,
                _TestFees,
                clsGlobal.CurrentUser.UserID);

            if (newAppointmentID <= 0)
            {
                MessageBox.Show("The appointment could not be saved.", "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("The appointment was saved successfully.", "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
