using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JustChatServer
{
    class Server
    {
        private const string CREATE_ACCOUNT = "CREATE_ACCOUNT";
        private const string SEND_MESSAGE = "SEND_MESSAGE";
        private const string LOGIN_ACCOUNT = "LOGIN_ACCOUNT";
        private const string RETRIEVE_MESSAGE = "RETRIEVE_MESSAGE";
        private const string ADD_CONTACT = "ADD_CONTACT";
        public static void Main(string[] args)
        {
            User.ReadUser();
            User.GetContacts();

            TcpListener? listener = null;
            try
            {
                // Set the IP address and port on which the server will listen
                IPAddress ipAddress = IPAddress.Any; // Listen on any IP address
                int port = 40000;

                // Create a TcpListener to listen for incoming connections
                listener = new TcpListener(ipAddress, port);
                listener.Start();
                Console.WriteLine("Server started. Waiting for connections...");

                bool valid = true;
                while (valid) //Keep on checking for a client
                {
                    // Accept client connections
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Client connected.");


                   Thread newThread = new Thread(() => Handle_Client(client)); //Handle the client on a different thread
                   newThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                listener?.Stop();
            }
        }

        public static void Handle_Client(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            bool valid = true;
            while (valid)
            {
                try
                {
                    byte[] buffer = new byte[1024];

                    // Read the data from the stream
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    // Convert the received data to a string
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received message: " + message);
                    string[] s = message.Split("\n");
                    if (s[0] == SEND_MESSAGE) //Check what kind of request
                    {
                        string messageToSend = Message.Handle_Message(s[1], s[2], s[3], s[4]);
                        int receiver_ID = User.FindUserID(s[2]);
                        if (User.clientStreams.ContainsKey(receiver_ID))
                        {
                            messageToSend = messageToSend.Insert(0, SEND_MESSAGE + ",");
                            Send_Response(User.clientStreams[receiver_ID], messageToSend);
                        }

                    }
                    else if (s[0] == LOGIN_ACCOUNT)
                    {
                        string messageToSend = $"{User.Check_Account(s[1], s[2], stream)}";
                        Send_Response(stream, messageToSend);
                        Throw_Exception(messageToSend, "-1", "Account not valid");
                    }
                    else if (s[0] == CREATE_ACCOUNT)
                    {
                        int CurrentID;
                        string messageToSend = $"{User.Check_Username(s[1], s[2], stream, out CurrentID)},{CurrentID}";
                        Send_Response(stream, messageToSend);
                        Throw_Exception(messageToSend, "false", "Name not valid");
                    }
                    else if (s[0] == RETRIEVE_MESSAGE)
                    {
                        string messageToSend = Message.Retrieve_Conversation(s[1], s[2]);
                        Send_Response(stream, messageToSend);
                    }
                    else if (s[0] == ADD_CONTACT)
                    {
                        string messageToSend;
                        int User_ID = User.FindUserID(s[2]);
                        bool IsContain = false;
                        for (int i = 0; i < User.users[int.Parse(s[1])].contacts.Count; i++)
                        {
                            if (User.users[int.Parse(s[1])].contacts[i].ToLower() == s[2].ToLower())
                            {
                                IsContain = true;
                            }
                        }

                        if (!IsContain && User_ID != -1)
                        {
                            User.users[int.Parse(s[1])].contacts.Add(s[2]);
                            User.SaveContacts();
                        }

                        messageToSend = $"{ADD_CONTACT},{User_ID}";
                        Send_Response(stream, messageToSend);
                    }
                    else
                    {
                        throw new Exception("Couldn't find command type");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    stream.Close();
                    valid = false;
                    int key = -1;
                    foreach (KeyValuePair<int,NetworkStream> kvp in User.clientStreams)
                    {
                        if (kvp.Value == stream)
                        {
                            key = kvp.Key;
                            break;
                        }
                    }

                    if (key != -1)
                    {
                        User.clientStreams.Remove(key);
                    }
                }
            }
        }

        public static void Send_Response(NetworkStream stream, string messageToSend)
        {
            byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);
            stream.Write(sendData, 0, sendData.Length);
            Console.WriteLine("Sent message: " + messageToSend);
        }

        public static void Throw_Exception(string expect, string answer, string text)
        {
            if (expect == answer)
            {
                throw new Exception(text);
            }
        }
    }
}