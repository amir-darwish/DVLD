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
    public partial class frmNewLocalDrivingLicenceApplication : Form
    {
        private int _PersonID = -1;
        public frmNewLocalDrivingLicenceApplication()
        {
            InitializeComponent();
            subscribeToPersonInfoEvents();
        }

        private void ctrlUserPersonInfo1_Load(object sender, EventArgs e)
        {

        }

        private void subscribeToPersonInfoEvents()
        {
            ctrlUserPersonInfo1.PersonSelected += ctrlUserPersonInfo1_PersonSelected;
            ctrlUserPersonInfo1.PersonCleared += ctrlUserPersonInfo1_PersonCleared;

        }

        private void ctrlUserPersonInfo1_PersonSelected(object sender, int personId)
        {
            _PersonID = personId;
            
        }
        private void ctrlUserPersonInfo1_PersonCleared(object sender, EventArgs e)
        {
            _PersonID -= -1;
        }

        private void frmNewLocalDrivingLicenceApplication_Load(object sender, EventArgs e)
        {
            loadApplicationDetails();
            LoadLicenseClasses();
        }
        private void loadApplicationDetails()
        {
           lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
           lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
        private void LoadLicenseClasses()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();
            if (dt.Rows.Count < 0)
            {
                MessageBox.Show("No license classes found. Please contact the system administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cbLicenseClass.DataSource = dt;
            cbLicenseClass.DisplayMember = "ClassName";        
            cbLicenseClass.ValueMember = "LicenseClassID";
            
            if (cbLicenseClass.Items.Count > 0)
            {
                cbLicenseClass.SelectedIndex = 0;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_PersonID == -1)
            {
                MessageBox.Show("Please select a person before creating an application.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsLocalDrivingLicenseApp.IsThereAnActiveApplicationIsLocalDrivingLicenceApplicationExists(_PersonID, (int)cbLicenseClass.SelectedValue))
            {
                MessageBox.Show("This person already has an active application for the selected license class.", "Active Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int appID = clsApplication.CreateApplication(_PersonID, 1, 15, clsGlobal.CurrentUser.UserID);
            if (appID > 0)
            {
                int localAppID = clsLocalDrivingLicenseApp.CreateNewLocalDrivingLicenceApplication(appID, (int)cbLicenseClass.SelectedValue);
                if (localAppID > 0)
                {
                    MessageBox.Show("Application created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbAppID.Text = localAppID.ToString();
                }
                else
                {
                    MessageBox.Show("Failed to create local driving license application. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Failed to create application. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
