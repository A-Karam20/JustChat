using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace JustChat
{
    public class Message
    {
        private string sender;
        private string receiver;
        private string date;
        private string message;

        public string _sender
        {
            get
            {
                return sender;
            }
        }

        public string _receiver
        {
            get
            {
                return receiver;
            }
        }

        public string _date
        {
            get
            {
                return date;
            }
        }

        public string _message
        {
            get
            {
                return message;
            }
        }
        public Message(string sender, string receiver, string date, string message)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.date = date;
            this.message = message;
        }
    }
}
