using DVLD_DataAccessLayer;
using System;
using System.Data;

namespace DVLD_BusinessLayer
{
    public class clsLicense
    {
        public enum enFirstTimeLicenseIssueResult
        {
            Eligible,
            Success,
            InvalidLocalApplicationID,
            InvalidUser,
            NotesTooLong,
            ApplicationNotFound,
            ApplicationIsNotNew,
            LicenseAlreadyIssued,
            TestsNotPassed,
            DriverCreationFailed,
            LicenseCreationFailed,
            ApplicationCompletionFailed
        }

        public static DataTable GetDriverLicenseInfo(int licenseID)
        {
            return clsLicenseData.GetDriverLicenseInfo(licenseID);
        }

        public static int GetLicenseIDByApplicationID(int applicationID)
        {
            return clsLicenseData.GetLicenseIDByApplicationID(applicationID);
        }

        public static DataTable GetRenewedLicenseInfo(int renewedLicenseID)
        {
            return clsLicenseData.GetRenewedLicenseInfo(renewedLicenseID);
        }

        public static DataTable GetReplacedLicenseInfo(int replacedLicenseID)
        {
            return clsLicenseData.GetReplacedLicenseInfo(replacedLicenseID);
        }

        public static enReplaceLicenseResult ReplaceLicense(
            int oldLicenseID, enLicenseReplacementType replacementType,
            int createdByUserID, out int replacementApplicationID,
            out int replacedLicenseID)
        {
            replacementApplicationID = -1;
            replacedLicenseID = -1;

            if (oldLicenseID <= 0)
                return enReplaceLicenseResult.InvalidLicenseID;

            if (createdByUserID <= 0)
                return enReplaceLicenseResult.InvalidUser;

            int applicationTypeID;
            byte issueReason;

            switch (replacementType)
            {
                case enLicenseReplacementType.Lost:
                    applicationTypeID = 3;
                    issueReason = 4;
                    break;
                case enLicenseReplacementType.Damaged:
                    applicationTypeID = 4;
                    issueReason = 3;
                    break;
                default:
                    return enReplaceLicenseResult.InvalidReplacementType;
            }

            clsLicenseData.enReplaceLicenseDataResult dataResult =
                clsLicenseData.ReplaceLicense(oldLicenseID, applicationTypeID,
                    issueReason, createdByUserID, out replacementApplicationID,
                    out replacedLicenseID);

            switch (dataResult)
            {
                case clsLicenseData.enReplaceLicenseDataResult.Success:
                    return enReplaceLicenseResult.Success;
                case clsLicenseData.enReplaceLicenseDataResult.InvalidUser:
                    return enReplaceLicenseResult.InvalidUser;
                case clsLicenseData.enReplaceLicenseDataResult.InvalidReplacementType:
                    return enReplaceLicenseResult.InvalidReplacementType;
                case clsLicenseData.enReplaceLicenseDataResult.LicenseNotFound:
                    return enReplaceLicenseResult.LicenseNotFound;
                case clsLicenseData.enReplaceLicenseDataResult.LicenseInactive:
                    return enReplaceLicenseResult.LicenseInactive;
                case clsLicenseData.enReplaceLicenseDataResult.LicenseDetained:
                    return enReplaceLicenseResult.LicenseDetained;
                case clsLicenseData.enReplaceLicenseDataResult.LicenseExpired:
                    return enReplaceLicenseResult.LicenseExpired;
                case clsLicenseData.enReplaceLicenseDataResult.ApplicationTypeNotFound:
                    return enReplaceLicenseResult.ApplicationTypeNotFound;
                case clsLicenseData.enReplaceLicenseDataResult.ApplicationCreationFailed:
                    return enReplaceLicenseResult.ApplicationCreationFailed;
                case clsLicenseData.enReplaceLicenseDataResult.LicenseCreationFailed:
                    return enReplaceLicenseResult.LicenseCreationFailed;
                case clsLicenseData.enReplaceLicenseDataResult.OldLicenseDeactivationFailed:
                    return enReplaceLicenseResult.OldLicenseDeactivationFailed;
                default:
                    return enReplaceLicenseResult.ApplicationCompletionFailed;
            }
        }

