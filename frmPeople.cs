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
        private static DataTable _dtAllPeople;
        public frmPeople()
        {
            InitializeComponent();
        }

        private void Initialize_dgv()
        {
            _dtAllPeople = clsPerson.GetAllPersons();

            dgvPeople.DataSource = _dtAllPeople;

            if (dgvPeople.Columns.Contains("ImagePath"))
            {
                dgvPeople.Columns["ImagePath"].Visible = false;
            }

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

        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
            Initialize_dgv();
            txtbFilterBy.Visible = false;
        }

        private void picGroupePeople_Click(object sender, EventArgs e)
        {

        }

        private void cbFillterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbFilterBy.Visible = cbFillterBy.Text != "None";
            if (!txtbFilterBy.Visible)
            {
                if (_dtAllPeople != null)
                {
                    _dtAllPeople.DefaultView.RowFilter = string.Empty;
                }
                txtbFilterBy.Text = string.Empty;
                lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
            }
        }

        private void txtbFilterBy_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFillterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gender":
                    FilterColumn = "Gender";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtbFilterBy.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "Phone" || FilterColumn == "PersonID")
            {
                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtbFilterBy.Text.Trim());
            }
            else
            {
                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtbFilterBy.Text.Trim());
            }

            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }

        private void txtbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFillterBy.Text == "Person ID" || cbFillterBy.Text == "Phone")
            {

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
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
    }
}
