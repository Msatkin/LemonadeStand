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
        int screenWidth = 115;
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
            ClearUpper();
            int margin = 6;
            int lineOne = 13 + margin;
            int lineTwo = 42 + margin;
            int lineThree = 58 + margin;
            int lineFour = 79 + margin;
            WriteName(margin);
            WriteDay(margin);
            DrawUpperLine(lineOne);
            WriteInventory(lineOne + margin);
            DrawUpperLine(lineTwo);
            WriteMoney(lineTwo + margin);
            DrawUpperLine(lineThree);
            WriteProfit(lineThree + margin);
            DrawUpperLine(lineFour);
            WriteRecipe(lineFour + margin);
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
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void WriteRecipe(int x)
        {
            Console.SetCursorPosition(x + 4, 1);
            Console.Write("Recipe");
            //Write lemon amount
            Console.SetCursorPosition(x, 2);
            Console.Write("Lemons         : ");
            if (player.recipe[0] == 0)
            {
                Console.Write("---");
            }
            else
            {
            Console.Write(player.recipe[0]);
            }
            //Write sugar amount
            Console.SetCursorPosition(x, 3);
            Console.Write("Cups of sugar  : ");
            if (player.recipe[1] == 0)
            {
                Console.Write("---");
            }
            else
            {
                Console.Write(player.recipe[1]);
            }
            //Write ice amount
            Console.SetCursorPosition(x, 4);
            Console.Write("Cubes of Ice   : ");
            if (player.recipe[2] == 0)
            {
                Console.Write("---");
            }
            else
            {
                Console.Write(player.recipe[2]);
            }
        }
        //---------------------------------------------Display middle section
        public void ClearMiddle()
        {
            for (int i = 1; i < screenWidth - 1; i++)
            {
                for (int j = upperHeight + 1; j < (screenHeight - lowerHeight) - 1; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
            Console.SetWindowPosition(0, 0);
        }
        public void DisplayStartOfDayChoices()
        {
            ClearMiddle();
            ClearLower();
            DisplayUpperInformation();
            int x = 15;
            int y = 9;
            Console.SetCursorPosition(x, y);
            Console.Write("1: Check the weather.");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("2: Buy ingredients.");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("3: Set your recipe.");
            Console.SetCursorPosition(x, y + 3);
            Console.Write("4: Set lemonade cost");
            Console.SetCursorPosition(x, y + 4);
            Console.Write("5: Start the day.");
            Console.SetCursorPosition(x, y + 5);
            Console.Write("6: Exit the game.");
            SetCursorForInput();
        }
        public void DisplayEndOfDayInformation()
        {
            ClearMiddle();
            ClearLower();
            DisplayUpperInformation();
            int x = 15;
            int y = 9;
            Console.SetCursorPosition(x, y);
            Console.Write("Today you made ${0}!", player.moneyMade);
            Console.SetCursorPosition(x, y + 2);
            Console.Write("You sold {0} cups of lemonade", player.salesMade);
            Console.SetCursorPosition(x, y + 4);
            int lemonsUsed = (player.recipe[0] * player.pitchersMade);
            int sugarUsed = (player.recipe[1] * player.pitchersMade);
            int iceUsed = (player.recipe[2] * player.salesMade);
            Console.Write("You used {0} lemons, {1} cups of sugar, {2} cubes of ice, and {3} cups.", lemonsUsed, sugarUsed, iceUsed, player.salesMade);
            SetCursorForInput();
        }
        public void DisplayRequest(string message)
        {
            SetCursorForDisplay();
            Console.Write(message);
            SetCursorForInput();
        }
        public void DisplayRequest(string message, string messageTwo)
        {
            SetCursorForDisplay();
            Console.Write(message);
            Console.SetCursorPosition(15, 10);
            Console.Write(messageTwo);
            SetCursorForInput();
        }
        public void DisplayNoMoneyError()
        {
            ClearMiddle();
            SetCursorForDisplay();
            Console.Write("You do not have enough money.");
            SetCursorForInput();
            Console.ReadLine();
        }
        public void DisplayEnterNumberError()
        {
            ClearMiddle();
            SetCursorForDisplay();
            Console.Write("Please enter a whole number.");
            SetCursorForInput();
            Console.ReadLine();
        }
        public void DisplayCostNumberError()
        {
            ClearMiddle();
            SetCursorForDisplay();
            Console.Write("Please enter a number.");
            SetCursorForInput();
            Console.ReadLine();
        }
        public void SetCursorForDisplay()
        {
            Console.SetCursorPosition(15, 9);
        }
        //---------------------------------------------Input
        public void SetCursorForInput()
        {
            Console.SetCursorPosition(4, 33);
        }
        public void GetPlayerName()
        {
            SetCursorForDisplay();
            Console.Write("Enter your name.");
            SetCursorForInput();
            player.name = Console.ReadLine();
            ClearLower();
        }
        //---------------------------------------------Weather
        public void DisplayWeather(float weather)
        {
            ClearMiddle();
            ClearLower();
            SetCursorForDisplay();
            Console.Write(GetWeatherMessage(weather));
            Console.ReadLine();
        }
        private string GetWeatherMessage(float weather)
        {
            switch (Convert.ToString(weather))
            {
                case "0.75":
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
                default:
                    message = "ERROR! ERROR! ERROR!";
                    break;
            }
            return message;
        }
    }
}