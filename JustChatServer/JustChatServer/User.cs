using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace JustChatServer
{
    public class User
    {
        private string username;
        private string password;
        private string? statusMessage;

        private readonly int UserID;

        private static int NextID;

        public List<string> contacts = new List<string>();

        public List<Message> all_chats = new List<Message>();
        public IEnumerable<Message> current_chat;

        public static List<User> users = new List<User>();

        public static Dictionary<int, NetworkStream> clientStreams = new Dictionary<int, NetworkStream>();

        public string _username
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

        public string _password
        {
            get
            {
                return password;
            }
        }

        public string? _statusMessage
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
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;

            this.UserID = NextID;
            NextID++;
        }

        public User(string username, string password, string statusMessage)
        {
            this.username = username;
            this.password = password;
            this.statusMessage = statusMessage;

            this.UserID = NextID;
            NextID++;
        }

        public static string Check_Username(string _username, string _password, NetworkStream stream, out int CurrentID) //Check the username of the account creation
        {
            CurrentID = -1;
            var filteredList = users.Where(u => u.username.ToLower() == _username.ToLower()); //filter the list
            if (filteredList.Any()) //Checks if it contains any element after filtering
            {
                return "false";
            }

            CurrentID = NextID;
            users.Add(new User(_username, _password));
            users[CurrentID].SaveUser();
            clientStreams.Add(CurrentID, stream);

            return "true";
        }

        public static string Check_Account(string _username, string _password, NetworkStream stream) //Using LINQ - Take the user's credentials for login checking
        {
            string _contacts = "";
            User? filteredUser = users.FirstOrDefault(u => u.username.ToLower() == _username.ToLower() && u.password == _password); //Get the first user that satisfy the given condition
            if (filteredUser == null)
            {
                return "-1";
            }

            int CurrentID = filteredUser.UserID;
            if (!User.clientStreams.ContainsKey(CurrentID)) //Check if a stream is already opened with the given user
            {
                clientStreams.Add(CurrentID, stream);
            }
            _contacts += $"{CurrentID},{filteredUser._username},";
            for (int i = 0; i < users[CurrentID].contacts.Count; i++) //Get the contacts of the user if found
            {
                _contacts += (users[CurrentID].contacts[i]) + ",";
            }
            _contacts = _contacts.Trim(',');

            return _contacts;
        }

        public void SaveUser()
        {
            string info = $"{username},{password},{statusMessage}\n";
            File.AppendAllText("Credentials.csv", info);
        }

        public void UpdateUser()
        {
            using (StreamWriter sw = new StreamWriter("Credentials.csv"))
            {
                foreach (User u in users)
                {
                    sw.WriteLine($"{username},{password},{statusMessage}");
                }
            }
        }

        public static void ReadUser()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Credentials.csv"))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] s = line.Split(',');
                        users.Add(new User(s[0], s[1], s[2]));
                    }
                }
            }
            catch
            {
                //Nothing to do
            }
        }

        public static int FindUserID(string _username)
        {
            User? user = users.FirstOrDefault(u => u.username.ToLower() == _username.ToLower());
            if (user != null)
            {
                return user.UserID;
            }

            return -1;
        }

        public static void SaveContacts()
        {
            using (StreamWriter sw = new StreamWriter("Contacts.csv"))
            {
                string? line = "";
                foreach (User u in users)   
                {
                    line = "";
                    for(int i=0; i<u.contacts.Count; i++)
                    {
                        line += $"{u.contacts[i]},";
                    }
                    line = line.Trim(',');

                    sw.WriteLine(line);
                }
            }
        }

        public static void GetContacts()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Contacts.csv"))
                {
                    string? line;
                    int index = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] s = line.Split(",");
                        for (int i = 0; i<s.Length; i++)
                        {
                            users[index].contacts.Add(s[i]);
                        }
                        index++;
                    }
                }
            }
            catch
            {
                //Nothing to do
            }
        }
    }
}
