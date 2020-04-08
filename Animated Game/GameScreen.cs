using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animated_Game
{
    public partial class GameScreen : UserControl
    {
        Random randGen = new Random();
        SolidBrush asteroidBrush = new SolidBrush(Color.White);
        Pen drawPen = new Pen(Color.White, 2);
        Boolean upKeyDown, downKeyDown;

        List<astroid> leftAsteroids = new List<astroid>();
        List<astroid> rightAsteriods = new List<astroid>();

        int playerSize = 9;
        int asteroidLeftX = 0;
        int asteroidRightX = 0;
        int asteriodSize = 3;
        int counter = 0;
        int newBoxCounter = 0;
        int player1score = 0;
        int player2score = 0;


        astroid hero;
        astroid hero2;


        public GameScreen()
        {
            InitializeComponent();
            OnStart();

        }
        public void OnStart()
        {
            astroid b1 = new astroid(asteroidBrush, asteroidLeftX, 0, asteriodSize);
            leftAsteroids.Add(b1);

            astroid b2 = new astroid(asteroidBrush, asteroidLeftX, 0, asteriodSize);
            rightAsteriods.Add(b2);

            newBoxCounter++;

            hero = new astroid(80, this.Height - 40, playerSize);
            hero2 = new astroid(this.Width - 80, this.Height - 40, playerSize);
        }
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    upKeyDown = true;
                    break;
                case Keys.Up:
                    downKeyDown = true;
                    break;
            }
        }
        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    upKeyDown = false;
                    break;
                case Keys.Up:
                    downKeyDown = false;
                    break;
            }
        }
        private void gameLoop_Tick(object sender, EventArgs e)
        {
            // - update location of all boxes (drop down screen)
            foreach (astroid b in leftAsteroids)
            {
                b.Move("right");
            }
            foreach (astroid b in rightAsteriods)
            {
                b.Move("left");
            }
            // -remove box if it has gone of screen
            if (leftAsteroids[0].x > this.Width)
            {
                leftAsteroids.RemoveAt(0);
            }
            if (rightAsteriods[0].x > this.Width)
            {
                rightAsteriods.RemoveAt(0);
            }

            counter++;
            if (counter == 9)
            {
                newBoxCounter++;

                int y = randGen.Next(81, this.Height);

                astroid b1 = new astroid(asteroidBrush, 0, y, asteriodSize);
                leftAsteroids.Add(b1);
                
                y = randGen.Next(81, this.Height);

                astroid b2 = new astroid(asteroidBrush, this.Width, y, asteriodSize);
                rightAsteriods.Add(b2);

                counter = 0;
            }

            if (upKeyDown)
            {
                hero.Move("up");
            }

            if (downKeyDown)
            {
                hero.Move("down");
            }
            

            

            foreach (astroid b in leftAsteroids.Union(rightAsteriods))
            {
                if (b.Collison(hero))
                {
                    hero = new astroid(80, this.Height - 40, playerSize);
                }
            }

            foreach (astroid b in leftAsteroids.Union(rightAsteriods))
            {
                if (b.Collison(hero2))
                {
                    hero2 = new astroid(this.Width - 80, this.Height - 40, playerSize);
                }
            }

            if (hero.y < 0)
            {
                hero = new astroid(80, this.Height - 40, playerSize);
                player1score++;
            }

            if (hero2.y < 0)
            {
                hero2 = new astroid(this.Width - 80, this.Height - 40, playerSize);
                player2score++;
            }




            Refresh();

        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // - draw boxes to screen
            foreach (astroid b in leftAsteroids)
            {
                e.Graphics.FillRectangle(b.asteroidBrush, b.x, b.y, b.size, b.size);
            }
            foreach (astroid b in rightAsteriods)
            {
                e.Graphics.FillRectangle(b.asteroidBrush, b.x, b.y, b.size, b.size);
            }

            e.Graphics.FillRectangle(asteroidBrush, hero.x, hero.y, hero.size, hero.size);
            e.Graphics.FillRectangle(asteroidBrush, hero2.x, hero2.y, hero2.size, hero2.size);
            e.Graphics.DrawLine(drawPen, 0, this.Height - 45, this.Width, this.Height - 45);

        }

    }
}

