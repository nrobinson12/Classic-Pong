namespace Classic_Pong
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBallColor = new System.Windows.Forms.Button();
            this.cdSettings = new System.Windows.Forms.ColorDialog();
            this.btnLeftPaddleColor = new System.Windows.Forms.Button();
            this.btnRightPaddleColor = new System.Windows.Forms.Button();
            this.btnBackgroundColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBallColor
            // 
            this.btnBallColor.Location = new System.Drawing.Point(12, 12);
            this.btnBallColor.Name = "btnBallColor";
            this.btnBallColor.Size = new System.Drawing.Size(150, 23);
            this.btnBallColor.TabIndex = 0;
            this.btnBallColor.Text = "Choose Ball Color";
            this.btnBallColor.UseVisualStyleBackColor = true;
            this.btnBallColor.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLeftPaddleColor
            // 
            this.btnLeftPaddleColor.Location = new System.Drawing.Point(13, 42);
            this.btnLeftPaddleColor.Name = "btnLeftPaddleColor";
            this.btnLeftPaddleColor.Size = new System.Drawing.Size(149, 23);
            this.btnLeftPaddleColor.TabIndex = 1;
            this.btnLeftPaddleColor.Text = "Choose Left Paddle Color";
            this.btnLeftPaddleColor.UseVisualStyleBackColor = true;
            this.btnLeftPaddleColor.Click += new System.EventHandler(this.btnLeftPaddleColor_Click);
            // 
            // btnRightPaddleColor
            // 
            this.btnRightPaddleColor.Location = new System.Drawing.Point(12, 71);
            this.btnRightPaddleColor.Name = "btnRightPaddleColor";
            this.btnRightPaddleColor.Size = new System.Drawing.Size(149, 23);
            this.btnRightPaddleColor.TabIndex = 2;
            this.btnRightPaddleColor.Text = "Choose Right Paddle Color";
            this.btnRightPaddleColor.UseVisualStyleBackColor = true;
            this.btnRightPaddleColor.Click += new System.EventHandler(this.btnRightPaddleColor_Click);
            // 
            // btnBackgroundColor
            // 
            this.btnBackgroundColor.Location = new System.Drawing.Point(12, 100);
            this.btnBackgroundColor.Name = "btnBackgroundColor";
            this.btnBackgroundColor.Size = new System.Drawing.Size(149, 23);
            this.btnBackgroundColor.TabIndex = 3;
            this.btnBackgroundColor.Text = "Choose Background Color";
            this.btnBackgroundColor.UseVisualStyleBackColor = true;
            this.btnBackgroundColor.Click += new System.EventHandler(this.btnBackgroundColor_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 370);
            this.Controls.Add(this.btnBackgroundColor);
            this.Controls.Add(this.btnRightPaddleColor);
            this.Controls.Add(this.btnLeftPaddleColor);
            this.Controls.Add(this.btnBallColor);
            this.Name = "frmSettings";
            this.Text = "Classic Pong Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBallColor;
        private System.Windows.Forms.ColorDialog cdSettings;
        private System.Windows.Forms.Button btnLeftPaddleColor;
        private System.Windows.Forms.Button btnRightPaddleColor;
        private System.Windows.Forms.Button btnBackgroundColor;
    }
}