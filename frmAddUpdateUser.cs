using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddUpdateUser : Form
    {
        public frmAddUpdateUser()
        {
            InitializeComponent();
            btnSearch.Enabled = false;
        }
        public frmAddUpdateUser(int personID)
        {
            InitializeComponent();
            btnSearch.Enabled = true;
            txtSearch.Text = personID.ToString();
            ctrlShowDetails1.LoadPersonInfo(personID);
            this.LoadUserDetails(personID);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ctrlShowDetails1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                btnSearch.Enabled = false;
            }
            else
            {
                btnSearch.Enabled = true;
                int personID = int.Parse(txtSearch.Text); 
                ctrlShowDetails1.LoadPersonInfo(personID);
                LoadUserDetails(personID);

            }


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbFind.SelectedIndex == 0) // Assuming 0 is the index for "Person ID"
            {
                ValidatePersonIDInput();
            }
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                btnSearch.Enabled = false;
            }
            else
            {
                btnSearch.Enabled = true;
            }
        }
        private void ValidatePersonIDInput()
        {
            if (!int.TryParse(txtSearch.Text, out _) && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Please enter a valid numeric Person ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNewPerson addPersonForm = new frmAddNewPerson();
            addPersonForm.DataBack += frmAddNewUser_DataBack;
            addPersonForm.ShowDialog();
        }
        private void frmAddNewUser_DataBack(object sender, int PersonID)
        {
            ctrlShowDetails1.LoadPersonInfo(PersonID);
            txtSearch.Text = PersonID.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoadUserDetails(int personID)
        {

            clsUser user = clsUser.FindByPersonID(personID);
            if (user == null)
            {
                tbUsername.Text = "";
                tbPass.Text = "";
                tbConfirmPass.Text = "";
                lbID.Text = "";
                return; 
            }
            lbID.Text = user.UserID.ToString();
            tbUsername.Text = user.UserName;
            chbActive.Checked = user.IsActive;

        }

        private void UpdateUserDetails(clsUser user, string newPassword)
        {

            user.UserName = tbUsername.Text;
            user.IsActive = chbActive.Checked;

            if (user.updateUser(newPassword))
            {
                MessageBox.Show("User info updated", "Update User", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error User info", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool ValidatePassword()
        {
            if (string.IsNullOrEmpty(tbPass.Text)) return false;
            if (tbPass.Text != tbConfirmPass.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int personID = int.Parse(txtSearch.Text);

            clsUser user = clsUser.FindByPersonID(personID);

            if (user == null)
            {
                if (!ValidatePassword())
                {
                    MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateUser();
                return;
            }

            string password = string.IsNullOrWhiteSpace(tbPass.Text) ? null : tbPass.Text;

            if (password != null && !ValidatePassword())
                return;

            UpdateUserDetails(user, password);
        }

        private void CreateUser()
        {
            int personID = int.Parse(txtSearch.Text);
            bool created = clsUser.CreateUser(
            personID,
            tbUsername.Text.Trim(),
            tbPass.Text.Trim());

            MessageBox.Show(created ? "User created" : "User not created");
            return;
        }
    }
}
