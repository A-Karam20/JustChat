using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JustChat
{
    public partial class AccountCreation : Form
    {
        public AccountCreation()
        {
            InitializeComponent();
        }

        private void AccountCreation_Load(object sender, EventArgs e)
        {
            ButtonDesign1 CreateAccount = new ButtonDesign1("Create");
            CreateAccount.Location = new Point(360, 270);
            CreateAccount.AutoSize = true;
            ButtonDesign1 Return = new ButtonDesign1("Return");
            Return.Location = new Point(2, 415);
            Return.AutoSize = true;

            this.Controls.Add(Return);
            this.Controls.Add(CreateAccount);

            Return.Click += Return_Click;
            CreateAccount.Click += CreateAccount_Click;
        }

        private void Return_Click(object? sender, EventArgs e)
        {
            this.Close();
            LogIn logIn = new LogIn();
            logIn.Show();
        }

        private void CreateAccount_Click(object? sender, EventArgs e)
        {
            string text = "";
            if (Password.Text == "" || Username.Text == "")
            {
                text = "Please fill all boxes";
                _warning.Text = text;
            }
            else
            {
                if (Client.IsServerAvailable())
                {
                    if (!Client.CreateAccountRequest(Username.Text, Password.Text, out text))
                    {
                        text = "Name already taken";
                        _warning.Text = text;
                    }
                    else
                    {
                        this.Close();
                        ChatForm chatForm = new ChatForm();
                        chatForm.Show();
                    }
                }
                else
                {
                    text = "Server not available";
                    _warning.Text = text;
                }
            }
        }
    }
}
