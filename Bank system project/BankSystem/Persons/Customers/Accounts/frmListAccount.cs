using System;
using businessAccess;
using System.Windows.Forms;
using System.Data;

namespace BankSystem.Persons.Customers.Accounts
{
    public partial class frmListAccount : Form
    {
        private DataTable _GetAllAccount = clsAccount.GetAllAccount();
        private void _LoadData()
        {
            dgvListAccount.DataSource = _GetAllAccount;
            lblRecords.Text = dgvListAccount.RowCount.ToString();
            cbFilterBy.SelectedIndex = 0;
            if(dgvListAccount.RowCount > 0)
            {
                dgvListAccount.Columns[0].HeaderText = "Account ID";
                dgvListAccount.Columns[0].Width = 90;

                dgvListAccount.Columns[1].HeaderText = "Customer ID";
                dgvListAccount.Columns[1].Width = 90;

                dgvListAccount.Columns[2].HeaderText = "Account Balance";
                dgvListAccount.Columns[2].Width = 130;

                dgvListAccount.Columns[3].HeaderText = "Branch ID";
                dgvListAccount.Columns[3].Width = 90;

                dgvListAccount.Columns[4].HeaderText = "Account Type";
                dgvListAccount.Columns[4].Width = 150;

                dgvListAccount.Columns[5].HeaderText = "Credit Card ID";
                dgvListAccount.Columns[5].Width = 100;

                dgvListAccount.Columns[6].HeaderText = "Loan ID";
                dgvListAccount.Columns[6].Width = 90;

            }
        }
        public frmListAccount()
        {
            InitializeComponent();
        }
        private void frmListAccount_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible = cbFilterBy.Text != "None";
            if(txtFilterBy.Visible)
            {
                txtFilterBy.Text = "";
                txtFilterBy.Focus();
            }
        }
        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text != "Account Type")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string ColName = "";
            switch(cbFilterBy.Text)
            {
                case "Account ID":
                    ColName = "AccountID";
                    break;
                case "Customer ID":
                    ColName = "Customer_ID";
                    break;
                case "Account Balance":
                    ColName = "AccountBalance";
                    break;
                case "Branch ID":
                    ColName = "Branch_ID";
                    break;
                case "Account Type":
                    ColName = "AccountType";
                    break;
                case "Credit Card ID":
                    ColName = "CreditCardID";
                    break;
                case "Loan ID":
                    ColName = "LoanID";
                    break;
                default:
                    ColName = "None";
                    break;
            }
            if(ColName == "None" || txtFilterBy.Text == "")
            {
                _GetAllAccount.DefaultView.RowFilter = "";
                lblRecords.Text = dgvListAccount.RowCount.ToString();
                return;
            }
            if(ColName != "AccountType")
                _GetAllAccount.DefaultView.RowFilter = string.Format("{0} = {1}", ColName, txtFilterBy.Text.Trim());
            else
                _GetAllAccount.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", ColName, txtFilterBy.Text.Trim());
            lblRecords.Text = dgvListAccount.RowCount.ToString();
        }
        private void btnAddNewAccount_Click(object sender, EventArgs e)
        {
            frmAddUpdateAccount frm = new frmAddUpdateAccount();
            frm.ShowDialog();
            _LoadData();
        }
        private void personInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsCustomer _CustomerInfo = clsCustomer.FindCustomerByID((int)dgvListAccount.CurrentRow.Cells[1].Value);
            if(_CustomerInfo == null)
            {
                MessageBox.Show("Not found person id!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmShowPersonInfo frm = new frmShowPersonInfo(_CustomerInfo.PersonID);
            frm.Show();
        }
        private void addNewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateAccount frm = new frmAddUpdateAccount();
            frm.ShowDialog();
            _LoadData();
        }
        private void updateAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateAccount frm = new frmAddUpdateAccount((int)dgvListAccount.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }
        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AccID = (int)dgvListAccount.CurrentRow.Cells[0].Value;
            if(MessageBox.Show($"Are you sure to delete account with id = {AccID}", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(clsAccount.DeleteAccount(AccID))
                {
                    MessageBox.Show($"Done successful with id = {AccID}", "Delete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show($"Not successful delete with id = {AccID}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _LoadData();
        }
    }
}
