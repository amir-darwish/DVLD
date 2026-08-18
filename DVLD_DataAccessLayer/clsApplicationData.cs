using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DVLD_DataAccessLayer
{
    public class clsApplicationData
    {
        public static int CreateApplication(int applicantPersonID, int applicationTypeID, decimal paidFees, int createdByUserID)
        {
            DateTime applicationDate = DateTime.Now;
            DateTime lastStatusDate = DateTime.Now;
            byte applicationStatus = 1; // Assuming 1 represents the initial status of the application

            string query = @"
                INSERT INTO dbo.Applications
                (
                    ApplicantPersonID,
                    ApplicationTypeID,
                    PaidFees,
                    ApplicationDate,
                    LastStatusDate,
                    CreatedByUserID,
                    ApplicationStatus
                )
                VALUES
                (
                    @ApplicantPersonID,
                    @ApplicationTypeID,
                    @PaidFees,
                    @ApplicationDate,
                    @LastStatusDate,
                    @CreatedByUserID,
                    @ApplicationStatus
                );

                SELECT CAST(SCOPE_IDENTITY() AS int);"; 

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicantPersonID", applicantPersonID);
                    cmd.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
                    cmd.Parameters.AddWithValue("@PaidFees", paidFees);
                    cmd.Parameters.AddWithValue("@ApplicationDate", applicationDate);
                    cmd.Parameters.AddWithValue("@LastStatusDate", lastStatusDate);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                    cmd.Parameters.AddWithValue("@ApplicationStatus", applicationStatus);
                    conn.Open();
                    
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1; // Return the new ApplicationID or -1 if failed
                }
            }
        }

        
    }
}
