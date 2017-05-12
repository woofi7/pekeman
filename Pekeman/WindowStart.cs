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

namespace Pekeman
{
    public partial class WindowStart : CustomGUI
    {
        private CapturedPekeman CapPeke;
        private bool PekedexOuvert = false;
        private bool PekeListOuvert = false;
        private FrmPekeman FrmPeke;
        private Player player;
        public WindowStart()
        {
            InitializeComponent();
        }

        public void InitializeWinStart(FrmPekeman frmPekeman)
        {
            FrmPeke = frmPekeman;
            player = frmPekeman.ThePlayer;
            CapPeke = frmPekeman.CapPeke;
        }

        private void BtnPekedex_Click(object sender, EventArgs e)
        {
            if (!PekedexOuvert)
            {
                PekedexOuvert = !PekedexOuvert;
                Point p = new Point(0, 0);
                FrmPeke.Pekedex.Location = p;
                FrmPeke.MapPeke.Controls.Add(FrmPeke.Pekedex);
                FrmPeke.Pekedex.Visible = PekedexOuvert;
            }
            else
            {
                PekedexOuvert = !PekedexOuvert;
                FrmPeke.Pekedex.Visible = PekedexOuvert;
            }
            
            
            
        }

        private void BtnOption_Click(object sender, EventArgs e)
        {
            WinOption option = new WinOption();
            Point p = new Point(0, 0);
            option.Location = p;

            FrmPeke.MapPeke.Controls.Add(option);
        }

        private void BtnAPropos_Click(object sender, EventArgs e)
        {
            MessageBox.Show(FrmPeke,"PeKeman\nFait par les valeureux étudiants\nNicolas Signori et Alex Gravel");
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            FrmPeke.MapPeke.EndGame(false);
        }

        private void BtnPekeman_Click(object sender, EventArgs e)
        {

            if (!PekeListOuvert)
            {
                PekeListOuvert = !PekeListOuvert;
                Point p = new Point(0, 0);
                CapPeke.Location = p;
                CapPeke.FillTableWithPekeman();
                FrmPeke.MapPeke.Controls.Add(CapPeke);
                FrmPeke.Pekedex.Visible = PekeListOuvert;
            }
            else
            {
                PekeListOuvert = !PekeListOuvert;
                FrmPeke.Pekedex.Visible = PekeListOuvert;
            }
        }
    }
}
