using System;
using System.Data;
using System.Windows.Forms;
using businessAccess;

namespace BankSystem.Transactions
{
    public partial class frmListTransaction : Form
    {
        private DataTable _GetAllTransaction = clsTransactions.GetAllTransaction();
        private void _LoadData()
        {
            dgvListTransaction.DataSource = _GetAllTransaction;
            lblRecord.Text = dgvListTransaction.RowCount.ToString();
            if(dgvListTransaction.RowCount > 0)
            {
                dgvListTransaction.Columns[0].HeaderText = "Transaction ID";
                dgvListTransaction.Columns[0].Width = 150;

                dgvListTransaction.Columns[1].HeaderText = "Credit Card ID";
                dgvListTransaction.Columns[1].Width = 140;

                dgvListTransaction.Columns[2].HeaderText = "Account ID";
                dgvListTransaction.Columns[2].Width = 115;

                dgvListTransaction.Columns[3].HeaderText = "Customer ID";
                dgvListTransaction.Columns[3].Width = 130;

                dgvListTransaction.Columns[4].HeaderText = "Person ID";
                dgvListTransaction.Columns[4].Width = 110;

                dgvListTransaction.Columns[5].HeaderText = "Name";
                dgvListTransaction.Columns[5].Width = 200;

            }
        }
        public frmListTransaction()
        {
            InitializeComponent();
        }
        private void frmListTransaction_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewTrans_Click(object sender, EventArgs e)
        {
            frmAddNewTransaction frm = new frmAddNewTransaction();
            frm.ShowDialog();
        }
    }
}
