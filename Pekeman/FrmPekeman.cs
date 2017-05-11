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
        private readonly Player _player = new Player();
        private Npc _npc = new Npc();

        public bool RightMovement;
        public bool LeftMovement;
        public bool UpMovement;
        public bool DownMovement;
        public bool OptionsMenu;

        public FrmPekeman()
        {
            InitializeComponent();
            
            MapPeke.player = _player;
            MapPeke.npc = _npc;
            _npc._mapData = MapPeke._mapData;
            ControlPanel.InitializeControlPanel(this);
        }

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    LeftMovement = true;
                    break;
                case Keys.D:
                case Keys.Right:
                    RightMovement = true;
                    break;
                case Keys.W:
                case Keys.Up:
                    UpMovement = true;
                    break;
                case Keys.S:
                case Keys.Down:
                    DownMovement = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    LeftMovement = false;
                    break;
                case Keys.D:
                case Keys.Right:
                    RightMovement = false;
                    break;
                case Keys.W:
                case Keys.Up:
                    UpMovement = false;
                    break;
                case Keys.S:
                case Keys.Down:
                    DownMovement = false;
                    break;
                case Keys.F3:
                    Debug.DebugMode = !Debug.DebugMode;
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

            if (RightMovement)
            {
                distance = ellapsedSeconds * baseSpeed;
                _player.Angle = 0;
            }
            else if (LeftMovement)
            {
                distance = ellapsedSeconds * baseSpeed;
                _player.Angle = Math.PI;
            }

            else if (UpMovement)
            {
                distance = ellapsedSeconds * baseSpeed;
                _player.Angle = Math.PI / 2;
            }
            else if (DownMovement)
            {
                distance = ellapsedSeconds * baseSpeed;
                _player.Angle = 3 * Math.PI / 2;
            }
            MapPeke.MovePlayer(distance);

            Refresh();
        }

        private void Deplacement_Tick(object sender, EventArgs e)
        {
            if (RightMovement || LeftMovement || UpMovement || DownMovement)
            {
                _player.MovementAnimation++;

                if (_player.MovementAnimation == 3)
                {
                    _player.MovementAnimation = 0;
                }
            }

            _npc.UpdateMovementAnimation();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
