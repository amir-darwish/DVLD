using DVLD_BusinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Remoting.Messaging;
namespace DVLD
{
    public partial class Add_UpdatePerson : UserControl
    {
        enum enMode {Add, Update}

        private int _PersonID = -1;
        private clsPerson _Person;
        DataTable dtCountry = new DataTable();

        enMode Mode;

        public Add_UpdatePerson()
        {
            InitializeComponent();
            InitCountryComboBox();
            CenterResponsiveControls();

            guna2DateTimePicker1.MaxDate = DateTime.Now.AddYears(-18) ; // Set minimum date to 18 years ago
        }
        public Add_UpdatePerson(int personID)
        {
            InitializeComponent();
            InitCountryComboBox();
            CenterResponsiveControls();
            _PersonID = personID;
            LoadPersonData(personID);
        }

        private void CenterResponsiveControls()
        {
            lbAdd_Update_Person.Left = (ClientSize.Width - lbAdd_Update_Person.Width) / 2;
            btnSave.Left = (groupBox1.ClientSize.Width - btnSave.Width) / 2;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterResponsiveControls();
        }


        public void LoadPersonData(int personID)
        {
            _PersonID = personID;

            Mode = enMode.Update;
            lbAdd_Update_Person.Text = "Update Person";

            _Person = clsPerson.Find(_PersonID);

            if (_Person != null)
            {
                lbID.Text = _Person.PersonID.ToString();

                txtbNantionalNo.Text = _Person.NationalNo;
                txtbFirst.Text = _Person.FirstName;
                txtbSecond.Text = _Person.SecondName;
                txtbThird.Text = _Person.ThirdName;
                txtbLast.Text = _Person.LastName;
                guna2DateTimePicker1.Value = _Person.DateOfBirth;

                if (_Person.Gender == 0)
                {
                    rdMale.Checked = true;
                }
                else if (_Person.Gender == 1)
                {
                    rdFemale.Checked = true;
                }

                txtbAddress.Text = _Person.Address;
                txtbPhone.Text = _Person.Phone;
                txtbEmail.Text = _Person.Email;

                cbCountry.SelectedIndex = dtCountry.AsEnumerable().ToList().FindIndex(row => row.Field<int>("CountryID") == _Person.NationalityCountryID);

                if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
                {
                    pbProfile.Load(_Person.ImagePath);
                }
            }
            else
            {
                MessageBox.Show("This person could not be found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InitCountryComboBox()
        {
            cbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            dtCountry = clsCountry.GetAllCountries();
            foreach (DataRow row in dtCountry.Rows)
            {
                cbCountry.Items.Add(row["CountryName"].ToString());
            }
            if (this.Mode == enMode.Add )
                cbCountry.SelectedIndex = 0; // Select the first country by default
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtbNantionalNo.Text) ||
                string.IsNullOrWhiteSpace(txtbFirst.Text) ||
                string.IsNullOrWhiteSpace(txtbLast.Text) ||
                string.IsNullOrWhiteSpace(txtbAddress.Text) ||
                string.IsNullOrWhiteSpace(txtbPhone.Text) ||
                string.IsNullOrWhiteSpace(txtbEmail.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool SavePersonData()
        {

            if (Mode == enMode.Add)
            {
                _Person = new clsPerson();
            }
             
            _Person.NationalNo = txtbNantionalNo.Text.Trim();
            _Person.FirstName = txtbFirst.Text.Trim();
            _Person.SecondName = txtbSecond.Text.Trim();
            _Person.ThirdName = txtbThird.Text.Trim();
            _Person.LastName = txtbLast.Text.Trim();
            _Person.DateOfBirth = guna2DateTimePicker1.Value;
            if (rdMale.Checked)
            {
                _Person.Gender = 0;
            }
            else if (rdFemale.Checked)
            {
                _Person.Gender = 1;
            }
            _Person.Address = txtbAddress.Text.Trim();
            _Person.Phone = txtbPhone.Text.Trim();
            _Person.Email = txtbEmail.Text.Trim();
            _Person.NationalityCountryID = dtCountry.Rows[cbCountry.SelectedIndex].Field<int>("CountryID");
            _Person.ImagePath = pbProfile.ImageLocation;

            return _Person.Save();
        }


        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMale.Checked)
            {
                rdFemale.Checked = false;
                pbProfile.Load("../../icons/man.png");
            }
        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFemale.Checked)
            {
                rdMale.Checked = false;
                pbProfile.Load("../../icons/woman.png");
            }
        }

        private void txtbEmail_Validating(object sender, CancelEventArgs e)
        {
            string regexPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (Regex.IsMatch(txtbEmail.Text.Trim(), regexPattern))
            {
                txtbEmail.BorderColor = Color.Green;
                txtbEmail.HoverState.BorderColor = Color.Green;
                txtbEmail.FocusedState.BorderColor = Color.Green;
                errorProvider1.SetError(txtbEmail, "");
                e.Cancel = false;
            }
            else
            {
                txtbEmail.BorderColor = Color.Red;
                txtbEmail.HoverState.BorderColor = Color.Red;
                errorProvider1.SetError(txtbEmail, "Please enter a valid email address.");
                e.Cancel = true;
            }
        }

       private void txtbNantionalNo_Validating(object sender, CancelEventArgs e)
        {
            string enteredNationalNo = txtbNantionalNo.Text.Trim();
            if (string.IsNullOrWhiteSpace(enteredNationalNo))
            {
                e.Cancel = true; 
                errorProvider1.SetError(txtbNantionalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtbNantionalNo, "");
            }
            if (Mode == enMode.Update && enteredNationalNo == _Person.NationalNo)
            {
                e.Cancel = false; 
                return;
            }
            if (clsPerson.IsPersonExist(enteredNationalNo))
            {
                e.Cancel = true; 
                errorProvider1.SetError(txtbNantionalNo, "This National No already exists. Please enter a unique value.");
            }
            else
            {
                errorProvider1.SetError(txtbNantionalNo, "");
                e.Cancel = false;
            }
        }


        private void lbSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string folderPath = Path.Combine("C:\\images");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string extension = Path.GetExtension(openFileDialog1.FileName);
                    string newFileName = Guid.NewGuid().ToString() + extension;
                    string destPath = Path.Combine(folderPath, newFileName);

                    File.Copy(openFileDialog1.FileName, destPath, true);
                    pbProfile.Load(openFileDialog1.FileName);
                    pbProfile.ImageLocation = destPath;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error loading image. Please select a valid image file.");
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }
            if (SavePersonData())
            {
                MessageBox.Show("Person saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mode = enMode.Update;
                lbAdd_Update_Person.Text = "Update Person";
                lbID.Text = _Person.PersonID.ToString();

            }
            else
            {
                MessageBox.Show("Failed to add person. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
