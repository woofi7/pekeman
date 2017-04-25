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
        private Player _player = new Player();

        private bool _right;
        private bool _left;
        private bool _up;
        private bool _down;

        public Form1()
        {
            InitializeComponent();
            _player.SetInitialPos(504, 364);
            map1.player = _player;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    _left = true;
                    break;
                case Keys.D:
                    _right = true;
                    break;
                case Keys.W:
                    _up = true;
                    break;
                case Keys.S:
                    _down = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    _left = false;
                    break;
                case Keys.D:
                    _right = false;
                    break;
                case Keys.W:
                    _up = false;
                    break;
                case Keys.S:
                    _down = false;
                    break;
            }
        }

        private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
        private void timer1_Tick(object sender, EventArgs e)
        {
            long ellapsed = _stopwatch.ElapsedMilliseconds;
            _stopwatch.Reset();
            _stopwatch.Restart();

            const float baseSpeed = 128; // Pixel/seconds
            float ellapsedSeconds = ellapsed / 1000f;
            float distance = 0;

            if (_right)
            {
                distance = ellapsedSeconds * baseSpeed;
                _player.Angle = 0;
            }
            else if (_left)
            {
                distance = ellapsedSeconds * baseSpeed;
                _player.Angle = Math.PI;
            }

            if (_up)
            {
                distance = ellapsedSeconds * baseSpeed;
                _player.Angle = Math.PI / 2;
                if (_right)
                {
                    _player.Angle -= Math.PI / 4;
                }
                else if (_left)
                {
                    _player.Angle += Math.PI / 4;
                }

            }
            else if (_down)
            {
                distance = ellapsedSeconds * baseSpeed;
                _player.Angle = 3 * Math.PI / 2;
                if (_right)
                {
                    _player.Angle += Math.PI / 4;
                }
                else if (_left)
                {
                    _player.Angle -= Math.PI / 4;
                }
            }
            map1.MovePlayer(distance);
        }
    }
}
