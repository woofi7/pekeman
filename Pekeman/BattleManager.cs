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
        private Map Map;
        private Pokemon Wild = new Pokemon();
        private Random rng = new Random();
        public BattleManager(Map map)
        {
            InitializeComponent();
            Map = map;
        }

        public void StartBattle()
        {
            System.Diagnostics.Debug.WriteLine("Start battle");
            DeterminerPokemon();
            Console.WriteLine(Wild.Name);
        }

        private void DeterminerPokemon()
        {
            int choix = rng.Next(0, Map.PokemonList.Length);

            Wild = Map.PokemonList.ElementAt(choix);
            
        }
    }
}
