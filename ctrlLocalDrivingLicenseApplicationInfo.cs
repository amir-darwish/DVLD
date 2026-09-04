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
    public partial class ctrlLocalDrivingLicenseApplicationInfo : UserControl
    {
        private int _LocalDrivingLicenseApplicationID = -1;

        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        public int ApplicationID { get; private set; } = -1;
        public int ApplicantPersonID { get; private set; } = -1;
        public byte ApplicationStatus { get; private set; }

        public event EventHandler ViewPersonInfoRequested;
        public event EventHandler ShowLicenseInfoRequested;

        public ctrlLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public bool LoadApplicationInfo(int localApplicationID)
        {
            if (localApplicationID <= 0)
            {
                MessageBox.Show("The local driving license application ID is invalid.", "Application Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearApplicationInfo();
                return false;
            }

            DataTable dtApplicationDetails =
                DVLD_BusinessLayer.clsLocalDrivingLicenseApp
                .GetLocalDrivingLicenseApplicationInfo(localApplicationID);

            if (dtApplicationDetails.Rows.Count == 0)
            {
                MessageBox.Show("Application details were not found.", "Application Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearApplicationInfo();
                return false;
            }


            _LocalDrivingLicenseApplicationID = localApplicationID;

            DataRow row = dtApplicationDetails.Rows[0];

            ApplicationID = Convert.ToInt32(row["ApplicationID"]);
            ApplicantPersonID = Convert.ToInt32(row["ApplicantPersonID"]);
            ApplicationStatus = Convert.ToByte(row["ApplicationStatus"]);
            lbDLID.Text = row["LocalDrivingLicenseApplicationID"].ToString();
            lbAppliedLic.Text = row["ClassName"].ToString();
            lbPTests.Text = DVLD_BusinessLayer.clsTests
                .GetPassedTestsCount(localApplicationID) + "/3";
            lbID.Text = row["ApplicationID"].ToString();
            lbStatus.Text = GetApplicationStatus(row["ApplicationStatus"]);
            lbFees.Text = Convert.ToDecimal(row["PaidFees"]).ToString("0.##");
            lbType.Text = row["ApplicationTypeTitle"].ToString();
            lbApplicant.Text = row["ApplicantName"].ToString();
            lbDate.Text = FormatDate(row, "ApplicationDate");
            lbStDate.Text = FormatDate(row, "LastStatusDate");
            lbCreatedBy.Text = row["CreatedBy"].ToString();
            llViewPersonInfo.Enabled = ApplicantPersonID > 0;
            llShowLicenseInfo.Enabled = false;

            return true;
        }

        private void ClearApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = -1;
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationStatus = 0;

            lbDLID.Text = "##";
            lbAppliedLic.Text = "##";
            lbPTests.Text = "##";
            lbID.Text = "##";
            lbStatus.Text = "##";
            lbFees.Text = "##";
            lbType.Text = "##";
            lbApplicant.Text = "##";
            lbDate.Text = "##";
            lbStDate.Text = "##";
            lbCreatedBy.Text = "##";
            llViewPersonInfo.Enabled = false;
            llShowLicenseInfo.Enabled = false;
        }

        private string FormatDate(DataRow row, string columnName)
        {
            if (row.IsNull(columnName))
            {
                return string.Empty;
            }

            return Convert.ToDateTime(row[columnName]).ToString("dd/MM/yyyy");
        }

        private string GetApplicationStatus(object statusValue)
        {
            if (statusValue == null || statusValue == DBNull.Value)
            {
                return string.Empty;
            }

            int status = Convert.ToInt32(statusValue);

            if (status == 1)
            {
                return "New";
            }

            if (status == 2)
            {
                return "Cancelled";
            }

            if (status == 3)
            {
                return "Completed";
            }

            return status.ToString();
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewPersonInfoRequested?.Invoke(this, EventArgs.Empty);
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfoRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
