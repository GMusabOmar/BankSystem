using System;
using System.Data;
using businessAccess;
using System.Windows.Forms;
using BankSystem.Loan.PaymentLoan;

namespace BankSystem.Loan
{
    public partial class frmListLoan : Form
    {
        private DataTable _GetAllLoan = clsLoan.GetAllLoan();
        private void _LoadData()
        {
            dgvListLoan.DataSource = _GetAllLoan;
            lblRecords.Text = dgvListLoan.RowCount.ToString();
            if(dgvListLoan.RowCount > 0)
            {
                dgvListLoan.Columns[0].HeaderText = "Loan ID";
                dgvListLoan.Columns[0].Width = 90;

                dgvListLoan.Columns[1].HeaderText = "Branch ID";
                dgvListLoan.Columns[1].Width = 105;

                dgvListLoan.Columns[2].HeaderText = "Account ID";
                dgvListLoan.Columns[2].Width = 112;

                dgvListLoan.Columns[3].HeaderText = "Issue money";
                dgvListLoan.Columns[3].Width = 132;

                dgvListLoan.Columns[4].HeaderText = "Remain. Amount";
                dgvListLoan.Columns[4].Width = 150;

                dgvListLoan.Columns[5].HeaderText = "Payment ID";
                dgvListLoan.Columns[5].Width = 132;

            }
        }
        public frmListLoan()
        {
            InitializeComponent();
        }
        private void frmListLoan_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddNewLoan_Click(object sender, EventArgs e)
        {
            frmAddUpdateLoan frm = new frmAddUpdateLoan();
            frm.ShowDialog();
            _LoadData();
        }
    }
}
