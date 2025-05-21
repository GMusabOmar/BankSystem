using System;
using businessAccess;
using System.Windows.Forms;
using System.Drawing;

namespace BankSystem.Persons.Control
{
    public partial class ctrlPersonInfo : UserControl
    {
        private clsPeron _Person;
        public int PersonId = -1;
        public void ResetDefaultValues()
        {
            PersonId = -1;
            lblPersonID.Text = "???";
            lblName.Text = "???";
            lblEmail.Text = "???";
            lblAddress.Text = "???";
            lblPhone.Text = "???";
            lblAccount.Text = "???";
            lblCreditCard.Text = "???";
        }
        private bool _HaveAccount()
        {
            clsCustomer _CustomerInfo = clsCustomer.FindCustomerByPersonID(PersonId);
            if (_CustomerInfo != null)
                if (clsAccount.IsExistsAccount(_CustomerInfo.AccountID))
                    return true;
            return false;
        }
        private bool _HaveCreditCard()
        {
            clsCustomer _CustomerInfo = clsCustomer.FindCustomerByPersonID(PersonId);
            if (_CustomerInfo != null)
            {
                clsAccount _Account = clsAccount.FindAccount(_CustomerInfo.AccountID);
                if (_Account != null)
                    if (clsCreditCard.IsExistsCreditCardByAccountID(_Account.AccountID))
                         return true;
            }
            return false;
        }
        private void _LoadInfo()
        {
            lblPersonID.Text = PersonId.ToString();
            lblName.Text = _Person.FullName;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblPhone.Text = _Person.Phone;
            if(_HaveAccount())
            {
                lblAccount.Text = "Yes";
                lblAccount.ForeColor = Color.Green;
            }
            else
                lblAccount.Text = "No";
            if(_HaveCreditCard())
            {
                lblCreditCard.Text = "Yes";
                lblCreditCard.ForeColor = Color.Green;
            }
            else
                lblCreditCard.Text = "No";
        }
        public ctrlPersonInfo()
        {
            InitializeComponent();
        }
        public void LoadPersonInfo(int PersonID)
        {
            ResetDefaultValues();
            PersonId = PersonID;
            _Person = clsPeron.FindPerson(PersonID);
            if(_Person == null)
            {
                MessageBox.Show("Not found person with id = " + PersonID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadInfo();
        }
    }
}
