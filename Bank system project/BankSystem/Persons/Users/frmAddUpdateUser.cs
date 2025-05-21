using System;
using System.Windows.Forms;
using businessAccess;

namespace BankSystem.Persons.Users
{
    public partial class frmAddUpdateUser : Form
    {
        private enum _enTypeMode { Add = 0, Update = 1}
        private _enTypeMode _Mode = _enTypeMode.Add;
        private int _PersonID = -1;
        private int _UserID = -1;
        private clsUser _UserInfo;
        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = _enTypeMode.Add;
            this.Text = "Add New User";
            lblTitle.Text = "Add New User";
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = _enTypeMode.Update;
            _UserID = UserID;
            this.Text = "Update User";
            lblTitle.Text = "Update User";
        }
        private void _RestDefaultValues()
        {
            _UserInfo = new clsUser();
            lblUserID.Text = "N/A";
            txtUserName.Text = "";
            txtPassword.Text = "";
            cbActiveUser.Checked = true;
        }
        private void _LoadDataUserInfo()
        {
            _UserInfo = clsUser.FindUserByID(_UserID);
            if(_UserInfo == null)
            {
                MessageBox.Show("Not found user with id = " + _UserID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblUserID.Text = _UserID.ToString();
            txtUserName.Text = _UserInfo.UserName;
            txtPassword.Text = _UserInfo.Password;
            cbActiveUser.Checked = _UserInfo.IsActive;
        }
        private void ctrlPersonInfoWithFilter1_OnPersonSelectedFromFilter2(int obj)
        {
            if(_Mode == _enTypeMode.Add)
            {
                if (obj < 0 || !clsPeron.IsExistsPerson(obj))
                {
                    gbUserInfo.Enabled = false;
                    btnSave.Enabled = false;
                    return;
                }
                if (clsCustomer.IsExistsCustomerByFPerson_ID(obj))
                {
                    MessageBox.Show("Can't add customer to became user!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gbUserInfo.Enabled = false;
                    btnSave.Enabled = false;
                    ctrlPersonInfoWithFilter1.FilterFocus();
                    return;
                }
                if (clsUser.IsExistsUserByFPerson_ID(obj))
                {
                    MessageBox.Show("This person already user , try another person.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gbUserInfo.Enabled = false;
                    btnSave.Enabled = false;
                    ctrlPersonInfoWithFilter1.FilterFocus();
                    return;
                }
                _PersonID = obj;
                _RestDefaultValues();
                ctrlPersonInfoWithFilter1.FilterEnable = false;
                gbUserInfo.Enabled = true;
                btnSave.Enabled = true;
                txtUserName.Focus();
            }
            else
            {
                ctrlPersonInfoWithFilter1.FilterEnable = false;
                gbUserInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ValidatingText(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;
            if(string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field must be not null");
            }
            else
                errorProvider1.SetError(Temp, null);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Please put the mouse on red flag!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_Mode == _enTypeMode.Add)
                _UserInfo.Person_ID = _PersonID;
            _UserInfo.UserName = txtUserName.Text.Trim();
            _UserInfo.Password = txtPassword.Text.Trim();
            if (cbActiveUser.Checked)
                _UserInfo.IsActive = true;
            else
                _UserInfo.IsActive = false;
            if(_UserInfo.Save())
            {
                MessageBox.Show("Done successful", "User Info",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTitle.Text = "Update User";
                this.Text = "Update User";
                _UserID = _UserInfo.UserID;
                lblUserID.Text = _UserID.ToString();
                btnSave.Enabled = false;
                gbUserInfo.Enabled = false;
            }
            else
                MessageBox.Show("Not successful!!", "User Info",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            gbUserInfo.Enabled = false;
            if(_Mode == _enTypeMode.Update)
            {
                _LoadDataUserInfo();
                ctrlPersonInfoWithFilter1.LoadData(_UserInfo.Person_ID);
            }
        }
        private void frmAddUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.FilterFocus();
        }
    }
}
