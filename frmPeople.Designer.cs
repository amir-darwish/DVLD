namespace DVLD
{
    partial class frmPeople
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPeople));
            this.dgvPeople = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Edit = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.tEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.picGroupePeople = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrlFilter1 = new DVLD.ctrlFilter();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.lbRecord = new System.Windows.Forms.Label();
            this.btnAddNewPeson = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.Edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGroupePeople)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.AllowUserToOrderColumns = true;
            this.dgvPeople.AllowUserToResizeColumns = false;
            this.dgvPeople.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeople.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPeople.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPeople.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPeople.ColumnHeadersHeight = 30;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPeople.ContextMenuStrip = this.Edit;
            this.dgvPeople.Cursor = System.Windows.Forms.Cursors.IBeam;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeople.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPeople.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.dgvPeople.Location = new System.Drawing.Point(9, 191);
            this.dgvPeople.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvPeople.RowHeadersVisible = false;
            this.dgvPeople.RowHeadersWidth = 51;
            this.dgvPeople.RowTemplate.Height = 30;
            this.dgvPeople.Size = new System.Drawing.Size(935, 455);
            this.dgvPeople.TabIndex = 0;
            this.dgvPeople.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.dgvPeople.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvPeople.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPeople.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPeople.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPeople.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPeople.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPeople.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.dgvPeople.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.dgvPeople.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPeople.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPeople.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPeople.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPeople.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvPeople.ThemeStyle.ReadOnly = true;
            this.dgvPeople.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvPeople.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPeople.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPeople.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPeople.ThemeStyle.RowsStyle.Height = 30;
            this.dgvPeople.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.dgvPeople.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPeople.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeople_CellContentClick);
            this.dgvPeople.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPeople_CellMouseDown);
            // 
            // Edit
            // 
            this.Edit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Edit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tEdit,
            this.tDelete,
            this.tShowDetails});
            this.Edit.Name = "Edit";
            this.Edit.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.Edit.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.Edit.RenderStyle.ColorTable = null;
            this.Edit.RenderStyle.RoundedEdges = true;
            this.Edit.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.Edit.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Edit.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.Edit.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.Edit.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.Edit.Size = new System.Drawing.Size(165, 76);
            // 
            // tEdit
            // 
            this.tEdit.Name = "tEdit";
            this.tEdit.Size = new System.Drawing.Size(164, 24);
            this.tEdit.Text = "Edit";
            this.tEdit.Click += new System.EventHandler(this.tEdit_Click);
            // 
            // tDelete
            // 
            this.tDelete.Name = "tDelete";
            this.tDelete.Size = new System.Drawing.Size(164, 24);
            this.tDelete.Text = "Delete";
            this.tDelete.Click += new System.EventHandler(this.tDelete_Click);
            // 
            // tShowDetails
            // 
            this.tShowDetails.Name = "tShowDetails";
            this.tShowDetails.Size = new System.Drawing.Size(164, 24);
            this.tShowDetails.Text = "Show Details";
            this.tShowDetails.Click += new System.EventHandler(this.tShowDetails_Click);
            // 
            // picGroupePeople
            // 
            this.picGroupePeople.Image = ((System.Drawing.Image)(resources.GetObject("picGroupePeople.Image")));
            this.picGroupePeople.InitialImage = ((System.Drawing.Image)(resources.GetObject("picGroupePeople.InitialImage")));
            this.picGroupePeople.Location = new System.Drawing.Point(376, 10);
            this.picGroupePeople.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picGroupePeople.Name = "picGroupePeople";
            this.picGroupePeople.Size = new System.Drawing.Size(189, 89);
            this.picGroupePeople.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGroupePeople.TabIndex = 2;
            this.picGroupePeople.TabStop = false;
            this.picGroupePeople.Click += new System.EventHandler(this.picGroupePeople_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(389, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "Manage People";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ctrlFilter1);
            this.groupBox1.Location = new System.Drawing.Point(10, 121);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(477, 84);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // ctrlFilter1
            // 
            this.ctrlFilter1.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlFilter1.Location = new System.Drawing.Point(3, 14);
            this.ctrlFilter1.Name = "ctrlFilter1";
            this.ctrlFilter1.Size = new System.Drawing.Size(430, 64);
            this.ctrlFilter1.TabIndex = 3;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(55, 654);
            this.lblRecordsCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(50, 16);
            this.lblRecordsCount.TabIndex = 5;
            this.lblRecordsCount.Text = "label3";
            // 
            // lbRecord
            // 
            this.lbRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecord.Location = new System.Drawing.Point(9, 654);
            this.lbRecord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(58, 17);
            this.lbRecord.TabIndex = 6;
            this.lbRecord.Text = "Record :";
            // 
            // btnAddNewPeson
            // 
            this.btnAddNewPeson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewPeson.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewPeson.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewPeson.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewPeson.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewPeson.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewPeson.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNewPeson.ForeColor = System.Drawing.Color.White;
            this.btnAddNewPeson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewPeson.Image")));
            this.btnAddNewPeson.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAddNewPeson.Location = new System.Drawing.Point(885, 136);
            this.btnAddNewPeson.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddNewPeson.Name = "btnAddNewPeson";
            this.btnAddNewPeson.Size = new System.Drawing.Size(59, 41);
            this.btnAddNewPeson.TabIndex = 7;
            this.btnAddNewPeson.Click += new System.EventHandler(this.btnAddNewPeson_Click);
            // 
            // frmPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 674);
            this.Controls.Add(this.btnAddNewPeson);
            this.Controls.Add(this.lbRecord);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picGroupePeople);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmPeople";
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmPeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.Edit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGroupePeople)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridViewStyler guna2DataGridViewStyler1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPeople;
        private System.Windows.Forms.PictureBox picGroupePeople;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ctrlFilter ctrlFilter1;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label lbRecord;
        private Guna.UI2.WinForms.Guna2Button btnAddNewPeson;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip Edit;
        private System.Windows.Forms.ToolStripMenuItem tEdit;
        private System.Windows.Forms.ToolStripMenuItem tDelete;
        private System.Windows.Forms.ToolStripMenuItem tShowDetails;
    }
}
