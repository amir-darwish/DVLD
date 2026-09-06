using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsInternationalLicense
    {
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

        public static enIssueInternationalLicenseResult IssueInternationalLicense(
            int localLicenseID, int createdByUserID, out int internationalLicenseID)
        {
            clsInternationalLicenseData.enIssueInternationalLicenseResult dataResult =
                clsInternationalLicenseData.CreateInternationalLicense(localLicenseID,
                    createdByUserID, out internationalLicenseID);

            switch (dataResult)
            {
                case clsInternationalLicenseData.enIssueInternationalLicenseResult.Success:
                    return enIssueInternationalLicenseResult.Success;
                case clsInternationalLicenseData.enIssueInternationalLicenseResult.LocalLicenseNotFound:
                    return enIssueInternationalLicenseResult.LocalLicenseNotFound;
                case clsInternationalLicenseData.enIssueInternationalLicenseResult.LocalLicenseExpired:
                    return enIssueInternationalLicenseResult.LocalLicenseExpired;
                case clsInternationalLicenseData.enIssueInternationalLicenseResult.LocalLicenseInactive:
                    return enIssueInternationalLicenseResult.LocalLicenseInactive;
                case clsInternationalLicenseData.enIssueInternationalLicenseResult.ActiveInternationalLicenseAlreadyExists:
                    return enIssueInternationalLicenseResult.ActiveInternationalLicenseAlreadyExists;
                case clsInternationalLicenseData.enIssueInternationalLicenseResult.ApplicationTypeNotFound:
                    return enIssueInternationalLicenseResult.ApplicationTypeNotFound;
                case clsInternationalLicenseData.enIssueInternationalLicenseResult.ApplicationCreationFailed:
                    return enIssueInternationalLicenseResult.ApplicationCreationFailed;
                default:
                    return enIssueInternationalLicenseResult.InternationalLicenseCreationFailed;
            }
        }

        public static DataTable GetInternationalLicenseInfo(int internationalLicenseID)
        {
            return clsInternationalLicenseData.GetInternationalLicenseInfo(internationalLicenseID);
        }

        public static DataTable GetAllInternationalLicenses()
        { 
            return clsInternationalLicenseData.GetAllInternationalLicenses();

        }

    }
}
