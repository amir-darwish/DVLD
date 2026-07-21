using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
namespace DVLD
{
    public partial class frmShowUserInfo : Form
    {
        public frmShowUserInfo(clsUser user)
        {
            InitializeComponent();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }
            ctrlShowDetails1.LoadPersonInfo(user.PersonInfo.PersonID);
            lbUserID.Text = user.UserID.ToString();
            lbUsername.Text = user.UserName;
            lbIsActive.Text = user.IsActive ? "Yes" : "No";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
