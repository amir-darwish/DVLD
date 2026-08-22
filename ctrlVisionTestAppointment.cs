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
    public partial class ctrlVisionTestAppointment : UserControl
    {
        private int _LocalDrivingLicenseApplicationID = -1;

        public ctrlVisionTestAppointment()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfo(int localApplicationID)
        {
            if (localApplicationID <= 0)
            {
                MessageBox.Show("The local driving license application ID is invalid.", "Application Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtApplicationDetails =
                DVLD_BusinessLayer.clsLocalDrivingLicenseApp
                .GetLocalDrivingLicenseApplicationInfo(localApplicationID);

            if (dtApplicationDetails.Rows.Count == 0)
            {
                MessageBox.Show("Application details were not found.", "Application Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            _LocalDrivingLicenseApplicationID = localApplicationID;

            DataRow row = dtApplicationDetails.Rows[0];


            lbDLID.Text = row["LocalDrivingLicenseApplicationID"].ToString();
            lbAppliedLic.Text = row["ClassName"].ToString();
            lbID.Text = row["ApplicationID"].ToString();
            lbStatus.Text = GetApplicationStatus(row["ApplicationStatus"]);
            lbFees.Text = Convert.ToDecimal(row["PaidFees"]).ToString("0.##");
            lbType.Text = row["ApplicationTypeTitle"].ToString();
            lbApplicant.Text = row["ApplicantName"].ToString();
            lbDate.Text = FormatDate(row, "ApplicationDate");
            lbStDate.Text = FormatDate(row, "LastStatusDate");
            lbCreatedBy.Text = row["CreatedBy"].ToString();

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

            return status.ToString();
        }

        private void ctrlVisionTestAppointment_Load(object sender, EventArgs e)
        {

        }
    }
}
