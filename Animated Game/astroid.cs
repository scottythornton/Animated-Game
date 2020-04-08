using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Animated_Game
{
    

    class astroid
    {
        public SolidBrush asteroidBrush;
        public int x, y, size;
        Random randGen = new Random();

        public astroid(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;

            randGen.Next(1, 20);
        }

        public astroid(SolidBrush _asteroidBrush, int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
            asteroidBrush = _asteroidBrush;
        }

        public void Move(string direction)
        {
            if (direction == "up")
            {
                y = y + 5;
            }

            if (direction == "down")
            {
                y = y - 5;
            }

            if (direction == "right")
            {
                x = x + 3;
            }

            if (direction == "left")
            {
                x = x - 3;
            }
        }
        public Boolean Collison(astroid heroBox)
        {
            Rectangle heroRec = new Rectangle(heroBox.x, heroBox.y, heroBox.size, heroBox.size);
            Rectangle hero2Rec = new Rectangle(heroBox.x, heroBox.y, heroBox.size, heroBox.size);
            Rectangle asteroidRec = new Rectangle(x, y, size, size);

            if (heroRec.IntersectsWith(asteroidRec))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
