﻿using System;
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
    public partial class ControlPanel : CustomGUI
    {
        private FrmPekeman FrmPeke;

        public ControlPanel()
        {
            InitializeComponent();
        }

        public void InitializeControlPanel(FrmPekeman frmPekeman)
        {
            FrmPeke = frmPekeman;
        }

        public ControlPanel(FrmPekeman frmPekeman)
        {
            InitializeComponent();
            FrmPeke = frmPekeman;
        }

        private void PctFlecheHaut_MouseDown(object sender, MouseEventArgs e)
        {
            FrmPeke.ThePlayer.KeyPress(Keys.Up, true);
        }

        private void PctFlecheHaut_MouseUp(object sender, MouseEventArgs e)
        {
            FrmPeke.ThePlayer.KeyPress(Keys.Up, false);
        }

        private void PctFlecheBas_MouseDown(object sender, MouseEventArgs e)
        {
            FrmPeke.ThePlayer.KeyPress(Keys.Down, true);
        }

        private void PctFlecheBas_MouseUp(object sender, MouseEventArgs e)
        {
            FrmPeke.ThePlayer.KeyPress(Keys.Down, false);
        }

        private void PctFlecheDroite_MouseDown(object sender, MouseEventArgs e)
        {
            FrmPeke.ThePlayer.KeyPress(Keys.Right, true);
        }

        private void PctFlecheDroite_MouseUp(object sender, MouseEventArgs e)
        {
            FrmPeke.ThePlayer.KeyPress(Keys.Right, false);
        }

        private void PctFlecheGauche_MouseDown(object sender, MouseEventArgs e)
        {
            FrmPeke.ThePlayer.KeyPress(Keys.Left, true);
        }

        private void PctFlecheGauche_MouseUp(object sender, MouseEventArgs e)
        {
            FrmPeke.ThePlayer.KeyPress(Keys.Left, false);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            FrmPeke.MapPeke.Battle.StartBattle();
        }
    }
}
