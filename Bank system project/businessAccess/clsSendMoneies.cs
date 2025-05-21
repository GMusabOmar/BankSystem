using System;
using System.Data;
using DataAccess;

namespace businessAccess
{
    public class clsSendMoneies
    {
        public int SendMoneyID { get; set; }
        public int Account_ID_FromSend {  get; set; }
        public int Account_ID_ToSend {  get; set; }
        public string FromCustomer {  get; set; }
        public string ToCustomer {  get; set; }
        public decimal Amount {  get; set; }
        public DateTime Date {  get; set; }
        public clsSendMoneies()
        {
            this.SendMoneyID = 0;
            this.Account_ID_FromSend = 0;
            this.Account_ID_ToSend = 0;
            this.FromCustomer = "";
            this.ToCustomer = "";
            this.Amount = 0;
            this.Date = DateTime.Now;
        }
        public bool AddNewSendMoneies()
        {
            this.SendMoneyID = clsSendMoneiesData.AddNewSendMoneiesData(this.Account_ID_FromSend,
            this.Account_ID_ToSend, this.FromCustomer, this.ToCustomer,
            this.Amount, this.Date);
            return this.SendMoneyID > 0;
        }
        public static DataTable GetAllSendMoneies()
        {
            return clsSendMoneiesData.GetAllSendMoneies();
        }
    }
}
