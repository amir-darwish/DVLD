using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_BusinessLayer;

namespace DVLD
{
    internal static class clsGlobal
    {
        public static clsPerson CurrentUser { get; private set; }

        public static void SignIn(clsPerson user)
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
        }

    }
}
