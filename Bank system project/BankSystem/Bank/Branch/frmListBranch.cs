using System;
using businessAccess;
using System.Windows.Forms;
using System.Data;

namespace BankSystem.Bank.Branch
{
    public partial class frmListBranch : Form
    {
        private DataTable _GetAllBranch = clsBranch.GetAllBranch();
        private void _LoadData()
        {
            dgvListBranch.DataSource = _GetAllBranch;
            lblRecords.Text = dgvListBranch.RowCount.ToString();
            if(dgvListBranch.RowCount > 0)
            {
                dgvListBranch.Columns[0].HeaderText = "Branch ID";
                dgvListBranch.Columns[0].Width = 110;

                dgvListBranch.Columns[1].HeaderText = "Name";
                dgvListBranch.Columns[1].Width = 155;

                dgvListBranch.Columns[2].HeaderText = "Address";
                dgvListBranch.Columns[2].Width = 150;

                dgvListBranch.Columns[3].HeaderText = "Assets";
                dgvListBranch.Columns[3].Width = 100;
            }
        }
        public frmListBranch()
        {
            InitializeComponent();
        }
        private void frmListBranch_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddNewBranch_Click(object sender, EventArgs e)
        {
            frmAddUpdateBranch frm = new frmAddUpdateBranch();
            frm.ShowDialog();
            _LoadData();
        }

        private void addNewBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateBranch frm = new frmAddUpdateBranch();
            frm.ShowDialog();
            _LoadData();
        }

        private void updateBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateBranch frm = new frmAddUpdateBranch((int)dgvListBranch.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }

        private void deleteBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BranchID = (int)dgvListBranch.CurrentRow.Cells[0].Value;
            if(MessageBox.Show($"Are you sure to delete branch with id = {BranchID}",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (clsBranch.DeleteBranch(BranchID))
                    MessageBox.Show($"Done successful with id = {BranchID}",
                        "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Not delete branch with id = {BranchID}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
