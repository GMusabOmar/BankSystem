using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using businessAccess;

namespace BankSystem.Persons.Customers
{
    public partial class frmFindPersonToAddCustomer : Form
    {
        private int _PersonID = -1;
        private clsCustomer _CustomerInfo;
        public frmFindPersonToAddCustomer()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmFindPersonToAddCustomer_Activated(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.FilterFocus();
        }
        private void btnMakeCustomer_Click(object sender, EventArgs e)
        {
            _CustomerInfo = new clsCustomer();
            bool AddNewCustomer = _CustomerInfo.AddNewCustomer(_PersonID);
            if(AddNewCustomer)
            {
                MessageBox.Show($"Done add customer with id = {_PersonID}", "successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMakeCustomer.Enabled = false;
            }
            else
                MessageBox.Show($"Not add customer with id = {_PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void frmFindPersonToAddCustomer_Load(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.FilterEnable = true;
            ctrlPersonInfoWithFilter1.FilterFocus();
        }
        private void ctrlPersonInfoWithFilter1_OnPersonSelectedFromFilter2(int obj)
        {
            _PersonID = obj;

            // Person exists in listPerson
            if(!clsPeron.IsExistsPerson(_PersonID))
                return;

            // Person exists in listCustomer
            if (clsCustomer.IsExistsCustomerByFPerson_ID(_PersonID))
            {
                MessageBox.Show($"Person already customer with id = {_PersonID}", "previously", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctrlPersonInfoWithFilter1.FilterEnable = false;
            btnMakeCustomer.Enabled = true;
        }
    }
}
