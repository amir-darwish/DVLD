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
            lbIsActive.Text = Convert.ToBoolean(row["IsActive"]) ? "Yes" : "No";
            lbDateOfBirth.Text = FormatDate(row, "DateOfBirth");
            lbDriverID.Text = DriverID.ToString();
            lbExpirationDate.Text = FormatDate(row, "ExpirationDate");
            lbIsDetained.Text = Convert.ToBoolean(row["IsDetained"]) ? "Yes" : "No";

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
