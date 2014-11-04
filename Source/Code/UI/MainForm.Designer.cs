namespace RippleSimulation
{
    partial class MainForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RenderTarget = new System.Windows.Forms.PictureBox();
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            this.DampingValue = new System.Windows.Forms.TextBox();
            this.SplashForceValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.RenderTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Splash Force:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Damping:";
            // 
            // RenderTarget
            // 
            this.RenderTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RenderTarget.Location = new System.Drawing.Point(3, 2);
            this.RenderTarget.Name = "RenderTarget";
            this.RenderTarget.Size = new System.Drawing.Size(256, 256);
            this.RenderTarget.TabIndex = 4;
            this.RenderTarget.TabStop = false;
            this.RenderTarget.Paint += new System.Windows.Forms.PaintEventHandler(this.RenderTarget_Paint);
            this.RenderTarget.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RenderTarget_MouseDown);
            this.RenderTarget.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RenderTarget_MouseMove);
            this.RenderTarget.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RenderTarget_MouseUp);
            // 
            // TickTimer
            // 
            this.TickTimer.Enabled = true;
            this.TickTimer.Interval = 33;
            this.TickTimer.Tick += new System.EventHandler(this.TickTimer_Tick);
            // 
            // DampingValue
            // 
            this.DampingValue.Location = new System.Drawing.Point(265, 57);
            this.DampingValue.Name = "DampingValue";
            this.DampingValue.Size = new System.Drawing.Size(81, 20);
            this.DampingValue.TabIndex = 7;
            this.DampingValue.Text = "0.99";
            // 
            // SplashForceValue
            // 
            this.SplashForceValue.Location = new System.Drawing.Point(265, 18);
            this.SplashForceValue.Name = "SplashForceValue";
            this.SplashForceValue.Size = new System.Drawing.Size(81, 20);
            this.SplashForceValue.TabIndex = 8;
            this.SplashForceValue.Text = "3000";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RenderTarget);
            this.Controls.Add(this.DampingValue);
            this.Controls.Add(this.SplashForceValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Ripple Simulation";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RenderTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox RenderTarget;
        private System.Windows.Forms.Timer TickTimer;
        private System.Windows.Forms.TextBox DampingValue;
        private System.Windows.Forms.TextBox SplashForceValue;
    }
}

