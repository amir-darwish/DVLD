using System;
using DVLD_BusinessLayer;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DVLD
{
    public partial class fLogin : Form
    {

        private static readonly string LoginInfoPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "DVLD",
            "login.txt");

        public fLogin()
        {
            InitializeComponent();
            CenterLoginControls();
        }

        private void CenterLoginControls()
        {
            int centerX = ClientSize.Width / 2;
            int top = Math.Max(35, ClientSize.Height / 2 - 160);
            int labelWidth = 110;
            int spacing = 16;
            int inputWidth = Math.Min(280, Math.Max(220, ClientSize.Width / 3));
            int groupWidth = labelWidth + spacing + inputWidth;
            int groupLeft = centerX - groupWidth / 2;

            guna2HtmlLabel1.AutoSize = true;
            guna2HtmlLabel1.Size = guna2HtmlLabel1.GetPreferredSize(Size.Empty);

            guna2HtmlLabel1.Left = centerX - guna2HtmlLabel1.Width / 2;
            guna2HtmlLabel1.Top = top;

            guna2HtmlLabel2.AutoSize = false;
            guna2HtmlLabel2.Size = new Size(labelWidth, 32);
            guna2HtmlLabel2.TextAlign = ContentAlignment.MiddleRight;
            guna2HtmlLabel2.Left = groupLeft;
            guna2HtmlLabel2.Top = top + 140;

            tbUsername.Size = new Size(inputWidth, 32);
            tbUsername.Left = groupLeft + labelWidth + spacing;
            tbUsername.Top = top + 136;

            guna2HtmlLabel3.AutoSize = false;
            guna2HtmlLabel3.Size = new Size(labelWidth, 32);
            guna2HtmlLabel3.TextAlign = ContentAlignment.MiddleRight;
            guna2HtmlLabel3.Left = groupLeft;
            guna2HtmlLabel3.Top = top + 188;

            tbPassword.Size = tbUsername.Size;
            tbPassword.Left = tbUsername.Left;
            tbPassword.Top = top + 184;

            btnLogin.Left = tbUsername.Left + (tbUsername.Width - btnLogin.Width) / 2;
            btnLogin.Top = top + 262;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterLoginControls();
        }
        private void LoadLoginInfo()
        {
            try
            {
                if (!File.Exists(LoginInfoPath))
                {
                    return;
                }

                string username = File.ReadAllText(LoginInfoPath).Trim();
                if (string.IsNullOrEmpty(username))
                {
                    return;
                }

                tbUsername.Text = username;
                cbRememberMe.Checked = true;
                tbPassword.Focus();
            }
            catch (IOException)
            {
                // Login must remain available if preferences cannot be read.
            }
            catch (UnauthorizedAccessException)
            {
                // Login must remain available if preferences cannot be read.
            }
        }

        private void SaveLoginInfo()
        {
            try
            {
                string directoryPath = Path.GetDirectoryName(LoginInfoPath);
                Directory.CreateDirectory(directoryPath);
                File.WriteAllText(LoginInfoPath, tbUsername.Text.Trim());
            }
            catch (IOException)
            {
                // Remember Me must not prevent a successful login.
            }
            catch (UnauthorizedAccessException)
            {
                // Remember Me must not prevent a successful login.
            }
        }

        private void ClearLoginInfo()
        {
            try
            {
                if (File.Exists(LoginInfoPath))
                {
                    File.Delete(LoginInfoPath);
                }
            }
            catch (IOException)
            {
                // Login must remain available if preferences cannot be cleared.
            }
            catch (UnauthorizedAccessException)
            {
                // Login must remain available if preferences cannot be cleared.
            }
        }


        private void Login(bool showErrorMessage)
        {
            clsUser user = clsUser.ValidateUser(tbUsername.Text, tbPassword.Text);

            if (user != null)
            {
                if (cbRememberMe.Checked)
                {
                   SaveLoginInfo();
                }
                else
                {
                    ClearLoginInfo();
                }
                    


                this.Hide();
                clsGlobal.SignIn(user);
                Form mainForm = new fWelcome();
                mainForm.ShowDialog();
                if (clsGlobal.IsLoggedIn())
                {
                  this.Close();
                } else
                {
                   tbUsername.Clear();
                   tbPassword.Clear();
                   cbRememberMe.Checked = false;
                   this.Show();
                   tbUsername.Focus();
                }
                
            }
            else
            {
                if (showErrorMessage)
                    MessageBox.Show("Invalid username or password.");
            }
        }
        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login(true);
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            LoadLoginInfo();
        }

        private void cbRememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
