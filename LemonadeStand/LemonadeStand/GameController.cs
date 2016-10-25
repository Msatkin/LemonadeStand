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
        Random random = new Random();
        Player player;
        Day day;
        int currentDay = 1;

        public void Start()
        {
            display.date = currentDay;
            display.FormatScreen();
            CreatePlayer();
            display.DisplayUpperInformation();
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
        private void CreatePlayer()
        {
            player = new Player();
            player.display = display;
            player.random = random;
            display.player = player;
            display.GetPlayerName();
        }
    }
}
