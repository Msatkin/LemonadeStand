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
            display.FormatScreen();
            Console.ReadLine();
            DisplayStartingMessage();
            player = new Player();
            bool exit = false;
            while (!exit)
            {
                CreateNewDay();
                day.RunPreparationPhase(player, display);
                exit = day.GetExit();
                currentDay++;
            }
        }
        public void DisplayStartingMessage()
        {
            Console.Write("Press enter to begin.");
            Console.ReadLine();
        }
        private void CreateNewDay()
        {
            day = new Day();
            day.date = currentDay;
        }
    }
}
