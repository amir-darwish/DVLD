using DVLD_DataAccessLayer;
using System;
using System.Data;

namespace DVLD_BusinessLayer
{
    public class clsUser
    {
        public clsUser() { }
        public static clsPerson ValidateUser(string username, string password)
        {
            return clsPerson.Find(clsUserData.ValidateUser(username, password));
        }

        public static bool CreateUser(int PersonID, string username, string password)
        {
            return clsUserData.CreateUser(PersonID, username, password);
        }

    }
}
