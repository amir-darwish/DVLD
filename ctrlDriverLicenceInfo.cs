using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class ctrlDriverLicenceInfo : UserControl
    {
        public int LicenseID { get; private set; } = -1;
        public int DriverID { get; private set; } = -1;
        public int PersonID { get; private set; } = -1;
        public decimal ClassFees { get; private set; }
        public int DefaultValidityLength { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDetained { get; private set; }
        public DateTime ExpirationDate { get; private set; } = DateTime.MinValue;

        public ctrlDriverLicenceInfo()
        {
            InitializeComponent();
        }

        public bool LoadLicenseInfo(int licenseID)
        {
            if (licenseID <= 0)
            {
                ClearLicenseInfo();
                MessageBox.Show("The license ID is invalid.", "License Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DataTable licenseInfo = clsLicense.GetDriverLicenseInfo(licenseID);
            if (licenseInfo.Rows.Count == 0)
            {
                ClearLicenseInfo();
                MessageBox.Show("License information was not found.", "License Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            DataRow row = licenseInfo.Rows[0];
            LicenseID = Convert.ToInt32(row["LicenseID"]);
            DriverID = Convert.ToInt32(row["DriverID"]);
            PersonID = Convert.ToInt32(row["PersonID"]);
            ClassFees = Convert.ToDecimal(row["ClassFees"]);
            DefaultValidityLength = Convert.ToInt32(row["DefaultValidityLength"]);
            IsActive = Convert.ToBoolean(row["IsActive"]);
            IsDetained = Convert.ToBoolean(row["IsDetained"]);
            ExpirationDate = Convert.ToDateTime(row["ExpirationDate"]);

            lbClass.Text = row["ClassName"].ToString();
            lbName.Text = row["ApplicantName"].ToString();
            lbLicenseID.Text = LicenseID.ToString();
            lbNationalNo.Text = row["NationalNo"].ToString();
            lbGender.Text = Convert.ToByte(row["Gender"]) == 0 ? "Male" : "Female";
            lbIssueDate.Text = FormatDate(row, "IssueDate");
            lbIssueReason.Text = GetIssueReasonText(row["IssueReason"]);
            lbNotes.Text = row.IsNull("Notes") ||
                string.IsNullOrWhiteSpace(row["Notes"].ToString())
                    ? "No Notes"
                    : row["Notes"].ToString();
            lbIsActive.Text = IsActive ? "Yes" : "No";
            lbDateOfBirth.Text = FormatDate(row, "DateOfBirth");
            lbDriverID.Text = DriverID.ToString();
            lbExpirationDate.Text = ExpirationDate.ToString("dd/MM/yyyy");
            lbIsDetained.Text = IsDetained ? "Yes" : "No";

            LoadPersonImage(row);
            return true;
        }

        private void LoadPersonImage(DataRow row)
        {
            string imagePath = row.IsNull("ImagePath")
                ? string.Empty
                : row["ImagePath"].ToString();

            picturePerson.ImageLocation = !string.IsNullOrWhiteSpace(imagePath) &&
                File.Exists(imagePath) ? imagePath : null;
        }

        private string FormatDate(DataRow row, string columnName)
        {
            return row.IsNull(columnName)
                ? string.Empty
                : Convert.ToDateTime(row[columnName]).ToString("dd/MM/yyyy");
        }

        private string GetIssueReasonText(object issueReasonValue)
        {
            byte issueReason = Convert.ToByte(issueReasonValue);

            switch (issueReason)
            {
                case 1:
                    return "First Time";
                case 2:
                    return "Renew";
                case 3:
                    return "Replacement for Damaged";
                case 4:
                    return "Replacement for Lost";
                default:
                    return issueReason.ToString();
            }
        }

        private void ClearLicenseInfo()
        {
            LicenseID = -1;
            DriverID = -1;
            PersonID = -1;
            ClassFees = 0;
            DefaultValidityLength = 0;
            IsActive = false;
            IsDetained = false;
            ExpirationDate = DateTime.MinValue;

            lbClass.Text = "##";
            lbName.Text = "##";
            lbLicenseID.Text = "##";
            lbNationalNo.Text = "##";
            lbGender.Text = "##";
            lbIssueDate.Text = "##";
            lbIssueReason.Text = "##";
            lbNotes.Text = "##";
            lbIsActive.Text = "##";
            lbDateOfBirth.Text = "##";
            lbDriverID.Text = "##";
            lbExpirationDate.Text = "##";
            lbIsDetained.Text = "##";
            picturePerson.ImageLocation = null;
            picturePerson.Image = null;
        }

        private void gbDriverLicenseInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
