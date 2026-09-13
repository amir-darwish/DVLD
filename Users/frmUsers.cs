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

            ctrlFilter1.SetFilter(_dtUsers, dgvUsers, lblRecordsCount,
                new ctrlFilter.clsFilterColumn("User ID", "UserID", ctrlFilter.enFilterDataType.Number),
                new ctrlFilter.clsFilterColumn("Person ID", "PersonID", ctrlFilter.enFilterDataType.Number),
                new ctrlFilter.clsFilterColumn("Username", "UserName", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Full Name", "FullName", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Is Active", "IsActive", ctrlFilter.enFilterDataType.Bool));

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

        private void frmUsers_Load_1(object sender, EventArgs e)
        {

        }
    }
}
