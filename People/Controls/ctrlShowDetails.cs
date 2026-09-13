using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class ctrlShowDetails : UserControl
    {
        private clsPerson _person;
        private int _PersonID = -1;

        public ctrlShowDetails()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int personID)
        {
            _PersonID = personID;
            _person = clsPerson.Find(_PersonID);

            if (_person == null)
            {
                MessageBox.Show("Person with ID = " + _PersonID + " was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitData();
        }

        private void InitData()
        {
            lbID.Text = _person.PersonID.ToString();
            lbName.Text = _person.GetFullName();
            lbNationalNo.Text = _person.NationalNo;
            lbGendor.Text = _person.Gender == 0 ? "Male" : "Female";
            lbEmail.Text = _person.Email;
            lbAddress.Text = _person.Address;
            lbDate.Text = _person.DateOfBirth.ToShortDateString();
            lbPhone.Text = _person.Phone;
            lbCountry.Text = _person.NationalityCountryID.ToString();

            if (!string.IsNullOrEmpty(_person.ImagePath))
                pictureBox9.ImageLocation = _person.ImagePath;
            else
                pictureBox9.ImageLocation = null;
        }

        private void linkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddNewPerson frmEdit = new frmAddNewPerson(_PersonID);
            frmEdit.ShowDialog();
            LoadPersonInfo(_PersonID);
        }
    }
}