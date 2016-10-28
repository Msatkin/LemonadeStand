using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LemonadeStand
{
    class GameController
    {
        Random random = new Random();
        public UserInterface display;
        public static Object thisLock = new Object();
        Thread animationThread;
        Player player;
        Audio audioPlayer;
        Day day;
        int daysToPlay = 7;
        int currentDay = 1;
        public bool playingFireWorks = false;

        public void Start()
        {
            audioPlayer = new Audio();
            display = new UserInterface(random);
            display.game = this;
            CreatePlayer();
            display.DisplayUpperInformation();
            //Run for each new day
            bool exit = false;
            while (!exit)
            {
                display.date = currentDay;
                CreateNewDay();
                day.RunMonrningPhase();
                if (currentDay == daysToPlay)
                {
                    exit = true;
                }
                else
                {
                    currentDay++;
                }
            }
            FinishWeek();
            display.ClearMiddleDisplay();
            display.ClearArt();
            display.ClearUpper();
        }
        private void FinishWeek()
        {
            if ((player.money - player.startingMoney) < 0)
            {
                display.DisplayLose();
            }
            else
            {
                display.DisplayWin();
                playingFireWorks = true;
                animationThread = new Thread(new ThreadStart(() => AnimationThread(this)));
                animationThread.Start();
                GetPlayAgain();
                playingFireWorks = false;
            }
        }
        public static void AnimationThread(GameController game)
        {
            Animation animation = new Animation();
            animation.RunFireworks(game);
        }
        private void GetPlayAgain()
        {
            bool exit = false;
            while (!exit)
            {
                switch(GetKeyPressString())
                {
                    case "enter":
                        exit = true;
                        break;

                    case "escape":
                        Environment.Exit(0);
                        break;
                }
            }

        }
        public string GetKeyPressString()
        {
            string input = "";
            input += Console.ReadKey(true).Key;
            return input.ToLower();
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
