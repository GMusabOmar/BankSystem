using System;
using System.Windows.Forms;

namespace BankSystem.Persons
{
    public partial class frmShowPersonInfo : Form
    {
        private int _PersonID = 0;
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        private void frmPersonInfo_Load(object sender, EventArgs e)
        {
            ctrlPersonInfo1.LoadPersonInfo(_PersonID);
            if(ctrlPersonInfo1.PersonId == -1)
            {
                this.Close();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
