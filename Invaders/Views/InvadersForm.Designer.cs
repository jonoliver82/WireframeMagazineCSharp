namespace Invaders.Views
{
    partial class InvadersForm
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
            this.shotTimer = new System.Windows.Forms.Timer(this.components);
            this.renderTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // shotTimer
            // 
            this.shotTimer.Enabled = true;
            this.shotTimer.Interval = 500;
            this.shotTimer.Tick += new System.EventHandler(this.shotTimer_Tick);
            // 
            // renderTimer
            // 
            this.renderTimer.Enabled = true;
            this.renderTimer.Interval = 50;
            this.renderTimer.Tick += new System.EventHandler(this.renderTimer_Tick);
            // 
            // InvadersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "InvadersForm";
            this.Text = "InvadersForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer shotTimer;
        private System.Windows.Forms.Timer renderTimer;
    }
}