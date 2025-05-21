using System;
using System.Data;
using System.Data.SqlClient;
using EventViewr;

namespace DataAccess
{
    public class clsLoanData
    {
        public static int AddNewLoan(int Branch_ID, int Account_ID, decimal Remaining_Amount,
            decimal Issue_Amount)
        {
            int NewID = -1;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AddNewLoan", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Branch_ID", Branch_ID);
                        command.Parameters.AddWithValue("@Account_ID", Account_ID);
                        command.Parameters.AddWithValue("@Remaining_Amount", Remaining_Amount);
                        command.Parameters.AddWithValue("@Issue_Amount", Issue_Amount);
                        var GetID = new SqlParameter("@NewLoanID", SqlDbType.Int)
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
                clsEventLog error = clsEventLog.SetEvent("clsLoanData: AddNewLoan", e.Message);
            }
            return NewID;
        }
        public static DataTable GetAllLoan()
        {
            DataTable dt = new DataTable();
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AllLoans", connection))
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
                clsEventLog error = clsEventLog.SetEvent("clsLoanData: GetAllLoan", e.Message);
            }
            return dt;
        }
        public static bool IsExistsLoan(int LoanID)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_IsExistsLoan", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LoanID", LoanID);
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
                clsEventLog error = clsEventLog.SetEvent("clsLoanData: IsExistsLoan", e.Message);
            }
            return isFound;
        }
        public static bool UpdateLoan(int LoanID, decimal Remaining_Amount)
        {
            int rowAffected = 0;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_UpdateLoan", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Remaining_Amount", Remaining_Amount);
                        command.Parameters.AddWithValue("@LoanID", LoanID);
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsLoanData: UpdateLoan", e.Message);
            }
            return rowAffected > 0;
        }
        public static bool FindLoan(int LoanID, ref int Branch_ID,
            ref int Account_ID, ref decimal Remaining_Amount, ref decimal Issue_Amount)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_FindLoan", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LoanID", LoanID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isFound = true;
                                Branch_ID = (int)reader["Branch_ID"];
                                Account_ID = (int)reader["Account_ID"];
                                Remaining_Amount = (decimal)reader["Remaining_Amount"];
                                Issue_Amount = (decimal)reader["Issue_Amount"];
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsLoanData: FindLoan", e.Message);
            }
            return isFound;
        }
        public static bool IsExistsLoanByAccountID(int Account_ID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IsExistsLoanByAccountID", connection))
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
                clsEventLog error = clsEventLog.SetEvent("clsLoanData: IsExistsLoanByAccountID", e.Message);
            }
            return isFound;
        }
    }
}
