using System;
using System.Windows.Forms;

namespace BankSystem.Persons
{
    public partial class frmFindPerson : Form
    {
        public int PersonID = -1;
        public frmFindPerson()
        {
            InitializeComponent();
        }
        private void frmFindPerson_Load(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.OnPersonSelectedFromFilter2 += _GetPersonID;
        }
        private void _GetPersonID(int PersonId)
        {
            PersonID = PersonId;
        }

        private void frmFindPerson_Activated(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.FilterFocus();
        }
    }
}
