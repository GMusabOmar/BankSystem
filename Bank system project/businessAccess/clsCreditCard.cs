using System;
using System.Data;
using DataAccess;

namespace businessAccess
{
    public class clsCreditCard
    {
        public int CreditCardID { get; set; }
        public int Account_ID { get; set; }
        public DateTime Expiry_Date { get; set; }
        public decimal CardLimit { get; set; }
        public clsCreditCard()
        {
            this.CreditCardID = 0;
            this.Account_ID = 0;
            this.Expiry_Date = DateTime.Now;
            this.CardLimit = 0;
        }
        public clsCreditCard(int CreditCardID, int Account_ID,
                    DateTime Expiry_Date, decimal CardLimit)
        {
            this.CreditCardID = CreditCardID;
            this.Account_ID = Account_ID;
            this.Expiry_Date = Expiry_Date;
            this.CardLimit = CardLimit;
        }
        public bool AddNewCreditCard()
        {
            this.CreditCardID = clsCreditCardData.AddNewCreditCard(this.Account_ID,
                                this.Expiry_Date, this.CardLimit);
            return this.CreditCardID > 0;
        }
        public static DataTable GetAllCreditCard()
        {
            return clsCreditCardData.GetAllCreditCard();
        }
        public static bool IsExistsCreditCard(int CreditCardID)
        {
            return clsCreditCardData.IsExistsCreditCard(CreditCardID);
        }
        public static bool IsExistsCreditCardByAccountID(int Account_ID)
        {
            return clsCreditCardData.IsExistsCreditCardByAccountID(Account_ID);
        }
        public static clsCreditCard FindCreditCard(int CreditCardID)
        {
            int Account_ID = 0;
            DateTime Expiry_Date = DateTime.Now;
            decimal CardLimit = 0;
            bool isFound = clsCreditCardData.FindCreditCard(CreditCardID, ref Account_ID,
                ref Expiry_Date, ref CardLimit);
            if (isFound)
                return new clsCreditCard(CreditCardID, Account_ID,
                        Expiry_Date, CardLimit);
            else
                return null;
        }
    }
}
