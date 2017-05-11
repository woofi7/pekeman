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
        
        private FrmPekeman FrmPeke;
        private Pekedex _pekedex;
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
            
            //Point p = new Point(FrmPeke.MapPeke.Size.Width / 2 - this.Size.Width / 2, FrmPeke.MapPeke.Size.Height / 2 - this.Size.Height / 2);
            Point p = new Point(0, 0);
            FrmPeke._Pekedex.Location = p;
            FrmPeke.MapPeke.Controls.Add(FrmPeke._Pekedex);
            FrmPeke._Pekedex.Visible = true;
            
        }
    }
}
