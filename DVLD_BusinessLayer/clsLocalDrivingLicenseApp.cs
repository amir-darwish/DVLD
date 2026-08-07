using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;


namespace DVLD_BusinessLayer
{
    public class clsLocalDrivingLicenseApp
    {
        public static DataTable GetAllLocalDrivingLicenceApplicationsFromView()
        {
            return clsLocalDrivingLicenceAppData.GetAllLocalDrivingLicenceApplicationsFromView();
        }

        public static bool IsThereAnActiveApplicationIsLocalDrivingLicenceApplicationExists(int applicantId, int licenseClassId)
        {
            return clsLocalDrivingLicenceAppData.IsThereAnActiveApplication(applicantId, licenseClassId);
        }

        public static int CreateNewLocalDrivingLicenceApplication(int applicantId, int licenseClassId)
        {
            return clsLocalDrivingLicenceAppData.CreateLocalDrivingLicenceApplication(applicantId, licenseClassId);
        } 
    }
}
