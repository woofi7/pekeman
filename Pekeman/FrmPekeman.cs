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
    public partial class FrmPekeman : Form
    {
        private Player _player = new Player();

        public bool _right;
        public bool _left;
        public bool _up;
        public bool _down;

        public FrmPekeman()
        {
            InitializeComponent();
            map1.player = _player;
            ControlPanel.InitializeControlPanel(this);
        }

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    _left = true;
                    break;
                case Keys.D:
                case Keys.Right:
                    _right = true;
                    break;
                case Keys.W:
                case Keys.Up:
                    _up = true;
                    break;
                case Keys.S:
                case Keys.Down:
                    _down = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    _left = false;
                    break;
                case Keys.D:
                case Keys.Right:
                    _right = false;
                    break;
                case Keys.W:
                case Keys.Up:
                    _up = false;
                    break;
                case Keys.S:
                case Keys.Down:
                    _down = false;
                    break;
                case Keys.F3:
                    Debug.DebugMode = !Debug.DebugMode;
                    map1.Refresh();
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

            else if (_up)
            {
                distance = ellapsedSeconds * baseSpeed;
                _player.Angle = Math.PI / 2;
            }
            else if (_down)
            {
                distance = ellapsedSeconds * baseSpeed;
                _player.Angle = 3 * Math.PI / 2;
            }
            map1.MovePlayer(distance);
        }

        private void DeplacementJoueur_Tick(object sender, EventArgs e)
        {
            _player.MovementAnimation++;

            if (_player.MovementAnimation == 3)
            {
                _player.MovementAnimation = 0;
            }
        }
    }
}
