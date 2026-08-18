using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsTestType
    {
        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetaAllTestTypes();
        }

        public static bool EditeTestType(int testTypeID, string testTypeName, string testTypeDescription, decimal fee)
        {
            return clsTestTypeData.EditeTestType(testTypeID, testTypeName, testTypeDescription, fee);
        }
    }

    

}
