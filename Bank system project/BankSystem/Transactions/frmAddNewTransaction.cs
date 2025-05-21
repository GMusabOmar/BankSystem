using System;
using businessAccess;
using System.Windows.Forms;
using System.Data;

namespace BankSystem.Transactions
{
    public partial class frmAddNewTransaction : Form
    {
        private void _LoadCbCreditCard()
        {
            cbCreditCard.Items.Add("None");
            DataTable _CardInfo = clsCreditCard.GetAllCreditCard();
            foreach (DataRow i in _CardInfo.Rows)
                cbCreditCard.Items.Add(i["CreditCardID"]);
            cbCreditCard.SelectedIndex = 0;
        }
        public frmAddNewTransaction()
        {
            InitializeComponent();
        }
        private void frmAddNewTransaction_Load(object sender, EventArgs e)
        {
            _LoadCbCreditCard();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int CardID = int.Parse(cbCreditCard.SelectedItem.ToString());
            if (clsTransactions.IsExistsTransactionByCreditCard(CardID))
            {
                MessageBox.Show($"This Credit card already exist with id = {CardID} ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            clsTransactions _TransIfno = new clsTransactions();
            _TransIfno.CreditCard_ID = CardID;
            if(_TransIfno.AddNewTransaction())
            {
                lblTransID.Text = _TransIfno.TransactionID.ToString();
                btnSave.Enabled = false;
                cbCreditCard.Enabled = false;
                MessageBox.Show($"Done successful with id = {_TransIfno.TransactionID}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Not Add Transaction!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void cbCreditCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCreditCard.Text != "None")
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }
    }
}
