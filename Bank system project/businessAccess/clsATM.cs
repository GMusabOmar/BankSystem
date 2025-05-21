using System;
using System.Data;
using businessAccess;
using DataAccess;

namespace businessAccess
{
    public class clsATM
    {
        public int ATMID { get; set; }
        public int Transaction_ID { get; set; }
        public DateTime Date { get; set; }
        public clsATM()
        {
            this.ATMID = -1;
            this.Transaction_ID = -1;
            this.Date = DateTime.Now;
        }
        public clsATM(int ATMID, int Transaction_ID, DateTime Date)
        {
            this.ATMID = ATMID;
            this.Transaction_ID = Transaction_ID;
            this.Date = Date;
        }
        public bool AddNewATM()
        {
            this.ATMID = clsATMData.AddNewATM(this.Transaction_ID, this.Date);
            return this.ATMID > 0;
        }
        public static DataTable GetAllATM()
        {
            return clsATMData.GetAllATM();
        }
        public static bool IsExistsATM(int ATMID)
        {
            return clsATMData.IsExistsATM(ATMID);
        }
        public static bool IsExistsATMByTransaction(int Transaction)
        {
            return clsATMData.IsExistsATMByTransaction(Transaction);
        }

        public static clsATM FindATM(int ATMID)
        {
            int Transaction_ID = -1;
            DateTime Date = DateTime.Now;
            bool isFound = clsATMData.FindATM(ATMID, ref Transaction_ID, ref Date);
            if(isFound)
                return new clsATM(ATMID, Transaction_ID, Date);
            return null;
        }
    }
}
