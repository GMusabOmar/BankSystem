using System;
using System.Data;
using System.Windows.Forms;
using businessAccess;

namespace BankSystem.ATM
{
    public partial class frmAddNewATM : Form
    {
        private int _ATMID = -1;
        private clsATM _ATMInfo;
        public frmAddNewATM()
        {
            InitializeComponent();
        }
        private void _LoadCbSTID()
        {
            cbSTID.Items.Add("None");
            var _TransactionData =  clsTransactions.GetAllTransaction();
            foreach (DataRow i in _TransactionData.Rows)
                cbSTID.Items.Add(i["TransactionID"]);
            cbSTID.SelectedIndex = 0;
        }
        private void cbSTID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbSTID.Text != "None")
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }
        private void frmAddNewATM_Load(object sender, EventArgs e)
        {
            _LoadCbSTID();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            _ATMInfo = new clsATM();
            int TransID = int.Parse(cbSTID.SelectedItem.ToString());
            if (clsATM.IsExistsATMByTransaction(TransID))
            {
                MessageBox.Show($"This Transaction already exist with Id = {TransID}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            _ATMInfo.Transaction_ID = TransID;
            _ATMInfo.Date = DateTime.Now;
            if(_ATMInfo.AddNewATM())
            {
                lblATMID.Text = _ATMInfo.ATMID.ToString();
                lblDate.Text = _ATMInfo.Date.ToString();
                cbSTID.Enabled = false;
                btnSave.Enabled = false;
                MessageBox.Show($"Done successfuly with id = {_ATMInfo.ATMID}", 
                    "Add ATM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Not save atm", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
