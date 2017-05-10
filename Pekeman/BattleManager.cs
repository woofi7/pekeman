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
    public partial class BattleManager : UserControl
    {
        private Map _Map;
        private Pokemon Wild;
        private Pokemon Hero;
        private Random rng = new Random();
        public BattleManager(Map map)
        {
            InitializeComponent();
            
            _Map = map;
            Hero = new Pokemon();
            
            
        }

        public void StartBattle()
        {
            Wild = new Pokemon();
            System.Diagnostics.Debug.WriteLine("Start battle");
            DeterminerPokemon();
            PnlWild.BackgroundImage = Image.FromFile("../../Resources/" + Wild.ImgFront);
            this.Visible = true;
            placerComp();
        }

        private void DeterminerPokemon()
        {
            int choix = rng.Next(0, _Map.PokemonList.Length);
            Wild = _Map.PokemonList.ElementAt(choix);
            
        }
        private void placerComp()
        {
            Hero = _Map.PokemonList.ElementAt(1);
            PnlPeke.BackgroundImage = Image.FromFile("../../Resources/" + Hero.ImgBack);
            Point p = new Point(_Map.Size.Width/2-this.Size.Width/2, _Map.Size.Height / 2 - this.Size.Height / 2);
            Console.WriteLine(p);
            this.Location = p;
        }

        private void BtnAttack_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void BtnRun_Click(object sender, EventArgs e)
        {

        }
    }
}
