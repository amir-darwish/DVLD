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
    }
}
