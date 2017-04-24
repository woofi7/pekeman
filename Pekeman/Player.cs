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
    public partial class Player : UserControl
    {
        private double _x
        {
            get;
            set;
        }

        private double _y {
            get;
            set;
        }

        public double Angle { get; set; }

        public double Speed { get; set; } = 1;
        public Player()
        {
            InitializeComponent();
        }


        public void MovPlayer(float distance)
        {
            _x += distance * Speed * Math.Cos(Angle);
            _y -= distance * Speed * Math.Sin(Angle);
            Top = (int) _y;
            Left = (int) _x;
        }

    }
}