        public static enRenewLicenseResult RenewLicense(
            int oldLicenseID, string notes, int createdByUserID,
            out int renewalApplicationID, out int renewedLicenseID)
        {
            renewalApplicationID = -1;
            renewedLicenseID = -1;

            if (oldLicenseID <= 0)
                return enRenewLicenseResult.InvalidLicenseID;

            if (createdByUserID <= 0)
                return enRenewLicenseResult.InvalidUser;

            if (!string.IsNullOrEmpty(notes) && notes.Length > 1000)
                return enRenewLicenseResult.NotesTooLong;

            clsLicenseData.enRenewLicenseDataResult dataResult =
                clsLicenseData.RenewLicense(oldLicenseID, notes, createdByUserID,
                    out renewalApplicationID, out renewedLicenseID);

            switch (dataResult)
            {
                case clsLicenseData.enRenewLicenseDataResult.Success:
                    return enRenewLicenseResult.Success;
                case clsLicenseData.enRenewLicenseDataResult.InvalidUser:
                    return enRenewLicenseResult.InvalidUser;
                case clsLicenseData.enRenewLicenseDataResult.LicenseNotFound:
                    return enRenewLicenseResult.LicenseNotFound;
                case clsLicenseData.enRenewLicenseDataResult.LicenseInactive:
                    return enRenewLicenseResult.LicenseInactive;
                case clsLicenseData.enRenewLicenseDataResult.LicenseDetained:
                    return enRenewLicenseResult.LicenseDetained;
                case clsLicenseData.enRenewLicenseDataResult.LicenseNotExpired:
                    return enRenewLicenseResult.LicenseNotExpired;
                case clsLicenseData.enRenewLicenseDataResult.ApplicationTypeNotFound:
                    return enRenewLicenseResult.ApplicationTypeNotFound;
                case clsLicenseData.enRenewLicenseDataResult.ApplicationCreationFailed:
                    return enRenewLicenseResult.ApplicationCreationFailed;
                case clsLicenseData.enRenewLicenseDataResult.LicenseCreationFailed:
                    return enRenewLicenseResult.LicenseCreationFailed;
                case clsLicenseData.enRenewLicenseDataResult.OldLicenseDeactivationFailed:
                    return enRenewLicenseResult.OldLicenseDeactivationFailed;
                default:
                    return enRenewLicenseResult.ApplicationCompletionFailed;
            }
        }

        public static enFirstTimeLicenseIssueResult ValidateFirstTimeLicenseIssue(
            int localDrivingLicenseApplicationID)
        {
            if (localDrivingLicenseApplicationID <= 0)
                return enFirstTimeLicenseIssueResult.InvalidLocalApplicationID;

            DataTable applicationInfo = clsLocalDrivingLicenseApp
                .GetLocalDrivingLicenseApplicationInfo(localDrivingLicenseApplicationID);

            if (applicationInfo.Rows.Count == 0)
                return enFirstTimeLicenseIssueResult.ApplicationNotFound;

            DataRow row = applicationInfo.Rows[0];
            if (Convert.ToByte(row["ApplicationStatus"]) != 1)
                return enFirstTimeLicenseIssueResult.ApplicationIsNotNew;

            int applicationID = Convert.ToInt32(row["ApplicationID"]);
            if (clsLicenseData.IsLicenseExistByApplicationID(applicationID))
                return enFirstTimeLicenseIssueResult.LicenseAlreadyIssued;

            if (clsTests.GetPassedTestsCount(localDrivingLicenseApplicationID) != 3)
                return enFirstTimeLicenseIssueResult.TestsNotPassed;

            return enFirstTimeLicenseIssueResult.Eligible;
        }

        public static enFirstTimeLicenseIssueResult IssueFirstTimeLicense(
            int localDrivingLicenseApplicationID, string notes, int createdByUserID,
            out int licenseID)
        {
            licenseID = -1;

            if (localDrivingLicenseApplicationID <= 0)
                return enFirstTimeLicenseIssueResult.InvalidLocalApplicationID;

            if (createdByUserID <= 0)
                return enFirstTimeLicenseIssueResult.InvalidUser;

            if (!string.IsNullOrEmpty(notes) && notes.Length > 1000)
                return enFirstTimeLicenseIssueResult.NotesTooLong;

            clsLicenseData.enIssueFirstTimeLicenseDataResult dataResult =
                clsLicenseData.IssueFirstTimeLicense(localDrivingLicenseApplicationID,
                    notes, createdByUserID, out licenseID);

            switch (dataResult)
            {
                case clsLicenseData.enIssueFirstTimeLicenseDataResult.Success:
                    return enFirstTimeLicenseIssueResult.Success;
                case clsLicenseData.enIssueFirstTimeLicenseDataResult.ApplicationNotFound:
                    return enFirstTimeLicenseIssueResult.ApplicationNotFound;
                case clsLicenseData.enIssueFirstTimeLicenseDataResult.ApplicationIsNotNew:
                    return enFirstTimeLicenseIssueResult.ApplicationIsNotNew;
                case clsLicenseData.enIssueFirstTimeLicenseDataResult.LicenseAlreadyIssued:
                    return enFirstTimeLicenseIssueResult.LicenseAlreadyIssued;
                case clsLicenseData.enIssueFirstTimeLicenseDataResult.TestsNotPassed:
                    return enFirstTimeLicenseIssueResult.TestsNotPassed;
                case clsLicenseData.enIssueFirstTimeLicenseDataResult.DriverCreationFailed:
                    return enFirstTimeLicenseIssueResult.DriverCreationFailed;
                case clsLicenseData.enIssueFirstTimeLicenseDataResult.LicenseCreationFailed:
                    return enFirstTimeLicenseIssueResult.LicenseCreationFailed;
                default:
                    return enFirstTimeLicenseIssueResult.ApplicationCompletionFailed;
            }
        }
    }
}
