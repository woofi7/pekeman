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
        public Pekedex()
        {
            InitializeComponent();
            NumeroterPekedex();
        }

      private void NumeroterPekedex()
        {
            CaseBulbusaure.LblNumI.Text = "001";
            CaseCharmender.LblNumI.Text = "002";
            CaseSquirtle.LblNumI.Text = "003";
            CasePikachu.LblNumI.Text = "004";
            CaseChikorita.LblNumI.Text = "005";
            CasePidgey.LblNumI.Text = "006";
            CaseRatata.LblNumI.Text = "007";
            CaseMew.LblNumI.Text = "008";
        }
    }
}
