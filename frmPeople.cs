using DVLD_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmPeople : Form
    {
        
        private static DataTable _dtAllPeople;
        public frmPeople()
        {
            InitializeComponent();
            CenterHeader();
           
        }

        private void CenterHeader()
        {
            picGroupePeople.Left = (ClientSize.Width - picGroupePeople.Width) / 2;
            label1.Left = (ClientSize.Width - label1.Width) / 2;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterHeader();
        }

        private void Initialize_dgv()
        {
            _dtAllPeople = clsPerson.GetAllPersons();

            dgvPeople.DataSource = _dtAllPeople;

            if (dgvPeople.Columns.Contains("ImagePath"))
            {
                dgvPeople.Columns["ImagePath"].Visible = false;
            }

            ctrlFilter1.SetFilter(_dtAllPeople, dgvPeople, lblRecordsCount,
                new ctrlFilter.clsFilterColumn("Person ID", "PersonID", ctrlFilter.enFilterDataType.Number),
                new ctrlFilter.clsFilterColumn("National No.", "NationalNo", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("First Name", "FirstName", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Second Name", "SecondName", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Third Name", "ThirdName", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Last Name", "LastName", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Nationality", "CountryName", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Gender", "Gender", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Phone", "Phone", ctrlFilter.enFilterDataType.Number),
                new ctrlFilter.clsFilterColumn("Email", "Email", ctrlFilter.enFilterDataType.Text));

            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();

            // Customize DataGridView appearance
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
            dgvPeople.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
            Initialize_dgv();
        }

        private void picGroupePeople_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewPeson_Click(object sender, EventArgs e)
        {
            Form addPersonForm = new frmAddNewPerson();
            addPersonForm.ShowDialog();
        }

        private void dgvPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvPeople.ClearSelection();
                dgvPeople.Rows[e.RowIndex].Selected = true;
                dgvPeople.CurrentCell = dgvPeople.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }


        private void tEdit_Click(object sender, EventArgs e)
        {
            if (dgvPeople.SelectedRows.Count > 0)
            {
                int personID = Convert.ToInt32(dgvPeople.SelectedRows[0].Cells["PersonID"].Value);
                Form editPersonForm = new frmAddNewPerson(personID);
                editPersonForm.ShowDialog();
            }
        }
        private void tDelete_Click(object sender, EventArgs e)
        {

            if (dgvPeople.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this person?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int personID = Convert.ToInt32(dgvPeople.SelectedRows[0].Cells["PersonID"].Value);
                    if (clsPerson.DeletePerson(personID))
                    {
                        MessageBox.Show("Person deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Initialize_dgv();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the person. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                
            }
        }

        private void tShowDetails_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dgvPeople.SelectedRows[0].Cells["PersonID"].Value);
            Form frm = new frmShowPersonInfo(personID);
            frm.ShowDialog();

        }

        private void dgvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
