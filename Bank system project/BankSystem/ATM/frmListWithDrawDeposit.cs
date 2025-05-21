using System;
using System.Data;
using businessAccess;
using System.Windows.Forms;
using BankSystem.Properties;

namespace BankSystem.ATM
{
    public partial class frmListWithDrawDeposit : Form
    {
        public enum enTypeMode { WithDraw = 0, Deposit = 1 }
        private enTypeMode _Mode = enTypeMode.WithDraw;

        private DataTable _GetAllWithDraw = clsWithDraw.GetAllWithDraw();
        private DataTable _GetAllDeposit = clsDeposts.GetAllDeposit();
        private void _LoadImage()
        {
            if (_Mode == enTypeMode.WithDraw)
            {
                pbImage.Image = Resources.WithDrawList;
                lblTitle.Text = "List WithDraw";
            }
            else
            {
                pbImage.Image = Resources.DepositList;
                lblTitle.Text = "List Deposit";
            }
        }
        private void _LoadCbFilter()
        {
            if(_Mode == enTypeMode.WithDraw)
            {
                string[] arrItemCbFilter = { "None", "WithDraw ID", "ATM ID", "Amount" };
                cbFilterBy.Items.AddRange(arrItemCbFilter);
            }
            else
            {
                string[] arrItemCbFilter = { "None", "Deposit ID", "ATM ID", "Amount" };
                cbFilterBy.Items.AddRange(arrItemCbFilter);
            }
        }
        private void _LoadDataWithDraw()
        {
            dgvListWithDraw.DataSource = _GetAllWithDraw;
            lblRecords.Text = dgvListWithDraw.RowCount.ToString();
            cbFilterBy.SelectedIndex = 0;
            if(dgvListWithDraw.RowCount > 0)
            {
                dgvListWithDraw.Columns[0].HeaderText = "WithDraw ID";
                dgvListWithDraw.Columns[0].Width = 125;

                dgvListWithDraw.Columns[1].HeaderText = "ATM ID";
                dgvListWithDraw.Columns[1].Width = 90;

                dgvListWithDraw.Columns[2].HeaderText = "Amount";
                dgvListWithDraw.Columns[2].Width = 160;

                dgvListWithDraw.Columns[3].HeaderText = "Date Of WithDraw";
                dgvListWithDraw.Columns[3].Width = 190;

            }
        }
        private void _LoadDataDeposit()
        {
            dgvListWithDraw.DataSource = _GetAllDeposit;
            lblRecords.Text = dgvListWithDraw.RowCount.ToString();
            cbFilterBy.SelectedIndex = 0;
            if (dgvListWithDraw.RowCount > 0)
            {
                dgvListWithDraw.Columns[0].HeaderText = "Deposit ID";
                dgvListWithDraw.Columns[0].Width = 125;

                dgvListWithDraw.Columns[1].HeaderText = "ATM ID";
                dgvListWithDraw.Columns[1].Width = 90;

                dgvListWithDraw.Columns[2].HeaderText = "Amount";
                dgvListWithDraw.Columns[2].Width = 160;

                dgvListWithDraw.Columns[3].HeaderText = "Date Of Deposit";
                dgvListWithDraw.Columns[3].Width = 190;

            }
        }
        public frmListWithDrawDeposit(enTypeMode Mode)
        {
            InitializeComponent();
            _Mode = Mode;
        }
        private void frmListWithDraw_Load(object sender, EventArgs e)
        {
            _LoadImage();
            _LoadCbFilter();
            if (_Mode == enTypeMode.WithDraw)
                _LoadDataWithDraw();
            else
                _LoadDataDeposit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible = cbFilterBy.Text != "None";
            if(txtFilterBy.Visible)
            {
                txtFilterBy.Text = "";
                txtFilterBy.Focus();
            }
        }
        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (_Mode == enTypeMode.WithDraw)
                TextChange_WithDraw();
            else
                TextChange_Deposit();
        }
        private void TextChange_WithDraw()
        {
            string ColName = "";
            switch (cbFilterBy.Text)
            {
                case "WithDraw ID":
                    ColName = "WithDrawID";
                    break;
                case "ATM ID":
                    ColName = "ATM_ID";
                    break;
                case "Amount":
                    ColName = "Amount";
                    break;
                default:
                    ColName = "None";
                    break;
            }
            if (ColName == "None" || txtFilterBy.Text == "")
            {
                _GetAllWithDraw.DefaultView.RowFilter = "";
                lblRecords.Text = dgvListWithDraw.RowCount.ToString();
                return;
            }
            _GetAllWithDraw.DefaultView.RowFilter = string.Format("{0} = {1}", ColName, txtFilterBy.Text.Trim());
            lblRecords.Text = dgvListWithDraw.RowCount.ToString();
        }
        private void TextChange_Deposit()
        {
            string ColName = "";
            switch (cbFilterBy.Text)
            {
                case "Deposit ID":
                    ColName = "DepostID";
                    break;
                case "ATM ID":
                    ColName = "ATM_ID";
                    break;
                case "Amount":
                    ColName = "Amount";
                    break;
                default:
                    ColName = "None";
                    break;
            }
            if (ColName == "None" || txtFilterBy.Text == "")
            {
                _GetAllDeposit.DefaultView.RowFilter = "";
                lblRecords.Text = dgvListWithDraw.RowCount.ToString();
                return;
            }
            _GetAllDeposit.DefaultView.RowFilter = string.Format("{0} = {1}", ColName, txtFilterBy.Text.Trim());
            lblRecords.Text = dgvListWithDraw.RowCount.ToString();
        }

    }
}
