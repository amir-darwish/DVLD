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
    public class clsTestAppointmentsData
    {
        // Existing DVLD lookup value: ApplicationTypes.ApplicationTypeID = 7 (Retake Test).
        private const int RetakeTestApplicationTypeID = 7;

        public static DataTable GetAppointmentBookingInfo(int localApplicationID, int testTypeID)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                return GetAppointmentBookingInfo(localApplicationID, testTypeID, conn, null);
            }
        }

        private static DataTable GetAppointmentBookingInfo(int localApplicationID, int testTypeID,
            SqlConnection conn, SqlTransaction transaction)
        {
            string query = @"SELECT A.ApplicantPersonID, A.ApplicationStatus,
                                    TT.TestTypeFees AS TestFees,
                                    RT.ApplicationFees AS RetakeFees,
                                    (SELECT COUNT(*) FROM TestAppointments TA
                                     WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID
                                       AND TA.TestTypeID = TT.TestTypeID) AS PreviousAppointmentCount,
                                    CAST(CASE WHEN EXISTS (
                                        SELECT 1 FROM TestAppointments TA
                                        WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID
                                          AND TA.TestTypeID = TT.TestTypeID AND TA.IsLocked = 0
                                    ) THEN 1 ELSE 0 END AS bit) AS HasActiveAppointment,
                                    CAST(CASE WHEN EXISTS (
                                        SELECT 1 FROM TestAppointments TA
                                        INNER JOIN Tests T ON T.TestAppointmentID = TA.TestAppointmentID
                                        WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID
                                          AND TA.TestTypeID = TT.TestTypeID AND T.TestResult = 1
                                    ) THEN 1 ELSE 0 END AS bit) AS HasPassedTest,
                                    CAST(CASE WHEN EXISTS (
                                        SELECT 1 FROM TestAppointments TA
                                        WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID
                                          AND TA.TestTypeID = TT.TestTypeID AND TA.IsLocked = 1
                                          AND NOT EXISTS (SELECT 1 FROM Tests T
                                                          WHERE T.TestAppointmentID = TA.TestAppointmentID)
                                    ) THEN 1 ELSE 0 END AS bit) AS HasLockedAppointmentWithoutResult
                             FROM LocalDrivingLicenseApplications L
                             INNER JOIN Applications A ON A.ApplicationID = L.ApplicationID
                             INNER JOIN TestTypes TT ON TT.TestTypeID = @TestTypeID
                             LEFT JOIN ApplicationTypes RT ON RT.ApplicationTypeID = @RetakeApplicationTypeID
                             WHERE L.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localApplicationID);
                cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
                cmd.Parameters.AddWithValue("@RetakeApplicationTypeID", RetakeTestApplicationTypeID);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static DataTable GetTestAppointments(int localApplicationID, int testTypeID)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT
                            TA.TestAppointmentID,
                            TA.AppointmentDate,
                            TA.PaidFees,
                            TA.IsLocked                
                        FROM TestAppointments TA
                        WHERE TA.LocalDrivingLicenseApplicationID =
                              @LocalDrivingLicenseApplicationID
                        AND TA.TestTypeID = @TestTypeID
                        ORDER BY TA.AppointmentDate DESC";
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localApplicationID);
                    cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static bool IsThereAnActiveTestAppointment(int localApplicationID, int testTypeID)
        {
            string query = @"SELECT TOP 1 1 FROM TestAppointments
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                            AND TestTypeID = @TestTypeID
                            AND IsLocked = 0";
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localApplicationID);
                    cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    conn.Open();
                    object res = cmd.ExecuteScalar();
                    return res != null;
                }
            }
        }

        public static int AddNewTestAppointment(int localApplicationID, int testTypeID, DateTime appointmentDate, decimal paidFees, int createdByUserID )
        {
            return AddNewTestAppointment(localApplicationID, testTypeID, appointmentDate,
                paidFees, createdByUserID, 0, out int retakeTestApplicationID);
        }

        public static int AddNewTestAppointment(int localApplicationID, int testTypeID,
            DateTime appointmentDate, decimal paidFees, int createdByUserID,
            decimal expectedRetakeFees, out int retakeTestApplicationID)
        {
            retakeTestApplicationID = -1;
            if (localApplicationID <= 0 || testTypeID <= 0 || createdByUserID <= 0 ||
                appointmentDate.Date < DateTime.Today || paidFees < 0 || expectedRetakeFees < 0)
            {
                return -1;
            }

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        // Serialize bookings for this local application, including its first appointment.
                        string lockQuery = @"SELECT LocalDrivingLicenseApplicationID
                                             FROM LocalDrivingLicenseApplications WITH (UPDLOCK, HOLDLOCK)
                                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
                        using (SqlCommand cmd = new SqlCommand(lockQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localApplicationID);
                            if (cmd.ExecuteScalar() == null)
                            {
                                transaction.Rollback();
                                return -1;
                            }
                        }

                        using (DataTable dt = GetAppointmentBookingInfo(localApplicationID, testTypeID, conn, transaction))
                        {
                            if (dt.Rows.Count == 0)
                            {
                                transaction.Rollback();
                                return -1;
                            }

                            DataRow row = dt.Rows[0];
                            bool isRetake = Convert.ToInt32(row["PreviousAppointmentCount"]) > 0;
                            if (Convert.ToByte(row["ApplicationStatus"]) != 1 ||
                                Convert.ToBoolean(row["HasActiveAppointment"]) ||
                                Convert.ToBoolean(row["HasPassedTest"]) ||
                                Convert.ToBoolean(row["HasLockedAppointmentWithoutResult"]) ||
                                Convert.ToDecimal(row["TestFees"]) != paidFees ||
                                (isRetake && (row.IsNull("RetakeFees") ||
                                    Convert.ToDecimal(row["RetakeFees"]) != expectedRetakeFees)) ||
                                (!isRetake && expectedRetakeFees != 0))
                            {
                                transaction.Rollback();
                                return -1;
                            }

                            int newRetakeApplicationID = -1;
                            if (isRetake)
                            {
                                // Existing Retake requests use status 3 (Completed): the scheduling service is fulfilled.
                                string applicationQuery = @"INSERT INTO Applications
                                    (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus,
                                     LastStatusDate, PaidFees, CreatedByUserID)
                                    VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, 3,
                                            @ApplicationDate, @PaidFees, @CreatedByUserID);
                                    SELECT CAST(SCOPE_IDENTITY() AS int);";
                                using (SqlCommand cmd = new SqlCommand(applicationQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ApplicantPersonID", Convert.ToInt32(row["ApplicantPersonID"]));
                                    cmd.Parameters.AddWithValue("@ApplicationDate", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@ApplicationTypeID", RetakeTestApplicationTypeID);
                                    cmd.Parameters.AddWithValue("@PaidFees", expectedRetakeFees);
                                    cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                                    object result = cmd.ExecuteScalar();
                                    newRetakeApplicationID = result != null ? Convert.ToInt32(result) : -1;
                                }
                                if (newRetakeApplicationID <= 0)
                                {
                                    transaction.Rollback();
                                    return -1;
                                }
                            }

                            string query = @"INSERT INTO TestAppointments
                                (LocalDrivingLicenseApplicationID, TestTypeID, AppointmentDate,
                                 PaidFees, IsLocked, CreatedByUserID, RetakeTestApplicationID)
                                VALUES (@LocalDrivingLicenseApplicationID, @TestTypeID, @AppointmentDate,
                                        @PaidFees, 0, @CreatedByUserID, @RetakeTestApplicationID);
                                SELECT CAST(SCOPE_IDENTITY() AS int);";
                            int newAppointmentID;
                            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localApplicationID);
                                cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
                                cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                                cmd.Parameters.AddWithValue("@PaidFees", paidFees);
                                cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                                cmd.Parameters.AddWithValue("@RetakeTestApplicationID",
                                    isRetake ? (object)newRetakeApplicationID : DBNull.Value);
                                object result = cmd.ExecuteScalar();
                                newAppointmentID = result != null ? Convert.ToInt32(result) : -1;
                            }
                            if (newAppointmentID <= 0)
                            {
                                transaction.Rollback();
                                return -1;
                            }

                            transaction.Commit();
                            retakeTestApplicationID = newRetakeApplicationID;
                            return newAppointmentID;
                        }
                    }
                    catch
                    {
                        if (transaction.Connection != null)
                        {
                            transaction.Rollback();
                        }
                        throw;
                    }
                }
            }
        }

        public static bool LockTestAppointment(int testAppointmentID)
        {
            string query = @"UPDATE TestAppointments
                            SET IsLocked = 1
                            WHERE TestAppointmentID = @TestAppointmentID";
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static DataTable GetTestAppointmentByID(int testAppointmentID)
        {
            string query = @"SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

   }


}
