using DVLD_BusinessLayer; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmApplicationType : Form
    {

        DataTable _appType;
        public frmApplicationType()
        {
            InitializeComponent();
        }

        private void frmApplicationType_Load(object sender, EventArgs e)
        {
            InitDGV();
        }

        

        private void InitDGV()
        {
            _appType = clsApplicationType.GetAllApplicationTypes();
            dgvApp.DataSource = _appType;

            // Customize DataGridView appearance
            dgvApp.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(197, 203, 232);
            dgvApp.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;


            dgvApp.DefaultCellStyle.BackColor = Color.White;
            dgvApp.DefaultCellStyle.ForeColor = Color.Black;
            dgvApp.DefaultCellStyle.SelectionBackColor = Color.FromArgb(110, 120, 180);
            dgvApp.DefaultCellStyle.SelectionForeColor = Color.White;


            dgvApp.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181);
            dgvApp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvApp.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvApp.ColumnHeadersHeight = 35;


            dgvApp.GridColor = Color.FromArgb(231, 229, 255);
            dgvApp.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvApp.ReadOnly = true;
            dgvApp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvApp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAppType frmEdit = new frmEditAppType(
                int.Parse(dgvApp.CurrentRow.Cells[0].Value.ToString()),
                dgvApp.CurrentRow.Cells[1].Value.ToString(),
                decimal.Parse(dgvApp.CurrentRow.Cells[2].Value.ToString())
            );
            frmEdit.ShowDialog();

        }
    }
}
