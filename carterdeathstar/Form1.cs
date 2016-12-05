using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;

//Program created by Carter Bott
//on November 28th, 2016.
//Description: A basic death star attack animation.

namespace carterdeathstar
{
    public partial class Form1 : Form
    {
        Graphics fg;    //Creates a graphics object

        int x;  //Variables for x and y locations and size
        int y;
        int s;

        SoundPlayer introsong = new SoundPlayer(Properties.Resources.imperial);     //Soundplayers for sound effects
        SoundPlayer explosion = new SoundPlayer(Properties.Resources.explosionfx);
        SoundPlayer xwing = new SoundPlayer(Properties.Resources.xwingfx);

        Font titleFont;     //Fonts, Brushes and Pens for creating strings and graphics
        Font msgFont;
        Font pFont;
        SolidBrush titleBrush;
        SolidBrush msgBrush;
        SolidBrush pBrush;
        SolidBrush bombBrush;
        Pen deathstarpen;
        
        public Form1()
        {
            InitializeComponent();
            Refresh();
        }

        public void endprogram()    //Ends program after simularion has ran
        {
            this.Close();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = null;
            Refresh();

            introsong.Play();

            clickLabel.Text = "";

            fg = this.CreateGraphics();

            titleFont = new Font("Arial", 20, FontStyle.Bold);
            titleBrush = new SolidBrush(Color.Red);
            
            msgFont = new Font("Courier New", 16, FontStyle.Regular);
            msgBrush = new SolidBrush(Color.White);

            pFont = new Font("Courier New", 14, FontStyle.Regular);
            pBrush = new SolidBrush(Color.White);

            fg.DrawString("Incoming Transmission...", titleFont, titleBrush, 0, 0);

            Thread.Sleep(3000);

            fg.Clear(Color.Black);

            fg.DrawString("Death Star Attack Plan:", msgFont, msgBrush, 20, 20);

            Thread.Sleep(1500);

            fg.DrawString("The empire does not consider a small snub fighter", pFont, pBrush, 20, 45);

            Thread.Sleep(2000);

            fg.DrawString("to be a threat against the Death Star. We will send", pFont, pBrush, 20, 70);

            Thread.Sleep(2000);

            fg.DrawString("X-Wing fighters down the trench to fire a photon", pFont, pBrush, 20, 95 );
            
            Thread.Sleep(2000);

            fg.DrawString("charge down the exhaust shaft of the ship. Only", pFont, pBrush, 20, 120);

            Thread.Sleep(2000);
               
            fg.DrawString("a direct hit will destroy the station.", pFont, pBrush, 20, 145);

            Thread.Sleep(2000);

            fg.DrawString("Good luck, and may the force be with you.", pFont, pBrush, 20, 170);

            Thread.Sleep(2000);

            pFont = new Font("Courier New", 16, FontStyle.Bold);
            pBrush = new SolidBrush(Color.Green);

            fg.DrawString("Simulation to follow...", pFont, pBrush, 20, 210);

            Thread.Sleep(3000);

            introsong.Stop();

            fg.Clear(Color.Black);

            Thread.Sleep(3000);

            xwing.Play();

            x = 610;    //Sets the initial location of the x and y values
            y = 20;
            s = 20;     //Sets the initial size of the explosion

            while (x >= -500) 
            {

                fg.Clear(Color.Black);

                deathstarpen = new Pen(Color.White);
                fg.DrawEllipse(deathstarpen, 150, 80, 300, 300);
                fg.DrawLine(deathstarpen, 300, 80, 300, 240);
                fg.DrawEllipse(deathstarpen, 290, 240, 20, 20);
                fg.DrawRectangle(deathstarpen, x, 20, 30, 20);

                if (x < 300 && y < 245)
                {
                    bombBrush = new SolidBrush(Color.Red);

                    fg.FillEllipse(bombBrush, 295, y, 10, 10);

                    y++;
                }

                if (y == 245)   //Creates an explosion graphic if y is equal to 245
                {
                    bombBrush = new SolidBrush(Color.Orange);

                    fg.FillEllipse(bombBrush, 295 - s / 2, 245 - s / 2, s, s);

                    s++;
                }

                if (s == 21)    //Plays an explosion sound effect if s is equal to 21
                {
                    explosion.Play();
                }

                if (s == 350) //Clears animation if s is equal to 350
                {
                    fg.Clear(Color.Black);

                    Thread.Sleep(1000);

                    fg.DrawString("End of Transmission", titleFont, titleBrush, 20, 20);

                    Thread.Sleep(3000);

                    endprogram();
                }

                Thread.Sleep(10);

                x--;
            }
        }
    }
}
