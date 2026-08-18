namespace DVLD
{
    partial class frmAddUpdateUser
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlUserPersonInfo1 = new DVLD.ctrlUserPersonInfo();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.lbID = new System.Windows.Forms.Label();
            this.chbActive = new Guna.UI2.WinForms.Guna2CheckBox();
            this.tbConfirmPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(833, 603);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlUserPersonInfo1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(825, 577);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personal Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrlUserPersonInfo1
            // 
            this.ctrlUserPersonInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlUserPersonInfo1.Name = "ctrlUserPersonInfo1";
            this.ctrlUserPersonInfo1.Size = new System.Drawing.Size(825, 577);
            this.ctrlUserPersonInfo1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.lbID);
            this.tabPage2.Controls.Add(this.chbActive);
            this.tabPage2.Controls.Add(this.tbConfirmPass);
            this.tabPage2.Controls.Add(this.tbPass);
            this.tabPage2.Controls.Add(this.tbUsername);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(825, 577);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Login Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.SystemColors.Desktop;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(248, 329);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 45);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbID.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbID.Location = new System.Drawing.Point(245, 102);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(36, 18);
            this.lbID.TabIndex = 9;
            this.lbID.Text = "??? ";
            this.lbID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chbActive
            // 
            this.chbActive.AutoSize = true;
            this.chbActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbActive.CheckedState.BorderRadius = 0;
            this.chbActive.CheckedState.BorderThickness = 0;
            this.chbActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chbActive.Location = new System.Drawing.Point(248, 272);
            this.chbActive.Name = "chbActive";
            this.chbActive.Size = new System.Drawing.Size(15, 14);
            this.chbActive.TabIndex = 8;
            this.chbActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbActive.UncheckedState.BorderRadius = 0;
            this.chbActive.UncheckedState.BorderThickness = 0;
            this.chbActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // tbConfirmPass
            // 
            this.tbConfirmPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbConfirmPass.DefaultText = "";
            this.tbConfirmPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbConfirmPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbConfirmPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbConfirmPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbConfirmPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbConfirmPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbConfirmPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbConfirmPass.Location = new System.Drawing.Point(248, 230);
            this.tbConfirmPass.Name = "tbConfirmPass";
            this.tbConfirmPass.PlaceholderText = "";
            this.tbConfirmPass.SelectedText = "";
            this.tbConfirmPass.Size = new System.Drawing.Size(118, 25);
            this.tbConfirmPass.TabIndex = 7;
            // 
            // tbPass
            // 
            this.tbPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPass.DefaultText = "";
            this.tbPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPass.Location = new System.Drawing.Point(248, 185);
            this.tbPass.Name = "tbPass";
            this.tbPass.PlaceholderText = "";
            this.tbPass.SelectedText = "";
            this.tbPass.Size = new System.Drawing.Size(118, 25);
            this.tbPass.TabIndex = 6;
            // 
            // tbUsername
            // 
            this.tbUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbUsername.DefaultText = "";
            this.tbUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbUsername.Location = new System.Drawing.Point(248, 137);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.PlaceholderText = "";
            this.tbUsername.SelectedText = "";
            this.tbUsername.Size = new System.Drawing.Size(118, 25);
            this.tbUsername.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label6.Location = new System.Drawing.Point(65, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Active :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.Location = new System.Drawing.Point(65, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Confirm Password :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.Location = new System.Drawing.Point(65, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.Location = new System.Drawing.Point(65, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "User Name :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(65, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "User ID :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // frmAddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 615);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAddUpdateUser";
            this.Text = "frmAddNewUser";
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ctrlUserPersonInfo ctrlUserPersonInfo1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox tbConfirmPass;
        private Guna.UI2.WinForms.Guna2TextBox tbPass;
        private Guna.UI2.WinForms.Guna2TextBox tbUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2CheckBox chbActive;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label lbID;
    }
}
