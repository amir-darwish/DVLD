using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlUserPersonInfo : UserControl
    {
        public delegate void PersonSelectedEventHandler(object sender, int personID);

        public event PersonSelectedEventHandler PersonSelected;
        public event EventHandler PersonCleared;
        public event EventHandler NextClicked;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public ctrlUserPersonInfo()
        {
            InitializeComponent();
            InitFilter();
            btnSearch.Enabled = false;
        }

        private void InitFilter()
        {
            ctrlFilter1.SetSearchFilter(
                new ctrlFilter.clsFilterColumn("National No.", "NationalNo", ctrlFilter.enFilterDataType.Text),
                new ctrlFilter.clsFilterColumn("Person ID", "PersonID", ctrlFilter.enFilterDataType.Number));

            ctrlFilter1.FilterValueChanged += ctrlFilter1_FilterValueChanged;
        }

        public void LoadPersonInfo(int personID)
        {
            ctrlFilter1.SetSelectedFilter("Person ID");
            ctrlFilter1.SetFilterValue(personID.ToString());
            _PersonID = personID;
            ctrlShowDetails1.LoadPersonInfo(personID);
            PersonSelected?.Invoke(this, personID);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ctrlFilter1.FilterValue))
            {
                btnSearch.Enabled = false;
                return;
            }

            clsPerson person = null;

            if (ctrlFilter1.SelectedFilterText == "Person ID")
            {
                if (!int.TryParse(ctrlFilter1.FilterValue, out int personID))
                {
                    MessageBox.Show("Please enter a valid numeric Person ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                person = clsPerson.Find(personID);
            }
            else
            {
                person = clsPerson.Find(ctrlFilter1.FilterValue);
            }

            if (person == null)
            {
                MessageBox.Show("Person was not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadPersonInfo(person.PersonID);
        }

        private void ctrlFilter1_FilterValueChanged(object sender, EventArgs e)
        {
            _PersonID = -1;
            btnSearch.Enabled = !string.IsNullOrWhiteSpace(ctrlFilter1.FilterValue);
            PersonCleared?.Invoke(this, EventArgs.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNewPerson addPersonForm = new frmAddNewPerson();
            addPersonForm.DataBack += frmAddNewUser_DataBack;
            addPersonForm.ShowDialog();
        }

        private void frmAddNewUser_DataBack(object sender, int PersonID)
        {
            LoadPersonInfo(PersonID);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ctrlUserPersonInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
