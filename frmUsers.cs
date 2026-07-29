using DVLD_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmUsers : Form
    {
        DataTable _dtUsers;
        public frmUsers()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void dgvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            _dtUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtUsers;

            txtbFilterBy.Visible = false;
            lblRecordsCount.Text = _dtUsers.Rows.Count.ToString();


            // Customize DataGridView appearance
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(197, 203, 232);
            dgvUsers.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;


            dgvUsers.DefaultCellStyle.BackColor = Color.White;
            dgvUsers.DefaultCellStyle.ForeColor = Color.Black;
            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(110, 120, 180);
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.White;


            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUsers.ColumnHeadersHeight = 35;


            dgvUsers.GridColor = Color.FromArgb(231, 229, 255);
            dgvUsers.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvUsers.ReadOnly = true;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cbFillterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbFillterBy_TextChanged(object sender, EventArgs e)
        {
            txtbFilterBy.Visible = cbFillterBy.Text != "None";
            if (!txtbFilterBy.Visible)
            {
                if (_dtUsers != null)
                {
                    _dtUsers.DefaultView.RowFilter = string.Empty;
                }
                txtbFilterBy.Text = string.Empty;
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
            }
        }

        private void txtbFilterBy_TextChanged(object sender, EventArgs e)
        {
            txtbFilterBy.Visible = cbFillterBy.Text != "None";

            if (!txtbFilterBy.Visible)
            {
                _dtUsers.DefaultView.RowFilter = string.Empty;
                lblRecordsCount.Text = _dtUsers.DefaultView.Count.ToString();
                return;
            }

            string filterColumn = "";

            switch (cbFillterBy.Text)
            {
                case "User ID":
                    filterColumn = "UserID";
                    break;
                case "Person ID":
                    filterColumn = "PersonID";
                    break;
                case "Username":
                    filterColumn = "UserName";
                    break;
                case "Is Active":
                    filterColumn = "IsActive";
                    break;
                case "Full Name":
                    filterColumn = "FullName";
                    break;
            }

            string filterText = txtbFilterBy.Text.Replace("'", "''");

            if (filterColumn == "UserID" || filterColumn == "PersonID" || filterColumn == "IsActive")
                _dtUsers.DefaultView.RowFilter = string.Format("Convert({0}, 'System.String') LIKE '%{1}%'", filterColumn, filterText);

            else
                _dtUsers.DefaultView.RowFilter = string.Format("{0} LIKE '%{1}%'", filterColumn, filterText);

            lblRecordsCount.Text = _dtUsers.DefaultView.Count.ToString();
        }

        private void lblRecordsCount_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewPeson_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddNewUser = new frmAddUpdateUser();
            frmAddNewUser.ShowDialog();
        }

        private void showUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["PersonID"].Value);
            if (personID > 0)
            {
                frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser(personID);
                frmAddUpdateUser.ShowDialog();
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            if (UserID > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    bool isDeleted = clsUser.DeleteUser(UserID);
                    if (isDeleted)
                    {
                        MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
