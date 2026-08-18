using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public static DataTable GetAllCountries()
        {
            return DVLD_DataAccessLayer.clsCountryData.GetAllCountries();
        }
    }
}
