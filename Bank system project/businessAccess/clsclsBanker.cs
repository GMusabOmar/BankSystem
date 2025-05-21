using System;
using System.Data;
using DataAccess;

namespace businessAccess
{
    public class clsclsBanker
    {
        public int BankerID { get; set; }
        public string BankName { get; set; }
        public int Branch_ID { get; set; }
        public clsclsBanker()
        {
            this.BankerID = -1;
            this.BankName = "";
            this.Branch_ID = -1;

        }
        public bool AddNewBanker()
        {
            this.BankerID = clsBankerData.AddNewBanker(this.BankName, this.Branch_ID);
            return this.BankerID > 0;
        }
        public static DataTable GetAllBanker()
        {
            return clsBankerData.GetAllBanker();
        }
        public static bool IsExistsBankers(int bankerID)
        {
            return clsBankerData.IsExistsBankers(bankerID);
        }
    }
}
