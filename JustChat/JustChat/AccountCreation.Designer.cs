namespace JustChat
{
    partial class AccountCreation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _password = new Label();
            _username = new Label();
            Password = new TextBox();
            Username = new TextBox();
            MainLabel = new Label();
            _status = new Label();
            Status = new TextBox();
            _optional = new Label();
            _warning = new Label();
            SuspendLayout();
            // 
            // _password
            // 
            _password.AutoSize = true;
            _password.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _password.ForeColor = SystemColors.Control;
            _password.Location = new Point(353, 148);
            _password.Name = "_password";
            _password.Size = new Size(100, 24);
            _password.TabIndex = 12;
            _password.Text = "Password:";
            // 
            // _username
            // 
            _username.AutoSize = true;
            _username.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _username.ForeColor = SystemColors.Control;
            _username.Location = new Point(351, 89);
            _username.Name = "_username";
            _username.Size = new Size(102, 24);
            _username.TabIndex = 11;
            _username.Text = "Username:";
            // 
            // Password
            // 
            Password.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Password.Location = new Point(332, 175);
            Password.Name = "Password";
            Password.PasswordChar = '*';
            Password.Size = new Size(133, 23);
            Password.TabIndex = 10;
            // 
            // Username
            // 
            Username.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Username.Location = new Point(332, 116);
            Username.MaxLength = 10;
            Username.Name = "Username";
            Username.Size = new Size(133, 23);
            Username.TabIndex = 9;
            // 
            // MainLabel
            // 
            MainLabel.AutoSize = true;
            MainLabel.Font = new Font("Unispace", 18F, FontStyle.Bold, GraphicsUnit.Point);
            MainLabel.ForeColor = SystemColors.Control;
            MainLabel.Location = new Point(138, 20);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new Size(538, 29);
            MainLabel.TabIndex = 8;
            MainLabel.Text = "Create your account and join others";
            // 
            // _status
            // 
            _status.AutoSize = true;
            _status.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _status.ForeColor = SystemColors.Control;
            _status.Location = new Point(362, 204);
            _status.Name = "_status";
            _status.Size = new Size(71, 24);
            _status.TabIndex = 14;
            _status.Text = "Status:";
            // 
            // Status
            // 
            Status.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Status.Location = new Point(332, 230);
            Status.MaxLength = 25;
            Status.Name = "Status";
            Status.Size = new Size(133, 23);
            Status.TabIndex = 13;
            // 
            // _optional
            // 
            _optional.AutoSize = true;
            _optional.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _optional.ForeColor = SystemColors.Control;
            _optional.Location = new Point(471, 230);
            _optional.Name = "_optional";
            _optional.Size = new Size(99, 24);
            _optional.TabIndex = 15;
            _optional.Text = "(Optional)";
            // 
            // _warning
            // 
            _warning.AutoSize = true;
            _warning.Font = new Font("Unispace", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            _warning.ForeColor = SystemColors.Control;
            _warning.Location = new Point(195, 380);
            _warning.Name = "_warning";
            _warning.Size = new Size(0, 23);
            _warning.TabIndex = 16;
            _warning.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AccountCreation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(800, 450);
            Controls.Add(_warning);
            Controls.Add(_optional);
            Controls.Add(_status);
            Controls.Add(Status);
            Controls.Add(_password);
            Controls.Add(_username);
            Controls.Add(Password);
            Controls.Add(Username);
            Controls.Add(MainLabel);
            Name = "AccountCreation";
            Text = "AccountCreation";
            Load += AccountCreation_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label _password;
        private Label _username;
        private TextBox Password;
        private TextBox Username;
        private Label MainLabel;
        private Label _status;
        private TextBox Status;
        private Label _optional;
        private Label _warning;
    }
}