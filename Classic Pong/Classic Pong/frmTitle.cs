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
    public partial class frmTitle : Form
    {

        Settings mySettings;
        //Console font variables
        Image consoleFontSprites = Properties.Resources.consoleFont;
        int frameWidth = 32, frameHeight = 32;
        int curLetter = 0;

        frmPong gameForm;
        frmSettings settingsForm;
        public frmTitle(Settings mySettings)
        {
            InitializeComponent();
            this.mySettings = mySettings;
            gameForm = new frmPong(mySettings );
            settingsForm = new frmSettings(mySettings );
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            gameForm.ShowDialog();
        }

        private void frmTitle_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Pong
            int pongLettersX = 220;
            for (int i = 1; i <= 4; i++)
            {
                if (i == 1) curLetter = 48;
                if (i == 2) curLetter = 47;
                if (i == 3) curLetter = 46;
                if (i == 4) curLetter = 39;
                Rectangle sourceLetterRect = new Rectangle((curLetter % 16) * frameWidth, (curLetter / 16) * frameHeight, frameWidth, frameHeight);
                Rectangle destLetterRect = new Rectangle(pongLettersX, 20, frameWidth, frameHeight);
                g.DrawImage(consoleFontSprites, destLetterRect, sourceLetterRect, GraphicsUnit.Pixel);
                pongLettersX += 40;
            }
            //Play
            int playLettersX = 87;
            for (int i = 1; i <= 4; i++)
            {
                if (i == 1) curLetter = 48;
                if (i == 2) curLetter = 44;
                if (i == 3) curLetter = 33;
                if (i == 4) curLetter = 57;
                Rectangle sourceLetterRect = new Rectangle((curLetter % 16) * frameWidth, (curLetter / 16) * frameHeight, frameWidth, frameHeight);
                Rectangle destLetterRect = new Rectangle(playLettersX, 137, frameWidth, frameHeight);
                g.DrawImage(consoleFontSprites, destLetterRect, sourceLetterRect, GraphicsUnit.Pixel);
                playLettersX += 40;
            }
            //Quit
            int quitLettersX = 350;
            for (int i = 1; i <= 4; i++)
            {
                if (i == 1) curLetter = 49;
                if (i == 2) curLetter = 53;
                if (i == 3) curLetter = 41;
                if (i == 4) curLetter = 52;
                Rectangle sourceLetterRect = new Rectangle((curLetter % 16) * frameWidth, (curLetter / 16) * frameHeight, frameWidth, frameHeight);
                Rectangle destLetterRect = new Rectangle(quitLettersX, 137, frameWidth, frameHeight);
                g.DrawImage(consoleFontSprites, destLetterRect, sourceLetterRect, GraphicsUnit.Pixel);
                quitLettersX += 40;
            }
            //Settings
            int settingsLettersX = 135;
            for (int i = 1; i <= 8; i++)
            {
                if (i == 1) curLetter = 51;
                if (i == 2) curLetter = 37;
                if (i == 3 || i == 4) curLetter = 52;
                if (i == 5) curLetter = 41;
                if (i == 6) curLetter = 46;
                if (i == 7) curLetter = 39;
                if (i == 8) curLetter = 51;
                Rectangle sourceLetterRect = new Rectangle((curLetter % 16) * frameWidth, (curLetter / 16) * frameHeight, frameWidth, frameHeight);
                Rectangle destLetterRect = new Rectangle(settingsLettersX, 265, frameWidth, frameHeight);
                g.DrawImage(consoleFontSprites, destLetterRect, sourceLetterRect, GraphicsUnit.Pixel);
                settingsLettersX += 40;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { //btnQuit
            Environment.Exit(0);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }
    }
}
