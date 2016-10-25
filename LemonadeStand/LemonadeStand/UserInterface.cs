using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class UserInterface
    {
        public Player player;
        public string message;
        public bool update = false;
        int upperHeight = 5;
        int lowerHeight = 10;
        int screenWidth = 125;
        int screenHeight = 40;
        public int date;

        public void FormatScreen()
        {
            Console.SetWindowSize(screenWidth, screenHeight);
            DrawBaseScreen();
        }
        //---------------------------------------------Draw base screen features
        public void DrawBaseScreen()
        {
            DrawBorder();
            DrawUpperDivider();
            DrawLowerDivider();
            Console.SetWindowPosition(0, 0);
        }
        private void DrawBorder()
        {
            for (int i = 0; i < screenWidth; i++)
            {
                for (int j = 0; j < screenHeight; j++)
                {
                    if (i == 0 || j == 0 || i == screenWidth - 1 || j == screenHeight - 1)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("*");
                    }
                }
            }
        }
        private void DrawUpperDivider()
        {
            for (int i = 1; i < screenWidth - 1; i++)
            {
                Console.SetCursorPosition(i, upperHeight);
                Console.Write("_");
            }
        }
        private void DrawLowerDivider()
        {
            for (int i = 1; i < screenWidth - 1; i++)
            {
                Console.SetCursorPosition(i, screenHeight - lowerHeight);
                Console.Write("_");
            }
        }
        //---------------------------------------------Display lower section
        public void DisplayLowerInformation()
        {

        }
        public void ClearLower()
        {
            for (int i = 1; i < screenWidth - 1; i++)
            {
                for (int j = (screenHeight - lowerHeight) + 1; j < screenHeight - 1; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
            Console.SetWindowPosition(0, 0);
        }
        //---------------------------------------------Display upper section
        public void ClearUpper()
        {
            for (int i = 1; i < screenWidth - 1; i++)
            {
                for (int j = 1; j < upperHeight; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
            Console.SetWindowPosition(0, 0);
        }
        public void DisplayUpperInformation()
        {
            int margin = 6;
            int lineOne = 13 + margin;
            int lineTwo = 42 + margin;
            int lineThree = 58 + margin;
            WriteName(margin);
            WriteDay(margin);
            DrawUpperLine(lineOne);
            WriteInventory(lineOne + margin);
            DrawUpperLine(lineTwo);
            WriteMoney(lineTwo + margin);
            DrawUpperLine(lineThree);
            WriteProfit(lineThree + margin);
            SetCursorForInput();
        }
        private void WriteName(int x)
        {
            Console.SetCursorPosition(x, 1);
            Console.Write(player.name);
        }
        private void WriteDay(int x)
        {
            Console.SetCursorPosition(x, 3);
            Console.Write("Day: " + date);
        }
        private void DrawUpperLine(int x)
        {
            for (int i = 1; i < upperHeight; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write("|");
            }
        }
        private void WriteInventory(int x)
        {
            //Write lemon amount
            Console.SetCursorPosition(x, 1);
            Console.Write("Lemons         : ");
            Console.Write(player.inventory[0]);
            //Write sugar amount
            Console.SetCursorPosition(x, 2);
            Console.Write("Cups of sugar  : ");
            Console.Write(player.inventory[1]);
            //Write ice amount
            Console.SetCursorPosition(x, 3);
            Console.Write("Cubes of Ice   : ");
            Console.Write(player.inventory[2]);
            //Write cup amount
            Console.SetCursorPosition(x, 4);
            Console.Write("Cups           : ");
            Console.Write(player.inventory[3]);
        }
        private void WriteMoney(int x)
        {
            Console.SetCursorPosition(x, 1);
            Console.Write("Money");
            Console.SetCursorPosition(x, 3);
            Console.Write("$" + player.money);
        }
        private void WriteProfit(int x)
        {
            Console.SetCursorPosition(x, 1);
            Console.Write("Net Profit");
            Console.SetCursorPosition(x, 3);
            decimal profit = player.money - player.startingMoney;
            if (profit > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (profit < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write("  $" + profit);
            Console.ForegroundColor = ConsoleColor.White;
        }
        //---------------------------------------------Display middle section
        public void ClearMiddle()
        {
            for (int i = 1; i < screenWidth - 1; i++)
            {
                for (int j = upperHeight + 1; j < lowerHeight - 1; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
            Console.SetWindowPosition(0, 0);
        }
        //---------------------------------------------Input
        public void SetCursorForInput()
        {
            Console.SetCursorPosition(4, 33);
        }
        public void DisplayInputString(string message)
        {
            Console.SetCursorPosition(4, 32);
            Console.Write(message);
        }
        public void GetPlayerName()
        {
            DisplayInputString("Enter your name.");
            SetCursorForInput();
            player.name = Console.ReadLine();
            ClearLower();
        }
        //---------------------------------------------Weather
        public void DisplayWeather(float weather)
        {
            ClearUpper();
            Console.SetCursorPosition(30, 26);
            GetWeatherMessage(weather);
        }
        private string GetWeatherMessage(float weather)
        {
            switch (Convert.ToString(weather))
            {
                case ".75":
                    message = "Today's weather is cloudy and cold. The tempature is 40°.";
                    break;
                case "1":
                    message = "Today's weather is cloudy. The tempature is 50°.";
                    break;
                case "1.25":
                    message = "Today's weather is cloudy but hot. The tempature is 70°.";
                    break;
                case "1.75":
                    message = "Today's weather is sunny but cold. The tempature is 60°.";
                    break;
                case "2":
                    message = "Today's weather is sunny. The tempature is 80°.";
                    break;
                case "2.25":
                    message = "Today's weather is sunny and hot. The tempature is 90°.";
                    break;
            }
            return message;
        }
    }
}