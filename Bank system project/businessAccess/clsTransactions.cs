using System;
using System.Data;
using DataAccess;


namespace businessAccess
{
    public class clsTransactions
    {
        public int TransactionID { get; set; }
        public int CreditCard_ID { get; set; }
        public clsTransactions()
        {
            this.TransactionID = 0;
            this.CreditCard_ID = 0;
        }
        public clsTransactions(int TransactionID, int CreditCard_ID)
        {
            this.TransactionID = TransactionID;
            this.CreditCard_ID = CreditCard_ID;
        }
        public bool AddNewTransaction()
        {
            this.TransactionID = clsTransactionsData.AddNewTransaction(this.CreditCard_ID);
            return this.TransactionID > 0;
        }
        public static DataTable GetAllTransaction()
        {
            return clsTransactionsData.GetAllTransaction();
        }
        public static bool IsExistsTransactionByCreditCard(int CreditCard_ID)
        {
            return clsTransactionsData.IsExistsTransactionByCreditCard(CreditCard_ID);
        }
        public static clsTransactions FindTransaction(int TransactionID)
        {
            int CreditCard_ID = 0;
            bool isFound = clsTransactionsData.FindTransaction(TransactionID, ref CreditCard_ID);
            if (isFound)
                return new clsTransactions(TransactionID, CreditCard_ID);
            else
                return null;
        }
    }
}
