using System;
using System.Data;
using DataAccess;

namespace businessAccess
{
    public class clsDeposts
    {
        public int DepostID { get; set; }
        public int ATM_ID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public clsDeposts()
        {
            this.DepostID = -1;
            this.Amount = 0;
            this.ATM_ID = -1;
            this.Date = DateTime.Now;
        }
        public clsDeposts(int DepostID, int ATM_ID, decimal Amount, DateTime Date)
        {
            this.DepostID = DepostID;
            this.ATM_ID = ATM_ID;
            this.Amount = Amount;
            this.Date = Date;
        }
        public bool AddNewDeposts()
        {
            this.DepostID = clsDepostsData.AddNewDepost(ATM_ID, Amount, Date);
            return this.DepostID > 0;
        }
        public static DataTable GetAllDeposit()
        {
            return clsDepostsData.GetAllDeposit();
        }
    }
}
