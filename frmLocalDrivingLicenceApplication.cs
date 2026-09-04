using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmLocalDrivingLicenceApplication : Form
    {
        private const int VisionTestTypeID = 1;
        private const int WrittenTestTypeID = 2;
        private const int StreetTestTypeID = 3;

        public frmLocalDrivingLicenceApplication()
        {
            InitializeComponent();
            Menu.Opening += Menu_Opening;
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void frmLocalDrivingLicenceApplication_Load(object sender, EventArgs e)
        {
            initDGV();
            initFilter();
        }
        private void initDGV()
        {
            DataTable dtApplications = DVLD_BusinessLayer.clsLocalDrivingLicenseApp.GetAllLocalDrivingLicenceApplicationsFromView();
            dgvLocalDrivingLicenceApplication.DataSource = dtApplications;
            // Customize DataGridView appearance
            dgvLocalDrivingLicenceApplication.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(197, 203, 232);
            dgvLocalDrivingLicenceApplication.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgvLocalDrivingLicenceApplication.DefaultCellStyle.BackColor = Color.White;
            dgvLocalDrivingLicenceApplication.DefaultCellStyle.ForeColor = Color.Black;
            dgvLocalDrivingLicenceApplication.DefaultCellStyle.SelectionBackColor = Color.FromArgb(110, 120, 180);
            dgvLocalDrivingLicenceApplication.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvLocalDrivingLicenceApplication.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181);
            dgvLocalDrivingLicenceApplication.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLocalDrivingLicenceApplication.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvLocalDrivingLicenceApplication.ColumnHeadersHeight = 35;
            dgvLocalDrivingLicenceApplication.GridColor = Color.FromArgb(231, 229, 255);
            dgvLocalDrivingLicenceApplication.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvLocalDrivingLicenceApplication.ReadOnly = true;
            dgvLocalDrivingLicenceApplication.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void initFilter()
        {
            ctrlFilter1.SetFilter(
                (DataTable)dgvLocalDrivingLicenceApplication.DataSource,
                dgvLocalDrivingLicenceApplication,
                lblRecordsCount,
                new ctrlFilter.clsFilterColumn("Application ID", "LocalDrivingLicenseApplicationID", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("National No", "NationalNo", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Applicant Name", "ApplicantName", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("License Number", "LicenseNumber", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Application Date", "ApplicationDate", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Status", "Status", ctrlFilter.enFilterDataType.Text)
            );

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTestAppointmentsForSelectedApplication(VisionTestTypeID);

        } 

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTestAppointmentsForSelectedApplication(VisionTestTypeID);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTestAppointmentsForSelectedApplication(WrittenTestTypeID);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTestAppointmentsForSelectedApplication(StreetTestTypeID);
        }

        private void Menu_Opening(object sender, CancelEventArgs e)
        {
            bool hasSelectedApplication =
                dgvLocalDrivingLicenceApplication.CurrentRow != null &&
                !dgvLocalDrivingLicenceApplication.CurrentRow.IsNewRow;

            if (!hasSelectedApplication)
            {
                visionTestToolStripMenuItem.Enabled = false;
                schedyleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                return;
            }

            object value = dgvLocalDrivingLicenceApplication.CurrentRow
                .Cells["LocalDrivingLicenseApplicationID"].Value;

            if (value == null || value == DBNull.Value ||
                !int.TryParse(value.ToString(), out int localApplicationID))
            {
                visionTestToolStripMenuItem.Enabled = false;
                schedyleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                return;
            }

            try
            {
                bool visionTestPassed = DVLD_BusinessLayer.clsTests
                    .IsTestPassed(localApplicationID, VisionTestTypeID);
                bool writtenTestPassed = DVLD_BusinessLayer.clsTests
                    .IsTestPassed(localApplicationID, WrittenTestTypeID);
                bool streetTestPassed = DVLD_BusinessLayer.clsTests
                    .IsTestPassed(localApplicationID, StreetTestTypeID);

                visionTestToolStripMenuItem.Enabled = !visionTestPassed;
                schedyleWrittenTestToolStripMenuItem.Enabled =
                    visionTestPassed && !writtenTestPassed;
                scheduleStreetTestToolStripMenuItem.Enabled =
                    visionTestPassed && writtenTestPassed && !streetTestPassed;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                visionTestToolStripMenuItem.Enabled = false;
                schedyleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
            }
        }

        private void OpenTestAppointmentsForSelectedApplication(int testTypeID)
        {
            if (dgvLocalDrivingLicenceApplication.CurrentRow == null ||
                dgvLocalDrivingLicenceApplication.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select an application first.", "Test Appointments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object value = dgvLocalDrivingLicenceApplication.CurrentRow
                .Cells["LocalDrivingLicenseApplicationID"].Value;

            if (value == null || value == DBNull.Value ||
                !int.TryParse(value.ToString(), out int localApplicationID))
            {
                MessageBox.Show("The selected application ID is invalid.", "Test Appointments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenTestAppointments(localApplicationID, testTypeID);
        }

        private void OpenTestAppointments(int localApplicationID, int testTypeID)
        {
            frmTestAppointments appointmentsForm = new frmTestAppointments(
                localApplicationID,
                testTypeID);

            appointmentsForm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenceApplication frm = new frmNewLocalDrivingLicenceApplication();
            frm.ShowDialog();

        }
    }
}
