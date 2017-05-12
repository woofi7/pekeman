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
    public partial class WindowStart : CustomGUI
    {
        private bool PekedexOuvert = false;
        private FrmPekeman FrmPeke;
        public WindowStart()
        {
            InitializeComponent();
        }

        public void InitializeWinStart(FrmPekeman frmPekeman)
        {
            FrmPeke = frmPekeman;
            
        }

        private void BtnPekedex_Click(object sender, EventArgs e)
        {
            if (!PekedexOuvert)
            {
                PekedexOuvert = !PekedexOuvert;
                Point p = new Point(0, 0);
                FrmPeke._Pekedex.Location = p;
                FrmPeke.MapPeke.Controls.Add(FrmPeke._Pekedex);
                FrmPeke._Pekedex.Visible = PekedexOuvert;
            }
            else
            {
                PekedexOuvert = !PekedexOuvert;
                FrmPeke._Pekedex.Visible = PekedexOuvert;
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
            FrmPeke.Dispose();
        }
    }
}
