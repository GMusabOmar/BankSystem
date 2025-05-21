using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using EventViewr;

namespace DataAccess
{
    public class clsCustomerData
    {
        public static bool FindCustomerByID(int CustomerID, ref int PersonID,
            ref string FirstName, ref string SecondName, ref string ThirdName,
            ref string LastName, ref string Email, ref string Address,
            ref string Phone, ref int AccountID, ref int CreditCardID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FindCustomerByID", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                PersonID = (int)reader["PersonID"];
                                FirstName = (string)reader["FirstName"];
                                SecondName = (string)reader["SecondName"];
                                ThirdName = (string)reader["ThirdName"];
                                LastName = (string)reader["LastName"];
                                Email = (string)reader["Email"];
                                Address = (string)reader["Address"];
                                Phone = (string)reader["Phone"];
                                if (reader["AccountID"] == DBNull.Value)
                                    AccountID = 0;
                                else
                                    AccountID = (int)reader["AccountID"];
                                if (reader["CreditCardID"] == DBNull.Value)
                                    CreditCardID = 0;
                                else
                                    CreditCardID = (int)reader["CreditCardID"];
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("FindCustomerByID", e.Message);
            }
            return isFound;
        }
        public static bool FindCustomerByPersonID(int PersonID, ref int CustomerID,
            ref string FirstName, ref string SecondName, ref string ThirdName,
            ref string LastName, ref string Email, ref string Address,
            ref string Phone, ref int AccountID, ref int CreditCardID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FindCustomerByPersonID", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Person_ID", PersonID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                CustomerID = (int)reader["CustomerID"];
                                FirstName = (string)reader["FirstName"];
                                SecondName = (string)reader["SecondName"];
                                ThirdName = (string)reader["ThirdName"];
                                LastName = (string)reader["LastName"];
                                Email = (string)reader["Email"];
                                Address = (string)reader["Address"];
                                Phone = (string)reader["Phone"];
                                if (reader["AccountID"] == DBNull.Value)
                                    AccountID = 0;
                                else
                                    AccountID = (int)reader["AccountID"];
                                if (reader["CreditCardID"] == DBNull.Value)
                                    CreditCardID = 0;
                                else
                                    CreditCardID = (int)reader["CreditCardID"];
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("SP_FindCustomerByPersonID", e.Message);
            }
            return isFound;
        }
        public static bool FindCustomerByName(string FirstName, string SecondName, 
            string ThirdName, string LastName, ref int PersonID, ref int CustomerID,
            ref string Email, ref string Address, ref string Phone, 
            ref int AccountID, ref int CreditCardID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FindCustomerByName", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@SecondName", SecondName);
                        command.Parameters.AddWithValue("@ThirdName", ThirdName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                CustomerID = (int)reader["CustomerID"];
                                PersonID = (int)reader["PersonID"];
                                Email = (string)reader["Email"];
                                Address = (string)reader["Address"];
                                Phone = (string)reader["Phone"];
                                if (reader["AccountID"] == DBNull.Value)
                                    AccountID = 0;
                                else
                                    AccountID = (int)reader["AccountID"];
                                if (reader["CreditCardID"] == DBNull.Value)
                                    CreditCardID = 0;
                                else
                                    CreditCardID = (int)reader["CreditCardID"];
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("FindCustomerByName", e.Message);
            }
            return isFound;
        }
        public static DataTable GetAllCustomer()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AllCustomers", connection))
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
                clsEventLog error = clsEventLog.SetEvent("GetAllCustomer", e.Message);
            }
            return dt;
        }
        public static int AddNewCustomer(int PersonID)
        {
            int newID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewCustomers", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Person_ID", PersonID);
                        var Result = new SqlParameter("@NewCustomerID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(Result);
                        command.ExecuteNonQuery();
                        newID = (int)Result.Value;
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("AddNewCustomer", e.Message);
            }
            return newID;
        }
        public static bool DeleteCustomer(int CustomerID)
        {
            int rowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteCustomer", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("DeleteCustomer", e.Message);
            }
            return rowAffected > 0;
        }
        public static bool IsExistsCustomerByFPerson_ID(int Person_ID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IsExistsCustomerByPersonID", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Person_ID", Person_ID);
                        var Result = new SqlParameter("", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(Result);
                        command.ExecuteNonQuery();
                        isFound = (int)Result.Value == 1;
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("SP_IsExistsCustomerByPersonID", e.Message);
            }
            return isFound;
        }
        public static bool IsExistsCustomerByID(int CustomerID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IsExistsCustomerByID", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        var Result = new SqlParameter("", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(Result);
                        command.ExecuteNonQuery();
                        isFound = (int)Result.Value == 1;
                    }
                }
            }
            catch (Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("IsExistsCustomerByID", e.Message);
            }
            return isFound;
        }
    }
}
