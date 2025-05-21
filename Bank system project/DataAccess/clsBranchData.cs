using System;
using System.Data;
using System.Data.SqlClient;
using EventViewr;

namespace DataAccess
{
    public class clsBranchData
    {
        public static DataTable GetAllBranch()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AllBranch", connection))
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
                clsEventLog error = clsEventLog.SetEvent("clsBranchData: GetAllBranch", e.Message);
            }
            return dt;
        }
        public static int AddNewBranch(string BranchName, 
            string BranchAddress, decimal Assets)
        {
            int NewID = 0;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_AddNewBranch", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BranchName", BranchName);
                        command.Parameters.AddWithValue("@BranchAddress", BranchAddress);
                        command.Parameters.AddWithValue("@Assets", Assets);
                        var GetID = new SqlParameter("@NewBranchID", SqlDbType.Int)
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
                clsEventLog error = clsEventLog.SetEvent("clsBranchData: AddNewBranch", e.Message);
            }
            return NewID;
        }
        public static bool DeleteBranch(int BranchID)
        {
            int rowAffected = 0;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_DeleteBranch", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BranchID", BranchID);
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsBranchData: DeleteBranch", e.Message);
            }
            return rowAffected > 0;
        }
        public static bool IsExistsBranch(int BranchID)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_IsExistsBranch", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BranchID", BranchID);
                        var ReturnValue = new SqlParameter("", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.ExecuteNonQuery();
                        isFound = (int)ReturnValue.Value == 1;
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsBranchData: IsExistsBranch", e.Message);
            }
            return isFound;
        }
        public static bool UpdateBranch(int BranchID, string BranchName,
            string BranchAddress, decimal Assets)
        {
            int rowAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateBranch", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BranchName", BranchName);
                        command.Parameters.AddWithValue("@BranchAddress", BranchAddress);
                        command.Parameters.AddWithValue("@Assets", Assets);
                        command.Parameters.AddWithValue("@BranchID", BranchID);
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsBranchData: UpdateBranch", e.Message);
            }
            return rowAffected > 0;
        }
        public static bool FindBranch(int BranchID, ref string BranchName,
                            ref string BranchAddress, ref decimal Assets)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("SP_FindBranch", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BranchID", BranchID);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                isFound = true;
                                BranchName = (string)reader["BranchName"];
                                BranchAddress = (string)reader["BranchAddress"];
                                Assets = (decimal)reader["Assets"];
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsBranchData", e.Message);
            }
            return isFound;
        }
        public static bool FindBranchByName(string BranchName, ref int BranchID,
                            ref string BranchAddress, ref decimal Assets)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FindBranchByName", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BranchName", BranchName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                BranchID = (int)reader["BranchID"];
                                BranchAddress = (string)reader["BranchAddress"];
                                Assets = (decimal)reader["Assets"];
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                clsEventLog error = clsEventLog.SetEvent("clsBranchData: FindBranchByName", e.Message);
            }
            return isFound;
        }
    }
}
