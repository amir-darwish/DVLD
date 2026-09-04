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
            ctrlLocalDrivingLicenseApplicationInfo1.ViewPersonInfoRequested +=
                ctrlLocalDrivingLicenseApplicationInfo1_ViewPersonInfoRequested;

        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseApplicationInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplicationID);
            initDGV();
        }

        private void ctrlLocalDrivingLicenseApplicationInfo1_ViewPersonInfoRequested(object sender, EventArgs e)
        {
            int personID = ctrlLocalDrivingLicenseApplicationInfo1.ApplicantPersonID;
            if (personID <= 0)
                return;

            using (frmShowPersonInfo frm = new frmShowPersonInfo(personID))
            {
                frm.ShowDialog(this);
            }
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

        private bool TryGetSelectedActiveTestAppointment(out int testAppointmentID)
        {
            testAppointmentID = -1;
            DataGridViewRow row = dgvAppointments.CurrentRow;

            if (row == null || row.IsNewRow || !row.Selected ||
                !dgvAppointments.Columns.Contains("TestAppointmentID") ||
                !dgvAppointments.Columns.Contains("IsLocked"))
            {
                return false;
            }

            object idValue = row.Cells["TestAppointmentID"].Value;
            object lockedValue = row.Cells["IsLocked"].Value;

            if (idValue == null || idValue == DBNull.Value ||
                !int.TryParse(idValue.ToString(), out testAppointmentID) ||
                testAppointmentID <= 0)
            {
                return false;
            }

            return lockedValue != null && lockedValue != DBNull.Value &&
                bool.TryParse(lockedValue.ToString(), out bool isLocked) && !isLocked;
        }

        private void dgvAppointments_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            DataGridView.HitTestInfo hit = dgvAppointments.HitTest(e.X, e.Y);
            dgvAppointments.ClearSelection();

            if (hit.RowIndex < 0 || hit.ColumnIndex < 0 ||
                dgvAppointments.Rows[hit.RowIndex].IsNewRow)
            {
                dgvAppointments.CurrentCell = null;
                return;
            }

            dgvAppointments.CurrentCell = dgvAppointments.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
            dgvAppointments.Rows[hit.RowIndex].Selected = true;
        }

        private void cmsAppointments_Opening(object sender, CancelEventArgs e)
        {
            takeTestToolStripMenuItem.Enabled =
                TryGetSelectedActiveTestAppointment(out int testAppointmentID);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedActiveTestAppointment(out int testAppointmentID))
            {
                MessageBox.Show("Please select a valid, unlocked appointment first.",
                    "Take Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmTakeTest frm = new frmTakeTest(testAppointmentID))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    initDGV();
                }
            }
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataTable bookingInfo = clsTestAppointments.GetAppointmentBookingInfo(
                    _LocalDrivingLicenseApplicationID, _TestTypeID))
                {
                    string error = clsTestAppointments.GetAppointmentBookingError(bookingInfo);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error, "Test Appointments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (frmAddTestAppointment addAppointmentForm = new frmAddTestAppointment(
                    _LocalDrivingLicenseApplicationID, _TestTypeID))
                {
                    if (addAppointmentForm.ShowDialog(this) == DialogResult.OK)
                    {
                        initDGV();
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("The appointments could not be loaded. Please refresh and try again.",
                    "Test Appointments", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
