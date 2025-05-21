using System;
using businessAccess;
using System.Windows.Forms;

namespace BankSystem.Persons.Users
{
    public partial class ctrlUserInfo : UserControl
    {
        private clsUser _UserInfo;
        private int _UserId;
        public ctrlUserInfo()
        {
            InitializeComponent();
        }
        public void LoadData(int UserID)
        {
            _UserId = UserID;
            _UserInfo = clsUser.FindUserByID(UserID);
            if (_UserInfo != null)
            {
                ctrlPersonInfo1.LoadPersonInfo(_UserInfo.Person_ID);
                lblUserID.Text = _UserInfo.UserID.ToString();
                lblUserName.Text = _UserInfo.UserName.ToString();
                if (_UserInfo.IsActive)
                    lblIsActive.Text = "Yes";
                else
                    lblIsActive.Text = "No";
            }
        }
    }
}
