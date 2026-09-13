namespace DVLD
{
    partial class frmAddTestAppointment
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
            this.gbTestInfo = new System.Windows.Forms.GroupBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDLAPPID = new System.Windows.Forms.Label();
            this.lbDClass = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbFees = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.gbRetakeTest = new System.Windows.Forms.GroupBox();
            this.lbRFees = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbRtotalFees = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbRAPPID = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.gbTestInfo.SuspendLayout();
            this.gbRetakeTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTestInfo
            // 
            this.gbTestInfo.Controls.Add(this.btnSave);
            this.gbTestInfo.Controls.Add(this.gbRetakeTest);
            this.gbTestInfo.Controls.Add(this.guna2DateTimePicker1);
            this.gbTestInfo.Controls.Add(this.lbFees);
            this.gbTestInfo.Controls.Add(this.label6);
            this.gbTestInfo.Controls.Add(this.label7);
            this.gbTestInfo.Controls.Add(this.label2);
            this.gbTestInfo.Controls.Add(this.label5);
            this.gbTestInfo.Controls.Add(this.lbName);
            this.gbTestInfo.Controls.Add(this.label4);
            this.gbTestInfo.Controls.Add(this.lbDClass);
            this.gbTestInfo.Controls.Add(this.label3);
            this.gbTestInfo.Controls.Add(this.lbDLAPPID);
            this.gbTestInfo.Controls.Add(this.label1);
            this.gbTestInfo.Controls.Add(this.lbTitle);
            this.gbTestInfo.Location = new System.Drawing.Point(5, 3);
            this.gbTestInfo.Name = "gbTestInfo";
            this.gbTestInfo.Size = new System.Drawing.Size(387, 523);
            this.gbTestInfo.TabIndex = 0;
            this.gbTestInfo.TabStop = false;
            this.gbTestInfo.Text = "groupBox1";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Century Gothic", 13.25F, System.Drawing.FontStyle.Bold);
            this.lbTitle.Location = new System.Drawing.Point(146, 37);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(64, 22);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "D.L APP ID :";
            // 
            // lbDLAPPID
            // 
            this.lbDLAPPID.AutoSize = true;
            this.lbDLAPPID.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDLAPPID.Location = new System.Drawing.Point(115, 98);
            this.lbDLAPPID.Name = "lbDLAPPID";
            this.lbDLAPPID.Size = new System.Drawing.Size(25, 15);
            this.lbDLAPPID.TabIndex = 2;
            this.lbDLAPPID.Text = "##";
            // 
            // lbDClass
            // 
            this.lbDClass.AutoSize = true;
            this.lbDClass.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDClass.Location = new System.Drawing.Point(115, 137);
            this.lbDClass.Name = "lbDClass";
            this.lbDClass.Size = new System.Drawing.Size(25, 15);
            this.lbDClass.TabIndex = 4;
            this.lbDClass.Text = "##";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "D.Class :";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(115, 175);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(25, 15);
            this.lbName.TabIndex = 6;
            this.lbName.Text = "##";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "##";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Trial :";
            // 
            // lbFees
            // 
            this.lbFees.AutoSize = true;
            this.lbFees.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFees.Location = new System.Drawing.Point(115, 287);
            this.lbFees.Name = "lbFees";
            this.lbFees.Size = new System.Drawing.Size(25, 15);
            this.lbFees.TabIndex = 10;
            this.lbFees.Text = "##";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Fees :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Date :";
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.FillColor = System.Drawing.Color.Gray;
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(118, 251);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(193, 19);
            this.guna2DateTimePicker1.TabIndex = 11;
            this.guna2DateTimePicker1.Value = new System.DateTime(2026, 8, 25, 14, 58, 55, 90);
            // 
            // gbRetakeTest
            // 
            this.gbRetakeTest.Controls.Add(this.lbRtotalFees);
            this.gbRetakeTest.Controls.Add(this.label10);
            this.gbRetakeTest.Controls.Add(this.lbRAPPID);
            this.gbRetakeTest.Controls.Add(this.label8);
            this.gbRetakeTest.Controls.Add(this.lbRFees);
            this.gbRetakeTest.Controls.Add(this.label9);
            this.gbRetakeTest.Location = new System.Drawing.Point(10, 329);
            this.gbRetakeTest.Name = "gbRetakeTest";
            this.gbRetakeTest.Size = new System.Drawing.Size(367, 96);
            this.gbRetakeTest.TabIndex = 12;
            this.gbRetakeTest.TabStop = false;
            this.gbRetakeTest.Text = "ReTake Test";
            // 
            // lbRFees
            // 
            this.lbRFees.AutoSize = true;
            this.lbRFees.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRFees.Location = new System.Drawing.Point(105, 30);
            this.lbRFees.Name = "lbRFees";
            this.lbRFees.Size = new System.Drawing.Size(25, 15);
            this.lbRFees.TabIndex = 14;
            this.lbRFees.Text = "##";
            this.lbRFees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "R. APP Fees :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRtotalFees
            // 
            this.lbRtotalFees.AutoSize = true;
            this.lbRtotalFees.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRtotalFees.Location = new System.Drawing.Point(270, 30);
            this.lbRtotalFees.Name = "lbRtotalFees";
            this.lbRtotalFees.Size = new System.Drawing.Size(25, 15);
            this.lbRtotalFees.TabIndex = 16;
            this.lbRtotalFees.Text = "##";
            this.lbRtotalFees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(192, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Total Fees :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "R. APP ID :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRAPPID
            // 
            this.lbRAPPID.AutoSize = true;
            this.lbRAPPID.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRAPPID.Location = new System.Drawing.Point(105, 62);
            this.lbRAPPID.Name = "lbRAPPID";
            this.lbRAPPID.Size = new System.Drawing.Size(25, 15);
            this.lbRAPPID.TabIndex = 14;
            this.lbRAPPID.Text = "##";
            this.lbRAPPID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.Gray;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(94, 444);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 34);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 529);
            this.Controls.Add(this.gbTestInfo);
            this.Name = "frmAddTestAppointment";
            this.Text = "frmAddTestAppointment";
            this.Load += new System.EventHandler(this.frmAddTestAppointment_Load);
            this.gbTestInfo.ResumeLayout(false);
            this.gbTestInfo.PerformLayout();
            this.gbRetakeTest.ResumeLayout(false);
            this.gbRetakeTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTestInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbDLAPPID;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private System.Windows.Forms.Label lbFees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbDClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbRetakeTest;
        private System.Windows.Forms.Label lbRtotalFees;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbRAPPID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbRFees;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Button btnSave;
    }
}
