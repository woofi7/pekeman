using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pekeman
{
    public partial class Form1 : Form
    {
        private Map map = new Map();

        private bool right;
        private bool left;
        private bool up;
        private bool down;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    left = true;
                    break;
                case Keys.D:
                case Keys.Right:
                    right = true;
                    break;
                case Keys.W:
                case Keys.Up:
                    up = true;
                    break;
                case Keys.S:
                case Keys.Down:
                    down = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    left = false;
                    break;
                case Keys.D:
                    right = false;
                    break;
                case Keys.W:
                    up = false;
                    break;
                case Keys.S:
                    down = false;
                    break;
            }
        }

        private Stopwatch _stopwatch = Stopwatch.StartNew();
        private void timer1_Tick(object sender, EventArgs e)
        {
            long ellapsed = _stopwatch.ElapsedMilliseconds;
            _stopwatch.Reset();
            _stopwatch.Restart();

            const float baseSpeed = 256; // Pixel/seconds
            float ellapsedSeconds = ellapsed / 1000f;
            float distance = 0;

            float dx = 0;
            float dy = 0;

            if (right)
            {
                distance = ellapsedSeconds * baseSpeed;
                player.Angle = 0;
            }
            else if (left)
            {
                distance = ellapsedSeconds * baseSpeed;
                player.Angle = Math.PI;
            }

            if (up)
            {
                distance = ellapsedSeconds * baseSpeed;
                player.Angle = Math.PI / 2;
                if (right)
                {
                    player.Angle -= Math.PI / 4;
                }
                else if (left)
                {
                    player.Angle += Math.PI / 4;
                }

            }
            else if (down)
            {
                distance = ellapsedSeconds * baseSpeed;
                player.Angle = 3 * Math.PI / 2;
                if (right)
                {
                    player.Angle += Math.PI / 4;
                }
                else if (left)
                {
                    player.Angle -= Math.PI / 4;
                }
            }
            player.MovPlayer(distance);
        }
    }
}
