using System;
using System.Data;
using businessAccess;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BankSystem.SendMoneies
{
    public partial class frmAddNewSendMoney : Form
    {
        private DataTable _GetAllCustomer = clsCustomer.GetAllCustomer();
        private clsCustomer _FromCustomerInfo;
        private clsCustomer _ToCustomerInfo;
        private clsSendMoneies _SendMoneyInfo;
        private void _LoadCbCustomer()
        {
            cbFromCustomer.Items.Add("None");
            cbToCustomer.Items.Add("None");
            foreach (DataRow i in _GetAllCustomer.Rows)
            {
                string Name = $"{i["FirstName"]} {i["SecondName"]} {i["ThirdName"]} {i["LastName"]}";
                cbFromCustomer.Items.Add(Name);
                cbToCustomer.Items.Add(Name);
            }
            cbFromCustomer.SelectedIndex = 0;
            cbToCustomer.SelectedIndex = 0;
        }
        public frmAddNewSendMoney()
        {
            InitializeComponent();
        }
        private void frmAddNewSendMoney_Load(object sender, EventArgs e)
        {
            _LoadCbCustomer();
        }
        private void txtAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAmount, "This field must be not null");
            }
            else
                errorProvider1.SetError(txtAmount, null);
        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckBeforeSave())
                return;
            _LoadFromCustomerInfo(cbFromCustomer.Text);
            _LoadToCustomerInfo(cbToCustomer.Text);
            if (!CheckBalanceBeforePayaLoan(_FromCustomerInfo.AccountID, decimal.Parse(txtAmount.Text)))
                return;
            _SendMoneyInfo = new clsSendMoneies();
            _SendMoneyInfo.Account_ID_FromSend = _FromCustomerInfo.AccountID;
            _SendMoneyInfo.Account_ID_ToSend = _ToCustomerInfo.AccountID;
            _SendMoneyInfo.FromCustomer = _FromCustomerInfo.PersonInfo.FullName;
            _SendMoneyInfo.ToCustomer = _ToCustomerInfo.PersonInfo.FullName;
            _SendMoneyInfo.Amount = decimal.Parse(txtAmount.Text);
            _SendMoneyInfo.Date = DateTime.Now;
            if(_SendMoneyInfo.AddNewSendMoneies())
            {
                lblSendMondyID.Text = _SendMoneyInfo.SendMoneyID.ToString();
                cbFromCustomer.Enabled = false;
                cbToCustomer.Enabled = false;
                txtAmount.Enabled = false;
                btnSave.Enabled = false;
                MessageBox.Show($"Done successfuly with id = {_SendMoneyInfo.SendMoneyID}",
                    "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Not save", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool CheckBalanceBeforePayaLoan(int AccountID, decimal Amount)
        {
            clsAccount _AccountInfo = clsAccount.FindAccount(AccountID);
            if (_AccountInfo == null)
            {
                MessageBox.Show($"This account not found with id = {AccountID}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_AccountInfo.AccountBalance < Amount)
            {
                MessageBox.Show("Insufficient balance", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool CheckBeforeSave()
        {
            if(cbFromCustomer.Text == "None")
            {
                MessageBox.Show("Please select ( from customer ) should be not none", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbToCustomer.Text == "None")
            {
                MessageBox.Show("Please select ( To customer ) should be not none", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(cbFromCustomer.Text == cbToCustomer.Text)
            {
                MessageBox.Show("You cannot send money to the same customer.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(!ValidateChildren())
            {
                MessageBox.Show("put the mouse on red flag", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private List<string> SplitNameFunction(string Name)
        {
            List<string> myList = new List<string>(Name.Split(' '));
            return myList;
        }
        private void GetName(ref string FirstName, ref string SecondName,
            ref string ThirName, ref string LastName, string Name)
        {
            List<string> SplitName = SplitNameFunction(Name);
            FirstName = SplitName[0];
            SecondName = SplitName[1];
            ThirName = SplitName[2];
            LastName = SplitName[3];
        }
        private void _LoadFromCustomerInfo(string FromCustomer)
        {
            string FirstName = "", SecondName = "", ThirName = "", LastName = "";
            GetName(ref FirstName, ref SecondName,ref ThirName, ref LastName, FromCustomer);
            _FromCustomerInfo = clsCustomer.FindCustomerByName(FirstName, SecondName, ThirName, LastName);
        }
        private void _LoadToCustomerInfo(string ToCustomer)
        {
            string FirstName = "", SecondName = "", ThirName = "", LastName = "";
            GetName(ref FirstName, ref SecondName, ref ThirName, ref LastName, ToCustomer);
            _ToCustomerInfo = clsCustomer.FindCustomerByName(FirstName, SecondName, ThirName, LastName);
        }
    }
}
