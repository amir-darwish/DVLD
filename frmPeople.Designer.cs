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
            this.picGroupePeople = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbFilterBy = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFillterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.lbRecord = new System.Windows.Forms.Label();
            this.btnAddNewPeson = new Guna.UI2.WinForms.Guna2Button();
            this.tShowDetails = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dgvPeople.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.dgvPeople.Location = new System.Drawing.Point(12, 235);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvPeople.RowHeadersVisible = false;
            this.dgvPeople.RowHeadersWidth = 51;
            this.dgvPeople.RowTemplate.Height = 30;
            this.dgvPeople.Size = new System.Drawing.Size(1109, 560);
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
            this.Edit.Size = new System.Drawing.Size(211, 104);
            // 
            // tEdit
            // 
            this.tEdit.Name = "tEdit";
            this.tEdit.Size = new System.Drawing.Size(210, 24);
            this.tEdit.Text = "Edit";
            this.tEdit.Click += new System.EventHandler(this.tEdit_Click);
            // 
            // tDelete
            // 
            this.tDelete.Name = "tDelete";
            this.tDelete.Size = new System.Drawing.Size(210, 24);
            this.tDelete.Text = "Delete";
            this.tDelete.Click += new System.EventHandler(this.tDelete_Click);
            // 
            // picGroupePeople
            // 
            this.picGroupePeople.Image = ((System.Drawing.Image)(resources.GetObject("picGroupePeople.Image")));
            this.picGroupePeople.InitialImage = ((System.Drawing.Image)(resources.GetObject("picGroupePeople.InitialImage")));
            this.picGroupePeople.Location = new System.Drawing.Point(501, 12);
            this.picGroupePeople.Name = "picGroupePeople";
            this.picGroupePeople.Size = new System.Drawing.Size(252, 109);
            this.picGroupePeople.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGroupePeople.TabIndex = 2;
            this.picGroupePeople.TabStop = false;
            this.picGroupePeople.Click += new System.EventHandler(this.picGroupePeople_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(519, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "Manage People";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbFilterBy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbFillterBy);
            this.groupBox1.Location = new System.Drawing.Point(14, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 103);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtbFilterBy
            // 
            this.txtbFilterBy.Animated = true;
            this.txtbFilterBy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbFilterBy.DefaultText = "";
            this.txtbFilterBy.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbFilterBy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbFilterBy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbFilterBy.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbFilterBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtbFilterBy.ForeColor = System.Drawing.Color.Black;
            this.txtbFilterBy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbFilterBy.Location = new System.Drawing.Point(317, 33);
            this.txtbFilterBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbFilterBy.Name = "txtbFilterBy";
            this.txtbFilterBy.PlaceholderText = "Try Filter !";
            this.txtbFilterBy.SelectedText = "";
            this.txtbFilterBy.Size = new System.Drawing.Size(174, 36);
            this.txtbFilterBy.TabIndex = 2;
            this.txtbFilterBy.TextChanged += new System.EventHandler(this.txtbFilterBy_TextChanged);
            this.txtbFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFilterBy_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filter By :";
            // 
            // cbFillterBy
            // 
            this.cbFillterBy.BackColor = System.Drawing.Color.Transparent;
            this.cbFillterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFillterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFillterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFillterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFillterBy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFillterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFillterBy.ItemHeight = 30;
            this.cbFillterBy.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No.",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality",
            "Gender",
            "Phone",
            "Email"});
            this.cbFillterBy.Location = new System.Drawing.Point(123, 33);
            this.cbFillterBy.Name = "cbFillterBy";
            this.cbFillterBy.Size = new System.Drawing.Size(175, 36);
            this.cbFillterBy.StartIndex = 0;
            this.cbFillterBy.TabIndex = 0;
            this.cbFillterBy.SelectedIndexChanged += new System.EventHandler(this.cbFillterBy_SelectedIndexChanged);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(73, 805);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(50, 16);
            this.lblRecordsCount.TabIndex = 5;
            this.lblRecordsCount.Text = "label3";
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecord.Location = new System.Drawing.Point(12, 805);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(58, 17);
            this.lbRecord.TabIndex = 6;
            this.lbRecord.Text = "Record :";
            // 
            // btnAddNewPeson
            // 
            this.btnAddNewPeson.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewPeson.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewPeson.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewPeson.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewPeson.FillColor = System.Drawing.Color.Transparent;
            this.btnAddNewPeson.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNewPeson.ForeColor = System.Drawing.Color.White;
            this.btnAddNewPeson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewPeson.Image")));
            this.btnAddNewPeson.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAddNewPeson.Location = new System.Drawing.Point(1042, 167);
            this.btnAddNewPeson.Name = "btnAddNewPeson";
            this.btnAddNewPeson.Size = new System.Drawing.Size(79, 51);
            this.btnAddNewPeson.TabIndex = 7;
            this.btnAddNewPeson.Click += new System.EventHandler(this.btnAddNewPeson_Click);
            // 
            // tShowDetails
            // 
            this.tShowDetails.Name = "tShowDetails";
            this.tShowDetails.Size = new System.Drawing.Size(210, 24);
            this.tShowDetails.Text = "Show Details";
            this.tShowDetails.Click += new System.EventHandler(this.tShowDetails_Click);
            // 
            // frmPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 830);
            this.Controls.Add(this.btnAddNewPeson);
            this.Controls.Add(this.lbRecord);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picGroupePeople);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.groupBox1);
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
        private Guna.UI2.WinForms.Guna2ComboBox cbFillterBy;
        private Guna.UI2.WinForms.Guna2TextBox txtbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label lbRecord;
        private Guna.UI2.WinForms.Guna2Button btnAddNewPeson;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip Edit;
        private System.Windows.Forms.ToolStripMenuItem tEdit;
        private System.Windows.Forms.ToolStripMenuItem tDelete;
        private System.Windows.Forms.ToolStripMenuItem tShowDetails;
    }
}