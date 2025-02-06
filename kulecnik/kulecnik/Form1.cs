using System;
using System.Drawing;
using System.Windows.Forms;

namespace kulecnik
{
    public partial class Form1 : Form
    {
        private float ballX = 100; // Výchozí pozice koule
        private float ballY = 100;
        private float velocityX = 0;
        private float velocityY = 0;
        private const int BallSize = 20; // Velikost koule
        private const float Friction = 0.99f; // Tření pro postupné zastavení koule

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;
            Timer timer = new Timer();
            timer.Interval = 16; // Aktualizace každých 16 ms
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // Nastaví směr a rychlost na základě kliknutí myší
            float deltaX = e.X - ballX;
            float deltaY = e.Y - ballY;
            float length = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            velocityX = deltaX / length * 10; // Nastaví rychlost
            velocityY = deltaY / length * 10;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Aktualizuje pozici koule
            ballX += velocityX;
            ballY += velocityY;

            // Uplatňuje tření
            velocityX *= Friction;
            velocityY *= Friction;

            // Odraz od okrajů formuláře
            if (ballX <= 0 || ballX >= ClientSize.Width - BallSize)
            {
                velocityX = -velocityX;
            }
            if (ballY <= 0 || ballY >= ClientSize.Height - BallSize)
            {
                velocityY = -velocityY;
            }

            Invalidate(); // Znovu vykreslí formulář
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Vykreslení koule
            e.Graphics.FillEllipse(Brushes.Blue, ballX, ballY, BallSize, BallSize);
        }
    }
}
