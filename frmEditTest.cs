using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmEditTest : Form
    {
        public frmEditTest(int testTypeId, string title, string description, decimal fees)
        {
            InitializeComponent();
            lbID.Text = testTypeId.ToString();
            tbTitle.Text = title;
            tbDescription.Text = description;
            tbFees.Text = fees.ToString();
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsTestType.EditeTestType(
                Convert.ToInt32(lbID.Text),
                tbTitle.Text,
                tbDescription.Text,
                Convert.ToDecimal(tbFees.Text)))
            {
                MessageBox.Show("Test type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update test type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
