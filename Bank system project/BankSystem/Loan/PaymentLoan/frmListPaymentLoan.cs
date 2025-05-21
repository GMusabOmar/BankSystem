using System;
using System.Data;
using businessAccess;
using System.Windows.Forms;

namespace BankSystem.Loan.PaymentLoan
{
    public partial class frmListPaymentLoan : Form
    {
        private DataTable _GetAllPaymentLoan = clsPaymentLoan.GetAllPaymentLoan();
        private void _LoadData()
        {
            dgvPaymentLoan.DataSource = _GetAllPaymentLoan;
            lblRecords.Text = dgvPaymentLoan.RowCount.ToString();
            if(dgvPaymentLoan.RowCount > 0)
            {
                dgvPaymentLoan.Columns[0].HeaderText = "Payment Loan ID";
                dgvPaymentLoan.Columns[0].Width = 160;

                dgvPaymentLoan.Columns[1].HeaderText = "Loan ID";
                dgvPaymentLoan.Columns[1].Width = 90;

                dgvPaymentLoan.Columns[2].HeaderText = "Amount";
                dgvPaymentLoan.Columns[2].Width = 120;

            }
        }
        public frmListPaymentLoan()
        {
            InitializeComponent();
        }
        private void frmListPaymentLoan_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddNewPayment_Click(object sender, EventArgs e)
        {
            frmAddUpdatePaymentLoan frm = new frmAddUpdatePaymentLoan();
            frm.ShowDialog();
        }

        private void updatePaymentLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePaymentLoan frm = new frmAddUpdatePaymentLoan((int)dgvPaymentLoan.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            frmListHistoryPaymentLoan frm = new frmListHistoryPaymentLoan();
            frm.ShowDialog();
        }
    }
}
