namespace DVLD
{
    partial class frmAddNewPerson
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
            this.add_UpdatePerson1 = new DVLD.Add_UpdatePerson();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // add_UpdatePerson1
            // 
            this.add_UpdatePerson1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.add_UpdatePerson1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_UpdatePerson1.Location = new System.Drawing.Point(11, 22);
            this.add_UpdatePerson1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.add_UpdatePerson1.Name = "add_UpdatePerson1";
            this.add_UpdatePerson1.Size = new System.Drawing.Size(1136, 680);
            this.add_UpdatePerson1.TabIndex = 0;
            this.add_UpdatePerson1.Load += new System.EventHandler(this.add_UpdatePerson1_Load);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // frmAddNewPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 810);
            this.Controls.Add(this.add_UpdatePerson1);
            this.Name = "frmAddNewPerson";
            this.Text = "frmAddNewPerson";
            this.ResumeLayout(false);

        }

        #endregion

        private Add_UpdatePerson add_UpdatePerson1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
