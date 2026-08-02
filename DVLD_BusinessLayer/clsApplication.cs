using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsApplication
    {
        public clsApplication() { }

        public static int CreateApplication(int applicantPersonID, int applicationTypeID, decimal paidFees, int createdByUserID)
        {
            return clsApplicationData.CreateApplication(applicantPersonID, applicationTypeID, paidFees, createdByUserID);
        }
    }
}
