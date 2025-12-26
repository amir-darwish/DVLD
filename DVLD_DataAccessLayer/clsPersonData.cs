using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsPersonData
    {
        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone, ref string Email,
            ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccsessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    // (Nullable)
                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];


                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    NationalityCountryID = (int)reader["NationalityCountryID"];


                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;

        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {

                string query = "SELECT Found=1 FROM People WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();


                        SqlDataReader reader = command.ExecuteReader();
                        isFound = reader.HasRows;

                        reader.Close();
                    }
                    catch (Exception ex)
                    {

                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        // by NationalNo
        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                string query = "SELECT Found=1 FROM People WHERE NationalNo = @NationalNo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        isFound = reader.HasRows;

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName,
            DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {

                string query = @"INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                            VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                            SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);


                    if (string.IsNullOrEmpty(ThirdName))
                        command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ThirdName", ThirdName);

                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);

                    if (string.IsNullOrEmpty(Email))
                        command.Parameters.AddWithValue("@Email", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Email", Email);

                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

                    if (string.IsNullOrEmpty(ImagePath))
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            PersonID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        PersonID = -1;
                    }
                }
            }

            return PersonID;
        }


        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName,
     string ThirdName, string LastName,
     DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email,
     int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {

                string query = @"UPDATE People 
                         SET NationalNo = @NationalNo,
                             FirstName = @FirstName, 
                             SecondName = @SecondName, 
                             ThirdName = @ThirdName, 
                             LastName = @LastName, 
                             DateOfBirth = @DateOfBirth, 
                             Gendor = @Gendor, 
                             Address = @Address, 
                             Phone = @Phone, 
                             Email = @Email, 
                             NationalityCountryID = @NationalityCountryID, 
                             ImagePath = @ImagePath
                         WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID); 
                    command.Parameters.AddWithValue("@NationalNo", NationalNo); 

                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);

                    if (string.IsNullOrEmpty(ThirdName))
                        command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ThirdName", ThirdName);

                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);

                    if (string.IsNullOrEmpty(Email))
                        command.Parameters.AddWithValue("@Email", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Email", Email);

                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

                    if (string.IsNullOrEmpty(ImagePath))
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Log error
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }
        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;
            using(SqlConnection connection = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                //connection.Open();
                string query = @"DELETE FROM People
                                WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        // log error
                        return false;
                    }
                }
                return (rowsAffected > 0);
            }
        }
    }


}
