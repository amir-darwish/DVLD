using DVLD_DataAccessLayer;
using System;
using System.Data;

namespace DVLD_BusinessLayer
{
    public class clsUser
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }

        public string UserName { get; set; }
        public bool IsActive { get; set; }

        public clsPerson PersonInfo { get; set; }


        public clsUser() { }
        public static clsUser ValidateUser(string username, string password)
        {
            int userID = -1;
            int personID = -1;
            string userName = "";
            bool isActive = false;
            
            bool isValid = clsUserData.ValidateUser(username, password, ref userID, ref personID, ref userName, ref isActive);
            if (!isValid)
            {
                return null;
            }

            clsUser user = new clsUser();
            user.PersonInfo = clsPerson.Find(personID);
            user.UserID = userID;
            user.UserName = userName;
            user.IsActive = isActive;
            user.PersonID = personID;

            return user;
        }

        public static bool CreateUser(int PersonID, string username, string password)
        {
            return clsUserData.CreateUser(PersonID, username, password);
        }

    }
}
