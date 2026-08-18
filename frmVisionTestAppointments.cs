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
    public partial class frmVisionTestAppointments : Form
    {
        int _LocalDrivingLicenseApplicationID = -1;
        public frmVisionTestAppointments(int localDrivingLicenseApplicationID   )
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
           
        }

        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlVisionTestAppointment1.LoadApplicationInfo(_LocalDrivingLicenseApplicationID);
        }
    }
}
