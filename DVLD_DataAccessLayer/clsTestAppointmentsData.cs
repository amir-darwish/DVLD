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
        public static DataTable GetTestAppointments(int localApplicationID)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT
                            TA.TestAppointmentID,
                            TA.LocalDrivingLicenseApplicationID,
                            TA.TestTypeID,
                            TT.TestTypeTitle,
                            TA.AppointmentDate,
                            TA.PaidFees,
                            TA.IsLocked,
                            U.UserName                 
                        FROM TestAppointments TA
                        INNER JOIN TestTypes TT
                            ON TA.TestTypeID = TT.TestTypeID
                        INNER JOIN Users U
                            ON TA.CreatedByUserID = U.UserID
                        WHERE TA.LocalDrivingLicenseApplicationID =
                              @LocalDrivingLicenseApplicationID
                        ORDER BY TA.AppointmentDate DESC";
            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localApplicationID);
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
            string query = @"INSERT INTO TestAppointments
                            (LocalDrivingLicenseApplicationID, TestTypeID, AppointmentDate, PaidFees, IsLocked, CreatedByUserID)
                            VALUES
                            (@LocalDrivingLicenseApplicationID, @TestTypeID, @AppointmentDate, @PaidFees, 0, @CreatedByUserID); 
                            SELECT CAST(SCOPE_IDENTITY() AS int);";

            using (SqlConnection conn = new SqlConnection(clsDataAccsessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localApplicationID);
                    cmd.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                    cmd.Parameters.AddWithValue("@PaidFees", paidFees);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                    conn.Open();
                    object newId = cmd.ExecuteScalar();
                    return newId != null ? (int)newId : -1;
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
