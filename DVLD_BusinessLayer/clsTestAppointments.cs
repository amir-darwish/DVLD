using System;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsTestAppointments
    {
        public static DataTable GetAppointmentBookingInfo(int localApplicationID, int testTypeID)
        {
            return clsTestAppointmentsData.GetAppointmentBookingInfo(localApplicationID, testTypeID);
        }

        public static string GetAppointmentBookingError(DataTable bookingInfo)
        {
            if (bookingInfo == null || bookingInfo.Rows.Count == 0)
                return "Application or test type information was not found.";

            DataRow row = bookingInfo.Rows[0];
            if (Convert.ToBoolean(row["HasPassedTest"]))
                return "This test has already been passed. Another appointment for the same test is not allowed.";
            if (Convert.ToBoolean(row["HasActiveAppointment"]))
                return "There is already an active appointment for this test. Record its result first.";
            if (Convert.ToBoolean(row["HasLockedAppointmentWithoutResult"]))
                return "A previous appointment is locked but has no test result. Please review its data before booking another appointment.";
            if (Convert.ToByte(row["ApplicationStatus"]) != 1)
                return "Appointments can only be booked for a New application.";
            if (Convert.ToDecimal(row["TestFees"]) < 0)
                return "The test fee is invalid.";
            if (Convert.ToInt32(row["PreviousAppointmentCount"]) > 0 &&
                (row.IsNull("RetakeFees") || Convert.ToDecimal(row["RetakeFees"]) < 0))
                return "Retake Test application fees are missing or invalid.";

            return string.Empty;
        }

        public static DataTable GetTestAppointments(int localApplicationID, int testTypeID)
        {
            return clsTestAppointmentsData.GetTestAppointments(localApplicationID, testTypeID);
        }

        public static bool IsThereAnActiveTestAppointment(int localApplicationID, int testTypeID)
        {
            return clsTestAppointmentsData.IsThereAnActiveTestAppointment(localApplicationID, testTypeID);
        }

        public static int AddNewTestAppointment(int localApplicationID, int testTypeID, DateTime appointmentDate, decimal paidFees, int createdByUserID)
        {
            return clsTestAppointmentsData.AddNewTestAppointment(localApplicationID, testTypeID, appointmentDate, paidFees, createdByUserID);
        }

        public static int AddNewTestAppointment(int localApplicationID, int testTypeID,
            DateTime appointmentDate, decimal paidFees, int createdByUserID,
            decimal expectedRetakeFees, out int retakeTestApplicationID)
        {
            return clsTestAppointmentsData.AddNewTestAppointment(localApplicationID, testTypeID,
                appointmentDate, paidFees, createdByUserID, expectedRetakeFees, out retakeTestApplicationID);
        }

        public static bool LockTestAppointment(int testAppointmentID)
        {
            return clsTestAppointmentsData.LockTestAppointment(testAppointmentID);
        }

        public static DataTable GetTestAppointmentByID(int testAppointmentID)
        {
            return clsTestAppointmentsData.GetTestAppointmentByID(testAppointmentID);
        }
    }
}
