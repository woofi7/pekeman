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
    public partial class Pekedex : CustomGUI
    {
        private Player _player;
        private Map _map;
        private List<CasePekedex> ListeCase = new List<CasePekedex>();
        public Pekedex()
        {
            InitializeComponent();
            
        }

        public void InitializePekedex(Map map)
        {
            _map = map;
            AddCasePekeList();
            NumeroterPekedex();
        }

        private void AddCasePekeList()
        {
            foreach (var c in this.Controls)
            {
                if (c is CasePekedex)
                {
                    ListeCase.Add((CasePekedex)c);
                }
                
            }
        }
      private void NumeroterPekedex()
        {
            CaseBulbusaure.LblNumI.Text = _map.PokemonList[0].Id;
            CaseCharmender.LblNumI.Text = _map.PokemonList[1].Id;
            CaseSquirtle.LblNumI.Text = _map.PokemonList[2].Id;
            CasePikachu.LblNumI.Text = _map.PokemonList[3].Id;
            CaseChikorita.LblNumI.Text = _map.PokemonList[4].Id;
            CasePidgey.LblNumI.Text = _map.PokemonList[5].Id;
            CaseRatata.LblNumI.Text = _map.PokemonList[6].Id;
            CaseMew.LblNumI.Text = _map.PokemonList[7].Id;
        }

        public void AddPeke(Pokemon peke)
        {
            
            foreach (CasePekedex casePeke in ListeCase)
            {
                if (casePeke.LblNomI.Text == peke.Name)
                {
                    casePeke.PnlImgPeke.BackgroundImage = Image.FromFile("../../Resources/" + peke.ImgBack);
                    casePeke.LblNomI.Text = peke.Name;
                    casePeke.LblTypeI.Text = peke.Name;
                    casePeke.LblCapturerI.Text = "Non";
                    casePeke.LblDescI.Text = peke.Name;
                }
            }
          
        }
    }
}
