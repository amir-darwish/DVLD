using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsLocalDrivingLicenceAppData
    {
        public static DataTable GetAllLocalDrivingLicenceApplicationsFromView()
        {
            DataTable dtLocalDrivingLicenceApplications = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM LocalDrivingLicenseApplications_View";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtLocalDrivingLicenceApplications.Load(reader);
                    }
                    reader.Close();
                }
            }
            return dtLocalDrivingLicenceApplications;
        }
    }
}
