namespace JustChat
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            ButtonDesign1 LogIn = new ButtonDesign1("Log In");
            LogIn.Location = new Point(362, 205);
            LogIn.AutoSize = true;
            ButtonDesign1 CreateAccount = new ButtonDesign1("Create an account");
            CreateAccount.Location = new Point(640, 415);
            CreateAccount.AutoSize = true;

            this.Controls.Add(LogIn);
            this.Controls.Add(CreateAccount);

            CreateAccount.Click += CreateAccount_Click;
            LogIn.Click += LogIn_Click;
        }

        private void CreateAccount_Click(object? sender, EventArgs e)
        {
            this.Hide();
            AccountCreation accountCreation = new AccountCreation();
            accountCreation.Show();
        }

        private void LogIn_Click(object? sender, EventArgs e)
        {
            string text = "";
            if (Client.IsServerAvailable())
            {
                if (Client.LogInAccountRequest(Username.Text, Password.Text, out text))
                {
                    this.Hide();
                    ChatForm chatForm = new ChatForm();
                    chatForm.Show();
                }
                else
                {
                    _warning.Text = text;
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