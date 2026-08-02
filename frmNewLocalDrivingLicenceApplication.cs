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
        }
        private void loadApplicationDetails()
        {
           lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
           lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
    }
}
