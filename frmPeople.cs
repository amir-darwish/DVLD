using DVLD_BusinessLayer;
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
    public partial class frmPeople : Form
    {
        public frmPeople()
        {
            InitializeComponent();
        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
            dgvPeople.DataSource = clsPerson.GetAllPersons();

           
            dgvPeople.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(197, 203, 232);
            dgvPeople.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            
            dgvPeople.DefaultCellStyle.BackColor = Color.White;
            dgvPeople.DefaultCellStyle.ForeColor = Color.Black;
            dgvPeople.DefaultCellStyle.SelectionBackColor = Color.FromArgb(110, 120, 180);
            dgvPeople.DefaultCellStyle.SelectionForeColor = Color.White;

            
            dgvPeople.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181);
            dgvPeople.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPeople.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPeople.ColumnHeadersHeight = 35; 

            
            dgvPeople.GridColor = Color.FromArgb(231, 229, 255);
            dgvPeople.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default; 
            dgvPeople.ReadOnly = true;
        }

        private void picGroupePeople_Click(object sender, EventArgs e)
        {

        }
    }
}
