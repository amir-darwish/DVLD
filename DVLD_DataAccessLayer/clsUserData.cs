using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password AND isActive = 1";
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
    }
}
