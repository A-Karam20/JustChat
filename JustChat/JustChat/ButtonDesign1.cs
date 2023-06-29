using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustChat
{
    public class ButtonDesign1 : Button
    {
        public ButtonDesign1(string Text)
        {
            this.Text = Text;
        }

        protected override void OnPaint(PaintEventArgs pevent) //Change the look of the button
        {
            GraphicsPath path = new GraphicsPath();
            int borderRadius = 10; // Adjust the border radius as desired

            // Create a rounded rectangle shape
            path.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
            path.AddLine(borderRadius, 0, Width - borderRadius, 0);
            path.AddArc(Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
            path.AddLine(Width, borderRadius, Width, Height - borderRadius);
            path.AddArc(Width - borderRadius * 2, Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
            path.AddLine(Width - borderRadius, Height, borderRadius, Height);
            path.AddArc(0, Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
            path.AddLine(0, Height - borderRadius, 0, borderRadius);

            Region = new Region(path);

            ForeColor = Color.Black;
            BackColor = Color.White;

            Font = new Font(Font.FontFamily, 12, FontStyle.Bold);

            base.OnPaint(pevent);
        }
    }
}
