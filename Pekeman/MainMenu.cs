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
    public partial class FrmMainMenu : Form
    {
        private FrmPekeman _frmPekeman;

        public FrmMainMenu()
        {
            InitializeComponent();
            this._frmPekeman = new FrmPekeman(this);
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            Hide();
            _frmPekeman.MapPeke.player.Name = TxtName.Text;
            _frmPekeman.Visible = true;
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
