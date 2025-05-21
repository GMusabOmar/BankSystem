using System;
using System.Data;
using System.Data.SqlClient;
using EventViewr;

namespace DataAccess
{
    public class clsSendMoneiesData
    {
        public static int AddNewSendMoneiesData(int Account_ID_FromSend,
            int Account_ID_ToSend, string FromCustomer, string ToCustomer,
            decimal Amount, DateTime Date)
        {
            int NewID = 0;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AddNewSendMoneies", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Account_ID_FromSend", Account_ID_FromSend);
                        command.Parameters.AddWithValue("@Account_ID_ToSend", Account_ID_ToSend);
                        command.Parameters.AddWithValue("@FromCustomer", FromCustomer);
                        command.Parameters.AddWithValue("@ToCustomer", ToCustomer);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@Date", Date);
                        var GetID = new SqlParameter("@SendMoneyID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(GetID);
                        command.ExecuteNonQuery();
                        NewID = (int)GetID.Value;
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsSendMoneiesData: AddNewSendMoneiesData", e.Message);
            }
            return NewID;
        }
        public static DataTable GetAllSendMoneies()
        {
            DataTable dt = new DataTable();
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AllSendMoneies", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsSendMoneiesData : GetAllSendMoneies", e.Message);
            }
            return dt;
        }
    }
}
