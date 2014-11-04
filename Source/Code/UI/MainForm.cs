using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RippleSimulation
{
    public partial class MainForm : Form
    {
        private RippleSim Sim = new RippleSim();

        private bool IsMouseDown = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Sim.SizeX = RenderTarget.Width;
            Sim.SizeY = RenderTarget.Height;

            Sim.InitBuffers();
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            Sim.TickSim();

            RenderTarget.Invalidate();
        }

        private void RenderTarget_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Sim.RenderOutput, 0, 0);
        }

        private void RenderTarget_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;

            Sim.Splash(e.X, e.Y, int.Parse(SplashForceValue.Text));
        }

        private void RenderTarget_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;

            Sim.Splash(e.X, e.Y, int.Parse(SplashForceValue.Text));
        }

        private void RenderTarget_MouseMove(object sender, MouseEventArgs e)
        {
            if( IsMouseDown == true )
            {
                Sim.Splash(e.X, e.Y, int.Parse(SplashForceValue.Text));
            }
        }     
    }
}
