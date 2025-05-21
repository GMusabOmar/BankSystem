using System;
using System.Data;
using System.Data.SqlClient;
using EventViewr;

namespace DataAccess
{
    public class clsCreditCardData
    {
        public static int AddNewCreditCard(int Account_ID, DateTime Expiry_Date, decimal CardLimit)
        {
            int NewID = 0;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AddNewCreditCard", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Account_ID", Account_ID);
                        command.Parameters.AddWithValue("@Expiry_Date", Expiry_Date);
                        command.Parameters.AddWithValue("@CardLimit", CardLimit);
                        var GetID = new SqlParameter("@NewCreditCardID", SqlDbType.Int)
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
                clsEventLog error = clsEventLog.SetEvent("clsCreditCardData: AddNewCreditCard", e.Message);
            }
            return NewID;
        }
        public static DataTable GetAllCreditCard()
        {
            DataTable dt = new DataTable();
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AllCreditCard", connection))
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
                clsEventLog error = clsEventLog.SetEvent("clsCreditCardData: GetAllCreditCard", e.Message);
            }
            return dt;
        }
        public static bool IsExistsCreditCard(int CreditCardID)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_IsExistsCreditCard", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CreditCardID", CreditCardID);
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
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsCreditCardData: IsExistsCreditCard", e.Message);
            }
            return isFound;
        }
        public static bool IsExistsCreditCardByAccountID(int Account_ID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IsExistsCreditCardByAccountID", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Account_ID", Account_ID);
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
                clsEventLog error = clsEventLog.SetEvent("clsCreditCardData: IsExistsCreditCardByAccountID", e.Message);
            }
            return isFound;
        }
        public static bool FindCreditCard(int CreditCardID, ref int Account_ID,
            ref DateTime Expiry_Date, ref decimal CardLimit)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_FindCreditCard", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CreditCardID", CreditCardID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                Account_ID = (int)reader["Account_ID"];
                                Expiry_Date = (DateTime)reader["Expiry_Date"];
                                CardLimit = (decimal)reader["CardLimit"];
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsCreditCardData: FindCreditCard", e.Message);
            }
            return isFound;
        }
    }
}
