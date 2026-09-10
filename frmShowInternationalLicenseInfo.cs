using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmShowInternationalLicenseInfo : Form
    {
        private readonly int _internationalLicenseID;

        public frmShowInternationalLicenseInfo(int internationalLicenseID)
        {
            if (internationalLicenseID <= 0)
                throw new ArgumentOutOfRangeException(nameof(internationalLicenseID));

            InitializeComponent();
            _internationalLicenseID = internationalLicenseID;
        }

        private void frmShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            DataTable internationalLicenseInfo =
                clsInternationalLicense.GetInternationalLicenseInfo(_internationalLicenseID);

            if (internationalLicenseInfo.Rows.Count == 0)
            {
                MessageBox.Show("International license information was not found.",
                    "International License Info", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
                return;
            }

            DataRow row = internationalLicenseInfo.Rows[0];
            ctrlDriverLicenceInfo1.LoadLicenseInfo(
                Convert.ToInt32(row["LicenseID"]));
            ctrlInternationalLicenseApplicationInfo1.LoadInfo(
                Convert.ToInt32(row["ApplicationID"]),
                Convert.ToInt32(row["InternationalLicenseID"]),
                Convert.ToInt32(row["LicenseID"]),
                Convert.ToDateTime(row["ApplicationDate"]),
                Convert.ToDateTime(row["IssueDate"]),
                Convert.ToDateTime(row["ExpirationDate"]),
                Convert.ToDecimal(row["PaidFees"]),
                row["CreatedByUserName"].ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
