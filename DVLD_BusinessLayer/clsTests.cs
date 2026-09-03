using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsTests
    {
        public static int AddNewTest(int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            return clsTestsData.AddNewTest(testAppointmentID, testResult, notes, createdByUserID);
        }

        public static bool HasTestResult(int testAppointmentID)
        {
            return clsTestsData.HasTestResult(testAppointmentID);
        }

        public static DataTable GetTestByAppointmentID(int testAppointmentID)
        {
            return clsTestsData.GetTestByAppointmentID(testAppointmentID);
        }

        public static bool? GetLastTestResult(int localApplicationID, int testTypeID)
        {
            return clsTestsData.GetLastTestResult(localApplicationID, testTypeID);
        }

        public static bool IsTestPassed(int localApplicationID, int testTypeID)
        {
            return clsTestsData.IsTestPassed(localApplicationID, testTypeID);
        }

        public static int GetPassedTestsCount(int localApplicationID)
        {
            return clsTestsData.GetPassedTestsCount(localApplicationID);
        }
    }
}
