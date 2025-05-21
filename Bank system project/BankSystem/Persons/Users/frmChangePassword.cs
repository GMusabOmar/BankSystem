using System;
using businessAccess;
using System.Windows.Forms;
using BankSystem.Global_Class;

namespace BankSystem.Persons.Users
{
    public partial class frmChangePassword : Form
    {
        private clsUser _UserInfo = clsGlobal.CurrentUser;
        public frmChangePassword()
        {
            InitializeComponent();
        }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserInfo1.LoadData(_UserInfo.UserID);
        }
        private void txtOldPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtOldPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtOldPassword, "This field must be not null");
            }
            if (_UserInfo.Password != txtOldPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtOldPassword, "Invalid old password");
            }
            else
                errorProvider1.SetError(txtOldPassword, null);
        }
        private void txtNewPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "This field must be not null");
            }
            else
                errorProvider1.SetError(txtNewPassword, null);
        }
        private void txtConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This field must be not null");
            }
            if(txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Mismatched password");
            }
            else
                errorProvider1.SetError(txtConfirmPassword, null);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Please put the mouse on red flag", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _UserInfo.Password = txtNewPassword.Text.Trim();
            if(_UserInfo.Save())
            {
                txtOldPassword.Enabled = false;
                txtNewPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;
                btnSave.Enabled = false;
                MessageBox.Show("Done successfuly", "Save update password",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Not Save", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void frmChangePassword_Activated(object sender, EventArgs e)
        {
            txtOldPassword.Focus();
        }
    }
}
