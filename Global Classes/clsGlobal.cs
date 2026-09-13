using System;
using System.IO;
using DVLD_BusinessLayer;

namespace DVLD
{
    internal static class clsGlobal
    {
        private static readonly string LoginInfoPath = @"C:\Users\Utilisateur\Desktop\DVLD\_login.txt";
        public static clsUser CurrentUser { get; private set; }

        public static void SignIn(clsUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }
            CurrentUser = user;
        }
        public static bool IsLoggedIn() { 
            return CurrentUser != null;
        }
        public static void SignOut()
        {

            CurrentUser = null;
            DeleteLoginInfo();
        }

        private static void DeleteLoginInfo()
        {
            if (File.Exists(LoginInfoPath))
                File.Delete(LoginInfoPath);
        }

    }
}
