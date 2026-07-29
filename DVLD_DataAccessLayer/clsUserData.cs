using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DVLD_DataAccessLayer
{
    public class clsUserData
    {
        public clsUserData() { }

        public static bool ValidateUser(string username, string password,
        ref int userID,
        ref int personID,
        ref string userName,
        ref bool isActive)
        {
            // Return the PersonID if the user is valid and active, otherwise return -1
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT UserID, PersonID, UserName, IsActive FROM Users" +
                    " WHERE Username = @Username AND Password = @Password AND isActive = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userID = (int)reader["UserID"];
                            personID = (int)reader["PersonID"];
                            userName = (string)reader["UserName"];
                            isActive = (bool)reader["IsActive"];
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool CreateUser(int PersonID, string username, string password)
        {
            // Create a new user in the database
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Users (PersonID, Username, Password, isActive) VALUES (@PersonID, @Username, @Password, 1)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static void FindByPersonID(int personID, ref int userID, ref string userName, ref bool isActive)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT UserID, UserName, IsActive FROM Users WHERE PersonID = @PersonID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PersonID", personID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userID = (int)reader["UserID"];
                            userName = (string)reader["UserName"];
                            isActive = (bool)reader["IsActive"];
                        }
                    }
                }
            }

        }

        public static bool ChangePassword(int userID, string oldPassword, string newPassword)
        {
            string query = "UPDATE Users SET Password = @NewPassword WHERE UserID = @UserID AND Password = @OldPassword";
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@OldPassword", oldPassword);
                    cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static DataTable GetAllUsers()
        {
            DataTable dtUsers = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = @"
                                SELECT 
                                    Users.UserID,
                                    Users.PersonID,
                                    CONCAT(People.FirstName, ' ', People.SecondName, ' ', ISNULL(People.ThirdName, ''), ' ', People.LastName) AS FullName,
                                    Users.UserName,
                                    Users.IsActive
                                FROM Users
                                INNER JOIN People ON Users.PersonID = People.PersonID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dtUsers);
                    }
                }
            }
            return dtUsers;
        }

        public static bool DeleteUser(int userID)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static bool DeactivateUser(int userID)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET IsActive = 0 WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public static bool ActivateUser(int userID)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET IsActive = 1 WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static bool UpdateUser(int userID, string username, bool isActive, string password = null) 
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                string query = @"
                    UPDATE Users
                    SET 
                        UserName = @Username,
                        IsActive = @IsActive";

                if (!string.IsNullOrWhiteSpace(password))
                {
                    query += ", Password = @Password";
                }

                query += " WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        cmd.Parameters.AddWithValue("@Password", password);
                    }

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }

}
