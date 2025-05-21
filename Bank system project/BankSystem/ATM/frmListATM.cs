using System;
using System.Data;
using businessAccess;
using System.Windows.Forms;

namespace BankSystem.ATM
{
    public partial class frmListATM : Form
    {
        private DataTable _GetAllATM = clsATM.GetAllATM();
        private void _LoadData()
        {
            dgvListATM.DataSource = _GetAllATM;
            cbFilterBy.SelectedIndex = 0;
            lblRecords.Text = dgvListATM.RowCount.ToString();
            if (dgvListATM.RowCount > 0)
            {
                dgvListATM.Columns[0].HeaderText = "ATM ID";
                dgvListATM.Columns[0].Width = 110;

                dgvListATM.Columns[1].HeaderText = "Transaction ID";
                dgvListATM.Columns[1].Width = 140;

                dgvListATM.Columns[2].HeaderText = "Date ATM";
                dgvListATM.Columns[2].Width = 200;

            }
        }
        public frmListATM()
        {
            InitializeComponent();
        }
        private void frmListATM_Load(object sender, EventArgs e)
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
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string ColName = "";
            switch(cbFilterBy.Text)
            {
                case "ATM ID":
                    ColName = "ATMID";
                    break;
                case "Transaction ID":
                    ColName = "Transaction_ID";
                    break;
                default:
                    ColName = "None";
                    break;
            }
            if (ColName == "None" || txtFilterBy.Text == "")
            {
                _GetAllATM.DefaultView.RowFilter = "";
                lblRecords.Text = dgvListATM.RowCount.ToString();
                return;
            }
            else
            {
                _GetAllATM.DefaultView.RowFilter = string.Format("{0} = {1}", ColName, txtFilterBy.Text.Trim());
                lblRecords.Text = dgvListATM.RowCount.ToString();
            }
        }
        private void btnAddNewATM_Click(object sender, EventArgs e)
        {
            frmAddNewATM frm = new frmAddNewATM();
            frm.ShowDialog();
        }
        private void makeDepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepostWithDraw frm = new frmDepostWithDraw((int)dgvListATM.CurrentRow.Cells[0].Value, frmDepostWithDraw.enTypeMake.Deposit);
            frm.ShowDialog();
        }

        private void makeWithDrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepostWithDraw frm = new frmDepostWithDraw((int)dgvListATM.CurrentRow.Cells[0].Value, frmDepostWithDraw.enTypeMake.WithDraw);
            frm.ShowDialog();
        }
        private void btnWithDraw_Click(object sender, EventArgs e)
        {
            frmListWithDrawDeposit frm = new frmListWithDrawDeposit(frmListWithDrawDeposit.enTypeMode.WithDraw);
            frm.ShowDialog();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            frmListWithDrawDeposit frm = new frmListWithDrawDeposit(frmListWithDrawDeposit.enTypeMode.Deposit);
            frm.ShowDialog();
        }
    }
}
