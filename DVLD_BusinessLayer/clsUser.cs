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


        public clsUser() {
            this.PersonInfo = new clsPerson();
            this.IsActive = false;
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
        }
        public clsUser(int userID, int personID, string userName, bool isActive, clsPerson personInfo)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.UserName = userName;
            this.IsActive = isActive;
            this.PersonInfo = personInfo;
        }
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
        public static clsUser FindByPersonID(int personID)
        {
            int userID = -1;
            string userName = "";
            bool isActive = false;

            clsUserData.FindByPersonID(personID, ref userID, ref userName, ref isActive);
            if (userID < 0)
            {
                return null;
            }

            return new clsUser(userID, personID, userName, isActive, clsPerson.Find(personID));
        }

        public static bool CreateUser(int PersonID, string username, string password)
        {
            return clsUserData.CreateUser(PersonID, username, password);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            return clsUserData.ChangePassword(this.UserID, oldPassword, newPassword);
        }
        public static bool DeleteUser(int userID)
        {
            return clsUserData.DeleteUser(userID);
        }
        public static bool DeactivateUser(int userID)
        {
            return clsUserData.DeactivateUser(userID);
        }

         public static bool ActivateUser(int userID)
        {
            return clsUserData.ActivateUser(userID);
        }

        public bool updateUser(string password = null)
        {
            return clsUserData.UpdateUser(this.UserID, this.UserName, this.IsActive, password);
        }

    }
}
