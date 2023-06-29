using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace JustChat
{
    public class Client
    {
        private const string CREATE_ACCOUNT = "CREATE_ACCOUNT";
        public const string SEND_MESSAGE = "SEND_MESSAGE";
        private const string LOGIN_ACCOUNT = "LOGIN_ACCOUNT";
        private const string RETRIEVE_MESSAGE = "RETRIEVE_MESSAGE";
        private const string ADD_CONTACT = "ADD_CONTACT";

        private static TcpClient? client = null;
        private static NetworkStream? stream = null;
        public static NetworkStream? _stream
        {
            get
            {
                return stream;
            }
        }

        public static bool IsServerAvailable() //Checks if the server is available
        {
            string serverIP = "127.0.0.1";
            int serverPort = 40000;

            try
            {
                client = new TcpClient(serverIP, serverPort);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool CreateAccountRequest(string _username, string _password, out string text) //Request for account creation
        {
            text = "";
            try
            {
                // Get the network stream from the client
                stream = client?.GetStream();

                // Send a message to the server
                string messageToSend = $"{CREATE_ACCOUNT}\n{_username}\n{_password}";
                byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);
                stream?.Write(sendData, 0, sendData.Length);

                // Receive a response from the server
                byte[] receiveData = new byte[1024];
                int bytesRead = stream.Read(receiveData, 0, receiveData.Length);
                string receivedMessage = Encoding.ASCII.GetString(receiveData, 0, bytesRead);

                string[] s = receivedMessage.Split(',');

                if (s[0] == "false")
                {
                    text = "Name already taken";
                    client?.Close();
                    return false;
                }
                else
                {
                    User._UserID = int.Parse(s[1]);
                    User._username = _username.ToLower();
                    User._IsOffline = false;
                }
            }
            catch
            {
                //Nothing to do
            }

            return true;
        }

        public static bool LogInAccountRequest(string _username, string _password, out string text)
        {
            text = "";
            try
            {
                // Get the network stream from the client
                stream = client?.GetStream();

                // Send a message to the server
                string messageToSend = $"{LOGIN_ACCOUNT}\n{_username}\n{_password}";
                byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);
                stream?.Write(sendData, 0, sendData.Length);

                // Receive a response from the server
                byte[] receiveData = new byte[1024];
                int bytesRead = stream.Read(receiveData, 0, receiveData.Length);
                string receivedMessage = Encoding.ASCII.GetString(receiveData, 0, bytesRead);

                string[] s = receivedMessage.Split(',');
                if (s[0] == "-1")
                {
                    text = "Account not found";
                    client?.Close();
                    return false;
                }
                else
                {
                    User._UserID = int.Parse(s[0]);
                    User._username = s[1];
                    for (int i = 2; i < s.Length; i++)
                    {
                        User.contacts.Add(s[i]);
                    }
                    User._IsOffline = false;
                }
            }
            catch
            {
                //Nothing to do
            }

            return true;
        }

        public static void SendMessageRequest(string _sender_ID, string _receiver_Name, string _dateTime, string _message) //Sending a message to a second user through the server
        {
            try
            {
                // Send a message to the server
                string messageToSend = $"{SEND_MESSAGE}\n{_sender_ID}\n{_receiver_Name}\n{_dateTime}\n{_message}";
                byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);
                stream?.Write(sendData, 0, sendData.Length);
            }
            catch //If the process didn't work then the connection is down --> user is offline
            {
                User._IsOffline = true;
                string messageToSend = $"{SEND_MESSAGE}\\{_sender_ID}\\{_receiver_Name}\\{_dateTime}\\{_message}\n";
                if (User._username.ToLower() != _receiver_Name.ToLower())
                {
                    File.AppendAllText("PendingMessages.csv", messageToSend);
                }
            }
        }

        public static string CatchMessage(string[] s) //Take the message and process it
        {
            string text = "";
            if (User._Destination == s[1]) //Check if the user name is equal to the opened user in the application
            {
                text += $"{s[3]}[{s[1]}]: {s[4]}\n\n";
            }

            return text;
        }

        public static void AddContactRequest(string _destination) //Request to add a user to the chats
        {
            try
            {
                string messageToSend = $"{ADD_CONTACT}\n{User._UserID}\n{_destination}";
                byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);
                stream?.Write(sendData, 0, sendData.Length);
            }
            catch
            {
                User._IsOffline = true;
            }
        }

        public static bool RetrieveContactRequest(string _destination) //Read response of the AddContactRequest from the server
        {
            try
            {
                byte[] receiveData = new byte[1024];
                int bytesRead = stream.Read(receiveData, 0, receiveData.Length);
                string receivedMessage = Encoding.ASCII.GetString(receiveData, 0, bytesRead);

                string[] s = receivedMessage.Split(",");
                if (s[1] != "-1")
                {
                    return true;
                }

                return false;
            }
            catch
            {
                User._IsOffline = true;
                return false;
            }
        }


        public static List<Message> RetrieveChatRequest(List<Message> messages) //Request to retrieve a conversation with a user
        {
            try
            {
                string messageToSend = $"{RETRIEVE_MESSAGE}\n{User._UserID}\n{User._Destination}";
                byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);
                stream?.Write(sendData, 0, sendData.Length);

                byte[] receiveData = new byte[1024];
                int bytesRead = stream.Read(receiveData, 0, receiveData.Length);
                string receivedMessage = Encoding.ASCII.GetString(receiveData, 0, bytesRead);

                messages.Clear();
                if (receivedMessage != "EMPTY")
                {
                    string[] s1 = receivedMessage.Split('\\');
                    for (int i = 0; i < s1.Length; i++)
                    {
                        string[] s2 = s1[i].Split(",");
                        messages.Add(new Message(s2[0], s2[1], s2[2], s2[3]));
                    }
                }
            }
            catch
            {
                User._IsOffline = true;
            }
            return messages;
        }

        public static void Reconnect() //Trying to reconnect to the server
        {
            bool online = IsServerAvailable();
            if (online)
            {
                stream = client.GetStream();
                User._IsOffline = false;
            }
        }
    }
}
