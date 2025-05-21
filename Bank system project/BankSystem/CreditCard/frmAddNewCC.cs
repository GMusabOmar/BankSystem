using System;
using System.Data;
using businessAccess;
using System.Windows.Forms;

namespace BankSystem.CreditCard
{
    public partial class frmAddNewCC : Form
    {
        private clsCreditCard _CardInfo;
        private void _LoadCbAccount()
        {
            cbAccountID.Items.Add("None");
            DataTable AccountInfo = clsAccount.GetAllAccount();
            foreach (DataRow i in AccountInfo.Rows)
                cbAccountID.Items.Add(i["AccountID"]);
            cbAccountID.SelectedIndex = 0;
        }
        private void _DateTimePickerSetting()
        {
            dtpExpireDate.MaxDate = DateTime.Now.AddYears(10);
            dtpExpireDate.MinDate = DateTime.Now;
            dtpExpireDate.Value = dtpExpireDate.MinDate;
        }
        public frmAddNewCC()
        {
            InitializeComponent();
        }
        private void frmAddNewCC_Load(object sender, EventArgs e)
        {
            _LoadCbAccount();
            _DateTimePickerSetting();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtCardLimit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtCardLimit.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCardLimit, "This field must be not null");
            }
            else
                errorProvider1.SetError(txtCardLimit, null);
        }
        private void txtCardLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_CheckButtonSave())
                return;
            _CardInfo = new clsCreditCard();
            _CardInfo.Expiry_Date = dtpExpireDate.Value;
            _CardInfo.Account_ID = int.Parse(cbAccountID.SelectedItem.ToString());
            _CardInfo.CardLimit = decimal.Parse(txtCardLimit.Text.Trim());
            if(_CardInfo.AddNewCreditCard())
            {
                btnSave.Enabled = false;
                txtCardLimit.Enabled = false;
                cbAccountID.Enabled = false;
                dtpExpireDate.Enabled = false;
                lblCCID.Text = _CardInfo.CreditCardID.ToString();
                MessageBox.Show($"Done successfuly with id = {_CardInfo.CreditCardID}",
                    "Add Card", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Not add new card", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool _CheckButtonSave()
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Put the mouse on red flag", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DateTime.Now.Year == dtpExpireDate.Value.Year)
            {
                MessageBox.Show($"Expire Date must be bigger then year = {DateTime.Now.Year}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbAccountID.Text == "None")
            {
                MessageBox.Show("Please select account id", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(clsCreditCard.IsExistsCreditCardByAccountID(int.Parse(cbAccountID.SelectedItem.ToString())))
            {
                int AccountID = int.Parse(cbAccountID.Text.Trim());
                MessageBox.Show($"This account already exists with id = {AccountID}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
