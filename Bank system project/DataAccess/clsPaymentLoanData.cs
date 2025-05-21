using System;
using System.Data;
using System.Data.SqlClient;
using EventViewr;

namespace DataAccess
{
    public class clsPaymentLoanData
    {
        public static int AddNewPaymentLoan(decimal Amount, int Loan_ID)
        {
            int NewID = -1;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AddNewPaymentLoan", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@Loan_ID", Loan_ID);
                        var GetID = new SqlParameter("@PaymentID", SqlDbType.Int)
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
                clsEventLog error = clsEventLog.SetEvent("clsPaymentLoanData: AddNewPaymentLoan", e.Message);
            }
            return NewID;
        }
        public static DataTable GetAllPaymentLoan()
        {
            DataTable dt = new DataTable();
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AllPaymentLoan", connection))
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
                clsEventLog error = clsEventLog.SetEvent("clsPaymentLoanData: GetAllPaymentLoan", e.Message);
            }
            return dt;
        }
        public static bool IsExistsPaymentLoan(int PaymentID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_IsExistsPaymentLoan", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
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
                clsEventLog error = clsEventLog.SetEvent("clsPaymentLoanData: IsExistsPaymentLoan", e.Message);
            }
            return isFound;
        }
        public static bool UpdatePaymentLoan(int PaymentID, decimal Amount)
        {
            int rowAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdatePaymentLoan", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsPaymentLoanData: UpdatePaymentLoan", e.Message);
            }
            return rowAffected > 0;
        }
        public static bool FindPaymentLoan(int PaymentID,
            ref decimal Amount, ref int Loan_ID)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_FindPaymentLoan", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isFound = true;
                                Amount = (decimal)reader["Amount"];
                                Loan_ID = (int)reader["Loan_ID"];
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsPaymentLoanData: FindPaymentLoan", e.Message);
            }
            return isFound;
        }
        public static bool IsExistsPaymentLoanByLoanID(int Loan_ID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IsExistsPaymentLoanByLoanID", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Loan_ID", Loan_ID);
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
                clsEventLog error = clsEventLog.SetEvent("clsPaymentLoanData: IsExistsPaymentLoanByLoanID", e.Message);
            }
            return isFound;
        }

    }
}
