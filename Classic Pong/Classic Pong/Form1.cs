/* Nicholas Robinson
 * March 9 2015
 * Classic Pong
 */

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
    public partial class frmPong : Form
    {
        Settings mySettings;

        //Console font variables
        Image consoleFontSprites = Properties.Resources.consoleFont;
        int frameWidth = 32, frameHeight = 32;

        //Score variables
        int curLeftScore = 0;   //Current left score
        int curRightScore = 0;  //Current right score
        int winner = 0;

        //Ball starting location
        int ballX = 488, ballY = 225;

        //Left paddle variables
        int paddleLeftX = 100, paddleLeftY = 200;
        bool leftUp = false, leftDown = false;

        //Right paddle variables
        int paddleRightX = 900, paddleRightY = 200;
        bool rightUp = false, rightDown = false;

        //Sizes
        const int PADDLE_LEFT_SIZE = 80;
        const int PADDLE_RIGHT_SIZE = 80;
        const int BALL_SIZE = 10;

        //Speeds
        public int PADDLE_SPEED = 10;
        public int BALL_X_SPEED = 5;
        public int BALL_Y_SPEED = 5;

        //Colors
        public Brush PADDLE_LEFT_COLOR = Brushes.White;
        public Brush PADDLE_RIGHT_COLOR = Brushes.White;
        public Brush BALL_COLOR=Brushes.White ;
        public Brush HALF_LINE_COLOR = Brushes.White;

        public frmPong(Settings mySettings)
        {
            InitializeComponent();
            this.mySettings = mySettings;
        }

        private void tmrPong_Tick(object sender, EventArgs e)
        {
            
            if (ActiveForm == null) return;

            //Check ball to sides on the x-axis collision
            //Check to see if right side scores a point
            if (ballX + BALL_X_SPEED < 0)
            {
                if (curRightScore == 0)
                {
                    if (winner == 0) curRightScore = 16;
                }
                if (curRightScore == 20)     //If LEFT side wins (gets 5 points)
                {
                    if (winner == 0)
                    {
                        curRightScore = 0;
                        winner = -1;
                    }
                }
                else
                {
                    if (winner == 0) curRightScore += 1;
                }
                BALL_X_SPEED = -BALL_X_SPEED;
            }
            //Check to see if left side scores a point
            if (ballX + BALL_X_SPEED + 10 > 980)
            {
                if (curLeftScore == 0)
                {
                    if (winner == 0) curLeftScore = 16;
                }
                if (curLeftScore == 20)    //If RIGHT side wins (gets 5 points)
                {
                    if (winner == 0)
                    {
                        curLeftScore = 0;
                        winner = 1;
                    }
                }
                else
                {
                    if (winner == 0) curLeftScore += 1;
                }
                BALL_X_SPEED = -BALL_X_SPEED;
            }

            //Check ball to sides on the y-axis collision
            if ((ballY + BALL_Y_SPEED < 0) || (ballY + BALL_Y_SPEED + 10 > 460))
            {
                BALL_Y_SPEED = -BALL_Y_SPEED;
            }

            //Check ball to paddle collision
            Rectangle ballRect = new Rectangle(ballX, ballY, 10, 10);
            Rectangle paddleLeftRect = new Rectangle(paddleLeftX, paddleLeftY, 10, PADDLE_LEFT_SIZE);
            Rectangle paddleRightRect = new Rectangle(paddleRightX, paddleRightY, 10, PADDLE_RIGHT_SIZE);

            if (paddleLeftRect.IntersectsWith(ballRect))
            {
                BALL_X_SPEED = -BALL_X_SPEED;
            }
            if (paddleRightRect.IntersectsWith(ballRect))
            {
                BALL_X_SPEED = -BALL_X_SPEED;
            }

            //Update ball location
            ballX += BALL_X_SPEED;
            ballY += BALL_Y_SPEED;

            //Update paddle locations
            if (paddleLeftY <= 0) leftUp = false;
            if (leftUp) paddleLeftY -= PADDLE_SPEED;

            if (paddleLeftY + 120 >= 500) leftDown = false;
            if (leftDown) paddleLeftY += PADDLE_SPEED;

            if (paddleRightY <= 0) rightUp = false;
            if (rightUp) paddleRightY -= PADDLE_SPEED;

            if (paddleRightY + 125 >= 500) rightDown = false;
            if (rightDown) paddleRightY += PADDLE_SPEED;

            //Force the form to redraw itself
            frmPong.ActiveForm.Invalidate();
        }

        private void frmPong_Paint(object sender, PaintEventArgs e)
        {
            if (ActiveForm == null) return;
            Graphics g = e.Graphics;

            //Set all the settings changes
            BALL_COLOR = mySettings.color_ball;
            PADDLE_LEFT_COLOR = mySettings.color_left_paddle;
            PADDLE_RIGHT_COLOR = mySettings.color_right_paddle;
            this.BackColor = mySettings.color_background;

            //Left controls
            if (tmrPong.Enabled == false)
            {
                //W
                Rectangle sourceLetterWRect = new Rectangle((55 % 16) * frameWidth, (55 / 16) * frameHeight, frameWidth, frameHeight);
                Rectangle destLetterWRect = new Rectangle(280, 200, frameWidth, frameHeight);
                g.DrawImage(consoleFontSprites, destLetterWRect, sourceLetterWRect, GraphicsUnit.Pixel);

                //S
                Rectangle sourceLetterSRect = new Rectangle((51 % 16) * frameWidth, (51 / 16) * frameHeight, frameWidth, frameHeight);
                Rectangle destLetterSRect = new Rectangle(280, 250, frameWidth, frameHeight);
                g.DrawImage(consoleFontSprites, destLetterSRect, sourceLetterSRect, GraphicsUnit.Pixel);

                //Up
                int upLettersX = 660;
                int curLetter = 0;
                for (int i = 1; i <= 2; i++)
                {
                    if (i == 1) curLetter = 53;
                    if (i == 2) curLetter = 48;
                    Rectangle sourceLetterRect = new Rectangle((curLetter % 16) * frameWidth, (curLetter / 16) * frameHeight, frameWidth, frameHeight);
                    Rectangle destLetterRect = new Rectangle(upLettersX, 200, frameWidth, frameHeight);
                    g.DrawImage(consoleFontSprites, destLetterRect, sourceLetterRect, GraphicsUnit.Pixel);
                    upLettersX += 40;
                }

                //Down
                int downLettersX = 620;
                for (int i = 1; i <= 4; i++)
                {
                    if (i == 1) curLetter = 36;
                    if (i == 2) curLetter = 47;
                    if (i == 3) curLetter = 55;
                    if (i == 4) curLetter = 46;
                    Rectangle sourceLetterRect = new Rectangle((curLetter % 16) * frameWidth, (curLetter / 16) * frameHeight, frameWidth, frameHeight);
                    Rectangle destLetterRect = new Rectangle(downLettersX, 250, frameWidth, frameHeight);
                    g.DrawImage(consoleFontSprites, destLetterRect, sourceLetterRect, GraphicsUnit.Pixel);
                    downLettersX += 40;
                }
            }

            //Ball
            g.FillRectangle(BALL_COLOR, new Rectangle(ballX, ballY, 10, 10));

            //Left paddle
            g.FillRectangle(PADDLE_LEFT_COLOR, new Rectangle(paddleLeftX, paddleLeftY, 10, 80));

            //Right paddle
            g.FillRectangle(PADDLE_RIGHT_COLOR, new Rectangle(paddleRightX, paddleRightY, 10, 80));

            //Middle dotted line
            for (int i = 5; i < 500; i += 60)
            {
                g.FillRectangle(HALF_LINE_COLOR, new Rectangle(490, i, 5, 30));
            }

            //Left score
            Rectangle sourceLeftRect = new Rectangle((curLeftScore % 16) * frameWidth, (curLeftScore / 16) * frameHeight, frameWidth, frameHeight);
            Rectangle destLeftRect = new Rectangle(435, 10, frameWidth, frameHeight);
            g.DrawImage(consoleFontSprites, destLeftRect, sourceLeftRect, GraphicsUnit.Pixel);

            //Right score
            Rectangle sourceRightRect = new Rectangle((curRightScore % 16) * frameWidth, (curRightScore / 16) * frameHeight, frameWidth, frameHeight);
            Rectangle destRightRect = new Rectangle(520, 10, frameWidth, frameHeight);
            g.DrawImage(consoleFontSprites, destRightRect, sourceRightRect, GraphicsUnit.Pixel);

            //Winners
            if (winner != 0)
            {
                int lettersLeftX = 520;
                int lettersRightX = 200;
                int curLetter = 55;
                for (int i = 1; i <= 7; i++)
                {
                    if (i == 1) curLetter = 55;
                    if (i == 2) curLetter = 41;
                    if (i == 3) curLetter = 46;
                    if (i == 4) curLetter = 46;
                    if (i == 5) curLetter = 37;
                    if (i == 6) curLetter = 50;
                    if (i == 7) curLetter = 1;
                    if (winner == -1)
                    {
                        Rectangle sourceLetterRect = new Rectangle((curLetter % 16) * frameWidth, (curLetter / 16) * frameHeight, frameWidth, frameHeight);
                        Rectangle destLetterRect = new Rectangle(lettersLeftX, 10, frameWidth, frameHeight);
                        g.DrawImage(consoleFontSprites, destLetterRect, sourceLetterRect, GraphicsUnit.Pixel);
                    }
                    if (winner == 1)
                    {
                        Rectangle sourceLetterRect = new Rectangle((curLetter % 16) * frameWidth, (curLetter / 16) * frameHeight, frameWidth, frameHeight);
                        Rectangle destLetterRect = new Rectangle(lettersRightX, 10, frameWidth, frameHeight);
                        g.DrawImage(consoleFontSprites, destLetterRect, sourceLetterRect, GraphicsUnit.Pixel);
                    }
                    lettersLeftX += 40;
                    lettersRightX += 40;
                }
            }
        }

        private void frmPong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                leftUp = true;
                tmrPong.Enabled = true;
            }
            if (e.KeyCode == Keys.S)
            {
                leftDown = true;
                tmrPong.Enabled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                rightUp = true;
                tmrPong.Enabled = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                rightDown = true;
                tmrPong.Enabled = true;
            }
        }

        private void frmPong_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) leftUp = false;
            if (e.KeyCode == Keys.S) leftDown = false;
            if (e.KeyCode == Keys.Up) rightUp = false;
            if (e.KeyCode == Keys.Down) rightDown = false;
        }

        private void frmPong_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrPong.Enabled = false;
            //Score variables
            curLeftScore = 0;   //Current left score
            curRightScore = 0;  //Current right score
            winner = 0;

            //Ball starting location
            ballX = 488;
            ballY = 225;

            //Left paddle variables
            paddleLeftX = 100;
            paddleLeftY = 200;
            leftUp = false;
            leftDown = false;

            //Right paddle variables
            paddleRightX = 900;
            paddleRightY = 200;
            rightUp = false;
            rightDown = false;
        }
    }
}
