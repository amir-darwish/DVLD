using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTestTypeData
    {
        public static DataTable GetaAllTestTypes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM TestTypes";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }
        public static bool EditeTestType(int testTypeID, string testTypeName,string testTypeDescription, decimal fee)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = "UPDATE TestTypes SET TestTypeTitle = @TestTypeName, TestTypeDescription = @TestTypeDescription, TestTypeFees = @Fee WHERE TestTypeID = @TestTypeID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    cmd.Parameters.AddWithValue("@TestTypeName", testTypeName);
                    cmd.Parameters.AddWithValue("@TestTypeDescription", testTypeDescription);
                    cmd.Parameters.AddWithValue("@Fee", fee);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

    }
}


 
