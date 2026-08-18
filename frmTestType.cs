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
    public partial class frmTestType : Form
    {
        public frmTestType()
        {
            InitializeComponent();
        }

        private void dgvTestType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void frmTestType_Load(object sender, EventArgs e)
        {
            initDGV();
        }

        private void initDGV()
        {
            DataTable dtTestTypes = clsTestType.GetAllTestTypes();
            dgvTestType.DataSource = dtTestTypes;

            // Customize DataGridView appearance
            dgvTestType.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(197, 203, 232);
            dgvTestType.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgvTestType.DefaultCellStyle.BackColor = Color.White;
            dgvTestType.DefaultCellStyle.ForeColor = Color.Black;
            dgvTestType.DefaultCellStyle.SelectionBackColor = Color.FromArgb(110, 120, 180);
            dgvTestType.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvTestType.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181);
            dgvTestType.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTestType.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTestType.ColumnHeadersHeight = 35;
            dgvTestType.GridColor = Color.FromArgb(231, 229, 255);
            dgvTestType.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvTestType.ReadOnly = true;
            dgvTestType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void eDITEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTest editTestForm = new frmEditTest(
                Convert.ToInt32(dgvTestType.CurrentRow.Cells["TestTypeID"].Value),
                dgvTestType.CurrentRow.Cells["TestTypeTitle"].Value.ToString(),
                dgvTestType.CurrentRow.Cells["TestTypeDescription"].Value.ToString(),
                Convert.ToDecimal(dgvTestType.CurrentRow.Cells["TestTypeFees"].Value)
            );
            editTestForm.ShowDialog();

        }
    }
}
