﻿using System;
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
    public partial class BattleManager : UserControl
    {
        private Map _Map;
        private Pokemon Wild;
        private Pokemon Hero;
        private static int nbAttempt;
        private Random rng = new Random();
        private Player _Player;
        private Pekedex pekedex;
        public BattleManager()
        {
            InitializeComponent();
        }

        public void InitialzeBattleManager(Map map)
        {
            _Map = map;
            _Player = map.FrmPekeman.ThePlayer;
            Hero = new Pokemon();
            Hero.Level = 3;
            DoubleBuffered = true;
            Hero = map.FrmPekeman.PokemonList[0];
            _Player.InitialPokemon = Hero;
            PbHpHero.Maximum = Hero.MaximumHp;
            PbHpHero.Value = Hero.CurrentHp;
            LblNomHero.Text = Hero.Name;
            Hero.CurrentHp = Hero.MaximumHp;

            pekedex = map.FrmPekeman.Pekedex;
            Visible = false;
        }
        public void StartBattle()
        {
            pekedex.AddPeke(Hero, true);
            Wild = new Pokemon();
            DeterminerPokemon();
            PnlWild.BackgroundImage = Image.FromFile("../../Resources/" + Wild.ImgFront);
            this.Visible = true;
            placerComp();
            PbHpHero.Value = Hero.CurrentHp;
            nbAttempt = 0;
        }

        private void DeterminerPokemon()
        {
            int choix = rng.Next(_Map.FrmPekeman.PokemonList.Length);
            Wild = _Map.FrmPekeman.PokemonList.ElementAt(choix);

            LblNomWild.Text = Wild.Name;
            PbHpWild.Maximum = Wild.MaximumHp;
            Wild.CurrentHp = Wild.MaximumHp;
            PbHpWild.Value = Wild.MaximumHp;


        }
        private void placerComp()
        {
            PnlPeke.BackgroundImage = Image.FromFile("../../Resources/" + Hero.ImgBack);
            Point p = new Point(_Map.Size.Width/2-this.Size.Width/2, _Map.Size.Height / 2 - this.Size.Height / 2);
            this.Location = p;
            
        }

        private void BtnAttack_Click(object sender, EventArgs e)
        {
            HeroAttack();
            if (Wild.CurrentHp > 0)
            {
                WildAttack();
            }
            
        }

        private void HeroAttack()
        {
            int dmg = Hero.Dammage(Hero, Wild);
            if (PbHpWild.Value - dmg > 0)
            {
                PbHpWild.Value -= dmg;
                Wild.CurrentHp -= dmg;
            }
            else
            {
                PbHpWild.Value = 0;
                this.Visible = false;
                _Map.Disable = false;
            }
        }

        private void WildAttack()
        {
            int dmg;
            dmg = Wild.Dammage(Wild, Hero);
            if (PbHpHero.Value - dmg > 0)
            {
                PbHpHero.Value -= dmg;
                Hero.CurrentHp -= dmg;
            }
            else
            {
                this.Visible = false;
                pekedex.AddPeke(Wild, false);
                _Map.EndGame(false);
                _Map.Disable = false;
            }
        }


        private void BtnRun_Click(object sender, EventArgs e)
        {
            if (Hero.CanEscape(Wild, nbAttempt))
            {
                this.Visible = false;
                pekedex.AddPeke(Wild,false);
                nbAttempt = 0;
                _Map.Disable = false;
            }
            else
            {
                nbAttempt++;
                WildAttack();
            }
        }

        private void BtnCatch_Click(object sender, EventArgs e)
        {
            
            if (Hero.CanBeCatch(Wild))
            {
                pekedex.AddPeke(Wild, true);

                int count = 0;
                foreach (CasePekedex casePeke in pekedex.ListeCase)
                {
                    if (casePeke.LblCapturerI.Text.Equals("Oui"))
                    {
                        count++;
                    }
                }

                if (count == 7)
                {
                    _Map.EndGame(true);
                }


                _Player.PokemonList.Add(Wild);
                this.Visible = false;
                _Map.Disable = false;
            }
            else
            {
                WildAttack();
            }
        }

        public void HealPokemon()
        {
            Hero.CurrentHp = Hero.MaximumHp;
        }
    }
}
