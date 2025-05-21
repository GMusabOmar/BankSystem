using System;
using System.Data;
using businessAccess;
using System.Windows.Forms;

namespace BankSystem.CreditCard
{
    public partial class frmListCreditCard : Form
    {
        private DataTable _GetAllCC = clsCreditCard.GetAllCreditCard();
        private void _LoadData()
        {
            dgvListCreditCard.DataSource = _GetAllCC;
            lblRecords.Text = dgvListCreditCard.RowCount.ToString();
            if (dgvListCreditCard.RowCount > 0)
            {
                dgvListCreditCard.Columns[0].HeaderText = "Credit Card ID";
                dgvListCreditCard.Columns[0].Width = 140;

                dgvListCreditCard.Columns[1].HeaderText = "Account ID";
                dgvListCreditCard.Columns[1].Width = 120;

                dgvListCreditCard.Columns[2].HeaderText = "Expire Date";
                dgvListCreditCard.Columns[2].Width = 170;

                dgvListCreditCard.Columns[3].HeaderText = "Card Limit";
                dgvListCreditCard.Columns[3].Width = 120;

            }
        }
        public frmListCreditCard()
        {
            InitializeComponent();
        }
        private void frmListCreditCard_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close ();
        }
        private void btnAddNewCC_Click(object sender, EventArgs e)
        {
            frmAddNewCC frm = new frmAddNewCC();
            frm.ShowDialog();
        }
    }
}
