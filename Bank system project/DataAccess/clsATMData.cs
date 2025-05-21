using System;
using System.Data;
using System.Data.SqlClient;
using EventViewr;

namespace DataAccess
{
    public class clsATMData
    {
        public static int AddNewATM(int Transaction_ID, DateTime Date)
        {
            int NewID = 0;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AddNewATM", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Transaction_ID", Transaction_ID);
                        command.Parameters.AddWithValue("@Date", Date);
                        var GetID = new SqlParameter("@NewATMID", SqlDbType.Int)
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
                clsEventLog error = clsEventLog.SetEvent("clsATMData: AddNewATM", e.Message);
            }
            return NewID;
        }
        public static DataTable GetAllATM()
        {
            DataTable dt = new DataTable();
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AllATMS", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsATMData: GetAllATM", e.Message);
            }
            return dt;
        }
        public static bool IsExistsATM(int ATMID)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IsExistsATM", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ATMID", ATMID);
                        var ReturnValue = new SqlParameter("", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(ReturnValue);
                        command.ExecuteNonQuery();
                        isFound = (int)ReturnValue.Value == 1;
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsATMData: IsExistsATM", e.Message);
            }
            return isFound;
        }
        public static bool IsExistsATMByTransaction(int Transaction)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FindATMByTransaction", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Transaction", Transaction);
                        var ReturnValue = new SqlParameter("", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(ReturnValue);
                        command.ExecuteNonQuery();
                        isFound = (int)ReturnValue.Value == 1;
                    }
                }
            }
            catch (Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsATMData: IsExistsATMTransaction", e.Message);
            }
            return isFound;
        }

        public static bool FindATM(int ATMID, ref int Transaction_ID,
            ref DateTime Date)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FindATM", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ATMID", ATMID);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isFound = true;
                                Transaction_ID = (int)reader["Transaction_ID"];
                                Date = (DateTime)reader["Date"];
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsATMData: FindATM", e.Message);
            }
            return isFound;
        }
    }
}
