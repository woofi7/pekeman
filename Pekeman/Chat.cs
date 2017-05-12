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
    public partial class Chat : CustomGUI
    {
        public Chat()
        {
            InitializeComponent();
        }

        public void ChangeChatText(String msg)
        {
            Content.Text = msg;
        }
    }
}
