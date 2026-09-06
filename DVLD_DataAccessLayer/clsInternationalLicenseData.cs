using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsInternationalLicenseData
    {
        private const int NewInternationalLicenseApplicationTypeID = 6;
        private class clsLocalLicenseData
        {
            public int PersonID { get; set; }
            public int LicenseClassID { get; set; }
            public int DriverID { get; set; }
            public DateTime ExpirationDate { get; set; }
            public bool IsActive { get; set; }
        }
        public enum enIssueInternationalLicenseResult
        {
            Success,
            LocalLicenseNotFound,
            LocalLicenseExpired,
            LocalLicenseInactive,
            ActiveInternationalLicenseAlreadyExists,
            ApplicationTypeNotFound,
            ApplicationCreationFailed,
            InternationalLicenseCreationFailed
        }
        public static DataTable GetInternationalLicenseInfo(int licenseID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {

            }
        }

        public static enIssueInternationalLicenseResult CreateInternationalLicense(int localLicenseID, int createdByUserID, out int internationalLicenseID)
        {
            internationalLicenseID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable))
                {
                    // Implementation for creating an international license
                    clsLocalLicenseData licenseData;
                    if (!TryGetLocalLicenseData(localLicenseID, connection, transaction, out licenseData))
                    {
                        transaction.Rollback();
                        return enIssueInternationalLicenseResult.LocalLicenseNotFound;
                    }
                    if (licenseData.ExpirationDate <= DateTime.Now)
                    {
                        transaction.Rollback();
                        return enIssueInternationalLicenseResult.LocalLicenseExpired;
                    }
                    if (!licenseData.IsActive)
                    {
                        transaction.Rollback();
                        return enIssueInternationalLicenseResult.LocalLicenseInactive;
                    }
                    if (HasActiveInternationalLicense(licenseData.DriverID, connection, transaction))
                    {
                        transaction.Rollback();
                        return enIssueInternationalLicenseResult.ActiveInternationalLicenseAlreadyExists;
                    }
                    if (!TryGetApplicationFees(NewInternationalLicenseApplicationTypeID, connection, transaction, out decimal applicationFees))
                    {
                        transaction.Rollback();
                        return enIssueInternationalLicenseResult.ApplicationTypeNotFound;
                    }

                    int applicationID = CreateInternationalApplication(
                    licenseData.PersonID, applicationFees, createdByUserID,
                    connection, transaction);

                    if (applicationID <= 0)
                    {
                        transaction.Rollback();
                        return enIssueInternationalLicenseResult.ApplicationCreationFailed;
                    }

                    internationalLicenseID = CreateInternationalLicenseRecord(licenseData.DriverID, applicationID, localLicenseID,createdByUserID, licenseData.ExpirationDate, connection, transaction);

                    if (internationalLicenseID <= 0)
                    {
                        transaction.Rollback();
                        return enIssueInternationalLicenseResult.InternationalLicenseCreationFailed;
                    }
                    transaction.Commit();
                    return enIssueInternationalLicenseResult.Success;

                }
            }
        }

        private static bool TryGetLocalLicenseData(int localLicenseID, SqlConnection connection, SqlTransaction transaction, out clsLocalLicenseData licenseData)
        {
            licenseData = null;
            const string query = @"SELECT L.DriverID, D.PersonID, L.ExpirationDate, L.IsActive, L.LicenseClass
                                     FROM Licenses L WITH (UPDLOCK, HOLDLOCK)
                                     INNER JOIN Drivers D ON L.DriverID = D.DriverID
                                     WHERE L.LicenseID = @LocalLicenseID";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.Add("@LocalLicenseID", SqlDbType.Int).Value = localLicenseID;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        licenseData = new clsLocalLicenseData
                        {
                            DriverID = reader.GetInt32(reader.GetOrdinal("DriverID")),
                            PersonID = reader.GetInt32(reader.GetOrdinal("PersonID")),
                            ExpirationDate = reader.GetDateTime(reader.GetOrdinal("ExpirationDate")),
                            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                            LicenseClassID = reader.GetInt32(reader.GetOrdinal("LicenseClass"))
                        };
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool HasActiveInternationalLicense(int driverID, SqlConnection connection, SqlTransaction transaction)
        {
            const string query = @"SELECT TOP 1 1 FROM InternationalLicenses WITH (UPDLOCK, HOLDLOCK) WHERE DriverID = @DriverID AND IsActive = 1";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;
                return command.ExecuteScalar() != null;
            }
        }

        private static bool TryGetApplicationFees(int applicationTypeID, SqlConnection connection, SqlTransaction transaction, out decimal applicationFees)
        {
            applicationFees = 0;
            const string query = @"SELECT ApplicationFees FROM ApplicationTypes WITH (UPDLOCK, HOLDLOCK) WHERE ApplicationTypeID = @ApplicationTypeID";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = applicationTypeID;
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    applicationFees = Convert.ToDecimal(result);
                    return true;
                }
            }
            return false;
        }

        private static int CreateInternationalApplication(int personID, decimal applicationFees, int createdByUserID, SqlConnection connection, SqlTransaction transaction)
        {
            const string query = @"
                    INSERT INTO dbo.Applications
                        (ApplicantPersonID, ApplicationTypeID, PaidFees, ApplicationDate,
                         LastStatusDate, CreatedByUserID, ApplicationStatus)
                    VALUES
                        (@ApplicantPersonID, @ApplicationTypeID, @PaidFees, @ApplicationDate,
                         @LastStatusDate, @CreatedByUserID, @ApplicationStatus);
                    SELECT CAST(SCOPE_IDENTITY() AS int);";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                DateTime now = DateTime.Now;

                command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = personID;
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = NewInternationalLicenseApplicationTypeID;
                command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = applicationFees;
                command.Parameters.Add("@ApplicationDate", SqlDbType.DateTime).Value = now;
                command.Parameters.Add("@LastStatusDate", SqlDbType.DateTime).Value = now;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;
                command.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = 1;
                object result = command.ExecuteScalar();
                return result == null ? -1 : Convert.ToInt32(result);
            }
        }

        private static int CreateInternationalLicenseRecord(int driverID, int applicationID, int localLicenseID, int createdByUserID,
            DateTime expirationDate, SqlConnection connection, SqlTransaction transaction)
        {
            const string query = @"
                INSERT INTO dbo.InternationalLicenses
                    (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate,
                     ExpirationDate, IsActive, CreatedByUserID)
                VALUES
                    (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate,
                     @ExpirationDate, @IsActive, @CreatedByUserID);
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;
                command.Parameters.Add("@IssuedUsingLocalLicenseID", SqlDbType.Int).Value = localLicenseID;
                command.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = expirationDate;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = true;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                object result = command.ExecuteScalar();
                return result == null ? -1 : Convert.ToInt32(result);
            }
        }
    }
}