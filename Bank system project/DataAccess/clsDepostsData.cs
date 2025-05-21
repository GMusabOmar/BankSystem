using System;
using System.Data;
using System.Data.SqlClient;
using EventViewr;

namespace DataAccess
{
    public class clsDepostsData
    {
        public static int AddNewDepost(int ATM_ID, decimal Amount, DateTime Date)
        {
            int NewID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewDeposts", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ATM_ID", ATM_ID);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@Date", Date);
                        var GetID = new SqlParameter("@NewDepostID", SqlDbType.Int)
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
                clsEventLog error = clsEventLog.SetEvent("clsDepostsData: AddNewDepost", e.Message);
            }
            return NewID;
        }
        public static DataTable GetAllDeposit()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AllDeposit", connection))
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
            catch (Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsDepostsData: GetAllDeposit", e.Message);
            }
            return dt;
        }
    }
}
