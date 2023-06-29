namespace JustChat
{
    partial class ChatForm
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
            TabControl = new TabControl();
            Chat = new TabPage();
            ShowMessages = new RichTextBox();
            TypingBar = new RichTextBox();
            panel1 = new Panel();
            Contacts = new TabPage();
            Settings = new TabPage();
            ChatPanel = new Panel();
            AddChat = new Button();
            TabControl.SuspendLayout();
            Chat.SuspendLayout();
            SuspendLayout();
            // 
            // TabControl
            // 
            TabControl.Controls.Add(Chat);
            TabControl.Controls.Add(Contacts);
            TabControl.Controls.Add(Settings);
            TabControl.Location = new Point(161, 12);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(627, 419);
            TabControl.TabIndex = 0;
            // 
            // Chat
            // 
            Chat.BackColor = Color.FromArgb(35, 35, 35);
            Chat.Controls.Add(ShowMessages);
            Chat.Controls.Add(TypingBar);
            Chat.Controls.Add(panel1);
            Chat.ForeColor = SystemColors.Control;
            Chat.Location = new Point(4, 24);
            Chat.Name = "Chat";
            Chat.Padding = new Padding(3);
            Chat.Size = new Size(619, 391);
            Chat.TabIndex = 0;
            Chat.Text = "Chat";
            Chat.Click += Chat_Click;
            // 
            // ShowMessages
            // 
            ShowMessages.BackColor = Color.FromArgb(35, 35, 35);
            ShowMessages.BorderStyle = BorderStyle.None;
            ShowMessages.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ShowMessages.ForeColor = SystemColors.Window;
            ShowMessages.Location = new Point(3, 3);
            ShowMessages.Name = "ShowMessages";
            ShowMessages.ReadOnly = true;
            ShowMessages.Size = new Size(613, 355);
            ShowMessages.TabIndex = 3;
            ShowMessages.Text = "";
            // 
            // TypingBar
            // 
            TypingBar.BorderStyle = BorderStyle.None;
            TypingBar.Dock = DockStyle.Bottom;
            TypingBar.Enabled = false;
            TypingBar.Location = new Point(3, 364);
            TypingBar.Name = "TypingBar";
            TypingBar.Size = new Size(613, 24);
            TypingBar.TabIndex = 2;
            TypingBar.Text = "";
            // 
            // panel1
            // 
            panel1.Location = new Point(-207, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(136, 395);
            panel1.TabIndex = 0;
            // 
            // Contacts
            // 
            Contacts.BackColor = Color.FromArgb(35, 35, 35);
            Contacts.ForeColor = SystemColors.Control;
            Contacts.Location = new Point(4, 24);
            Contacts.Name = "Contacts";
            Contacts.Padding = new Padding(3);
            Contacts.Size = new Size(619, 391);
            Contacts.TabIndex = 1;
            Contacts.Text = "Contacts";
            Contacts.Click += Contacts_Click;
            // 
            // Settings
            // 
            Settings.BackColor = Color.FromArgb(35, 35, 35);
            Settings.ForeColor = SystemColors.Control;
            Settings.Location = new Point(4, 24);
            Settings.Name = "Settings";
            Settings.Padding = new Padding(3);
            Settings.Size = new Size(619, 391);
            Settings.TabIndex = 2;
            Settings.Text = "Settings";
            Settings.Click += Settings_Click;
            // 
            // ChatPanel
            // 
            ChatPanel.BackColor = SystemColors.WindowFrame;
            ChatPanel.Location = new Point(12, 36);
            ChatPanel.Name = "ChatPanel";
            ChatPanel.Size = new Size(143, 395);
            ChatPanel.TabIndex = 1;
            // 
            // AddChat
            // 
            AddChat.BackColor = SystemColors.ButtonShadow;
            AddChat.Location = new Point(12, 12);
            AddChat.Name = "AddChat";
            AddChat.Size = new Size(143, 23);
            AddChat.TabIndex = 1;
            AddChat.Text = "Add Chat";
            AddChat.UseVisualStyleBackColor = false;
            AddChat.Click += AddChat_Click;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 34, 34);
            ClientSize = new Size(800, 450);
            Controls.Add(AddChat);
            Controls.Add(ChatPanel);
            Controls.Add(TabControl);
            Name = "ChatForm";
            Text = "ChatForm";
            Load += ChatForm_Load;
            TabControl.ResumeLayout(false);
            Chat.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabControl;
        private TabPage Chat;
        private TabPage Contacts;
        private TabPage Settings;
        private Panel panel1;
        private Panel ChatPanel;
        private Button AddChat;
        private RichTextBox TypingBar;
        private RichTextBox ShowMessages;
    }
}