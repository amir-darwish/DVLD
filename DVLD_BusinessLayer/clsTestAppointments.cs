using System;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsTestAppointments
    {
        public static DataTable GetTestAppointments(int localApplicationID)
        {
            return clsTestAppointmentsData.GetTestAppointments(localApplicationID);
        }

        public static bool IsThereAnActiveTestAppointment(int localApplicationID, int testTypeID)
        {
            return clsTestAppointmentsData.IsThereAnActiveTestAppointment(localApplicationID, testTypeID);
        }

        public static int AddNewTestAppointment(int localApplicationID, int testTypeID, DateTime appointmentDate, decimal paidFees, int createdByUserID)
        {
            return clsTestAppointmentsData.AddNewTestAppointment(localApplicationID, testTypeID, appointmentDate, paidFees, createdByUserID);
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
