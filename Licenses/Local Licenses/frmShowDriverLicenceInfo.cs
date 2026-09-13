using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmShowDriverLicenceInfo : Form
    {
        private readonly int _LicenseID;

        public frmShowDriverLicenceInfo(int licenseID)
        {
            if (licenseID <= 0)
                throw new ArgumentOutOfRangeException(nameof(licenseID));

            InitializeComponent();
            _LicenseID = licenseID;
        }

        private void frmShowDriverLicenceInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenceInfo1.LoadLicenseInfo(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
