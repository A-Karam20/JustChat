namespace JustChat
{
    partial class ContactsLook
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
            nameBtn = new Button();
            SuspendLayout();
            // 
            // nameBtn
            // 
            nameBtn.BackColor = Color.PaleTurquoise;
            nameBtn.Cursor = Cursors.Hand;
            nameBtn.FlatStyle = FlatStyle.Popup;
            nameBtn.Font = new Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            nameBtn.ForeColor = Color.Black;
            nameBtn.Location = new Point(0, 0);
            nameBtn.Margin = new Padding(0);
            nameBtn.Name = "nameBtn";
            nameBtn.Size = new Size(108, 115);
            nameBtn.TabIndex = 0;
            nameBtn.Text = "Name";
            nameBtn.UseVisualStyleBackColor = false;
            // 
            // ContactsLook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.PaleTurquoise;
            Controls.Add(nameBtn);
            Margin = new Padding(2);
            Name = "ContactsLook";
            Size = new Size(108, 115);
            ResumeLayout(false);
        }

        #endregion

        private Button nameBtn;
    }
}
