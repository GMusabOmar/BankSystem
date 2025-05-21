using System;
using System.Windows.Forms;
using BankSystem.Global_Class;
using businessAccess;

namespace BankSystem.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser _UserInfo = clsUser.FindUserByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if (_UserInfo != null)
            {
                if(!_UserInfo.IsActive)
                {
                    MessageBox.Show("This username is inactive. Try contacting an administrator.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtUserName.Focus();
                    return;
                }
                if(cbRememberMe.Checked)
                    clsGlobal.SaveCredential(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                else
                    clsGlobal.SaveCredential("", "");
                clsGlobal.CurrentUser = _UserInfo;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.SaveCredential("", "");
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtUserName.Focus();
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";
            if(clsGlobal.GetCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                cbRememberMe.Checked = true;
            }
            else
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtUserName.Focus();
            }
        }
    }
}
