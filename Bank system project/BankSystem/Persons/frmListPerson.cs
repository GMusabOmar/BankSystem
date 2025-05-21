using System;
using businessAccess;
using System.Windows.Forms;
using System.Data;
using BankSystem.Persons;

namespace BankSystem
{
    public partial class frmListPerson : Form
    {
        private DataTable _GetAllPerson = clsPeron.GetAllPerson();
        private void _LoadData()
        {
            dgvAllPerson.DataSource = _GetAllPerson;
            cbFilter.SelectedIndex = 0;
            lblRecords.Text = dgvAllPerson.RowCount.ToString();
            if (dgvAllPerson.Rows.Count > 0)
            {
                dgvAllPerson.Columns[0].HeaderText = "P.ID";
                dgvAllPerson.Columns[0].Width = 80;

                dgvAllPerson.Columns[1].HeaderText = "User";
                dgvAllPerson.Columns[1].Width = 70;

                dgvAllPerson.Columns[2].HeaderText = "Customer";
                dgvAllPerson.Columns[2].Width = 90;

                dgvAllPerson.Columns[3].HeaderText = "First Name";
                dgvAllPerson.Columns[3].Width = 110;

                dgvAllPerson.Columns[4].HeaderText = "Second Name";
                dgvAllPerson.Columns[4].Width = 110;

                dgvAllPerson.Columns[5].HeaderText = "Third Name";
                dgvAllPerson.Columns[5].Width = 110;

                dgvAllPerson.Columns[6].HeaderText = "Last Name";
                dgvAllPerson.Columns[6].Width = 140;

                dgvAllPerson.Columns[7].HeaderText = "Email";
                dgvAllPerson.Columns[7].Width = 160;

                dgvAllPerson.Columns[8].HeaderText = "Address";
                dgvAllPerson.Columns[8].Width = 110;

                dgvAllPerson.Columns[8].HeaderText = "Phone";
                dgvAllPerson.Columns[8].Width = 130;

            }
        }
        public frmListPerson()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilter.Text == "None")
            {
                cbFiltter2.Visible = false;
                txtFilter.Visible = false;
            }
            txtFilter.Visible = cbFilter.Text != "None";
            if(txtFilter.Visible)
            {
                cbFiltter2.Visible = false;
                txtFilter.Text = "";
                txtFilter.Focus();
            }
            if(cbFilter.Text == "User" || cbFilter.Text == "Customer")
            {
                txtFilter.Visible = false;
                cbFiltter2.Visible = true;
                cbFiltter2.SelectedIndex = 0;
            }
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilter.Text == "P.ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string ColName = "";
            switch(cbFilter.Text)
            {
                case "P.ID":
                    ColName = "PersonID";
                    break;
                case "User":
                    ColName = "IS_User";
                    break;
                case "Customer":
                    ColName = "IS_Customer";
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
                default:
                    ColName = "None";
                    break;
            }
            if (ColName == "None" || txtFilter.Text == "")
            {
                _GetAllPerson.DefaultView.RowFilter = "";
                lblRecords.Text = dgvAllPerson.Rows.Count.ToString();
                return;
            }
            if(ColName == "PersonID")
                _GetAllPerson.DefaultView.RowFilter = string.Format("{0} = {1}", ColName, txtFilter.Text.Trim());
            else
                _GetAllPerson.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", ColName, txtFilter.Text.Trim());
            lblRecords.Text = dgvAllPerson.Rows.Count.ToString();
        }
        private void cbFiltter2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "User")
            {
                if(cbFiltter2.Text == "Yes")
                    _GetAllPerson.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", "IS_User", "Yes");
                else
                    _GetAllPerson.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", "IS_User", "No");
            }
            else if (cbFilter.Text == "Customer")
            {
                if (cbFiltter2.Text == "Yes")
                    _GetAllPerson.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", "IS_Customer", "Yes");
                else
                    _GetAllPerson.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", "IS_Customer", "No");
            }
            lblRecords.Text = dgvAllPerson.RowCount.ToString();
        }
        private void personInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvAllPerson.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void dgvAllPerson_DoubleClick(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvAllPerson.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void AddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _LoadData();
        }
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _LoadData();
        }
        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dgvAllPerson.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }
        private void frmListPerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvAllPerson.CurrentRow.Cells[0].Value;
            if(MessageBox.Show($"Are you sure to delete person with id = {PersonID}", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool isPersonExists = clsPeron.IsExistsPerson(PersonID);
                if (isPersonExists)
                {
                    clsPeron.DeletePerson(PersonID);
                    MessageBox.Show($"Done successful with person id = {PersonID}", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadData();
                }
                else
                    MessageBox.Show($"Not delete person with id = {PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
