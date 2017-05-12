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
    public partial class CapturedPekeman : CustomGUI
    {
        private Player _player;
        public CapturedPekeman(FrmPekeman frm)
        {
            InitializeComponent();
            _player = frm.ThePlayer;

        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void FillTableWithPekeman()
        {
            int PekeInList = 0;
            for (int i = 0; i < TlpPeke.RowCount; i++)
            {
                for (int j = 0; j < TlpPeke.ColumnCount; j++)
                {
                    if (PekeInList < _player.PokemonList.Count)
                    {
                        PictureBox p = new PictureBox();
                        p.Image = Image.FromFile("../../Resources/" + _player.PokemonList[PekeInList].ImgFront);
                        TlpPeke.Controls.Add(p,i,j);
                    }
                }
            }
        }
    }
}
