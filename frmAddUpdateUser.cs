using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddUpdateUser : Form
    {
        private int _PersonID = -1;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            subscribeToPersonInfoEvents();
        }
        public frmAddUpdateUser(int personID)
        {
            InitializeComponent();
            subscribeToPersonInfoEvents();
            ctrlUserPersonInfo1.LoadPersonInfo(personID);
        }

        private void subscribeToPersonInfoEvents()
        {
            ctrlUserPersonInfo1.PersonSelected += ctrlUserPersonInfo1_PersonSelected;
            ctrlUserPersonInfo1.PersonCleared += ctrlUserPersonInfo1_PersonCleared;
        }

        private void ctrlUserPersonInfo1_PersonCleared(object sender, EventArgs e)
        {
            _PersonID = -1;
        }

        private void ctrlUserPersonInfo1_PersonSelected(object sender, int personID)
        {
            _PersonID = personID;
            LoadUserDetails(personID);
        }

        private void ResetUserDetails()
        {
            tbUsername.Text = "";
            tbPass.Text = "";
            tbConfirmPass.Text = "";
            lbID.Text = "";
            chbActive.Checked = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoadUserDetails(int personID)
        {

            clsUser user = clsUser.FindByPersonID(personID);
            if (user == null)
            {
                ResetUserDetails();
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
            if (_PersonID == -1)
            {
                MessageBox.Show("Please choose a person first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsUser user = clsUser.FindByPersonID(_PersonID);

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
            bool created = clsUser.CreateUser(
            _PersonID,
            tbUsername.Text.Trim(),
            tbPass.Text.Trim());

            MessageBox.Show(created ? "User created" : "User not created");
            return;
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {

        }
    }
}
