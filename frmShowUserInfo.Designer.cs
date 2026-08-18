namespace DVLD
{
    partial class frmShowUserInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlShowDetails1 = new DVLD.ctrlShowDetails();
            this.gbUserInfo = new System.Windows.Forms.GroupBox();
            this.lbIsActive = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbChangePassword = new System.Windows.Forms.GroupBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.tbReTypePass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNewPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCurrentPass = new System.Windows.Forms.TextBox();
            this.gbUserInfo.SuspendLayout();
            this.gbChangePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlShowDetails1
            // 
            this.ctrlShowDetails1.Location = new System.Drawing.Point(11, 11);
            this.ctrlShowDetails1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrlShowDetails1.Name = "ctrlShowDetails1";
            this.ctrlShowDetails1.Size = new System.Drawing.Size(778, 373);
            this.ctrlShowDetails1.TabIndex = 0;
            // 
            // gbUserInfo
            // 
            this.gbUserInfo.Controls.Add(this.lbIsActive);
            this.gbUserInfo.Controls.Add(this.label4);
            this.gbUserInfo.Controls.Add(this.lbUsername);
            this.gbUserInfo.Controls.Add(this.label3);
            this.gbUserInfo.Controls.Add(this.lbUserID);
            this.gbUserInfo.Controls.Add(this.label1);
            this.gbUserInfo.Location = new System.Drawing.Point(23, 373);
            this.gbUserInfo.Name = "gbUserInfo";
            this.gbUserInfo.Size = new System.Drawing.Size(748, 73);
            this.gbUserInfo.TabIndex = 1;
            this.gbUserInfo.TabStop = false;
            this.gbUserInfo.Text = "User Info";
            // 
            // lbIsActive
            // 
            this.lbIsActive.AutoSize = true;
            this.lbIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lbIsActive.Location = new System.Drawing.Point(563, 38);
            this.lbIsActive.Name = "lbIsActive";
            this.lbIsActive.Size = new System.Drawing.Size(31, 13);
            this.lbIsActive.TabIndex = 5;
            this.lbIsActive.Text = "0000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(483, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "IsActive :";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.Location = new System.Drawing.Point(348, 40);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(24, 13);
            this.lbUsername.TabIndex = 3;
            this.lbUsername.Text = "test";
            this.lbUsername.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(250, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lbUserID.Location = new System.Drawing.Point(151, 37);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(31, 13);
            this.lbUserID.TabIndex = 1;
            this.lbUserID.Text = "0000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(71, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // gbChangePassword
            // 
            this.gbChangePassword.Controls.Add(this.guna2Button1);
            this.gbChangePassword.Controls.Add(this.tbReTypePass);
            this.gbChangePassword.Controls.Add(this.label6);
            this.gbChangePassword.Controls.Add(this.tbNewPass);
            this.gbChangePassword.Controls.Add(this.label5);
            this.gbChangePassword.Controls.Add(this.label2);
            this.gbChangePassword.Controls.Add(this.tbCurrentPass);
            this.gbChangePassword.Location = new System.Drawing.Point(23, 463);
            this.gbChangePassword.Name = "gbChangePassword";
            this.gbChangePassword.Size = new System.Drawing.Size(748, 143);
            this.gbChangePassword.TabIndex = 2;
            this.gbChangePassword.TabStop = false;
            this.gbChangePassword.Text = "Change Password";
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(438, 108);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(237, 29);
            this.guna2Button1.TabIndex = 11;
            this.guna2Button1.Text = "Change Password";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // tbReTypePass
            // 
            this.tbReTypePass.Location = new System.Drawing.Point(472, 70);
            this.tbReTypePass.Name = "tbReTypePass";
            this.tbReTypePass.Size = new System.Drawing.Size(143, 20);
            this.tbReTypePass.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(315, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Retype Password :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tbNewPass
            // 
            this.tbNewPass.Location = new System.Drawing.Point(472, 32);
            this.tbNewPass.Name = "tbNewPass";
            this.tbNewPass.Size = new System.Drawing.Size(143, 20);
            this.tbNewPass.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(315, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "New Password :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Current Password :";
            // 
            // tbCurrentPass
            // 
            this.tbCurrentPass.Location = new System.Drawing.Point(166, 32);
            this.tbCurrentPass.Name = "tbCurrentPass";
            this.tbCurrentPass.Size = new System.Drawing.Size(143, 20);
            this.tbCurrentPass.TabIndex = 0;
            // 
            // frmShowUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 640);
            this.Controls.Add(this.gbChangePassword);
            this.Controls.Add(this.gbUserInfo);
            this.Controls.Add(this.ctrlShowDetails1);
            this.Name = "frmShowUserInfo";
            this.Text = "frmShowUserInfo";
            this.gbUserInfo.ResumeLayout(false);
            this.gbUserInfo.PerformLayout();
            this.gbChangePassword.ResumeLayout(false);
            this.gbChangePassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowDetails ctrlShowDetails1;
        private System.Windows.Forms.GroupBox gbUserInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbUserID;
        private System.Windows.Forms.Label lbIsActive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbChangePassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCurrentPass;
        private System.Windows.Forms.TextBox tbNewPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbReTypePass;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}