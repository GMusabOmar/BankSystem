using System;
using System.Data;
using businessAccess;
using System.Windows.Forms;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using static System.Net.Mime.MediaTypeNames;

namespace BankSystem.Loan.PaymentLoan
{
    public partial class frmAddUpdatePaymentLoan : Form
    {
        private enum _enTypeMode { Add = 0, Update = 1 }
        private _enTypeMode _Mode = _enTypeMode.Add;
        private int _PaymentLoanID = -1;
        private clsPaymentLoan _PaymentLoanInfo;
        private clsLoan _LoanInfo;
        private void _LoadCbLoanID()
        {
            cbLoanID.Items.Add("None");
            DataTable _GetLoan = clsLoan.GetAllLoan();
            foreach (DataRow i in _GetLoan.Rows)
                cbLoanID.Items.Add(i["LoanID"]);
            cbLoanID.SelectedIndex = 0;
        }
        public frmAddUpdatePaymentLoan()
        {
            InitializeComponent();
            _Mode = _enTypeMode.Add;
        }
        public frmAddUpdatePaymentLoan(int PaymentLoanID)
        {
            InitializeComponent();
            _PaymentLoanID = PaymentLoanID;
            _Mode = _enTypeMode.Update;
        }
        private void _RestDefaultValues()
        {
            _PaymentLoanInfo = new clsPaymentLoan();
            lblTitle.Text = "Add New Payment Loan";
            lblPLID.Text = "N/A";
            txtAmount.Text = "";
            _LoadCbLoanID();
        }
        private void _LoadData()
        {
            _PaymentLoanInfo = clsPaymentLoan.FindPaymentLoan(_PaymentLoanID);
            if (_PaymentLoanInfo == null)
            {
                MessageBox.Show($"Not found payment loan with id = {_PaymentLoanID}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblTitle.Text = "Update Info Payment Loan";
            lblPLID.Text = _PaymentLoanInfo.PaymentID.ToString();
            txtAmount.Text = "";
            cbLoanID.Text = _PaymentLoanInfo.Loan_ID.ToString();
            cbLoanID.Enabled = false;
            lblPLID.Enabled = false;
        }
        private void frmAddUpdatePaymentLoan_Load(object sender, EventArgs e)
        {
            _RestDefaultValues();
            if (_Mode == _enTypeMode.Update)
                _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtAmount.Text.Trim()))
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckBeforeSave())
                return;
            _PaymentLoanInfo.Loan_ID = int.Parse(cbLoanID.Text);
            _PaymentLoanInfo.Amount = decimal.Parse(txtAmount.Text.Trim());
            if(_PaymentLoanInfo.Save())
            {
                lblPLID.Text = _PaymentLoanInfo.PaymentID.ToString();
                lblTitle.Text = "Update Info Payment Loan";
                cbLoanID.Enabled = false;
                txtAmount.Enabled = false;
                btnSave.Enabled = false;
                MessageBox.Show($"Done successfuly with id = {lblPLID.Text}",
                    "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Not Save", "Error",
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
            if(_AccountInfo.AccountBalance < Amount)
            {
                MessageBox.Show("Insufficient balance","Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool CheckBeforeSave()
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Put the mouse on red flag", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(cbLoanID.Text == "None")
            {
                MessageBox.Show("Loan Id must be not none", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(_Mode == _enTypeMode.Add)
            {
                if (clsPaymentLoan.IsExistsPaymentLoanByLoanID(int.Parse(cbLoanID.Text)))
                {
                    MessageBox.Show($"This loan already exists with id = {cbLoanID.Text}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if(decimal.Parse(txtAmount.Text) <= 0) {
                MessageBox.Show("Please enter value bigger then zero", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _LoanInfo = clsLoan.FindLoan(int.Parse(cbLoanID.Text));
            if (!CheckAmountToPay(decimal.Parse(txtAmount.Text.Trim())))
                return false;
            if (!CheckBalanceBeforePayaLoan(_LoanInfo.Account_ID, decimal.Parse(txtAmount.Text.Trim())))
                return false;
            return true;
        }
        private bool CheckAmountToPay(decimal Amount)
        {
            if (_LoanInfo.Remaining_Amount <= 0)
            {
                MessageBox.Show("The loan has been fully paid.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Amount > _LoanInfo.Remaining_Amount)
            {
                MessageBox.Show("This is too much money to pay.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
