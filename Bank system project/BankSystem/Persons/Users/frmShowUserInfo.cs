using BankSystem.Global_Class;
using businessAccess;
using System;
using System.Windows.Forms;

namespace BankSystem.Persons.Users
{
    public partial class frmShowUserInfo : Form
    {
        public frmShowUserInfo()
        {
            InitializeComponent();
        }
        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            clsUser _UserInfo = clsGlobal.CurrentUser;
            ctrlUserInfo1.LoadData(_UserInfo.UserID);
        }
    }
}
