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
        private decimal _RetakeFees = 0;
        private bool _IsRetakeTest = false;

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

            try
            {
                LoadApplicationInfo();
                LoadTestTypeInfo();
                LoadTrialsCount();
                LoadRetakeInfo();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                btnSave.Enabled = false;
                MessageBox.Show("Appointment information could not be loaded. Please close this window and try again.",
                    "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void LoadRetakeInfo()
        {
            using (DataTable bookingInfo = clsTestAppointments.GetAppointmentBookingInfo(
                _LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                string error = clsTestAppointments.GetAppointmentBookingError(bookingInfo);
                if (!string.IsNullOrEmpty(error))
                {
                    btnSave.Enabled = false;
                    MessageBox.Show(error, "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRow row = bookingInfo.Rows[0];
                _IsRetakeTest = Convert.ToInt32(row["PreviousAppointmentCount"]) > 0;
                _TestFees = Convert.ToDecimal(row["TestFees"]);
                _RetakeFees = _IsRetakeTest ? Convert.ToDecimal(row["RetakeFees"]) : 0;
                gbRetakeTest.Enabled = _IsRetakeTest;
                lbFees.Text = _TestFees.ToString("0.##");
                lbRFees.Text = _RetakeFees.ToString("0.##");
                lbRtotalFees.Text = (_TestFees + _RetakeFees).ToString("0.##");
                lbRAPPID.Text = _IsRetakeTest ? "Not created yet" : "N/A";
                label2.Text = row["PreviousAppointmentCount"].ToString();
                Text = lbTitle.Text + (_IsRetakeTest ? " - Retake Appointment" : " Appointment");
            }
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

            btnSave.Enabled = false;
            try
            {
                using (DataTable bookingInfo = clsTestAppointments.GetAppointmentBookingInfo(
                    _LocalDrivingLicenseApplicationID, _TestTypeID))
                {
                    string error = clsTestAppointments.GetAppointmentBookingError(bookingInfo);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error, "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DataRow row = bookingInfo.Rows[0];
                    bool isRetake = Convert.ToInt32(row["PreviousAppointmentCount"]) > 0;
                    decimal retakeFees = isRetake ? Convert.ToDecimal(row["RetakeFees"]) : 0;
                    if (isRetake != _IsRetakeTest || retakeFees != _RetakeFees ||
                        Convert.ToDecimal(row["TestFees"]) != _TestFees)
                    {
                        LoadRetakeInfo();
                        MessageBox.Show("The booking details or fees have changed. Review the updated amounts before saving again.",
                            "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                int newAppointmentID = clsTestAppointments.AddNewTestAppointment(
                    _LocalDrivingLicenseApplicationID,
                    _TestTypeID,
                    guna2DateTimePicker1.Value,
                    _TestFees,
                    clsGlobal.CurrentUser.UserID,
                    _RetakeFees,
                    out int retakeTestApplicationID);

                if (newAppointmentID <= 0)
                {
                    MessageBox.Show("The appointment could not be saved. Its booking conditions or fees may have changed. Please close this window and try again.",
                        "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lbRAPPID.Text = retakeTestApplicationID > 0 ? retakeTestApplicationID.ToString() : "N/A";
                MessageBox.Show("The appointment was saved successfully." +
                    (retakeTestApplicationID > 0 ? "\nRetake Application ID: " + retakeTestApplicationID : string.Empty),
                    "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Saving could not be confirmed. Close this window and refresh the appointments before trying again.",
                    "Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed)
                    btnSave.Enabled = true;
            }
        }
    }
}
