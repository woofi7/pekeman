using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pekeman
{
    public partial class FrmEndGame : Form
    {
        private FrmPekeman _frmPekeman;

        public FrmEndGame(FrmPekeman frmPekeman)
        {
            InitializeComponent();
            _frmPekeman = frmPekeman;
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            _frmPekeman.CloseGame();
        }
    }
}
