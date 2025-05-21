using System;
using System.Data;
using businessAccess;
using System.Windows.Forms;

namespace BankSystem.Loan
{
    public partial class frmAddUpdateLoan : Form
    {
        private int _LoanID = -1;
        private clsLoan _LoanInfo;
        private DataTable _BranchNameInfo;
        private DataTable _AccountIDInfo;
        public frmAddUpdateLoan()
        {
            InitializeComponent();
        }
        private void _LoadBranchName()
        {
            cbBranchName.Items.Add("None");
            _BranchNameInfo = clsBranch.GetAllBranch();
            foreach (DataRow i in _BranchNameInfo.Rows)
                cbBranchName.Items.Add(i["BranchName"]);
            cbBranchName.SelectedIndex = 0;
        }
        private void _LoadAccountName()
        {
            cbAccountID.Items.Add("None");
            _AccountIDInfo = clsAccount.GetAllAccount();
            foreach (DataRow i in _AccountIDInfo.Rows)
                cbAccountID.Items.Add(i["AccountID"]);
            cbAccountID.SelectedIndex = 0;
        }
        private void _RestDefaultValue()
        {
            _LoanInfo = new clsLoan();
            _LoadBranchName();
            _LoadAccountName();
            lblTitle.Text = "Add New Loan";
            lblLoanID.Text = "N/A";
            txtIssueAmount.Text = "";
            txtRemainAmount.Text = "0000 000 000";
            txtRemainAmount.Enabled = false;
        }
        private void txtIssueAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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
        private void frmAddUpdateLoan_Load(object sender, EventArgs e)
        {
            _RestDefaultValue();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckBeforeSave())
                return;
            clsBranch _Branch = clsBranch.FindBranchByName(cbBranchName.Text);
            _LoanInfo.Branch_ID = _Branch.BranchID;
            _LoanInfo.Account_ID = int.Parse(cbAccountID.SelectedItem.ToString());
            _LoanInfo.Issue_Amount = decimal.Parse(txtIssueAmount.Text.Trim());
            txtRemainAmount.Text = txtIssueAmount.Text.Trim();
            _LoanInfo.Remaining_Amount = decimal.Parse(txtRemainAmount.Text.Trim());
            if(_LoanInfo.Save())
            {
                _LoanID = _LoanInfo.LoanID;
                lblLoanID.Text = _LoanID.ToString();
                cbBranchName.Enabled = false;
                cbAccountID.Enabled = false;
                txtIssueAmount.Enabled = false;
                txtRemainAmount.Enabled = false;
                btnSave.Enabled = false;
                lblTitle.Text = "Update Info Loan";
                MessageBox.Show($"Done successfuly with id = {_LoanInfo.LoanID}",
                    "Save Loan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Not save Loan","Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void txtIssueAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private bool CheckBeforeSave()
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Put the mouse on red flag", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbAccountID.Text == "None" || cbBranchName.Text == "None")
            {
                MessageBox.Show("Account ID && Branch Name must be not null", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (clsLoan.IsExistsLoanByAccountID(int.Parse(cbAccountID.Text)))
            {
                MessageBox.Show($"This Account already exists with id = {cbAccountID.Text}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
