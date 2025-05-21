using System;
using System.Data;
using System.Data.SqlClient;
using EventViewr;

namespace DataAccess
{
    public class clsAccountData
    {
        public static DataTable GetAllAccount()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AllAccount", connection))
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
            catch (Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsAccountData GetAllAccount", e.Message);
            }
            return dt;
        }
        public static bool DeleteAccount(int AccountID)
        {
            int rowAffected = 0;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_DeleteAccount", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsAccountData: DeleteAccount", e.Message);
            }
            return rowAffected > 0;
        }
        public static bool IsExistsAccount(int AccountID)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_IsExistsAccount", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AccountID", AccountID);
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
                clsEventLog error = clsEventLog.SetEvent("clsAccountData : IsExistsAccount", e.Message);
            }
            return isFound;
        }
        public static int AddNewAccount(int AccountID, int Customer_ID,
            decimal AccountBalance, int Branch_ID, string AccountType)
        {
            int NewID = 0;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AddNewAccount", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Customer_ID", Customer_ID);
                        command.Parameters.AddWithValue("@AccountBalance", AccountBalance);
                        command.Parameters.AddWithValue("@Branch_ID", Branch_ID);
                        command.Parameters.AddWithValue("@AccountType", AccountType);
                        var Acc_ID = new SqlParameter("@AccountID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(Acc_ID);
                        command.ExecuteNonQuery();
                        NewID = (int)Acc_ID.Value;
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsAccountData: AddNewAccount", e.Message);
            }
            return NewID;
        }
        public static bool UpdateAccount(int AccountID, decimal AccountBalance, 
            string AccountType)
        {
            int rowAffected = 0;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_UpdateAccount", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AccountBalance", AccountBalance);
                        command.Parameters.AddWithValue("@AccountType", AccountType);
                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsAccountData: UpdateAccount", e.Message);
            }
            return rowAffected > 0;
        }
        public static bool FindAccount(int AccountID, ref int Customer_ID,
            ref decimal AccountBalance, ref int Branch_ID, ref string AccountType)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FindAccount", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isFound = true;
                                Customer_ID = (int)reader["Customer_ID"];
                                AccountBalance = (decimal)reader["AccountBalance"];
                                Branch_ID = (int)reader["Branch_ID"];
                                AccountType = (string)reader["AccountType"];
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsAccountData: FindAccount", e.Message);
            }
            return isFound;
        }
    }
}
