using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController game;
            bool exit = false;
            while (!exit)
            {
                game = new GameController();
                game.Start();
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}
