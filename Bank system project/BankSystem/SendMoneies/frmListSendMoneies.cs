using System;
using System.Data;
using businessAccess;
using System.Windows.Forms;

namespace BankSystem.SendMoneies
{
    public partial class frmListSendMoneies : Form
    {
        private DataTable _GetAllSendMoneies = clsSendMoneies.GetAllSendMoneies();
        private void _LoadData()
        {
            dgvSendMoneies.DataSource = _GetAllSendMoneies;
            lblRecords.Text = dgvSendMoneies.RowCount.ToString();
            if(dgvSendMoneies.RowCount > 0)
            {
                dgvSendMoneies.Columns[0].HeaderText = "Send Money ID";
                dgvSendMoneies.Columns[0].Width = 130;

                dgvSendMoneies.Columns[1].HeaderText = "Account ID From Send";
                dgvSendMoneies.Columns[1].Width = 140;

                dgvSendMoneies.Columns[2].HeaderText = "Account ID To Send";
                dgvSendMoneies.Columns[2].Width = 130;

                dgvSendMoneies.Columns[3].HeaderText = "Amount";
                dgvSendMoneies.Columns[3].Width = 110;

                dgvSendMoneies.Columns[4].HeaderText = "Date";
                dgvSendMoneies.Columns[4].Width = 180;

            }
        }
        public frmListSendMoneies()
        {
            InitializeComponent();
        }
        private void frmListSendMoneies_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewSendMoney_Click(object sender, EventArgs e)
        {
            frmAddNewSendMoney frm = new frmAddNewSendMoney();
            frm.ShowDialog();
        }
    }
}
