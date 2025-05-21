using System;
using System.Data;
using businessAccess;
using System.Windows.Forms;

namespace BankSystem.Persons.Users
{
    public partial class frmListUser : Form
    {
        private DataTable _GetAllUser = clsUser.GetAllUser();
        private clsUser _UserInfo;
        private void _LoadData()
        {
            dgvListUser.DataSource = _GetAllUser;
            lblRecords.Text = dgvListUser.RowCount.ToString();
            cbFilterBy.SelectedIndex = 0;
            if(dgvListUser.RowCount > 0)
            {
                dgvListUser.Columns[0].HeaderText = "U.ID";
                dgvListUser.Columns[0].Width = 60;

                dgvListUser.Columns[1].HeaderText = "P.ID";
                dgvListUser.Columns[1].Width = 60;

                dgvListUser.Columns[2].HeaderText = "User Name";
                dgvListUser.Columns[2].Width = 100;

                dgvListUser.Columns[3].HeaderText = "Active";
                dgvListUser.Columns[3].Width = 70;

                dgvListUser.Columns[4].HeaderText = "Full Name";
                dgvListUser.Columns[4].Width = 300;

                dgvListUser.Columns[5].HeaderText = "Email";
                dgvListUser.Columns[5].Width = 140;

                dgvListUser.Columns[6].HeaderText = "Address";
                dgvListUser.Columns[6].Width = 80;

                dgvListUser.Columns[7].HeaderText = "Phone";
                dgvListUser.Columns[7].Width = 60;

            }
        }
        public frmListUser()
        {
            InitializeComponent();
        }
        private void frmListUser_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible = (cbFilterBy.Text != "None");
            cbIsActive.Visible = false;
            if(txtFilterBy.Visible)
            {
                txtFilterBy.Text = "";
                txtFilterBy.Focus();
                cbIsActive.Visible = false;
            }
            if(cbFilterBy.Text == "Active")
            {
                cbIsActive.SelectedIndex = 0;
                cbIsActive.Visible = true;
                txtFilterBy.Visible = false;
            }
        }
        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "U.ID" || cbFilterBy.Text == "P.ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string ColName = "";
            switch(cbFilterBy.Text)
            {
                case "U.ID":
                    ColName = "UserID";
                    break;
                case "P.ID":
                    ColName = "Person_ID";
                    break;
                case "User Name":
                    ColName = "UserName";
                    break;
                case "Active":
                    ColName = "IsActive";
                    break;
                case "Full Name":
                    ColName = "FullName";
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
            if(ColName == "None" || txtFilterBy.Text == "")
            {
                _GetAllUser.DefaultView.RowFilter = "";
                lblRecords.Text = dgvListUser.RowCount.ToString();
                return;
            }
            if (ColName == "UserID" || ColName == "Person_ID")
                _GetAllUser.DefaultView.RowFilter = string.Format("{0} = {1}", ColName, txtFilterBy.Text.Trim());
            else
                _GetAllUser.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", ColName, txtFilterBy.Text.Trim());
            lblRecords.Text = dgvListUser.RowCount.ToString();
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ColName = "IsActive";
            bool CheckTrue = true;
            if (cbIsActive.Text == "Yes")
                _GetAllUser.DefaultView.RowFilter = string.Format("{0} = {1}", ColName, CheckTrue);
            else
                _GetAllUser.DefaultView.RowFilter = string.Format("{0} = {1}", ColName, !CheckTrue);
        }
        private void AddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
        }
        private void dgvListUser_DoubleClick(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvListUser.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvListUser.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _LoadData();
        }
        private void updeteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvListUser.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }
        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvListUser.CurrentRow.Cells[0].Value;
            if(MessageBox.Show($"Are you sure delete user with id = {UserID}", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(UserID))
                    MessageBox.Show($"Done successfuly with user id = {UserID}", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Not delete user with id = {UserID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
