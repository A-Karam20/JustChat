using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace JustChat
{
    public partial class ChatLook : UserControl
    {
        private static readonly int x = 3;
        private static Color borderColor = Color.White;
        public ChatLook(string _Name, int y)
        {
            InitializeComponent();
            User.Text = _Name;
            User.AutoSize = true;
            Message.Text = "new";
            Message.AutoSize = true;
            Message.Enabled = false;

            this.Location = new Point(x, y);

            this.Name = User.Text = _Name;
        }

        public ChatLook(string _Name, string _Message, int y)
        {
            InitializeComponent();
            User.Text = _Name;
            Message.Text = _Message;
            User.AutoSize = true;
            Message.AutoSize = true;
            Message.Enabled = false;

            this.Location = new Point(x, y);

            this.Name = User.Text = _Name;
        }

        protected override void OnPaint(PaintEventArgs e) //Change the border
        {
            base.OnPaint(e);

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, borderColor, ButtonBorderStyle.Solid);
        }

        public void ChangeBackgroundColor() //Change the backcolor
        {
            this.BackColor = Color.PaleTurquoise;
            foreach (Control control in this.Controls)
            {
                control.BackColor = Color.PaleTurquoise;
            }
        }

        public void ResetBackgroundColor() //Reset the backcolor to its default color
        {
            this.BackColor = Color.FromKnownColor(KnownColor.WindowFrame);
            foreach (Control control in this.Controls)
            {
                control.BackColor = Color.FromKnownColor(KnownColor.WindowFrame);
            }
        }
    }
}
