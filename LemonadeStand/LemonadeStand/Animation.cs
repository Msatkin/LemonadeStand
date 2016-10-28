using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Animation
    {
        public void RunFireworks(GameController game)
        {
            while (game.playingFireWorks)
            {
                int x = game.display.random.Next(5, 75);
                if (x < 55 || x > 60)
                {
                    lock (GameController.thisLock)
                    {
                        game.display.DisplayFireworks(x, game.display.screenHeight - 3);
                    }
                }
            }
        }
    }
}
