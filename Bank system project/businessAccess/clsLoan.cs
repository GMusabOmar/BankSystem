using System.Data;
using DataAccess;

namespace businessAccess
{
    public class clsLoan
    {
        private enum _enTypeMode { Add = 0, Update = 1}
        private _enTypeMode _Mode = _enTypeMode.Add;
        public int LoanID { get; set; }
        public int Branch_ID { get; set; }
        public int Account_ID { get; set; }
        public decimal Remaining_Amount {  get; set; }
        public decimal Issue_Amount {  get; set; }
        public clsLoan()
        {
            this.LoanID = 0;
            this.Branch_ID = 0;
            this.Account_ID = 0;
            this.Remaining_Amount = 0;
            this.Issue_Amount = 0;
            _Mode = _enTypeMode.Add;
        }
        public clsLoan(int LoanID, int Branch_ID, int Account_ID,
            decimal Remaining_Amount, decimal Issue_Amount)
        {
            this.LoanID = LoanID;
            this.Branch_ID = Branch_ID;
            this.Account_ID = Account_ID;
            this.Remaining_Amount = Remaining_Amount;
            this.Issue_Amount = Issue_Amount;
            _Mode = _enTypeMode.Update;
        }
        public static clsLoan FindLoan(int LoanID)
        {
            int Branch_ID = 0, Account_ID = 0;
            decimal Remaining_Amount = 0, Issue_Amount = 0;
            bool isFound = clsLoanData.FindLoan(LoanID, ref Branch_ID,
                ref Account_ID, ref Remaining_Amount, ref Issue_Amount);
            if (isFound)
            {
                return new clsLoan(LoanID, Branch_ID, Account_ID,
                            Remaining_Amount, Issue_Amount);
            }
            return null;
        }
        public static DataTable GetAllLoan()
        {
            return clsLoanData.GetAllLoan();
        }
        public static bool IsExistsLoan(int LoanID)
        {
            return clsLoanData.IsExistsLoan(LoanID);
        }
        private bool _AddNewLoan()
        {
            this.LoanID = clsLoanData.AddNewLoan(this.Branch_ID, this.Account_ID, 
                this.Remaining_Amount, this.Issue_Amount);
            return this.LoanID > 0;
        }
        private bool _UpdateLoan()
        {
            return clsLoanData.UpdateLoan(this.LoanID, this.Remaining_Amount);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case _enTypeMode.Add:
                    if(_AddNewLoan())
                    {
                        _Mode = _enTypeMode.Update;
                        return true;
                    }
                    return false;
                default:
                    return _UpdateLoan();
            }
        }
        public static bool IsExistsLoanByAccountID(int Account_ID)
        {
            return clsLoanData.IsExistsLoanByAccountID(@Account_ID);
        }

    }
}
