using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseData
    {
        public enum enIssueFirstTimeLicenseDataResult
        {
            Success,
            ApplicationNotFound,
            ApplicationIsNotNew,
            LicenseAlreadyIssued,
            TestsNotPassed,
            DriverCreationFailed,
            LicenseCreationFailed,
            ApplicationCompletionFailed
        }

        private const byte NewApplicationStatus = 1;
        private const byte CompletedApplicationStatus = 3;
        private const byte FirstTimeIssueReason = 1;
        private const int RequiredPassedTestsCount = 3;

        private class clsFirstTimeLicenseIssueData
        {
            public int ApplicationID { get; set; }
            public int ApplicantPersonID { get; set; }
            public int LicenseClassID { get; set; }
            public byte ApplicationStatus { get; set; }
            public int ValidityLength { get; set; }
            public decimal ClassFees { get; set; }
        }

        public static bool IsLicenseExistByApplicationID(int applicationID)
        {
            const string query = @"
                SELECT TOP 1 1
                FROM Licenses
                WHERE ApplicationID = @ApplicationID";

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
                conn.Open();
                return cmd.ExecuteScalar() != null;
            }
        }

        public static enIssueFirstTimeLicenseDataResult IssueFirstTimeLicense(
            int localDrivingLicenseApplicationID, string notes, int createdByUserID,
            out int licenseID)
        {
            licenseID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        clsFirstTimeLicenseIssueData issueData;
                        if (!TryGetIssueData(localDrivingLicenseApplicationID,
                            conn, transaction, out issueData))
                        {
                            transaction.Rollback();
                            return enIssueFirstTimeLicenseDataResult.ApplicationNotFound;
                        }

                        if (issueData.ApplicationStatus != NewApplicationStatus)
                        {
                            transaction.Rollback();
                            return enIssueFirstTimeLicenseDataResult.ApplicationIsNotNew;
                        }

                        if (IsLicenseExistByApplicationID(issueData.ApplicationID,
                            conn, transaction))
                        {
                            transaction.Rollback();
                            return enIssueFirstTimeLicenseDataResult.LicenseAlreadyIssued;
                        }

                        if (GetPassedTestsCount(localDrivingLicenseApplicationID,
                            conn, transaction) != RequiredPassedTestsCount)
                        {
                            transaction.Rollback();
                            return enIssueFirstTimeLicenseDataResult.TestsNotPassed;
                        }

                        int driverID = GetOrCreateDriverID(issueData.ApplicantPersonID,
                            createdByUserID, conn, transaction);
                        if (driverID <= 0)
                        {
                            transaction.Rollback();
                            return enIssueFirstTimeLicenseDataResult.DriverCreationFailed;
                        }

                        licenseID = CreateLicense(issueData, driverID, notes,
                            createdByUserID, conn, transaction);
                        if (licenseID <= 0)
                        {
                            transaction.Rollback();
                            return enIssueFirstTimeLicenseDataResult.LicenseCreationFailed;
                        }

                        if (!CompleteApplication(issueData.ApplicationID, conn, transaction))
                        {
                            licenseID = -1;
                            transaction.Rollback();
                            return enIssueFirstTimeLicenseDataResult.ApplicationCompletionFailed;
                        }

                        transaction.Commit();
                        return enIssueFirstTimeLicenseDataResult.Success;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private static bool TryGetIssueData(int localDrivingLicenseApplicationID,
            SqlConnection conn, SqlTransaction transaction,
            out clsFirstTimeLicenseIssueData issueData)
        {
            issueData = null;

            const string query = @"
                SELECT
                    L.ApplicationID,
                    L.LicenseClassID,
                    A.ApplicantPersonID,
                    A.ApplicationStatus,
                    LC.DefaultValidityLength,
                    LC.ClassFees
                FROM LocalDrivingLicenseApplications L WITH (UPDLOCK, HOLDLOCK)
                INNER JOIN Applications A WITH (UPDLOCK, HOLDLOCK)
                    ON A.ApplicationID = L.ApplicationID
                INNER JOIN LicenseClasses LC
                    ON LC.LicenseClassID = L.LicenseClassID
                WHERE L.LocalDrivingLicenseApplicationID =
                      @LocalDrivingLicenseApplicationID";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value =
                    localDrivingLicenseApplicationID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return false;

                    issueData = new clsFirstTimeLicenseIssueData
                    {
                        ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                        ApplicantPersonID = Convert.ToInt32(reader["ApplicantPersonID"]),
                        LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]),
                        ApplicationStatus = Convert.ToByte(reader["ApplicationStatus"]),
                        ValidityLength = Convert.ToInt32(reader["DefaultValidityLength"]),
                        ClassFees = Convert.ToDecimal(reader["ClassFees"])
                    };

                    return true;
                }
            }
        }

        private static bool IsLicenseExistByApplicationID(int applicationID,
            SqlConnection conn, SqlTransaction transaction)
        {
            const string query = @"
                SELECT TOP 1 1
                FROM Licenses WITH (UPDLOCK, HOLDLOCK)
                WHERE ApplicationID = @ApplicationID";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
                return cmd.ExecuteScalar() != null;
            }
        }

        private static int GetPassedTestsCount(int localDrivingLicenseApplicationID,
            SqlConnection conn, SqlTransaction transaction)
        {
            const string query = @"
                SELECT COUNT(DISTINCT TA.TestTypeID)
                FROM TestAppointments TA WITH (HOLDLOCK)
                INNER JOIN Tests T WITH (HOLDLOCK)
                    ON T.TestAppointmentID = TA.TestAppointmentID
                WHERE TA.LocalDrivingLicenseApplicationID =
                      @LocalDrivingLicenseApplicationID
                  AND TA.TestTypeID IN (1, 2, 3)
                  AND T.TestResult = 1";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value =
                    localDrivingLicenseApplicationID;
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private static int GetOrCreateDriverID(int applicantPersonID, int createdByUserID,
            SqlConnection conn, SqlTransaction transaction)
        {
            const string findDriverQuery = @"
                SELECT TOP 1 DriverID
                FROM Drivers WITH (UPDLOCK, HOLDLOCK)
                WHERE PersonID = @PersonID";

            using (SqlCommand cmd = new SqlCommand(findDriverQuery, conn, transaction))
            {
                cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = applicantPersonID;
                object result = cmd.ExecuteScalar();
                if (result != null)
                    return Convert.ToInt32(result);
            }

            const string createDriverQuery = @"
                INSERT INTO Drivers
                    (PersonID, CreatedByUserID, CreatedDate)
                VALUES
                    (@PersonID, @CreatedByUserID, @CreatedDate);
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            using (SqlCommand cmd = new SqlCommand(createDriverQuery, conn, transaction))
            {
                cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = applicantPersonID;
                cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime).Value = DateTime.Now;
                object result = cmd.ExecuteScalar();
                return result == null ? -1 : Convert.ToInt32(result);
            }
        }

        private static int CreateLicense(clsFirstTimeLicenseIssueData issueData,
            int driverID, string notes, int createdByUserID,
            SqlConnection conn, SqlTransaction transaction)
        {
            const string query = @"
                INSERT INTO Licenses
                (
                    ApplicationID,
                    DriverID,
                    LicenseClass,
                    IssueDate,
                    ExpirationDate,
                    Notes,
                    PaidFees,
                    IsActive,
                    IssueReason,
                    CreatedByUserID
                )
                VALUES
                (
                    @ApplicationID,
                    @DriverID,
                    @LicenseClass,
                    @IssueDate,
                    @ExpirationDate,
                    @Notes,
                    @PaidFees,
                    1,
                    @IssueReason,
                    @CreatedByUserID
                );
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = issueDate.AddYears(issueData.ValidityLength);

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = issueData.ApplicationID;
                cmd.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;
                cmd.Parameters.Add("@LicenseClass", SqlDbType.Int).Value = issueData.LicenseClassID;
                cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = issueDate;
                cmd.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = expirationDate;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 1000).Value =
                    string.IsNullOrWhiteSpace(notes) ? (object)DBNull.Value : notes.Trim();
                cmd.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = issueData.ClassFees;
                cmd.Parameters.Add("@IssueReason", SqlDbType.TinyInt).Value = FirstTimeIssueReason;
                cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                object result = cmd.ExecuteScalar();
                return result == null ? -1 : Convert.ToInt32(result);
            }
        }

        private static bool CompleteApplication(int applicationID,
            SqlConnection conn, SqlTransaction transaction)
        {
            const string query = @"
                UPDATE Applications
                SET ApplicationStatus = @CompletedStatus,
                    LastStatusDate = @LastStatusDate
                WHERE ApplicationID = @ApplicationID
                  AND ApplicationStatus = @NewStatus";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@CompletedStatus", SqlDbType.TinyInt).Value =
                    CompletedApplicationStatus;
                cmd.Parameters.Add("@LastStatusDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
                cmd.Parameters.Add("@NewStatus", SqlDbType.TinyInt).Value = NewApplicationStatus;
                return cmd.ExecuteNonQuery() == 1;
            }
        }
    }
}
