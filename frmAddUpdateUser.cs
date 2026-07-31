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
            InitFilter();
            btnSearch.Enabled = false;
        }
        public frmAddUpdateUser(int personID)
        {
            InitializeComponent();
            InitFilter();
            btnSearch.Enabled = true;
            ctrlFilter1.SetSelectedFilter("Person ID");
            ctrlFilter1.SetFilterValue(personID.ToString());
            LoadPersonAndUser(personID);
        }

        private void InitFilter()
        {
            ctrlFilter1.SetSearchFilter(
                new ctrlFilter.clsFilterColumn("National No.", "NationalNo", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Person ID", "PersonID", ctrlFilter.enFilterDataType.Number));

            ctrlFilter1.FilterValueChanged += ctrlFilter1_FilterValueChanged;
        }

        private void ctrlShowDetails1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ctrlFilter1.FilterValue))
            {
                btnSearch.Enabled = false;
                return;
            }

            clsPerson person = null;

            if (ctrlFilter1.SelectedFilterText == "Person ID")
            {
                if (!int.TryParse(ctrlFilter1.FilterValue, out int personID))
                {
                    MessageBox.Show("Please enter a valid numeric Person ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                person = clsPerson.Find(personID);
            }
            else
            {
                person = clsPerson.Find(ctrlFilter1.FilterValue);
            }

            if (person == null)
            {
                MessageBox.Show("Person was not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadPersonAndUser(person.PersonID);
        }

        private void ctrlFilter1_FilterValueChanged(object sender, EventArgs e)
        {
            _PersonID = -1;
            btnSearch.Enabled = !string.IsNullOrWhiteSpace(ctrlFilter1.FilterValue);
        }

        private void LoadPersonAndUser(int personID)
        {
            _PersonID = personID;
            ctrlShowDetails1.LoadPersonInfo(personID);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNewPerson addPersonForm = new frmAddNewPerson();
            addPersonForm.DataBack += frmAddNewUser_DataBack;
            addPersonForm.ShowDialog();
        }
        private void frmAddNewUser_DataBack(object sender, int PersonID)
        {
            ctrlFilter1.SetSelectedFilter("Person ID");
            ctrlFilter1.SetFilterValue(PersonID.ToString());
            LoadPersonAndUser(PersonID);
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
    }
}
