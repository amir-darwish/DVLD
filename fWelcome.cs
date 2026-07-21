using System;
using System.Drawing;
using System.Windows.Forms;
using DVLD_BusinessLayer;
namespace DVLD
{
    public partial class fWelcome : Form
    {
        public fWelcome()
        {
            InitializeComponent();
            ResizeNavigationButtons();
            
        }

        private void ResizeNavigationButtons()
        {
            Control[] buttons =
            {
                btnApplications,
                btnPeople,
                btnDrivers,
                btnUsers,
                btnSettings
            };
            int buttonCount = buttons.Length;

            if (buttonCount == 0)
            {
                return;
            }

            int buttonWidth = guna2ContainerControl1.ClientSize.Width / buttonCount;
            int x = 0;

            foreach (Control control in buttons)
            {
                control.Location = new Point(x, 0);
                control.Size = new Size(buttonWidth, guna2ContainerControl1.ClientSize.Height);
                x += buttonWidth;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeNavigationButtons();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void fWelcome_Load(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            contextMenuStrip_Settings.Show(btnSettings,0,btnSettings.Height);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {

        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {

        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            Form frmPeople = new frmPeople();
            frmPeople.ShowDialog();

        }

        private void btnApplications_Click(object sender, EventArgs e)
        {

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo currentUser = new frmShowUserInfo(clsGlobal.CurrentUser);
            currentUser.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.SignOut();
            this.Close();
           
        }
    }
}
