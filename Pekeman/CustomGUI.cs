using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pekeman
{
    public partial class CustomGUI : UserControl
    {
        public CustomGUI()
        {
            InitializeComponent();
        }

        private void CustomGUI_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SolidBrush brush = new SolidBrush(Color.FromArgb(224, 32, 32, 32));

            int x1 = 2;
            int x2 = this.Width - 3;
            int y1 = 2;
            int y2 = this.Height - 3;


            g.FillRectangle(brush, 0, 0, this.Width, this.Height);
            g.DrawLine(Pens.WhiteSmoke, x1, y1, x2, x1);
            g.DrawLine(Pens.WhiteSmoke, x1, y2, x2, y2);
            g.DrawLine(Pens.WhiteSmoke, x1, y1, x1, y2);
            g.DrawLine(Pens.WhiteSmoke, x2, y1, x2, y2);
        }
    }
}
