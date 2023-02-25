using Particulas1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Particulas1
{
    public partial class Form1 : Form
    {
        public int ballsize;
        private Bitmap bmp;
        private Graphics g;
        private int NumBalls = 8000;
        private Random rand = new Random();
        private List<Particles> particulas = new List<Particles>();
        PointF position= new PointF();
        bool FuegoB=false;
        bool LluviaB = false;
        bool NieveB = false;
        bool HumoB = false;

        public Form1()
        {
            InitializeComponent();
            // Create the PictureBox and add it to the form
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

           
            for (int i = 0; i < NumBalls; i++)
            {
                this.particulas.Add(new Particles
                {
                   ballsize = 2,
                   X = position.X,
                   Y = position.Y,
                   DX = rand.Next(5, 15),
                   DY = rand.Next(5, 15),
                   lifes = rand.Next(30, 50),
                   Color = Color.FromArgb(255, rand.Next(256), rand.Next(256), rand.Next(256))
                });
            }
        }

        private PointF emisor(int x, int y)
        {
            PointF emisor= new PointF(x, y);
            return emisor;
        }

        private void timer1_Tick(object sender, EventArgs e)
         {
            if (LluviaB == true)
            {
                for (int i = 0; i < particulas.Count; i++)
                {
                    if (particulas[i].lifes == 0)
                    {
                        PointF position = emisor(rand.Next(10, pictureBox1.Width), -30);
                        particulas[i].X = position.X;
                        particulas[i].Y = position.Y;
                        particulas[i].DX = 0;
                        particulas[i].DY = rand.Next(5, 15);
                        particulas[i].lifes = rand.Next(30, 50);
                        particulas[i].Color = Color.FromArgb(255,0, 0, rand.Next(256));
                    }

                    // Update ball's position
                    particulas[i].Y += particulas[i].DY;
                    particulas[i].lifes--;
                }
            }

            if (FuegoB==true)
            {
                for (int i = 0; i < particulas.Count; i++)
                {
                    particulas[i].X += particulas[i].DX;
                    particulas[i].Y += particulas[i].DY;

                    if (particulas[i].lifes == 0)
                    {
                        PointF position = emisor(rand.Next(250, pictureBox1.Width - 250), rand.Next(pictureBox1.Height - 50, pictureBox1.Height));
                        particulas[i].X = position.X;
                        particulas[i].Y = position.Y;
                        particulas[i].DX = rand.Next(-3, 4);
                        particulas[i].DY = rand.Next(-5, 0);
                        particulas[i].lifes = rand.Next(30, 50);
                        particulas[i].Color = Color.FromArgb(255, rand.Next(256), 0, 0);
                    }
                    // Update ball's position          
                    particulas[i].lifes--;
                }

            }

            if (NieveB == true)
            {
                for (int i = 0; i < particulas.Count; i++)
                {
                    if (particulas[i].lifes == 0)
                    {
                        PointF position = emisor(rand.Next(10, pictureBox1.Width), -30);
                        particulas[i].X = position.X;
                        particulas[i].Y = position.Y;
                        particulas[i].DX = 0;
                        particulas[i].DY = rand.Next(5, 15);
                        particulas[i].lifes = rand.Next(30, 50);
                        particulas[i].Color = Color.FromArgb(255, 54, 69, 79);
                    }
                    // Update ball's position
                    particulas[i].Y += particulas[i].DY;
                    particulas[i].lifes--;
                }
            }


            if (HumoB == true)
            {
                for (int i = 0; i < particulas.Count; i++)
                {
                    particulas[i].X += particulas[i].DX;
                    particulas[i].Y += particulas[i].DY;

                    if (particulas[i].lifes == 0)
                    {
                        PointF position = emisor(rand.Next(250, pictureBox1.Width - 250), rand.Next(pictureBox1.Height - 50, pictureBox1.Height));
                        particulas[i].X = position.X;
                        particulas[i].Y = position.Y;
                        particulas[i].DX = rand.Next(-3, 4);
                        particulas[i].DY = rand.Next(-5, 0);
                        particulas[i].lifes = rand.Next(30, 50);
                        particulas[i].Color = Color.FromArgb(255,155, 155, 155);
                    }
                    // Update ball's position          
                    particulas[i].lifes--;
                }
              
            }

            // Draw the balls
            drawBalls();
            pictureBox1.Invalidate();

        }

         public void drawBalls()
         {
            // Draw the background
            g.Clear(Color.Black);
           
            // Draw the balls
            for (int i = 0; i < particulas.Count; i++)
                {
                    int alpha = 255 * particulas[i].lifes / 50; // calcular valor de alpha en función de lifes
                    Color colorWithAlpha = Color.FromArgb(alpha, particulas[i].Color); // crear nuevo color con valor de alpha
                    Brush brush = new SolidBrush(colorWithAlpha);
                    g.FillEllipse(brush, Convert.ToInt32(particulas[i].X), Convert.ToInt32(particulas[i].Y), particulas[i].ballsize, particulas[i].ballsize);
                }
            pictureBox1.Refresh();
         }

        private void button1_Click(object sender, EventArgs e)
        {
            LluviaB = true;
            FuegoB = false;
            NieveB = false;
            HumoB = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LluviaB = false;
            FuegoB = true;
            NieveB = false;
            HumoB = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LluviaB = false;
            FuegoB = false;
            NieveB= true;
            HumoB = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LluviaB = false;
            FuegoB = false;
            NieveB = false;
            HumoB = true;
        }
    }
    
}
