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

        public enum enRenewLicenseDataResult
        {
            Success,
            InvalidUser,
            LicenseNotFound,
            LicenseInactive,
            LicenseDetained,
            LicenseNotExpired,
            ApplicationTypeNotFound,
            ApplicationCreationFailed,
            LicenseCreationFailed,
            OldLicenseDeactivationFailed,
            ApplicationCompletionFailed
        }

        public enum enReplaceLicenseDataResult
        {
            Success,
            InvalidUser,
            InvalidReplacementType,
            LicenseNotFound,
            LicenseInactive,
            LicenseDetained,
            LicenseExpired,
            ApplicationTypeNotFound,
            ApplicationCreationFailed,
            LicenseCreationFailed,
            OldLicenseDeactivationFailed,
            ApplicationCompletionFailed
        }

        private const byte NewApplicationStatus = 1;
        private const byte CompletedApplicationStatus = 3;
        private const byte FirstTimeIssueReason = 1;
        private const byte RenewIssueReason = 2;
        private const byte DamagedIssueReason = 3;
        private const byte LostIssueReason = 4;
        private const int RenewApplicationTypeID = 2;
        private const int LostReplacementApplicationTypeID = 3;
        private const int DamagedReplacementApplicationTypeID = 4;
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

        private class clsRenewLicenseData
        {
            public int DriverID { get; set; }
            public int PersonID { get; set; }
            public int LicenseClassID { get; set; }
            public DateTime ExpirationDate { get; set; }
            public bool IsActive { get; set; }
            public bool IsDetained { get; set; }
            public int ValidityLength { get; set; }
            public decimal ClassFees { get; set; }
        }

        private class clsReplacementLicenseData
        {
            public int DriverID { get; set; }
            public int PersonID { get; set; }
            public int LicenseClassID { get; set; }
            public DateTime ExpirationDate { get; set; }
            public bool IsActive { get; set; }
            public bool IsDetained { get; set; }
            public string Notes { get; set; }
        }

        public static DataTable GetDriverLicenseInfo(int licenseID)
        {
            DataTable licenseInfo = new DataTable();

            const string query = @"
                SELECT
                    L.LicenseID,
                    L.ApplicationID,
                    L.DriverID,
                    L.LicenseClass,
                    LC.ClassName,
                    L.IssueDate,
                    L.ExpirationDate,
                    L.Notes,
                    L.PaidFees,
                    L.IsActive,
                    L.IssueReason,
                    D.PersonID,
                    P.NationalNo,
                    CONCAT(
                        P.FirstName, ' ', P.SecondName, ' ',
                        ISNULL(P.ThirdName, ''), ' ', P.LastName
                    ) AS ApplicantName,
                    P.DateOfBirth,
                    P.Gendor AS Gender,
                    P.ImagePath,
                    CASE WHEN EXISTS
                    (
                        SELECT 1
                        FROM DetainedLicenses DL
                        WHERE DL.LicenseID = L.LicenseID
                          AND DL.IsReleased = 0
                    ) THEN 1 ELSE 0 END AS IsDetained,
                    LC.ClassFees,
                    LC.DefaultValidityLength
                FROM Licenses L
                INNER JOIN Drivers D
                    ON D.DriverID = L.DriverID
                INNER JOIN People P
                    ON P.PersonID = D.PersonID
                INNER JOIN LicenseClasses LC
                    ON LC.LicenseClassID = L.LicenseClass
                WHERE L.LicenseID = @LicenseID";

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@LicenseID", SqlDbType.Int).Value = licenseID;
                adapter.Fill(licenseInfo);
            }

            return licenseInfo;
        }

        public static int GetLicenseIDByApplicationID(int applicationID)
        {
            const string query = @"
                SELECT TOP 1 LicenseID
                FROM Licenses
                WHERE ApplicationID = @ApplicationID
                ORDER BY LicenseID DESC";

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
                conn.Open();

                object result = cmd.ExecuteScalar();
                return result == null ? -1 : Convert.ToInt32(result);
            }
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

        public static DataTable GetRenewedLicenseInfo(int renewedLicenseID)
        {
            DataTable renewalInfo = new DataTable();

            const string query = @"
                SELECT
                    A.ApplicationID,
                    L.LicenseID AS RenewedLicenseID,
                    A.ApplicationDate,
                    L.IssueDate,
                    L.ExpirationDate,
                    A.PaidFees AS ApplicationFees,
                    L.PaidFees AS LicenseFees,
                    U.UserName AS CreatedBy
                FROM Licenses L
                INNER JOIN Applications A
                    ON A.ApplicationID = L.ApplicationID
                INNER JOIN Users U
                    ON U.UserID = A.CreatedByUserID
                WHERE L.LicenseID = @RenewedLicenseID
                  AND A.ApplicationTypeID = @RenewApplicationTypeID";

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@RenewedLicenseID", SqlDbType.Int).Value = renewedLicenseID;
                cmd.Parameters.Add("@RenewApplicationTypeID", SqlDbType.Int).Value =
                    RenewApplicationTypeID;
                adapter.Fill(renewalInfo);
            }

            return renewalInfo;
        }

        public static DataTable GetReplacedLicenseInfo(int replacedLicenseID)
        {
            DataTable replacementInfo = new DataTable();

            const string query = @"
                SELECT
                    A.ApplicationID,
                    L.LicenseID AS ReplacedLicenseID,
                    A.ApplicationDate,
                    A.PaidFees AS ApplicationFees,
                    A.ApplicationTypeID,
                    U.UserName AS CreatedBy
                FROM Licenses L
                INNER JOIN Applications A
                    ON A.ApplicationID = L.ApplicationID
                INNER JOIN Users U
                    ON U.UserID = A.CreatedByUserID
                WHERE L.LicenseID = @ReplacedLicenseID
                  AND A.ApplicationTypeID IN
                      (@LostApplicationTypeID, @DamagedApplicationTypeID)";

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@ReplacedLicenseID", SqlDbType.Int).Value =
                    replacedLicenseID;
                cmd.Parameters.Add("@LostApplicationTypeID", SqlDbType.Int).Value =
                    LostReplacementApplicationTypeID;
                cmd.Parameters.Add("@DamagedApplicationTypeID", SqlDbType.Int).Value =
                    DamagedReplacementApplicationTypeID;
                adapter.Fill(replacementInfo);
            }

            return replacementInfo;
        }

        public static enReplaceLicenseDataResult ReplaceLicense(
            int oldLicenseID, int applicationTypeID, byte issueReason,
            int createdByUserID, out int replacementApplicationID,
            out int replacedLicenseID)
        {
            replacementApplicationID = -1;
            replacedLicenseID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        if (!IsValidReplacementMapping(applicationTypeID, issueReason))
                        {
                            transaction.Rollback();
                            return enReplaceLicenseDataResult.InvalidReplacementType;
                        }

                        if (!IsActiveUser(createdByUserID, conn, transaction))
                        {
                            transaction.Rollback();
                            return enReplaceLicenseDataResult.InvalidUser;
                        }

                        clsReplacementLicenseData licenseData;
                        if (!TryGetReplacementLicenseData(oldLicenseID, conn, transaction,
                            out licenseData))
                        {
                            transaction.Rollback();
                            return enReplaceLicenseDataResult.LicenseNotFound;
                        }

                        if (!licenseData.IsActive)
                        {
                            transaction.Rollback();
                            return enReplaceLicenseDataResult.LicenseInactive;
                        }

                        if (licenseData.IsDetained)
                        {
                            transaction.Rollback();
                            return enReplaceLicenseDataResult.LicenseDetained;
                        }

                        DateTime operationDate = DateTime.Now;
                        if (licenseData.ExpirationDate.Date <= operationDate.Date)
                        {
                            transaction.Rollback();
                            return enReplaceLicenseDataResult.LicenseExpired;
                        }

                        decimal applicationFees;
                        if (!TryGetApplicationFees(applicationTypeID, conn, transaction,
                            out applicationFees))
                        {
                            transaction.Rollback();
                            return enReplaceLicenseDataResult.ApplicationTypeNotFound;
                        }

                        replacementApplicationID = CreateReplacementApplication(
                            licenseData.PersonID, applicationTypeID, applicationFees,
                            createdByUserID, operationDate, conn, transaction);
                        if (replacementApplicationID <= 0)
                        {
                            transaction.Rollback();
                            return enReplaceLicenseDataResult.ApplicationCreationFailed;
                        }

                        replacedLicenseID = CreateReplacementLicense(
                            replacementApplicationID, licenseData, issueReason,
                            createdByUserID, operationDate, conn, transaction);
                        if (replacedLicenseID <= 0)
                        {
                            replacementApplicationID = -1;
                            transaction.Rollback();
                            return enReplaceLicenseDataResult.LicenseCreationFailed;
                        }

                        if (!DeactivateOldLicense(oldLicenseID, conn, transaction))
                        {
                            replacementApplicationID = -1;
                            replacedLicenseID = -1;
                            transaction.Rollback();
                            return enReplaceLicenseDataResult.OldLicenseDeactivationFailed;
                        }

                        if (!CompleteApplication(replacementApplicationID, conn, transaction))
                        {
                            replacementApplicationID = -1;
                            replacedLicenseID = -1;
                            transaction.Rollback();
                            return enReplaceLicenseDataResult.ApplicationCompletionFailed;
                        }

                        transaction.Commit();
                        return enReplaceLicenseDataResult.Success;
                    }
                    catch
                    {
                        replacementApplicationID = -1;
                        replacedLicenseID = -1;
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private static bool IsValidReplacementMapping(int applicationTypeID,
            byte issueReason)
        {
            return applicationTypeID == LostReplacementApplicationTypeID &&
                   issueReason == LostIssueReason ||
                   applicationTypeID == DamagedReplacementApplicationTypeID &&
                   issueReason == DamagedIssueReason;
        }

        private static bool TryGetReplacementLicenseData(int oldLicenseID,
            SqlConnection conn, SqlTransaction transaction,
            out clsReplacementLicenseData licenseData)
        {
            licenseData = null;

            const string query = @"
                SELECT
                    L.DriverID,
                    D.PersonID,
                    L.LicenseClass,
                    L.ExpirationDate,
                    L.IsActive,
                    L.Notes,
                    CASE WHEN EXISTS
                    (
                        SELECT 1
                        FROM DetainedLicenses DL WITH (UPDLOCK, HOLDLOCK)
                        WHERE DL.LicenseID = L.LicenseID
                          AND DL.IsReleased = 0
                    ) THEN 1 ELSE 0 END AS IsDetained
                FROM Licenses L WITH (UPDLOCK, HOLDLOCK)
                INNER JOIN Drivers D
                    ON D.DriverID = L.DriverID
                WHERE L.LicenseID = @OldLicenseID";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@OldLicenseID", SqlDbType.Int).Value = oldLicenseID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return false;

                    licenseData = new clsReplacementLicenseData
                    {
                        DriverID = Convert.ToInt32(reader["DriverID"]),
                        PersonID = Convert.ToInt32(reader["PersonID"]),
                        LicenseClassID = Convert.ToInt32(reader["LicenseClass"]),
                        ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        IsDetained = Convert.ToBoolean(reader["IsDetained"]),
                        Notes = reader["Notes"] == DBNull.Value
                            ? null
                            : reader["Notes"].ToString()
                    };

                    return true;
                }
            }
        }

        private static int CreateReplacementApplication(int personID,
            int applicationTypeID, decimal applicationFees, int createdByUserID,
            DateTime operationDate, SqlConnection conn, SqlTransaction transaction)
        {
            const string query = @"
                INSERT INTO Applications
                (
                    ApplicantPersonID,
                    ApplicationDate,
                    ApplicationTypeID,
                    ApplicationStatus,
                    LastStatusDate,
                    PaidFees,
                    CreatedByUserID
                )
                VALUES
                (
                    @ApplicantPersonID,
                    @ApplicationDate,
                    @ApplicationTypeID,
                    @ApplicationStatus,
                    @LastStatusDate,
                    @PaidFees,
                    @CreatedByUserID
                );
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = personID;
                cmd.Parameters.Add("@ApplicationDate", SqlDbType.DateTime).Value = operationDate;
                cmd.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value =
                    applicationTypeID;
                cmd.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value =
                    NewApplicationStatus;
                cmd.Parameters.Add("@LastStatusDate", SqlDbType.DateTime).Value = operationDate;
                cmd.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = applicationFees;
                cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                object result = cmd.ExecuteScalar();
                return result == null ? -1 : Convert.ToInt32(result);
            }
        }

        private static int CreateReplacementLicense(int replacementApplicationID,
            clsReplacementLicenseData licenseData, byte issueReason,
            int createdByUserID, DateTime issueDate, SqlConnection conn,
            SqlTransaction transaction)
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

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value =
                    replacementApplicationID;
                cmd.Parameters.Add("@DriverID", SqlDbType.Int).Value = licenseData.DriverID;
                cmd.Parameters.Add("@LicenseClass", SqlDbType.Int).Value =
                    licenseData.LicenseClassID;
                cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = issueDate;
                cmd.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value =
                    licenseData.ExpirationDate;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 1000).Value =
                    string.IsNullOrWhiteSpace(licenseData.Notes)
                        ? (object)DBNull.Value
                        : licenseData.Notes.Trim();
                cmd.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = 0m;
                cmd.Parameters.Add("@IssueReason", SqlDbType.TinyInt).Value = issueReason;
                cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                object result = cmd.ExecuteScalar();
                return result == null ? -1 : Convert.ToInt32(result);
            }
        }

        public static enRenewLicenseDataResult RenewLicense(
            int oldLicenseID, string notes, int createdByUserID,
            out int renewalApplicationID, out int renewedLicenseID)
        {
            renewalApplicationID = -1;
            renewedLicenseID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        if (!IsActiveUser(createdByUserID, conn, transaction))
                        {
                            transaction.Rollback();
                            return enRenewLicenseDataResult.InvalidUser;
                        }

                        clsRenewLicenseData licenseData;
                        if (!TryGetRenewLicenseData(oldLicenseID, conn, transaction,
                            out licenseData))
                        {
                            transaction.Rollback();
                            return enRenewLicenseDataResult.LicenseNotFound;
                        }

                        if (!licenseData.IsActive)
                        {
                            transaction.Rollback();
                            return enRenewLicenseDataResult.LicenseInactive;
                        }

                        if (licenseData.IsDetained)
                        {
                            transaction.Rollback();
                            return enRenewLicenseDataResult.LicenseDetained;
                        }

                        DateTime operationDate = DateTime.Now;
                        if (licenseData.ExpirationDate.Date > operationDate.Date)
                        {
                            transaction.Rollback();
                            return enRenewLicenseDataResult.LicenseNotExpired;
                        }

                        decimal applicationFees;
                        if (!TryGetApplicationFees(RenewApplicationTypeID, conn,
                            transaction, out applicationFees))
                        {
                            transaction.Rollback();
                            return enRenewLicenseDataResult.ApplicationTypeNotFound;
                        }

                        renewalApplicationID = CreateRenewalApplication(
                            licenseData.PersonID, applicationFees, createdByUserID,
                            operationDate, conn, transaction);
                        if (renewalApplicationID <= 0)
                        {
                            transaction.Rollback();
                            return enRenewLicenseDataResult.ApplicationCreationFailed;
                        }

                        renewedLicenseID = CreateRenewedLicense(renewalApplicationID,
                            licenseData, notes, createdByUserID, operationDate,
                            conn, transaction);
                        if (renewedLicenseID <= 0)
                        {
                            renewalApplicationID = -1;
                            transaction.Rollback();
                            return enRenewLicenseDataResult.LicenseCreationFailed;
                        }

                        if (!DeactivateOldLicense(oldLicenseID, conn, transaction))
                        {
                            renewalApplicationID = -1;
                            renewedLicenseID = -1;
                            transaction.Rollback();
                            return enRenewLicenseDataResult.OldLicenseDeactivationFailed;
                        }

                        if (!CompleteApplication(renewalApplicationID, conn, transaction))
                        {
                            renewalApplicationID = -1;
                            renewedLicenseID = -1;
                            transaction.Rollback();
                            return enRenewLicenseDataResult.ApplicationCompletionFailed;
                        }

                        transaction.Commit();
                        return enRenewLicenseDataResult.Success;
                    }
                    catch
                    {
                        renewalApplicationID = -1;
                        renewedLicenseID = -1;
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private static bool IsActiveUser(int userID, SqlConnection conn,
            SqlTransaction transaction)
        {
            const string query = @"
                SELECT TOP 1 1
                FROM Users WITH (HOLDLOCK)
                WHERE UserID = @UserID
                  AND IsActive = 1";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                return cmd.ExecuteScalar() != null;
            }
        }

        private static bool TryGetRenewLicenseData(int oldLicenseID,
            SqlConnection conn, SqlTransaction transaction,
            out clsRenewLicenseData licenseData)
        {
            licenseData = null;

            const string query = @"
                SELECT
                    L.DriverID,
                    D.PersonID,
                    L.LicenseClass,
                    L.ExpirationDate,
                    L.IsActive,
                    LC.DefaultValidityLength,
                    LC.ClassFees,
                    CASE WHEN EXISTS
                    (
                        SELECT 1
                        FROM DetainedLicenses DL WITH (UPDLOCK, HOLDLOCK)
                        WHERE DL.LicenseID = L.LicenseID
                          AND DL.IsReleased = 0
                    ) THEN 1 ELSE 0 END AS IsDetained
                FROM Licenses L WITH (UPDLOCK, HOLDLOCK)
                INNER JOIN Drivers D
                    ON D.DriverID = L.DriverID
                INNER JOIN LicenseClasses LC
                    ON LC.LicenseClassID = L.LicenseClass
                WHERE L.LicenseID = @OldLicenseID";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@OldLicenseID", SqlDbType.Int).Value = oldLicenseID;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return false;

                    licenseData = new clsRenewLicenseData
                    {
                        DriverID = Convert.ToInt32(reader["DriverID"]),
                        PersonID = Convert.ToInt32(reader["PersonID"]),
                        LicenseClassID = Convert.ToInt32(reader["LicenseClass"]),
                        ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        IsDetained = Convert.ToBoolean(reader["IsDetained"]),
                        ValidityLength = Convert.ToInt32(reader["DefaultValidityLength"]),
                        ClassFees = Convert.ToDecimal(reader["ClassFees"])
                    };

                    return true;
                }
            }
        }

        private static bool TryGetApplicationFees(int applicationTypeID,
            SqlConnection conn, SqlTransaction transaction, out decimal applicationFees)
        {
            applicationFees = 0;

            const string query = @"
                SELECT ApplicationFees
                FROM ApplicationTypes WITH (HOLDLOCK)
                WHERE ApplicationTypeID = @ApplicationTypeID";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value =
                    applicationTypeID;
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return false;

                applicationFees = Convert.ToDecimal(result);
                return true;
            }
        }

        private static int CreateRenewalApplication(int personID,
            decimal applicationFees, int createdByUserID, DateTime operationDate,
            SqlConnection conn, SqlTransaction transaction)
        {
            const string query = @"
                INSERT INTO Applications
                (
                    ApplicantPersonID,
                    ApplicationDate,
                    ApplicationTypeID,
                    ApplicationStatus,
                    LastStatusDate,
                    PaidFees,
                    CreatedByUserID
                )
                VALUES
                (
                    @ApplicantPersonID,
                    @ApplicationDate,
                    @ApplicationTypeID,
                    @ApplicationStatus,
                    @LastStatusDate,
                    @PaidFees,
                    @CreatedByUserID
                );
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = personID;
                cmd.Parameters.Add("@ApplicationDate", SqlDbType.DateTime).Value = operationDate;
                cmd.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value =
                    RenewApplicationTypeID;
                cmd.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value =
                    NewApplicationStatus;
                cmd.Parameters.Add("@LastStatusDate", SqlDbType.DateTime).Value = operationDate;
                cmd.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = applicationFees;
                cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                object result = cmd.ExecuteScalar();
                return result == null ? -1 : Convert.ToInt32(result);
            }
        }

        private static int CreateRenewedLicense(int renewalApplicationID,
            clsRenewLicenseData licenseData, string notes, int createdByUserID,
            DateTime issueDate, SqlConnection conn, SqlTransaction transaction)
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

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@ApplicationID", SqlDbType.Int).Value =
                    renewalApplicationID;
                cmd.Parameters.Add("@DriverID", SqlDbType.Int).Value = licenseData.DriverID;
                cmd.Parameters.Add("@LicenseClass", SqlDbType.Int).Value =
                    licenseData.LicenseClassID;
                cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = issueDate;
                cmd.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value =
                    issueDate.AddYears(licenseData.ValidityLength);
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 1000).Value =
                    string.IsNullOrWhiteSpace(notes) ? (object)DBNull.Value : notes.Trim();
                cmd.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value =
                    licenseData.ClassFees;
                cmd.Parameters.Add("@IssueReason", SqlDbType.TinyInt).Value = RenewIssueReason;
                cmd.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                object result = cmd.ExecuteScalar();
                return result == null ? -1 : Convert.ToInt32(result);
            }
        }

        private static bool DeactivateOldLicense(int oldLicenseID,
            SqlConnection conn, SqlTransaction transaction)
        {
            const string query = @"
                UPDATE Licenses
                SET IsActive = 0
                WHERE LicenseID = @OldLicenseID
                  AND IsActive = 1";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@OldLicenseID", SqlDbType.Int).Value = oldLicenseID;
                return cmd.ExecuteNonQuery() == 1;
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
