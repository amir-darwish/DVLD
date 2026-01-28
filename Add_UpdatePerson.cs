using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Add_UpdatePerson : UserControl
    {
        
        DataTable dtCountry = new DataTable();
        enum enMode
        {
            Add,
            Update
        }
        enMode Mode;
        public Add_UpdatePerson()
        {
            InitializeComponent();
            InitCountryComboBox();

            guna2DateTimePicker1.MaxDate = DateTime.Now.AddYears(-18) ; // Set minimum date to 18 years ago
        }

        private void InitCountryComboBox()
        {
            cbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            dtCountry = clsCountry.GetAllCountries();
            foreach (DataRow row in dtCountry.Rows)
            {
                cbCountry.Items.Add(row["CountryName"].ToString());
            }
            if (this.Mode == enMode.Add )
                cbCountry.SelectedIndex = 0; // Select the first country by default
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_UpdatePerson_Load(object sender, EventArgs e)
        {

        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMale.Checked)
            {
                rdFemale.Checked = false;
                pbProfile.Load("../../icons/man.png");
            }
        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFemale.Checked)
            {
                rdMale.Checked = false;
                pbProfile.Load("../../icons/woman.png");
            }
        }
    }
}
