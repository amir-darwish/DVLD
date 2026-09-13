namespace DVLD
{
    partial class ctrlFilter
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.txtbFilterBy = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFillterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SuspendLayout();
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
            this.txtbFilterBy.Location = new System.Drawing.Point(238, 15);
            this.txtbFilterBy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtbFilterBy.Name = "txtbFilterBy";
            this.txtbFilterBy.PlaceholderText = "Try Filter !";
            this.txtbFilterBy.SelectedText = "";
            this.txtbFilterBy.Size = new System.Drawing.Size(170, 29);
            this.txtbFilterBy.TabIndex = 5;
            this.txtbFilterBy.TextChanged += new System.EventHandler(this.txtbFilterBy_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 4;
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
            this.cbFillterBy.Location = new System.Drawing.Point(92, 15);
            this.cbFillterBy.Margin = new System.Windows.Forms.Padding(2);
            this.cbFillterBy.Name = "cbFillterBy";
            this.cbFillterBy.Size = new System.Drawing.Size(132, 36);
            this.cbFillterBy.TabIndex = 3;
            this.cbFillterBy.SelectedIndexChanged += new System.EventHandler(this.cbFillterBy_SelectedIndexChanged);
            // 
            // ctrlFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.txtbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFillterBy);
            this.Name = "ctrlFilter";
            this.Size = new System.Drawing.Size(430, 64);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtbFilterBy;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbFillterBy;
    }
}
