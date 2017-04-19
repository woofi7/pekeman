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
    public partial class Chat : ControlPanel
    {
        [Description("Text"), DefaultValue(""), DisplayName("Text")]
        public new string Text
        {
            get;
            set;
        }

        public Chat()
        {
            InitializeComponent();
        }
    }
}
