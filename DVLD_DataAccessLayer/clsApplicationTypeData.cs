using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DVLD_DataAccessLayer
{
    public class clsApplicationTypeData
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dtApplicationTypes = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM ApplicationTypes";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtApplicationTypes.Load(reader);
                    }
                    reader.Close();
                }
            }
            return dtApplicationTypes;
        }

        public static bool EditeApplicationType(int applicationTypeID, string applicationTypeName, decimal fee)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = "UPDATE ApplicationTypes SET ApplicationTypeTitle = @ApplicationTypeName, ApplicationFees = @Fee WHERE ApplicationTypeID = @ApplicationTypeID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
                    cmd.Parameters.AddWithValue("@ApplicationTypeName", applicationTypeName);
                    cmd.Parameters.AddWithValue("@Fee", fee);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static decimal? GetApplicationFees(int applicationTypeID)
        {
            decimal? result = null;

            using(SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT ApplicationFees FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
                    object value = cmd.ExecuteScalar();
                    if (value != null && value != DBNull.Value)
                    {
                        result = Convert.ToDecimal(value);
                    }
                }
            }
            return result;
        }

    }
}
