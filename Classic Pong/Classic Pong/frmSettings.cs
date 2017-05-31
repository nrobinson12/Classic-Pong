using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classic_Pong
{
    public partial class frmSettings : Form
    {
        Settings mySettings;
        public frmSettings(Settings mySettings)
        {
            InitializeComponent();
            this.mySettings = mySettings;
        }

        private void button1_Click(object sender, EventArgs e)
        { //btnBallColor
            cdSettings.ShowDialog();
            mySettings.color_ball = new SolidBrush(cdSettings.Color);
        }

        private void btnLeftPaddleColor_Click(object sender, EventArgs e)
        {
            cdSettings.ShowDialog();
            mySettings.color_left_paddle = new SolidBrush(cdSettings.Color);
        }

        private void btnRightPaddleColor_Click(object sender, EventArgs e)
        {
            cdSettings.ShowDialog();
            mySettings.color_right_paddle = new SolidBrush(cdSettings.Color);
        }

        private void btnBackgroundColor_Click(object sender, EventArgs e)
        {
            cdSettings.ShowDialog();
            mySettings.color_background = cdSettings.Color;
        }
    }
}
