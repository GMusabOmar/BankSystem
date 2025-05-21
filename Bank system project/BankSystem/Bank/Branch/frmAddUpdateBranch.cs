using System;
using System.ComponentModel;
using System.Windows.Forms;
using businessAccess;

namespace BankSystem.Bank.Branch
{
    public partial class frmAddUpdateBranch : Form
    {
        public event Action<int> OnBranchSelect;
        private enum _enTypeMode { Add = 0, Update = 1 }
        private _enTypeMode _Mode = _enTypeMode.Add;
        private int _BranchID = -1;
        private clsBranch _BranchInfo;
        public frmAddUpdateBranch()
        {
            InitializeComponent();
            _BranchID = -1;
            _Mode = _enTypeMode.Add;
            this.Text = "Add New Branch";
            lblTitle.Text = "Add New Branch";
        }
        public frmAddUpdateBranch(int BranchID)
        {
            InitializeComponent();
            _BranchID = BranchID;
            _Mode = _enTypeMode.Update;
            this.Text = "Update Branch";
            lblTitle.Text = "Update Branch";
        }
        private void txtBranchName_Validating(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field must be not null");
            }
            else
                errorProvider1.SetError(Temp, null);
        }
        private void txtAssets_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtAssets_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtAssets.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAssets, "This field must be only numbers");
            }
            else
                errorProvider1.SetError(txtAssets, null);
        }
        private void _RestDefaultValues()
        {
            lblBranchID.Text = "???";
            txtBranchName.Text = "";
            txtBranchAddress.Text = "";
            txtAssets.Text = "";
            _BranchInfo = new clsBranch();
        }
        private void _LoadData()
        {
            _BranchInfo = clsBranch.FindBranch(_BranchID);
            if (_BranchInfo == null)
            {
                MessageBox.Show("Not found branch with id = " + _BranchID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblBranchID.Text = _BranchInfo.BranchID.ToString();
            txtBranchName.Text = _BranchInfo.BranchName;
            txtBranchAddress.Text = _BranchInfo.BranchAddress;
            txtAssets.Text = _BranchInfo.Assets.ToString();
        }
        private void frmAddUpdateBranch_Load(object sender, EventArgs e)
        {
            _RestDefaultValues();
            if (_Mode == _enTypeMode.Update)
                _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Please put the mouse on red flag!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _BranchInfo.BranchName = txtBranchName.Text.Trim();
            _BranchInfo.BranchAddress = txtBranchAddress.Text.Trim();
            _BranchInfo.Assets = decimal.Parse(txtAssets.Text.Trim());
            if(_BranchInfo.Save())
            {
                if (_Mode == _enTypeMode.Add)
                    MessageBox.Show("Done successful with id = " + _BranchInfo.BranchID,
                        "Branch Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Done update successful", "Branch Update", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblBranchID.Text = _BranchInfo.BranchID.ToString();
                lblTitle.Text = "Update Branch";
                this.Text = "Update Branch";
                btnSave.Enabled = false;
                gbBranch.Enabled = false;
                if (OnBranchSelect != null)
                    OnBranchSelect?.Invoke(_BranchInfo.BranchID);
            }
            else
                MessageBox.Show("Not save branch", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
