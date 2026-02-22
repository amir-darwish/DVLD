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
    public partial class frmAddNewPerson : Form
    {
        public frmAddNewPerson()
        {
            InitializeComponent();
        }

        public frmAddNewPerson(int personID)
        {
            InitializeComponent();
            add_UpdatePerson1.LoadPersonData(personID);
        }

        private void add_UpdatePerson1_Load(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
