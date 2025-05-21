using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BankSystem.Properties;
using businessAccess;

namespace BankSystem.ATM
{
    public partial class frmDepostWithDraw : Form
    {
        public enum enTypeMake { Deposit = 0, WithDraw = 1}
        private enTypeMake _Make = enTypeMake.Deposit;
        private int _ATMID = -1;
        private clsATM _ATMInfo;
        private clsTransactions _TransInfo;
        private clsCreditCard _CardInfo;
        private clsAccount _AccountInfo;
        private clsDeposts _DepositInfo;
        private clsWithDraw _WithDrawInfo;
        private decimal _Amount = -1;
        public frmDepostWithDraw(int ATMID, enTypeMake Make)
        {
            InitializeComponent();
            _ATMID = ATMID;
            _Make = Make;
            _ATMInfo = clsATM.FindATM(_ATMID);
            _TransInfo = clsTransactions.FindTransaction(_ATMInfo.Transaction_ID);
            _CardInfo = clsCreditCard.FindCreditCard(_TransInfo.CreditCard_ID);
        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtAmount.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAmount, "This field must be not null");
            }
            else
                errorProvider1.SetError(txtAmount, null);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadDepost()
        {
            decimal Amount = decimal.Parse(txtAmount.Text.Trim());
            if (!ChechLimitCard(Amount))
            {
                MessageBox.Show($"Can't deposit more card limit ({((short)_CardInfo.CardLimit)})", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Enabled = false;
                btnSave.Enabled = false;
                return;
            }
            _DepositInfo.ATM_ID = _ATMID;
            _DepositInfo.Amount = Amount;
            _DepositInfo.Date = DateTime.Now;
            if (_DepositInfo.AddNewDeposts())
            {
                lblDepositIWithDrawD.Text = _DepositInfo.DepostID.ToString();
                lblDate.Text = _DepositInfo.Date.ToString();
                txtAmount.Enabled = false;
                btnSave.Enabled = false;
                MessageBox.Show($"Done successful with id = {_DepositInfo.DepostID}",
                            "Make deposit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadBalanceAccount();
            }
            else
                MessageBox.Show("Not Save deposit", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void _LoadWithDraw()
        {
            decimal Amount = decimal.Parse(txtAmount.Text.Trim());
            if(!ChekMinimCard(Amount))
            {
                MessageBox.Show($"Can't withDraw more card limit ({((short)_CardInfo.CardLimit)})", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!IsThereBalance(Amount))
            {
                MessageBox.Show($"Insufficient balance, account must have at least $50", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _WithDrawInfo.ATM_ID = _ATMID;
            _WithDrawInfo.Amount = Amount;
            _WithDrawInfo.Date = DateTime.Now;
            if (_WithDrawInfo.AddNewWithDraw())
            {
                lblDepositIWithDrawD.Text = _WithDrawInfo.WithDrawID.ToString();
                lblDate.Text = _WithDrawInfo.Date.ToString();
                txtAmount.Enabled = false;
                btnSave.Enabled = false;
                MessageBox.Show($"Done successful with id = {_WithDrawInfo.WithDrawID}",
                            "Make WithDraw", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadBalanceAccount();
            }
            else
                MessageBox.Show("Not Save WithDraw", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Put the mouse on red flag", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_Make == enTypeMake.Deposit)
                _LoadDepost();
            else
                _LoadWithDraw();
        }
        private void frmDepost_Load(object sender, EventArgs e)
        {
            lblATMID.Text = _ATMID.ToString();
            _LoadBalanceAccount();
            if (_Make == enTypeMake.Deposit)
            {
                pbImage.Image = Resources.Deposit_Wallpaper;
                lblTitle.Text = "Make Deposit";
                lblEnableWithDraw.Visible = false;
                lblDepositEnable.Visible = true;
                _DepositInfo = new clsDeposts();
            }
            else
            {
                pbImage.Image = Resources.WithDraw_Wallpaper;
                lblTitle.Text = "Make WithDraw";
                lblTitle.ForeColor = Color.Blue;
                lblEnableWithDraw.Visible = true;
                lblDepositEnable.Visible = false;
                _WithDrawInfo = new clsWithDraw();
            }
        }
        private void _LoadBalanceAccount()
        {
            _AccountInfo = clsAccount.FindAccount(_CardInfo.Account_ID);
            if(_AccountInfo.AccountBalance > _CardInfo.CardLimit)
                _Amount = _AccountInfo.AccountBalance - _CardInfo.CardLimit;
            else
                _Amount = _AccountInfo.AccountBalance;
            lblBalance.Text = ((short)_Amount).ToString();
        }
        private bool ChechLimitCard(decimal amount)
        {
            decimal BalanceAfterDeposit = _Amount + amount;
            if (BalanceAfterDeposit > _CardInfo.CardLimit)
                return false;
            return true;
        }
        private bool ChekMinimCard(decimal amount)
        {
            if(_CardInfo.CardLimit <= amount)
                return false;
            return true;
        }
        private bool IsThereBalance(decimal amount)
        {
            decimal TotalAmount = _Amount - amount;
            if (TotalAmount < 50)
                return false;
            return true;
        }
    }
}
