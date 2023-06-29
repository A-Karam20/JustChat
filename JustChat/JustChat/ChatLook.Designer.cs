namespace JustChat
{
    partial class ChatLook
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            User = new Label();
            Message = new TextBox();
            SuspendLayout();
            // 
            // User
            // 
            User.AutoSize = true;
            User.BackColor = SystemColors.WindowFrame;
            User.Dock = DockStyle.Fill;
            User.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            User.ForeColor = Color.Black;
            User.Location = new Point(0, 0);
            User.Name = "User";
            User.Size = new Size(50, 24);
            User.TabIndex = 0;
            User.Text = "User";
            // 
            // Message
            // 
            Message.BackColor = SystemColors.WindowFrame;
            Message.BorderStyle = BorderStyle.None;
            Message.Cursor = Cursors.Hand;
            Message.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Message.ForeColor = Color.Black;
            Message.Location = new Point(0, 21);
            Message.MaxLength = 10;
            Message.Name = "Message";
            Message.ReadOnly = true;
            Message.Size = new Size(137, 22);
            Message.TabIndex = 1;
            Message.Text = "MESSAGE";
            Message.TextAlign = HorizontalAlignment.Center;
            // 
            // ChatLook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            Controls.Add(Message);
            Controls.Add(User);
            Cursor = Cursors.Hand;
            Name = "ChatLook";
            Size = new Size(137, 59);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label User;
        private TextBox Message;
    }
}
