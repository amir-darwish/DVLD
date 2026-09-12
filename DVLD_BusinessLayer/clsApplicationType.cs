using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using System.Data;

namespace DVLD_BusinessLayer
{
    public class clsApplicationType
    {
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }

        /**
         * Edits an application type in the database.
         * @param applicationTypeID The ID of the application type to edit.
         * @param applicationTypeName The new name of the application type.
         * @param fee The new fee for the application type.
         * @return True if the edit was successful, false otherwise.
         */
        public static bool EditeApplicationType(int applicationTypeID, string applicationTypeName, decimal fee)
        {
            return clsApplicationTypeData.EditeApplicationType(applicationTypeID, applicationTypeName, fee);
        }

        public static decimal? GetApplicationFees(int applicationTypeID)
        {
            return clsApplicationTypeData.GetApplicationFees(applicationTypeID);
        }

    }
}


