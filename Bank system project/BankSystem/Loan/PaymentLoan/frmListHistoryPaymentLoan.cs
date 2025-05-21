using System;
using System.Data;
using businessAccess;
using System.Windows.Forms;

namespace BankSystem.Loan.PaymentLoan
{
    public partial class frmListHistoryPaymentLoan : Form
    {
        private DataTable _GetAllHistory = clsHistoryPaymentLoans.GetAllHistoryPaymentLoans();
        private void _LoadData()
        {
            dgvListHistoryPaymentLoan.DataSource = _GetAllHistory;
            lblRecords.Text = dgvListHistoryPaymentLoan.RowCount.ToString();
            if(dgvListHistoryPaymentLoan.RowCount > 0)
            {
                dgvListHistoryPaymentLoan.Columns[0].HeaderText = "H.P.L._ID";
                dgvListHistoryPaymentLoan.Columns[0].Width = 100;

                dgvListHistoryPaymentLoan.Columns[1].HeaderText = "P.L._ID";
                dgvListHistoryPaymentLoan.Columns[1].Width = 80;

                dgvListHistoryPaymentLoan.Columns[2].HeaderText = "Amount B.Ch.";
                dgvListHistoryPaymentLoan.Columns[2].Width = 140;

                dgvListHistoryPaymentLoan.Columns[3].HeaderText = "Amount A.Ch.";
                dgvListHistoryPaymentLoan.Columns[3].Width = 140;

                dgvListHistoryPaymentLoan.Columns[4].HeaderText = "Date";
                dgvListHistoryPaymentLoan.Columns[4].Width = 180;

            }
        }
        public frmListHistoryPaymentLoan()
        {
            InitializeComponent();
        }
        private void frmListHistoryPaymentLoan_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
