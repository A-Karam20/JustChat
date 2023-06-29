using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustChatServer
{
    public class Message
    {
        private string sender;
        private string receiver;
        private string date;
        private string message;
        public Message(string sender, string receiver, string date, string message)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.date = date;
            this.message = message;
        }

        public void SaveMessage() //Save the message in a file named after both users
        {
            string _message = $"{sender},{receiver},{date},{message}\n";
            string path1 = $"{sender}_{receiver}.csv";
            string path2 = $"{receiver}_{sender}.csv";
            if (File.Exists(path1))
            {
                File.AppendAllText(path1, _message);
            }
            else if (File.Exists(path2))
            {
                File.AppendAllText(path2, _message);
            }
            else
            {
                File.AppendAllText(path1, _message);
            }
        }

        public static void ReadMessages(User sender, User receiver) //Read the message from a file if it exists
        {
            string default_path = "";

            string path1 = $"{sender._username}_{receiver._username}.csv";
            string path2 = $"{receiver._username}_{sender._username}.csv";
            if (File.Exists(path1))
            {
                default_path = path1;
            }
            else if (File.Exists(path2))
            {
                default_path = path2;
            }

            try
            {
                using (StreamReader sr = new StreamReader(default_path))
                {
                    sender.all_chats.Clear();
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] s = line.Split(',');
                        sender.all_chats.Add(new Message(s[0], s[1], s[2], s[3]));
                    }
                }

                DateTime today_date = DateTime.Today;
                sender.current_chat = sender.all_chats.Where(c => (Convert.ToDateTime(c.date) - today_date).TotalSeconds > 0); //Only load today's messages
            }
            catch
            {
                sender.current_chat = null;
            }
        }

        public static string Handle_Message(string sender_ID, string receiver_Name, string dateTime, string message) //Handle the message sent by a user
        {
            string MessageToSend = "";
            string sender_Name = User.users[int.Parse(sender_ID)]._username; //Get the name of the sender
            int receiver_ID = User.FindUserID(receiver_Name); //Get the ID of the receiver
            if (receiver_ID != -1)
            {
                Message _message = new Message(sender_Name, receiver_Name, dateTime, message);
                _message.SaveMessage();
            }

            MessageToSend += $"{sender_Name},{receiver_Name},{dateTime},{message}";

            return MessageToSend;
        }

        public static string Retrieve_Conversation(string sender_ID, string receiver_Name) //Retrieve a conversation between two users
        {
            string MessageToSend = "EMPTY";
            int receiver_ID = User.FindUserID(receiver_Name);
            ReadMessages(User.users[int.Parse(sender_ID)], User.users[receiver_ID]);

            if (User.users[int.Parse(sender_ID)].current_chat != null && User.users[int.Parse(sender_ID)].current_chat.Any())
            {
                MessageToSend = "";
                foreach (Message m in User.users[int.Parse(sender_ID)].current_chat)
                {
                    MessageToSend += $"{m.sender},{m.receiver},{m.date},{m.message}\\";
                }
            }

            MessageToSend = MessageToSend.Trim('\\');

            return MessageToSend;
        }
    }
}
