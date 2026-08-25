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
    public partial class frmTestAppointments : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _TestTypeID = -1;

        public frmTestAppointments(
            int localDrivingLicenseApplicationID,
            int testTypeID)
        {
            if (localDrivingLicenseApplicationID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(localDrivingLicenseApplicationID));
            }

            if (testTypeID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(testTypeID));
            }

            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _TestTypeID = testTypeID;

        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlVisionTestAppointment1.LoadApplicationInfo(_LocalDrivingLicenseApplicationID);
            initDGV();
        }

        private void initDGV()
        {
            DataTable dtAppointments = clsTestAppointments.GetTestAppointments(
                _LocalDrivingLicenseApplicationID,
                _TestTypeID);
            dgvAppointments.DataSource = dtAppointments;
            // Customize DataGridView appearance
            dgvAppointments.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(197, 203, 232);
            dgvAppointments.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgvAppointments.DefaultCellStyle.BackColor = Color.White;
            dgvAppointments.DefaultCellStyle.ForeColor = Color.Black;
            dgvAppointments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(110, 120, 180);
            dgvAppointments.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAppointments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181);
            dgvAppointments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAppointments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAppointments.ColumnHeadersHeight = 35;
            dgvAppointments.GridColor = Color.FromArgb(231, 229, 255);
            dgvAppointments.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvAppointments.ReadOnly = true;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if (clsTestAppointments.IsThereAnActiveTestAppointment(
                _LocalDrivingLicenseApplicationID,
                _TestTypeID))
            {
                MessageBox.Show("There is already an active appointment for this test.", "Test Appointments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtPreviousAppointments = clsTestAppointments.GetTestAppointments(
                _LocalDrivingLicenseApplicationID,
                _TestTypeID);

            if (dtPreviousAppointments.Rows.Count > 0)
            {
                MessageBox.Show("A previous appointment exists. Complete the test result and retake flow before adding another appointment.", "Test Appointments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddTestAppointment addAppointmentForm = new frmAddTestAppointment(
                _LocalDrivingLicenseApplicationID,
                _TestTypeID);

            if (addAppointmentForm.ShowDialog() == DialogResult.OK)
            {
                initDGV();
            }
        }
    }
}
