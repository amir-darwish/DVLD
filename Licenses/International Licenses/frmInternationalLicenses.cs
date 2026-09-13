using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmInternationalLicenses : Form
    {
        private DataTable _internationalLicenses;

        public frmInternationalLicenses()
        {
            InitializeComponent();
        }

        private void frmInternationalLicenses_Load(object sender, EventArgs e)
        {
            LoadInternationalLicenses();
        }

        private void LoadInternationalLicenses()
        {
            _internationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternationalLicenses.DataSource = _internationalLicenses;

            if (dgvInternationalLicenses.Columns.Contains("ImagePath"))
                dgvInternationalLicenses.Columns["ImagePath"].Visible = false;

            ctrlFilter1.SetFilter(_internationalLicenses, dgvInternationalLicenses,
                lblRecordsCount,
                new ctrlFilter.clsFilterColumn("International License ID",
                    "InternationalLicenseID", ctrlFilter.enFilterDataType.Number),
                new ctrlFilter.clsFilterColumn("Application ID", "ApplicationID",
                    ctrlFilter.enFilterDataType.Number),
                new ctrlFilter.clsFilterColumn("Driver ID", "DriverID",
                    ctrlFilter.enFilterDataType.Number),
                new ctrlFilter.clsFilterColumn("Local License ID", "LocalLicenseID",
                    ctrlFilter.enFilterDataType.Number),
                new ctrlFilter.clsFilterColumn("National No", "NationalNo",
                    ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Applicant Name", "ApplicantName",
                    ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Issue Date", "IssueDate",
                    ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Expiration Date", "ExpirationDate",
                    ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Is Active", "IsActive",
                    ctrlFilter.enFilterDataType.Bool));

            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dgvInternationalLicenses.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(197, 203, 232);
            dgvInternationalLicenses.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgvInternationalLicenses.DefaultCellStyle.BackColor = Color.White;
            dgvInternationalLicenses.DefaultCellStyle.ForeColor = Color.Black;
            dgvInternationalLicenses.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(110, 120, 180);
            dgvInternationalLicenses.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvInternationalLicenses.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(63, 81, 181);
            dgvInternationalLicenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInternationalLicenses.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvInternationalLicenses.ColumnHeadersHeight = 35;
            dgvInternationalLicenses.GridColor = Color.FromArgb(231, 229, 255);
            dgvInternationalLicenses.Theme =
                Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvInternationalLicenses.ReadOnly = true;
            dgvInternationalLicenses.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvInternationalLicenses_CellMouseDown(
            object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0)
                return;

            dgvInternationalLicenses.ClearSelection();
            dgvInternationalLicenses.Rows[e.RowIndex].Selected = true;
            dgvInternationalLicenses.CurrentCell =
                dgvInternationalLicenses.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenses.CurrentRow == null ||
                dgvInternationalLicenses.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select an international license first.",
                    "International License Info", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            object value = dgvInternationalLicenses.CurrentRow
                .Cells["InternationalLicenseID"].Value;

            if (value == null || value == DBNull.Value ||
                !int.TryParse(value.ToString(), out int internationalLicenseID) ||
                internationalLicenseID <= 0)
            {
                MessageBox.Show("The selected international license ID is invalid.",
                    "International License Info", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (frmShowInternationalLicenseInfo frm =
                new frmShowInternationalLicenseInfo(internationalLicenseID))
            {
                frm.ShowDialog(this);
            }
        }
    }
}
