using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID = -1;

        public frmTakeTest()
        {
            InitializeComponent();
            // Keep the result unselected when the form opens.
            ActiveControl = txtNotes;
        }

        public frmTakeTest(int testAppointmentID)
            : this()
        {
            if (testAppointmentID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(testAppointmentID));
            }

            _TestAppointmentID = testAppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {

        }
    }
}
