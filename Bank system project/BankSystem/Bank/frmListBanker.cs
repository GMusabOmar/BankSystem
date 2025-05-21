using System;
using businessAccess;
using System.Windows.Forms;
using System.Data;
using BankSystem.Bank.Branch;

namespace BankSystem.Bank
{
    public partial class frmListBanker : Form
    {
        private DataTable _GetAllBanker = clsclsBanker.GetAllBanker();
        private void _LoadData()
        {
            dgvListBanker.DataSource = _GetAllBanker;
            lblRecords.Text = dgvListBanker.RowCount.ToString();
            if(dgvListBanker.RowCount > 0)
            {
                dgvListBanker.Columns[0].HeaderText = "Bank ID";
                dgvListBanker.Columns[0].Width = 95;

                dgvListBanker.Columns[1].HeaderText = "Name";
                dgvListBanker.Columns[1].Width = 110;

                dgvListBanker.Columns[2].HeaderText = "Branch ID";
                dgvListBanker.Columns[2].Width = 95;
            }
        }
        public frmListBanker()
        {
            InitializeComponent();
        }
        private void frmListBanker_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _AddNewBank(int BranchID)
        {
            frmAddNewBank frm = new frmAddNewBank(BranchID);
            frm.ShowDialog();
        }
        private void addNewBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateBranch frm = new frmAddUpdateBranch();
            frm.OnBranchSelect += _AddNewBank;
            frm.ShowDialog();
        }
    }
}
