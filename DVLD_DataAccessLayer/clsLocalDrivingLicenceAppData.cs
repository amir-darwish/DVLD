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

        public static DataTable GetLocalDrivingLicenseApplicationInfo(int localApplicationID)
        {
            DataTable dtLocalDrivingLicenceApplication = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();

                string query = @"
                    SELECT
                        L.LocalDrivingLicenseApplicationID,
                        L.ApplicationID,
                        L.LicenseClassID,
                        LC.ClassName,
                        A.ApplicationDate,
                        A.ApplicationStatus,
                        A.LastStatusDate,
                        A.PaidFees,
                        A.ApplicationTypeID,
                        AT.ApplicationTypeTitle,
                        A.ApplicantPersonID,
                        CONCAT(
                            P.FirstName, ' ', P.SecondName, ' ',
                            ISNULL(P.ThirdName, ''), ' ', P.LastName
                        ) AS ApplicantName,
                        A.CreatedByUserID,
                        U.UserName AS CreatedBy
                    FROM LocalDrivingLicenseApplications L
                    INNER JOIN Applications A
                        ON L.ApplicationID = A.ApplicationID
                    INNER JOIN LicenseClasses LC
                        ON L.LicenseClassID = LC.LicenseClassID
                    INNER JOIN ApplicationTypes AT
                        ON A.ApplicationTypeID = AT.ApplicationTypeID
                    INNER JOIN People P
                        ON A.ApplicantPersonID = P.PersonID
                    LEFT JOIN Users U
                        ON A.CreatedByUserID = U.UserID
                    WHERE L.LocalDrivingLicenseApplicationID = @LocalApplicationID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LocalApplicationID", localApplicationID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dtLocalDrivingLicenceApplication);
                    }
                }
            }

            return dtLocalDrivingLicenceApplication;
        }

        public static int CreateLocalDrivingLicenceApplication(int applicationId, int licenceClassId)
        {
            string query = @"
                INSERT INTO dbo.LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                VALUES (@ApplicationID, @LicenseClassID);
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", applicationId);
                    cmd.Parameters.AddWithValue("@LicenseClassID", licenceClassId);
                    conn.Open();

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        public static bool IsThereAnActiveApplication(int applicantId, int licenseClassId) {

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                string query = @"
                      SELECT 1 FROM LocalDrivingLicenseApplications L 
                        INNER JOIN Applications A ON L.ApplicationID = A.ApplicationID
                        WHERE A.ApplicantPersonID = @ApplicantPersonID AND L.LicenseClassID = @LicenseClassID AND A.ApplicationStatus = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicantPersonID", applicantId);
                    cmd.Parameters.AddWithValue("@LicenseClassID", licenseClassId);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null;
                }
            }

        }
    }
}
