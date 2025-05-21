using System;
using System.Data;
using System.Data.SqlClient;
using EventViewr;

namespace DataAccess
{
    public class clsHistoryPaymentLoansData
    {
        public static DataTable GetAllHistoryPaymentLoans()
        {
            DataTable dt = new DataTable();
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AllHistoryPaymentLoan", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsHistoryPaymentLoansData: GetAllHistory", e.Message);
            }
            return dt;
        }
    }
}
