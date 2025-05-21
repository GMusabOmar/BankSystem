using System;
using System.Windows.Forms;
using businessAccess;

namespace BankSystem.Bank
{
    public partial class frmAddNewBank : Form
    {
        private int _BranchID = -1;
        public frmAddNewBank(int BranchID)
        {
            InitializeComponent();
            _BranchID = BranchID;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Put the mouse on red flag", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsclsBanker NBank = new clsclsBanker();
            NBank.Branch_ID = _BranchID;
            NBank.BankName = txtBankName.Text.Trim();
            if(NBank.AddNewBanker())
            {
                lblBankID.Text = NBank.BankerID.ToString();
                MessageBox.Show($"Done successful with id = {NBank.BankerID}",
                    "Add New Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                gbBankInfo.Enabled = false;
                btnClose.Enabled = true;
            }
            else
                MessageBox.Show("Not add new bank!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void txtBankName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBankName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBankName, "This field must be not null");
            }
            else
                errorProvider1.SetError(txtBankName, null);
        }
        private void frmAddNewBank_Load(object sender, EventArgs e)
        {
            lblBranchID.Text = _BranchID.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
