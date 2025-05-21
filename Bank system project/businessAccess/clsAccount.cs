using System;
using System.Data;
using DataAccess;

namespace businessAccess
{
    public class clsAccount
    {
        private enum _enTypeMode { Add = 0, Update = 1 }
        private _enTypeMode _Mode = _enTypeMode.Add;
        public int AccountID { get; set; }
        public int Customer_ID { get; set; }
        public decimal AccountBalance { get; set; }
        public int Branch_ID { get; set; }
        public string AccountType { get; set; }
        public clsAccount()
        {
            this.AccountID = -1;
            this.Customer_ID = -1;
            this.AccountBalance = -1;
            this.Branch_ID = -1;
            this.AccountType = "";
            _Mode = _enTypeMode.Add;
        }
        public clsAccount(int AccountID, int Customer_ID, decimal AccountBalance,
            int Branch_ID, string AccountType)
        {
            this.AccountID = AccountID;
            this.Customer_ID = Customer_ID;
            this.AccountBalance = AccountBalance;
            this.Branch_ID = Branch_ID;
            this.AccountType = AccountType;
            _Mode = _enTypeMode.Update;
        }
        public static DataTable GetAllAccount()
        {
            return clsAccountData.GetAllAccount();
        }
        public static bool DeleteAccount(int AccountID)
        {
            return clsAccountData.DeleteAccount(AccountID);
        }
        private bool _AddNewAccount()
        {
            this.AccountID = clsAccountData.AddNewAccount(this.AccountID, this.Customer_ID,
                             this.AccountBalance, this.Branch_ID, this.AccountType);
            return this.AccountID > 0;
        }
        private bool _UpdateAccount()
        {
            return clsAccountData.UpdateAccount(this.AccountID, this.AccountBalance,
                            this.AccountType);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case _enTypeMode.Add:
                    if (_AddNewAccount())
                    {
                        _Mode = _enTypeMode.Update;
                        return true;
                    }
                    else
                        return false;
                default:
                    return _UpdateAccount();
            }
        }
        public static bool IsExistsAccount(int AccountID)
        {
            return clsAccountData.IsExistsAccount(AccountID);
        }
        public static clsAccount FindAccount(int AccountID)
        {
            int Customer_ID = -1, Branch_ID = -1;
            decimal AccountBalance = -1;
            string AccountType = "";
            bool isFound = clsAccountData.FindAccount(AccountID, ref Customer_ID,
                            ref AccountBalance, ref Branch_ID, ref AccountType);
            if (isFound)
                return new clsAccount(AccountID, Customer_ID, AccountBalance,
                             Branch_ID, AccountType);
            return null;
        }
    }
}
