namespace DVLD
{
    partial class frmVisionTestAppointments
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
            this.ctrlVisionTestAppointment1 = new DVLD.ctrlVisionTestAppointment();
            this.SuspendLayout();
            // 
            // ctrlVisionTestAppointment1
            // 
            this.ctrlVisionTestAppointment1.Location = new System.Drawing.Point(12, 12);
            this.ctrlVisionTestAppointment1.Name = "ctrlVisionTestAppointment1";
            this.ctrlVisionTestAppointment1.Size = new System.Drawing.Size(704, 513);
            this.ctrlVisionTestAppointment1.TabIndex = 0;
            // 
            // frmVisionTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 518);
            this.Controls.Add(this.ctrlVisionTestAppointment1);
            this.Name = "frmVisionTestAppointments";
            this.Text = "frmVisionTestAppointments";
            this.Load += new System.EventHandler(this.frmVisionTestAppointments_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlVisionTestAppointment ctrlVisionTestAppointment1;
    }
}