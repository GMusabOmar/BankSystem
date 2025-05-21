using System.Data;
using DataAccess;

namespace businessAccess
{
    public class clsHistoryPaymentLoans
    {
        public static DataTable GetAllHistoryPaymentLoans()
        {
            return clsHistoryPaymentLoansData.GetAllHistoryPaymentLoans();
        }
    }
}
