using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JustChat
{
    public partial class ContactsLook : UserControl
    {
        private static int x = 2;
        private static int y = 2;
        private static readonly int max = 540;
        public ContactsLook(string name)
        {
            InitializeComponent();
            nameBtn.Text = name;
            this.Location = SetLocation();
        }

        private Point SetLocation()
        {
            if (x > max)
            {
                x = 2;
                y += 50;
            }

            Point point = new Point(x, y);
            x += 110;

            return point;
        }

        public static void ResetCoordinates()
        {
            x = 2;
            y = 2;
        }
    }
}
