using System;

namespace Project_UAS_Pemrograman_Framework.NET
{
    class Session
    {
        private static string username;

        public static string getLoggedInUsername()
        {
            return username;
        }

        public static void setLoggedInUsername(string usernameSetter)
        {
            username = usernameSetter;
        }

        public static void resetLoggedInUsername()
        {
            username = String.Empty;
        }
    }
}
