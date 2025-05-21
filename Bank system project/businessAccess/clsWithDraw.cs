using System;
using System.Data;
using DataAccess;

namespace businessAccess
{
    public class clsWithDraw
    {
        public int WithDrawID { get; set; }
        public int ATM_ID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public clsWithDraw()
        {
            this.WithDrawID = 0;
            this.ATM_ID = 0;
            this.Amount = 0;
            this.Date = DateTime.Now;
        }
        public bool AddNewWithDraw()
        {
            this.WithDrawID = clsWithDrawData.AddNewWithDraw(this.ATM_ID, this.Amount, this.Date);
            return this.WithDrawID > 0;
        }
        public static DataTable GetAllWithDraw()
        {
            return clsWithDrawData.GetAllWithDraw();
        }
    }
}
