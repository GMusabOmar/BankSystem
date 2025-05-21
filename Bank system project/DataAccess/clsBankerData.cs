using System;
using System.Data;
using System.Data.SqlClient;
using EventViewr;

namespace DataAccess
{
    public class clsBankerData
    {
        public static int AddNewBanker(string BankName, int Branch_ID)
        {
            int NewID = 0;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AddNewBankers", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BankName", BankName);
                        command.Parameters.AddWithValue("@Branch_ID", Branch_ID);
                        var GetID = new SqlParameter("@NewIDBankers", SqlDbType.Int)
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
                clsEventLog error = clsEventLog.SetEvent("clsBankerData", e.Message);
            }
            return NewID;
        }
        public static DataTable GetAllBanker()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AllBanker", connection))
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
                clsEventLog error = clsEventLog.SetEvent("clsBankerData", e.Message);
            }
            return dt;
        }
        public static bool IsExistsBankers(int BankerID)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection())
                {
                    using(SqlCommand command = new SqlCommand("SP_IsExistsBankers", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();
                        var GetReturn = new SqlParameter("", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(GetReturn);
                        command.ExecuteNonQuery();
                        isFound = (int)GetReturn.Value == 1;
                    }
                }
            }
            catch (Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsBankerData", e.Message);
            }
            return isFound;
        }
    }
}
