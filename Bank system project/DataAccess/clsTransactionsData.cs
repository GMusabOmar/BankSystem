using System;
using System.Data;
using System.Data.SqlClient;
using EventViewr;

namespace DataAccess
{
    public class clsTransactionsData
    {
        public static int AddNewTransaction(int CreditCard_ID)
        {
            int NewID = 0;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AddNewTransaction", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CreditCard_ID", CreditCard_ID);
                        var GetID = new SqlParameter("@NewTransactionID", SqlDbType.Int)
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
                clsEventLog error = clsEventLog.SetEvent("clsTransactionsData: AddNewTransaction", e.Message);
            }
            return NewID;
        }
        public static DataTable GetAllTransaction()
        {
            DataTable dt = new DataTable();
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AllTransaction", connection))
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
                clsEventLog error = clsEventLog.SetEvent("clsTransactionsData: GetAllTransaction", e.Message);
            }
            return dt;
        }
        public static bool IsExistsTransactionByCreditCard(int CreditCard_ID)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_IsExistsTransactionByCreditCard", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CreditCard_ID", CreditCard_ID);
                        var GetFound = new SqlParameter("", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(GetFound);
                        command.ExecuteNonQuery();
                        isFound = (int)GetFound.Value == 1;
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsTransactionsData: IsExistsTransactionByCreditCard", e.Message);
            }
            return isFound;
        }
        public static bool FindTransaction(int TransactionID, ref int CreditCard_ID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using(SqlCommand command = new SqlCommand("SP_FindTransaction", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TransactionID", TransactionID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            isFound = true;
                            CreditCard_ID = (int)reader["CreditCard_ID"];
                        }
                    }
                }
            }
                return isFound;
        }
    }
}
