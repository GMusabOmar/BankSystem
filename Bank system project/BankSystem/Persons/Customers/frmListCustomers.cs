using System;
using System.Data;
using System.Windows.Forms;
using businessAccess;

namespace BankSystem.Persons.Customers
{
    public partial class frmListCustomers : Form
    {
        private DataTable _GetAllCustomers = clsCustomer.GetAllCustomer();
        private clsCustomer _CustomerInfo;
        private void _LoadCustomerData()
        {
            dgvListCustomer.DataSource = _GetAllCustomers;
            cbFindBy.SelectedIndex = 0;
            lblRecords.Text = dgvListCustomer.RowCount.ToString();
            if(dgvListCustomer.Rows.Count > 0)
            {
                dgvListCustomer.Columns[0].HeaderText = "C.ID";
                dgvListCustomer.Columns[0].Width = 60;

                dgvListCustomer.Columns[1].HeaderText = "P.ID";
                dgvListCustomer.Columns[1].Width = 60;

                dgvListCustomer.Columns[2].HeaderText = "First Name";
                dgvListCustomer.Columns[2].Width = 120;

                dgvListCustomer.Columns[3].HeaderText = "Second Name";
                dgvListCustomer.Columns[3].Width = 120;

                dgvListCustomer.Columns[4].HeaderText = "Third Name";
                dgvListCustomer.Columns[4].Width = 120;

                dgvListCustomer.Columns[5].HeaderText = "Last Name";
                dgvListCustomer.Columns[5].Width = 120;

                dgvListCustomer.Columns[6].HeaderText = "Email";
                dgvListCustomer.Columns[6].Width = 140;

                dgvListCustomer.Columns[7].HeaderText = "Address";
                dgvListCustomer.Columns[7].Width = 80;

                dgvListCustomer.Columns[8].HeaderText = "Phone";
                dgvListCustomer.Columns[8].Width = 80;

                dgvListCustomer.Columns[9].HeaderText = "Acc.ID";
                dgvListCustomer.Columns[9].Width = 60;

                dgvListCustomer.Columns[10].HeaderText = "CC.ID";
                dgvListCustomer.Columns[10].Width = 60;

            }
        }
        public frmListCustomers()
        {
            InitializeComponent();
        }
        private void frmListCustomers_Load(object sender, EventArgs e)
        {
            _LoadCustomerData();
        }
        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible = (cbFindBy.Text != "None");
            txtFilterBy.Text = "";
            txtFilterBy.Focus();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string ColName = null;
            switch(cbFindBy.Text)
            {
                case "C.ID":
                    ColName = "CustomerID";
                    break;
                case "P.ID":
                    ColName = "PersonID";
                    break;
                case "First Name":
                    ColName = "FirstName";
                    break;
                case "Second Name":
                    ColName = "SecondName";
                    break;
                case "Third Name":
                    ColName = "ThirdName";
                    break;
                case "Last Name":
                    ColName = "LastName";
                    break;
                case "Email":
                    ColName = "Email";
                    break;
                case "Address":
                    ColName = "Address";
                    break;
                case "Phone":
                    ColName = "Phone";
                    break;
                case "Acc.ID":
                    ColName = "AccountID";
                    break;
                case "CC.ID":
                    ColName = "CreditCardID";
                    break;
                default:
                    ColName = "None";
                    break;
            }
            if(ColName == "None" || txtFilterBy.Text == "")
            {
                _GetAllCustomers.DefaultView.RowFilter = "";
                lblRecords.Text = dgvListCustomer.RowCount.ToString();
                return;
            }
            if (ColName == "CustomerID" || ColName == "PersonID" || ColName == "AccountID" || ColName == "CreditCardID")
                _GetAllCustomers.DefaultView.RowFilter = string.Format("{0} = {1}", ColName, txtFilterBy.Text.Trim());
            else
                _GetAllCustomers.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", ColName, txtFilterBy.Text.Trim());
            lblRecords.Text = dgvListCustomer.RowCount.ToString();
        }
        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFindBy.Text == "C.ID" || cbFindBy.Text == "P.ID" || cbFindBy.Text == "Acc.ID" || cbFindBy.Text == "CC.ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        private void _GetPersonSelectedInfo(int PersonID)
        {
            if (PersonID < 0)
                return;
            _CustomerInfo = new clsCustomer();
            bool AddNewCustomer = _CustomerInfo.AddNewCustomer(PersonID);
            if (AddNewCustomer)
            {
                MessageBox.Show($"Done add new customer with id = {PersonID}", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadCustomerData();
            }
            else
                MessageBox.Show($"Not add customer with id = {PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.OnPersonSelected += _GetPersonSelectedInfo;
            frm.ShowDialog();
        }
        private void customerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvListCustomer.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
        private void dgvListCustomer_DoubleClick(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvListCustomer.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.OnPersonSelected += _GetPersonSelectedInfo;
            frm.ShowDialog();
        }
        private void updateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dgvListCustomer.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CustomerID = (int)dgvListCustomer.CurrentRow.Cells[0].Value;
            if (MessageBox.Show($"Are you sure to delete customer with id = {CustomerID}", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsCustomer.DeleteCustomer(CustomerID))
                    MessageBox.Show($"Done delete customer with id = {CustomerID}", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Not delete customer with id = {CustomerID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void findCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindPersonToAddCustomer frm = new frmFindPersonToAddCustomer();
            frm.ShowDialog();
        }
    }
}
