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
        public delegate void DataBackEventHandler(object sender, int personID);

        public event DataBackEventHandler DataBack;

        public frmAddNewPerson()
        {
            InitializeComponent();
            subscribeToDataSavedEvent();
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

        private void add_UpdatePerson1_DataSaved(object sender, int personID)
        {
            DataBack?.Invoke(this, personID);
            this.Close();
        }

        private void subscribeToDataSavedEvent()
        {
            add_UpdatePerson1.DataBack += add_UpdatePerson1_DataSaved;
        }
    }
}
