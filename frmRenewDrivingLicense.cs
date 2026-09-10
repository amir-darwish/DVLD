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
    public partial class frmRenewDrivingLicense : Form
    {
        public frmRenewDrivingLicense()
        {
            InitializeComponent();
            ctrlLicenseIdFilter1.LicenseSelected += ctrlLicenseIdFilter1_LicenseSelected;
        }

        private void frmRenewDrivingLicense_Load(object sender, EventArgs e)
        {

        }

        private void ctrlLicenseIdFilter1_LicenseSelected(object sender, EventArgs e)
        {
            int selectedLicenseID = ctrlLicenseIdFilter1.SelectedLicenseID;
            ctrlDriverLicenceInfo1.LoadLicenseInfo(selectedLicenseID);
        }
    }
}
