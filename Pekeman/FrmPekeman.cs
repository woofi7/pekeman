using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Pekeman.Entity;

namespace Pekeman
{
    public partial class FrmPekeman : Form
    {
        public Player ThePlayer;
        private FrmMainMenu _menu;
        public Pokemon[] PokemonList;
        
        public Pekedex Pekedex;
        public CapturedPekeman CapPeke;
        public bool OptionsMenu;

        public FrmPekeman(FrmMainMenu menu) : this()
        {
            _menu = menu;
        }

        public FrmPekeman()
        {
            Pekedex = new Pekedex();
            
            InitializeComponent();
            InitializeFrmPekeman();
        }

        private void InitializeFrmPekeman()
        {
            LoadPokemon();
            WinStart.InitializeWinStart(this);
            MapPeke.InitializeMap(this);
            Pekedex.InitializePekedex(MapPeke);
            ControlPanel.InitializeControlPanel(this);
            CapPeke = new CapturedPekeman(this);
        }

        public void LoadPokemon()
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();

                using (StreamReader sw = new StreamReader("../../../pekeman.json"))
                using (JsonReader reader = new JsonTextReader(sw))
                {
                    PokemonList = serializer.Deserialize<Pokemon[]>(reader);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ThePlayer.KeyPress(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            ThePlayer.KeyPress(e.KeyCode, false);
        }


        private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
        /// <summary>
        /// Tick pour le déplacement du joueur dans la map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            long ellapsed = _stopwatch.ElapsedMilliseconds;
            _stopwatch.Reset();
            _stopwatch.Restart();
            double ellapsedSeconds = ellapsed / 1000f;

            ThePlayer.MovePlayer(ellapsedSeconds);
            Refresh();
        }

        /// <summary>
        /// Tick pour le déplacement des membre de l'entité.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Deplacement_Tick(object sender, EventArgs e)
        {
            ThePlayer.UpdateMovementAnimation();

            foreach (Npc npc in Npc.NpcList)
            {
                npc.UpdateMovementAnimation();
            }
        }

        public void ShowPekedex(bool i)
        {
            if (i)
            {
                Pekedex.Location = new Point(0, 0);
                MapPeke.Controls.Add(Pekedex);
                Pekedex.Visible = true;
            }
            else
            {
                Pekedex.Visible = false;
            }

        }
    }
}
