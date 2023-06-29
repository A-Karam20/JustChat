namespace JustChat
{
    partial class LogIn
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            MainLabel = new Label();
            Username = new TextBox();
            Password = new TextBox();
            _username = new Label();
            _password = new Label();
            _warning = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // MainLabel
            // 
            MainLabel.AutoSize = true;
            MainLabel.Font = new Font("Unispace", 18F, FontStyle.Bold, GraphicsUnit.Point);
            MainLabel.ForeColor = SystemColors.Control;
            MainLabel.Location = new Point(333, 15);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new Size(133, 29);
            MainLabel.TabIndex = 1;
            MainLabel.Text = "JustChat";
            // 
            // Username
            // 
            Username.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Username.Location = new Point(333, 111);
            Username.MaxLength = 10;
            Username.Name = "Username";
            Username.Size = new Size(133, 23);
            Username.TabIndex = 4;
            // 
            // Password
            // 
            Password.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Password.Location = new Point(333, 170);
            Password.Name = "Password";
            Password.PasswordChar = '*';
            Password.Size = new Size(133, 23);
            Password.TabIndex = 5;
            // 
            // _username
            // 
            _username.AutoSize = true;
            _username.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _username.ForeColor = SystemColors.Control;
            _username.Location = new Point(352, 84);
            _username.Name = "_username";
            _username.Size = new Size(102, 24);
            _username.TabIndex = 6;
            _username.Text = "Username:";
            // 
            // _password
            // 
            _password.AutoSize = true;
            _password.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _password.ForeColor = SystemColors.Control;
            _password.Location = new Point(354, 143);
            _password.Name = "_password";
            _password.Size = new Size(100, 24);
            _password.TabIndex = 7;
            _password.Text = "Password:";
            // 
            // _warning
            // 
            _warning.AutoSize = true;
            _warning.Font = new Font("Unispace", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            _warning.ForeColor = SystemColors.Control;
            _warning.Location = new Point(298, 284);
            _warning.Name = "_warning";
            _warning.Size = new Size(0, 23);
            _warning.TabIndex = 8;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(800, 450);
            Controls.Add(_warning);
            Controls.Add(_password);
            Controls.Add(_username);
            Controls.Add(Password);
            Controls.Add(Username);
            Controls.Add(MainLabel);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LogIn";
            Text = "Log In";
            Load += LogIn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label MainLabel;
        private TextBox Username;
        private TextBox Password;
        private Label _username;
        private Label _password;
        private Label _warning;
    }
}