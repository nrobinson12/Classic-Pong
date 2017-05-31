namespace Classic_Pong
{
    partial class frmPong
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
            this.components = new System.ComponentModel.Container();
            this.tmrPong = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrPong
            // 
            this.tmrPong.Interval = 10;
            this.tmrPong.Tick += new System.EventHandler(this.tmrPong_Tick);
            // 
            // frmPong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "frmPong";
            this.Text = "Classic Pong";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPong_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPong_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPong_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmPong_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrPong;
    }
}

