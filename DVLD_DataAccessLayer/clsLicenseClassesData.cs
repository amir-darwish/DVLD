using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseClassesData
    {
        public static DataTable GetAllLicenseClasses()
        {
            DataTable licenseClasses = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM LicenseClasses";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                licenseClasses.Load(reader);
            }

            return licenseClasses;
        }
    }
}
