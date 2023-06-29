using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JustChat
{
    public static class User
    {
        private static string? username;
        private static string? password;
        private static string? statusMessage;

        private static int UserID = -1;

        public static List<Message> current_Chat = new List<Message>();

        public static List<string> contacts = new List<string>();

        private static string? Destination;

        private static bool IsOffline = true;

        public static string? _username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public static string? _password
        {
            get
            {
                return password;
            }
        }

        public static string? _statusMessage
        {
            get
            {
                return statusMessage;
            }
            set
            {
                statusMessage = value;
            }
        }

        public static int _UserID
        {
            get
            {
                return UserID;
            }
            set
            {
                if (UserID == -1)
                {
                    UserID = value;
                }
            }
        }

        public static string? _Destination
        {
            get
            {
                return Destination;
            }
            set
            {
                Destination = value;
            }
        }

        public static bool _IsOffline
        {
            get
            {
                return IsOffline;
            }
            set
            {
                IsOffline = value;
            }
        }
    }
}
