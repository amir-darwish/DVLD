using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlLicenseIdFilter : UserControl
    {
        public int SelectedLicenseID { get; private set; } = -1;
        public event EventHandler LicenseSelected;

        public ctrlLicenseIdFilter()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLicenseID.Text.Trim(), out int licenseID) || licenseID <= 0)
            {
                MessageBox.Show("Please enter a valid license ID.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HandleLicenseSelected(licenseID);
        }

        private void HandleLicenseSelected(int licenseID)
        {
            SelectedLicenseID = licenseID;
            LicenseSelected?.Invoke(this, EventArgs.Empty);

        }
    }
}
