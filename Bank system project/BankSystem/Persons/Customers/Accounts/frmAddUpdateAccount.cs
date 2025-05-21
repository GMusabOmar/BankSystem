using System;
using System.Data;
using System.Windows.Forms;
using businessAccess;

namespace BankSystem.Persons.Customers.Accounts
{
    public partial class frmAddUpdateAccount : Form
    {
        private enum _enTypeMode { Add = 0, Update = 1 }
        private _enTypeMode _Mode = _enTypeMode.Add;
        private int _AccountID = -1;
        private int _CustomerID = -1;
        private clsAccount _AccountInfo;
        private clsBranch _BranchInfo;
        public frmAddUpdateAccount()
        {
            InitializeComponent();
            _Mode = _enTypeMode.Add;
            lblTitle.Text = "Add New Account";
            this.Text = "Add New Account";
            _AccountID = -1;
        }
        public frmAddUpdateAccount(int AccountID)
        {
            InitializeComponent();
            _Mode = _enTypeMode.Update;
            lblTitle.Text = "Update Account";
            this.Text = "Update Account";
            _AccountID = AccountID;
        }
        private void _RestDefaultValues()
        {
            _AccountInfo = new clsAccount();
            lblAccountID.Text = "???";
            txtAccountBalance.Text = "";
            txtAccountType.Text = "";
            cbBranchName.SelectedIndex = 0;
        }
        private void _LoadData()
        {
            _AccountInfo = clsAccount.FindAccount(_AccountID);
            if(_AccountInfo == null)
            {
                MessageBox.Show($"Not found account with id = {_AccountID}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlCustomersInfoWithFilter1.FilterEnable = false;
                gbAccountInfo.Enabled = false;
                btnSave.Enabled = false;
                return;
            }
            ctrlCustomersInfoWithFilter1.FilterEnable = false;
            ctrlCustomersInfoWithFilter1.LoadData(_AccountInfo.Customer_ID);
            gbAccountInfo.Enabled = true;
            btnSave.Enabled = true;
            lblAccountID.Text = _AccountInfo.AccountID.ToString();
            txtAccountBalance.Text = _AccountInfo.AccountBalance.ToString();
            txtAccountType.Text = _AccountInfo.AccountType.ToString();
            _BranchInfo = clsBranch.FindBranch(_AccountInfo.Branch_ID);
            cbBranchName.SelectedItem = _BranchInfo.BranchName;
            cbBranchName.Enabled = false;
        }
        private void ctrlCustomersInfoWithFilter1_OnCustomerSelected(int obj)
        {
            if(_Mode == _enTypeMode.Add)
            {
                _RestDefaultValues();
                clsCustomer CustomerAccountID = clsCustomer.FindCustomerByID(obj);
                if (clsAccount.IsExistsAccount(CustomerAccountID.AccountID))
                {
                    MessageBox.Show("This customer already have account, please choice another one.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlCustomersInfoWithFilter1.FilterEnable = true;
                    gbAccountInfo.Enabled = false;
                    btnSave.Enabled = false;
                    return;
                }
                if(obj < 0)
                {
                    MessageBox.Show("Customer Id not vaild!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gbAccountInfo.Enabled = false;
                    btnSave.Enabled = false;
                    return;
                }
                _CustomerID = obj;
                ctrlCustomersInfoWithFilter1.FilterEnable = false;
                gbAccountInfo.Enabled = true;
                btnSave.Enabled = true;
                txtAccountBalance.Focus();
            }
        }
        private void frmAddUpdateAccount_Load(object sender, EventArgs e)
        {
            _LoadBranchName();
            gbAccountInfo.Enabled = false;
            if (_Mode == _enTypeMode.Update)
                _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmAddUpdateAccount_Activated(object sender, EventArgs e)
        {
            ctrlCustomersInfoWithFilter1.FilterFocus();
        }
        private void ValidatingText(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;
            if(string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field must be not null");
            }
            else
                errorProvider1.SetError(Temp, null);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Put the mouse on red flag", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _AccountInfo.AccountBalance = decimal.Parse(txtAccountBalance.Text.Trim());
            _AccountInfo.AccountType = txtAccountType.Text.Trim();
            _AccountInfo.Branch_ID = _BranchInfo.BranchID;
            _AccountInfo.Customer_ID = _CustomerID;
            if(_AccountInfo.Save())
            {
                if(_Mode == _enTypeMode.Add)
                    MessageBox.Show($"Done successfuly with account id = {_AccountInfo.AccountID}",
                        "Add New Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show($"Done successfuly", "Update Account", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                lblAccountID.Text = _AccountInfo.AccountID.ToString();
                ctrlCustomersInfoWithFilter1.FilterEnable = false;
                btnSave.Enabled = false;
                gbAccountInfo.Enabled = false;
                lblTitle.Text = "Update Account";
                this.Text = "Update Account";
            }
            else
                MessageBox.Show($"Not save account", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void _LoadBranchName()
        {
            DataTable _GetAllData = clsBranch.GetAllBranch();
            foreach (DataRow rows in _GetAllData.Rows)
                cbBranchName.Items.Add(rows["BranchName"]);
        }
    }
}
