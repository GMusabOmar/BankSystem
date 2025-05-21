using System;
using System.Data;
using DataAccess;

namespace businessAccess
{
    public class clsPaymentLoan
    {
        private enum _enTypeMode { Add = 0, Update = 1}
        private _enTypeMode _Mode = _enTypeMode.Add;
        public int PaymentID { get; set; }
        public decimal Amount { get; set; }
        public int Loan_ID { get; set; }
        public clsPaymentLoan()
        {
            this.PaymentID = 0;
            this.Amount = 0;
            this.Loan_ID = 0;
            _Mode = _enTypeMode.Add;
        }
        public clsPaymentLoan(int PaymentID, decimal Amount, int Loan_ID)
        {
            this.PaymentID = PaymentID;
            this.Amount = Amount;
            this.Loan_ID = Loan_ID;
            _Mode = _enTypeMode.Update;
        }
        private bool _AddNewPaymentLoan()
        {
            this.PaymentID = clsPaymentLoanData.AddNewPaymentLoan(this.Amount, this.Loan_ID);
            return this.PaymentID > 0;
        }
        private bool _UpdatePaymentLoan()
        {
            return clsPaymentLoanData.UpdatePaymentLoan(this.PaymentID, this.Amount);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case _enTypeMode.Add:
                    if (_AddNewPaymentLoan())
                    {
                        _Mode = _enTypeMode.Update;
                        return true;
                    }
                    else
                        return false;
                default:
                    return _UpdatePaymentLoan();
            }
        }
        public static DataTable GetAllPaymentLoan()
        {
            return clsPaymentLoanData.GetAllPaymentLoan();
        }
        public static bool IsExistsPaymentLoan(int PaymentID)
        {
            return clsPaymentLoanData.IsExistsPaymentLoan(PaymentID);
        }
        public static clsPaymentLoan FindPaymentLoan(int PaymentID)
        {
            decimal Amount = 0;
            int Loan_ID = 0;
            bool isFound = clsPaymentLoanData.FindPaymentLoan(PaymentID,
                            ref Amount, ref Loan_ID);
            if (isFound)
                return new clsPaymentLoan(PaymentID, Amount, Loan_ID);
            return null;
        }
        public static bool IsExistsPaymentLoanByLoanID(int Loan_ID)
        {
            return clsPaymentLoanData.IsExistsPaymentLoanByLoanID(Loan_ID);
        }

    }
}
