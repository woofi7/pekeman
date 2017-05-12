using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pekeman.Entity;
using Pekeman.Map2;

namespace Pekeman
{
    public partial class Pekedex : CustomGUI
    {
        private Player _player;
        private Map _map;
        public List<CasePekedex> ListeCase = new List<CasePekedex>();
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
            ListeCase.Add(CaseBulbusaure);
            ListeCase.Add(CaseCharmender);
            ListeCase.Add(CaseSquirtle);
            ListeCase.Add(CaseCaterpie);
            ListeCase.Add(CasePidgey);
            ListeCase.Add(CaseRattata);
            ListeCase.Add(CasePikachu);
            ListeCase.Add(CaseChikorita);
        }

      private void NumeroterPekedex()
        {
            CaseBulbusaure.LblNumI.Text = _map.FrmPekeman.PokemonList[0].Id;
            CaseCharmender.LblNumI.Text = _map.FrmPekeman.PokemonList[1].Id;
            CaseSquirtle.LblNumI.Text = _map.FrmPekeman.PokemonList[2].Id;
            CaseCaterpie.LblNumI.Text = _map.FrmPekeman.PokemonList[3].Id;
            CasePidgey.LblNumI.Text = _map.FrmPekeman.PokemonList[4].Id;
            CaseRattata.LblNumI.Text = _map.FrmPekeman.PokemonList[5].Id;
            CasePikachu.LblNumI.Text = _map.FrmPekeman.PokemonList[6].Id;
            CaseChikorita.LblNumI.Text = _map.FrmPekeman.PokemonList[7].Id;
            
        }

        public void AddPeke(Pokemon peke, bool isCaptured)
        {
            
            foreach (CasePekedex casePeke in ListeCase)
            {
                if (casePeke.LblNumI.Text == peke.Id)
                {
                    casePeke.PnlImgPeke.BackgroundImage = Image.FromFile("../../Resources/" + peke.ImgFront);
                    casePeke.LblNomI.Text = peke.Name;
                    for (int i = 0; i < peke.ElementType.Length; i++)
                    {
                        casePeke.LblTypeI.Text += peke.ElementType[i] + " ";
                    }
                    casePeke.LblDescI.Text = peke.Description;
                    if (isCaptured)
                    {
                        casePeke.LblCapturerI.Text = "Oui";
                    }
                    else if(casePeke.LblCapturerI.Text != "Oui")
                    {
                        casePeke.LblCapturerI.Text = "Non";
                    }
                }
            }
          
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            _map.FrmPekeman.ShowPekedex(false);
            _map.Disable = false;
        }
    }
}
