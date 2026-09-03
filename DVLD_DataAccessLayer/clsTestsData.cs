using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsTestsData
    {
        public static int AddNewTest(int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        string appointmentQuery = @"SELECT IsLocked
                                                    FROM TestAppointments WITH (UPDLOCK, HOLDLOCK)
                                                    WHERE TestAppointmentID = @TestAppointmentID";

                        using (SqlCommand cmd = new SqlCommand(appointmentQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

                            object isLocked = cmd.ExecuteScalar();

                            if (isLocked == null || Convert.ToBoolean(isLocked))
                            {
                                transaction.Rollback();
                                return -1;
                            }
                        }

                        string resultExistsQuery = @"SELECT TOP 1 1
                                                     FROM Tests WITH (UPDLOCK, HOLDLOCK)
                                                     WHERE TestAppointmentID = @TestAppointmentID";

                        using (SqlCommand cmd = new SqlCommand(resultExistsQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

                            if (cmd.ExecuteScalar() != null)
                            {
                                transaction.Rollback();
                                return -1;
                            }
                        }

                        string insertQuery = @"INSERT INTO Tests
                                               (
                                                   TestAppointmentID,
                                                   TestResult,
                                                   Notes,
                                                   CreatedByUserID
                                               )
                                               VALUES
                                               (
                                                   @TestAppointmentID,
                                                   @TestResult,
                                                   @Notes,
                                                   @CreatedByUserID
                                               );

                                               SELECT CAST(SCOPE_IDENTITY() AS int);";

                        int newTestID;

                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
                            cmd.Parameters.AddWithValue("@TestResult", testResult);
                            cmd.Parameters.AddWithValue("@Notes",
                                string.IsNullOrWhiteSpace(notes) ? (object)DBNull.Value : notes);
                            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                            object result = cmd.ExecuteScalar();
                            newTestID = result != null ? Convert.ToInt32(result) : -1;
                        }

                        if (newTestID <= 0)
                        {
                            transaction.Rollback();
                            return -1;
                        }

                        string lockAppointmentQuery = @"UPDATE TestAppointments
                                                        SET IsLocked = 1
                                                        WHERE TestAppointmentID = @TestAppointmentID
                                                          AND IsLocked = 0";

                        using (SqlCommand cmd = new SqlCommand(lockAppointmentQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

                            if (cmd.ExecuteNonQuery() != 1)
                            {
                                transaction.Rollback();
                                return -1;
                            }
                        }

                        transaction.Commit();
                        return newTestID;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static bool HasTestResult(int testAppointmentID)
        {
            string query = @"SELECT TOP 1 1
                             FROM Tests
                             WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
                    conn.Open();

                    return cmd.ExecuteScalar() != null;
                }
            }
        }

        public static DataTable GetTestByAppointmentID(int testAppointmentID)
        {
            DataTable dtTest = new DataTable();

            string query = @"SELECT
                                 TestID,
                                 TestAppointmentID,
                                 TestResult,
                                 Notes,
                                 CreatedByUserID
                             FROM Tests
                             WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dtTest);
                    }
                }
            }

            return dtTest;
        }

        public static bool? GetLastTestResult(int localApplicationID, int testTypeID)
        {
            string query = @"SELECT TOP 1 T.TestResult
                             FROM Tests T
                             INNER JOIN TestAppointments TA
                                 ON T.TestAppointmentID = TA.TestAppointmentID
                             WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                               AND TA.TestTypeID = @TestTypeID
                             ORDER BY T.TestID DESC";

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localApplicationID);
                    cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    conn.Open();

                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        return null;
                    }

                    return Convert.ToBoolean(result);
                }
            }
        }

        public static bool IsTestPassed(int localApplicationID, int testTypeID)
        {
            string query = @"SELECT TOP 1 1
                             FROM Tests T
                             INNER JOIN TestAppointments TA
                                 ON T.TestAppointmentID = TA.TestAppointmentID
                             WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                               AND TA.TestTypeID = @TestTypeID
                               AND T.TestResult = 1";

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localApplicationID);
                    cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    conn.Open();

                    return cmd.ExecuteScalar() != null;
                }
            }
        }

        public static int GetPassedTestsCount(int localApplicationID)
        {
            string query = @"SELECT COUNT(DISTINCT TA.TestTypeID)
                             FROM Tests T
                             INNER JOIN TestAppointments TA
                                 ON T.TestAppointmentID = TA.TestAppointmentID
                             WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                               AND T.TestResult = 1";

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localApplicationID);
                    conn.Open();

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }
    }
}
