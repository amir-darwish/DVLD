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
        public frmLocalDrivingLicenceApplication()
        {
            InitializeComponent();
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
            if (dgvLocalDrivingLicenceApplication.CurrentRow == null ||
                dgvLocalDrivingLicenceApplication.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select an application first.", "Application Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object value = dgvLocalDrivingLicenceApplication.CurrentRow
                .Cells["LocalDrivingLicenseApplicationID"].Value;

            if (value == null || value == DBNull.Value ||
                !int.TryParse(value.ToString(), out int localApplicationID))
            {
                MessageBox.Show("The selected application ID is invalid.", "Application Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int visionTestTypeID = 1;
            frmVisionTestAppointments detailsForm = new frmVisionTestAppointments(
                localApplicationID,
                visionTestTypeID);
            detailsForm.ShowDialog();

        } 
    }
}
