using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace JustChat
{
    public partial class ChatForm : Form
    {
        private TextBox ChatInput = new TextBox();

        private readonly int VerticalSpace = 70;

        private int Jump = 12;

        private Thread new_thread;

        private bool IsReading = true;

        public ChatForm()
        {
            InitializeComponent();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            ChatPanel.MouseClick += ChatPanel_MouseClick;

            ChatInput.Location = new Point(12, 12);
            ChatInput.Size = new Size(143, 23);
            ChatInput.Visible = false;
            ChatInput.KeyDown += ChatInput_Click;

            this.Controls.Add(ChatInput);

            Jump = 12;

            for (int i = 0; i < User.contacts.Count; i++)
            {
                ChatLook chatLook = new ChatLook(User.contacts[i], Jump);
                ChatPanel.Controls.Add(chatLook);
                Jump += VerticalSpace;
            }

            foreach (Control control in ChatPanel.Controls)
            {
                if (control is ChatLook)
                {
                    control.Click += ChatLook_OnClick;
                }
            }

            TypingBar.KeyDown += On_Enter;

            new_thread = new Thread(() => ListenForResponse(Client._stream));
            new_thread.Start();
        }

        private void ChatPanel_MouseClick(object? sender, MouseEventArgs e)
        {
            TypingBar.Enabled = false;
            ShowMessages.Clear();
            foreach (ChatLook CL in ChatPanel.Controls)
            {
                CL.ResetBackgroundColor();
            }
            User._Destination = "";
        }

        private void ListenForResponse(NetworkStream stream)
        {
            bool valid = true;
            while (valid)
            {
                if (IsReading == false) //Prevent it from reading data meant for other threads and methods
                {
                    if (stream.DataAvailable) //Prevent it from getting stuck at stream.Read
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        string[] s = message.Split(",");
                        if (s[0] == Client.SEND_MESSAGE)
                        {
                            string receivedText = Client.CatchMessage(s);
                            if (receivedText != "")
                            {
                                UpdateShowMessages(receivedText);
                            }
                            else if (User._Destination != s[1])
                            {
                                SaveContact(s[1]);
                            }
                        }
                    }

                    if (User._IsOffline == true)
                    {
                        Client.Reconnect();
                    }
                }
            }
        }

        private void UpdateShowMessages(string receivedText) //Invoke this method on the UI thread since ShowMessages is declared on the mainthread not the one using this method
        {
            ShowMessages.BeginInvoke(new Action(() => ShowMessages.Text += receivedText));
        }
        private void AddChat_Click(object sender, EventArgs e)
        {
            AddChat.Visible = false;
            ChatInput.Visible = true;
        }

        private void Chat_Click(object sender, EventArgs e)
        {
            ShowMessages.Clear();
            User._Destination = "";
        }

        private void Contacts_Click(object sender, EventArgs e)
        {
            Contacts.Controls.Clear();
            ContactsLook.ResetCoordinates();
            foreach (string name in User.contacts)
            {
                ContactsLook contactsLook = new ContactsLook(name);
                Contacts.Controls.Add(contactsLook);
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

        private void Print_Message()
        {
            ShowMessages.Clear();
            if (User.current_Chat != null)
            {
                foreach (Message message in User.current_Chat)
                {
                    if (message._sender.ToLower() == User._username.ToLower())
                    {
                        ShowMessages.Text += $"{message._date}[{message._sender}]: {message._message}\n\n";
                    }
                    else
                    {
                        ShowMessages.Text += $"{message._date}[{message._sender}]: {message._message}\n\n";
                    }
                }
            }
        }

        private void On_Enter(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TypingBar.Text = TypingBar.Text.Trim();
                string _text = TypingBar.Text;
                if (TypingBar.Text != "")
                {
                    Message message = new Message(User._username, User._Destination, DateTime.Now.ToString(), _text);
                    ShowMessages.Text += $"{message._date}[{message._sender}]: {message._message}\n\n";
                    Client.SendMessageRequest(User._UserID.ToString(), User._Destination, message._date, message._message);
                    TypingBar.Clear();
                }
            }
        }

        private void ChatLook_OnClick(object? sender, EventArgs e)
        {
            TypingBar.Enabled = true;
            IsReading = true;
            ShowMessages.Clear();
            if (sender != null)
            {
                foreach (ChatLook CL in ChatPanel.Controls)
                {
                    CL.ResetBackgroundColor();
                }
                ChatLook? chatLook = (ChatLook)sender;
                chatLook.ChangeBackgroundColor();
                User._Destination = chatLook.Name;
            }

            if (User._Destination != "")
            {
                User.current_Chat = Client.RetrieveChatRequest(User.current_Chat);
                Print_Message();
            }
            IsReading = false;

            if (User._IsOffline == true)
            {
                ShowMessages.Clear();
            }
        }

        private void ChatInput_Click(object? sender, KeyEventArgs e)
        {
            IsReading = true;
            if (e.KeyCode == Keys.Enter)
            {
                string _Destination = ChatInput.Text;
                Client.AddContactRequest(_Destination);
                bool AddContact = Client.RetrieveContactRequest(_Destination);
                if (AddContact)
                {
                    bool valid = true;
                    foreach (Control control in ChatPanel.Controls)
                    {
                        if (control is ChatLook)
                        {
                            if (control.Name == ChatInput.Text)
                            {
                                valid = false;
                            }
                        }
                    }

                    if (valid)
                    {
                        ChatLook chatlook = new ChatLook(_Destination, "new", Jump);
                        ChatPanel.Controls.Add(chatlook);
                        chatlook.Click += ChatLook_OnClick;
                        Jump += VerticalSpace;
                        User.contacts.Add(_Destination);
                    }
                }
                ChatInput.Clear();
                ChatInput.Visible = false;
                AddChat.Visible = true;
            }
            IsReading = false;
        }

        private void SaveContact(string contact) //Save the contact that talked to him
        {
            string _Destination = contact;
            Client.AddContactRequest(_Destination);
            bool AddContact = Client.RetrieveContactRequest(_Destination);
            if (AddContact)
            {
                bool valid = true;
                foreach (Control control in ChatPanel.Controls)
                {
                    if (control is ChatLook)
                    {
                        if (control.Name == contact)
                        {
                            valid = false;
                        }
                    }
                }

                if (valid)
                {
                    ChatLook chatlook = new ChatLook(_Destination, "new", Jump);
                    ChatPanel.BeginInvoke(new Action(() => ChatPanel.Controls.Add(chatlook)));
                    chatlook.Click += ChatLook_OnClick;
                    Jump += VerticalSpace;
                    User.contacts.Add(_Destination);
                }
            }
        }
    }
}
