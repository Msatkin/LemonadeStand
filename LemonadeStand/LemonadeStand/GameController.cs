using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class GameController
    {
        UserInterface display = new UserInterface();
        Player player;
        Day day;
        int currentDay = 1;

        public void Start()
        {
            //Draw screen, create player, and set player name
            display.date = currentDay;
            display.FormatScreen();
            player = new Player();
            display.player = player;
            display.GetPlayerName();
            display.DisplayUpperInformation();
            Console.ReadLine();
            //Run for each new day
            bool exit = false;
            while (!exit)
            {
                CreateNewDay();
                day.RunPreparationPhase(player, display);
                exit = day.GetExit();
                currentDay++;
            }
        }
        private void CreateNewDay()
        {
            day = new Day();
            day.date = currentDay;
        }
    }
}
