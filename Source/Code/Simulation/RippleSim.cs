using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RippleSimulation
{
    public class RippleSim
    {
        private int[] Buffer1;

        private int[] Buffer2;

        private int[] FrontBuffer;

        private int[] BackBuffer;

        public int SizeX;

        public int SizeY;

        public int ScaleX;

        public int ScaleY;

        public float Damping = 0.9999f;

        public float SplashForce = 8000.0f;

        public float MaxForce = 16000.0f;

        public Bitmap RenderOutput;

        public Graphics g;

        public void InitBuffers()
        {
            Buffer1 = new int[SizeX * SizeY];
            Buffer2 = new int[SizeX * SizeY];

            for (int y = 0; y < SizeY; ++y)
            {
                for (int x = 0; x < SizeX; ++x)
                {
                    Buffer1[y * SizeX + x] = 0;
                    Buffer2[y * SizeX + x] = 0;
                }
            }

            FrontBuffer = Buffer1;
            BackBuffer  = Buffer2;

            RenderOutput = new Bitmap(SizeX, SizeY, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(RenderOutput);
        }

        public void Splash(int x, int y, int force)
        {
            force = (int)SplashForce;

            // Initial point.
            Buffer1[y * SizeX + x] = force;

            // Left/Right of point.
            Buffer1[y * SizeX + x + 1] = force;
            Buffer1[y * SizeX + x - 1] = force;

            // Up/Down of point.
            Buffer1[(y - 1) * SizeX + x] = force;
            Buffer1[(y + 1) * SizeX + x] = force;

            Buffer1[(y - 1) * SizeX + x - 1] = force;
            Buffer1[(y - 1) * SizeX + x + 1] = force;

            Buffer1[(y + 1) * SizeX + x - 1] = force;
            Buffer1[(y + 1) * SizeX + x + 1] = force;

        }

        public void TickSim()
        {
            ProcessBuffers(BackBuffer, FrontBuffer);
            SwapBuffers();

            Render();
        }

        public void ProcessBuffers(int[] sourceBuffer, int[] destBuffer)
        {
            // Start at 1, and end at Size-1 to skip edge elements.
            for (int y = 1; y < SizeY - 1; ++y)
            {
                for (int x = 1; x < SizeX - 1; ++x)
                {
                    int i = y * SizeX + x;

                    float v1 = sourceBuffer[y * SizeX + x - 1];
                    float v2 = sourceBuffer[y * SizeX + x + 1];
                    float v3 = sourceBuffer[(y - 1) * SizeX + x];
                    float v4 = sourceBuffer[(y + 1) * SizeX + x];

                    float v = ((v1 + v2 + v3 + v4) / 2.0f) - destBuffer[i];
                    int iv = (int)v;

                    destBuffer[i] = Math.Max(0, iv);                   // Clamp to 0.
                    destBuffer[i] = (int)Math.Min(MaxForce, destBuffer[i]); // Clamp to MaxForce.

                    destBuffer[i] = (int)(destBuffer[i] * Damping);
                }
            }
        }

        public void SwapBuffers()
        {
            if (FrontBuffer == Buffer1)
            {
                FrontBuffer = Buffer2;
                BackBuffer = Buffer1;
            }
            else
            {
                FrontBuffer = Buffer1;
                BackBuffer = Buffer2;
            }
        }

        public void Fill(int value)
        {
            for (int y = 0; y < SizeY; ++y)
            {
                for (int x = 0; x < SizeX; ++x)
                {
                    int i = y * SizeX + x;
                    Buffer1[i] = value;
                    Buffer2[i] = value;
                }
            }
        }

        public void Render()
        {
            for (int y = 0; y < SizeY; ++y)
            {
                for (int x = 0; x < SizeX; ++x)
                {
                    int i = y * SizeX + x;
                    int value = FrontBuffer[i];
                    float unit = (float)value / MaxForce;
                    int colour = (int)(255.0f * unit);

                    RenderOutput.SetPixel(x, y, Color.FromArgb(colour, colour, colour));
                }
            }
        }
    }
}
