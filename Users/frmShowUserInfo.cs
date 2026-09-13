using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
namespace DVLD
{
    public partial class frmShowUserInfo : Form
    {
        public frmShowUserInfo(clsUser user, bool showChangePassword = false)
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

            gbChangePassword.Visible = showChangePassword;
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (tbNewPass.Text != tbReTypePass.Text)
            {
                MessageBox.Show("New password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!clsGlobal.CurrentUser.ChangePassword(tbCurrentPass.Text, tbNewPass.Text))
            {
                MessageBox.Show("Failed to change password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
