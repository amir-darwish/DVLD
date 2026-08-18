using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DVLD_DataAccessLayer
{
    public class clsCountryData
    {
        public static DataTable GetAllCountries()
        {
            DataTable dtCountries = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT CountryID, CountryName FROM Countries";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtCountries.Load(reader);
                    }
                    reader.Close();
                }
            }
            return dtCountries;
        }
    }
}
