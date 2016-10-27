using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class GameController
    {
        Random random = new Random();
        UserInterface display;

        Player player;
        Audio audioPlayer;
        Day day;
        int currentDay = 1;

        public void Start()
        {
            audioPlayer = new Audio();
            display = new UserInterface(random);
            CreatePlayer();
            display.DisplayUpperInformation();
            //Run for each new day
            bool exit = false;
            while (!exit)
            {
                display.date = currentDay;
                CreateNewDay();
                day.RunMonrningPhase();
                currentDay++;
            }
        }
        private void CreateNewDay()
        {
            day = new Day(player, display);
            day.date = currentDay;
        }
        private void CreatePlayer()
        {
            player = new Player();
            player.display = display;
            player.random = random;
            display.player = player;
            display.GetPlayerName();
            player.name = player.name.Substring(0, Math.Min(13, player.name.Length));
        }
    }
}
