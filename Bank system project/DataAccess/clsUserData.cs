using System;
using System.Data;
using System.Data.SqlClient;
using EventViewr;

namespace DataAccess
{
    public class clsUserData
    {
        public static bool FindUserByID(int UserID, ref int Person_ID,
            ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_FindUser", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isFound = true;
                                Person_ID = (int)reader["Person_ID"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("FindUserByID", e.Message);
            }
            return isFound;
        }
        public static int AddNewUser(int Person_ID, string UserName,
            string Password, bool IsActive)
        {
            int NewID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewUser", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Person_ID", Person_ID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        var GetID = new SqlParameter("@NewUserID", SqlDbType.Int)
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
                clsEventLog error = clsEventLog.SetEvent("AddNewUser", e.Message);
            }
            return NewID;
        }
        public static bool UpdateUser(int UserID, string UserName,
            string Password, bool IsActive)
        {
            int rowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateUser", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("UpdateUser", e.Message);
            }
            return rowAffected > 0;
        }
        public static bool DeleteUser(int UserID)
        {
            int rowAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteUser", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("DeleteUser", e.Message);
            }
            return rowAffected > 0;
        }
        public static DataTable GetAllUser()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AllUsers", connection))
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
                clsEventLog error = clsEventLog.SetEvent("GetAllUser", e.Message);
            }
            return dt;
        }
        public static bool IsExistsUser(int UserID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IsExistsUser", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);
                        var ResultQuery = new SqlParameter("", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        isFound = ((int)ResultQuery.Value == 1);
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("IsExistsUser", e.Message);
            }
            return isFound;
        }
        public static bool IsExistsUserByFPerson_ID(int Person_ID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IsExistsUserByFPerson_ID", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Person_ID", Person_ID);
                        var ResultQuery = new SqlParameter("", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(ResultQuery);
                        command.ExecuteNonQuery();
                        isFound = ((int)ResultQuery.Value == 1);
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("IsExistsUserByFPerson_ID", e.Message);
            }
            return isFound;
        }
        public static bool FindUserByUserNameAndPassword(string UserName, string Password,
            ref int UserID, ref int Person_ID, ref bool IsActive)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_FindUserByUserNameAndPassword", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isFound = true;
                                UserID = (int)reader["UserID"];
                                Person_ID = (int)reader["Person_ID"];
                                IsActive = (bool)reader["IsActive"];
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {

            }
            return isFound;
        }
    }
}
