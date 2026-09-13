using DVLD_BusinessLayer;
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
    public partial class frmEditAppType : Form
    {
        public frmEditAppType(int appTypeID, string appTypeName, decimal fee)
        {
            InitializeComponent();
            lbID.Text = appTypeID.ToString();
            tbFees.Text = fee.ToString();
            tbTitle.Text = appTypeName;

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void lbFee_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isUpdated = clsApplicationType.EditeApplicationType(int.Parse(lbID.Text), tbTitle.Text, decimal.Parse(tbFees.Text));
            if (isUpdated)
            {
                MessageBox.Show("Application type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update application type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
