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
        public Weather weather;
        public Random random;
        public string message;
        public bool update = false;
        int upperHeight = 5;
        int screenWidth = 115;
        int screenHeight = 30;
        public int date;
        public int startDaySelection = 0;

        public UserInterface(Random random)
        {
            this.random = random;
            FormatScreen();
            Console.SetWindowPosition(0, 0);
        }
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
            DisplayInventory(lineOne + margin);
            DrawUpperLine(lineTwo);
            DisplayMoney(lineTwo + margin);
            DrawUpperLine(lineThree);
            DisplayProfit(lineThree + margin);
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
        private void DisplayInventory(int x)
        {
            DisplayLemonAmount(x);
            DisplaySugarAmount(x);
            DisplayIceAmount(x);
            DisplayCupAmount(x);
        }
        private void DisplayLemonAmount(int x)
        {
            Console.SetCursorPosition(x, 1);
            Console.Write("Lemons         : ");
            Console.Write(player.stand.inventory.lemons.Count());
        }
        private void DisplaySugarAmount(int x)
        {
            Console.SetCursorPosition(x, 2);
            Console.Write("Cups of sugar  : ");
            Console.Write(player.stand.inventory.sugar.Count());
        }
        private void DisplayIceAmount(int x)
        {
            Console.SetCursorPosition(x, 3);
            Console.Write("Cubes of Ice   : ");
            Console.Write(player.stand.inventory.ice.Count());
        }
        private void DisplayCupAmount(int x)
        {
            Console.SetCursorPosition(x, 4);
            Console.Write("Cups           : ");
            Console.Write(player.stand.inventory.cups.Count());
        }
        private void DisplayMoney(int x)
        {
            Console.SetCursorPosition(x, 1);
            Console.Write("Money");
            Console.SetCursorPosition(x, 3);
            Console.Write("$" + player.money);
        }
        private void DisplayProfit(int x)
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
            DisplayRecipeLemons(x);
            DisplayRecipeSugar(x);
            DisplayRecipeIce(x);
        }
        private void DisplayRecipeLemons(int x)
        {
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
        }
        private void DisplayRecipeSugar(int x)
        {
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
        }
        private void DisplayRecipeIce(int x)
        {
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
        public void ClearMiddleDisplay()
        {
            for (int i = 1; i < screenWidth - 1; i++)
            {
                for (int j = upperHeight + 1; j < (screenHeight/2) + 1; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
            Console.SetWindowPosition(0, 0);
        }
        //Start of Day selections
        public void DisplayStartOfDayChoices()
        {
            ClearMiddleDisplay();
            DisplayUpperInformation();
            startDaySelection = 0;
            int x = 15;
            int y = 9;
            Console.SetCursorPosition(x, y);
            Console.Write("-> Check the weather.");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("   Buy ingredients.");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("   Set your recipe.");
            Console.SetCursorPosition(x, y + 3);
            Console.Write("   Set lemonade cost");
            Console.SetCursorPosition(x, y + 4);
            Console.Write("   Start the day.");
            Console.SetCursorPosition(x, y + 5);
            Console.Write("   Exit the game.");
        }
        public bool GetStartDaySelection()
        {
            Console.SetCursorPosition(0, 0);
            ConsoleKeyInfo keypressed = Console.ReadKey();
            if (keypressed.Key == ConsoleKey.UpArrow || keypressed.Key == ConsoleKey.W)
            {
                MoveStartDaySelectionUp();
                return false;
            }
            else if (keypressed.Key == ConsoleKey.DownArrow || keypressed.Key == ConsoleKey.S)
            {
                MoveStartDaySelectionDown();
                return false;
            }
            else if (keypressed.Key == ConsoleKey.Enter)
            {
                return true;
            }
            return false;
        }
        private void MoveStartDaySelectionUp()
        {
            if (startDaySelection == 0)
            {
                ClearSelection();
                startDaySelection = 5;
                DrawNewSelection();
            }
                else
                {
                ClearSelection();
                startDaySelection -= 1;
                DrawNewSelection();
            }
        }
        private void MoveStartDaySelectionDown()
        {
            if (startDaySelection == 5)
            {
                ClearSelection();
                startDaySelection = 0;
                DrawNewSelection();
            }
            else
            {
                ClearSelection();
                startDaySelection += 1;
                DrawNewSelection();
            }
        }
        private void ClearSelection()
        {
            int x = 15;
            int y = 9;
            Console.SetCursorPosition(x, y + startDaySelection);
            Console.Write("  ");
        }
        private void DrawNewSelection()
        {
            int x = 15;
            int y = 9;
            Console.SetCursorPosition(x, y + startDaySelection);
            Console.Write("->");
        }
        public void DisplayEndOfDayInformation(int[] complaints)
        {
            ClearMiddleDisplay();
            DisplayUpperInformation();
            int x = 15;
            int y = 9;
            Console.SetCursorPosition(x, y);
            Console.Write("Today you made ${0}!", player.moneyMade);
            Console.SetCursorPosition(x, y + 1);
            Console.Write("You made {0} pitchers, totaling {1} cups of lemonade. You sold {2} cups of lemonade", player.pitchersMade, player.pitchersMade * 12, player.salesMade);
            Console.SetCursorPosition(x, y + 2);
            int lemonsUsed = (player.recipe[0] * player.pitchersMade);
            int sugarUsed = (player.recipe[1] * player.pitchersMade);
            int iceUsed = (player.recipe[2] * player.salesMade);
            Console.Write("You used {0} lemons, {1} cups of sugar, {2} cubes of ice, and {3} cups.", lemonsUsed, sugarUsed, iceUsed, player.salesMade);
            Console.SetCursorPosition(x, y + 3);
            Console.Write("{0} customers found your prices too expensive.", complaints[1]);
            Console.SetCursorPosition(x, y + 4);
            Console.Write("{0} customers found your recipe repulsive.", complaints[0]);
            Console.SetCursorPosition(x, y + 5);
            Console.Write("{0} customers didn't like the amount of lemons.", complaints[2]);
            Console.SetCursorPosition(x, y + 6);
            Console.Write("{0} customers didn't like the amount of sugar.", complaints[3]);
            Console.SetCursorPosition(x, y + 7);
            Console.Write("{0} customers didn't like the amount of ice cubes.", complaints[4]);
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
            ClearMiddleDisplay();
            DisplayUpperInformation();
            SetCursorForDisplay();
            Console.Write(message);
            Console.SetCursorPosition(15, 10);
            Console.Write(messageTwo);
            SetCursorForInput();
        }
        public void DisplayNoMoneyError()
        {
            ClearMiddleDisplay();
            SetCursorForDisplay();
            Console.Write("You do not have enough money.");
            SetCursorForInput();
            Console.ReadLine();
        }
        public void DisplayEnterNumberError()
        {
            ClearMiddleDisplay();
            SetCursorForDisplay();
            Console.Write("Please enter a whole number.");
            SetCursorForInput();
            Console.ReadLine();
        }
        public void DisplayCostNumberError()
        {
            ClearMiddleDisplay();
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
            Console.SetCursorPosition(15, 11);
        }
        public void GetPlayerName()
        {
            SetCursorForDisplay();
            Console.Write("Enter your name.");
            SetCursorForInput();
            player.name = Console.ReadLine();
            ClearMiddleDisplay();
        }
        //---------------------------------------------Weather
        public void DisplayWeather(float weather)
        {
            ClearMiddleDisplay();
            SetCursorForDisplay();
            if (this.weather.actualWeather)
            {
                Console.Write("Today's weather is {0} with a tempature of {1}°.",this.weather.currentWeather.ToLower(),this.weather.currentTemperature);
                Console.ReadLine();
            }
            else
            {
            Console.Write(GetWeatherMessage(weather));
            Console.ReadLine();
            }
        }
        private string GetWeatherMessage(float weather)
        {
            switch (Convert.ToString(weather))
            {
                case "0.75":
                    message = "Oh no! Its raining!";
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
        //---------------------------------------------Art
        private void ClearArt()
        {
            for (int i = 1; i < screenWidth - 1; i++)
            {
                for (int j = (screenHeight / 2) + 1; j < screenHeight; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
            Console.SetWindowPosition(0, 0);
        }
        public void DisplayArt(float weather)
        {
            ClearArt();
            if (weather == 0)
            {
                ClearArt();
                DisplayArtRain();
                DisplayArtGround();
                DisplayArtTree();
                DisplayArtStand();
            }
            else
            {
                ClearArt();
                DisplayArtGround();
                DisplayArtTree();
                DisplayArtStand();
            }
        }
        private void DisplayArtGround()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 1; i < screenWidth - 1; i++)
            {
                Console.SetCursorPosition(i, screenHeight - 1);
                Console.Write("M");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 1; i < screenWidth - 1; i++)
            {
                Console.SetCursorPosition(i, screenHeight - 2);
                Console.Write("_");
            }
        }
        private void DisplayArtTree()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int x = screenWidth - 30;
            Console.SetCursorPosition(x, screenHeight- 12);
            Console.Write("          ******");
            Console.SetCursorPosition(x, screenHeight- 11);
            Console.Write("       *************");
            Console.SetCursorPosition(x, screenHeight- 10);
            Console.Write("    *****************");
            Console.SetCursorPosition(x, screenHeight- 9);
            Console.Write("   *******************");
            Console.SetCursorPosition(x, screenHeight- 8);
            Console.Write("   ********************");
            Console.SetCursorPosition(x, screenHeight- 7);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("      \\\\   //");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ********");
            Console.SetCursorPosition(x, screenHeight- 6);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("       \\\\\\//");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" *******");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(x, screenHeight - 5);
            Console.Write("         \\\\\\////");
            Console.SetCursorPosition(x, screenHeight - 4);
            Console.Write("          |||//");
            Console.SetCursorPosition(x, screenHeight - 3);
            Console.Write("          |||||");
            Console.SetCursorPosition(x + 9, screenHeight - 2);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("/|||||\\");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void DisplayArtStand()
        {
            int x = screenWidth - 60;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, screenHeight - 5);
            Console.Write(" ___");
            Console.SetCursorPosition(x, screenHeight - 4);
            Console.Write("/___\\");
            Console.SetCursorPosition(x, screenHeight - 3);
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|");
            Console.SetCursorPosition(x, screenHeight - 2);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void DisplayArtRain()
        {
            for (int i = 1; i < screenWidth - 1; i++)
            {
                for (int j = (screenHeight / 2) + 1; j < screenHeight; j++)
                {
                    Console.SetCursorPosition(i, j);
                    if (random.Next(5) == 1)
                    {
                        Console.Write("/");
                    }
                }
            }
            Console.SetWindowPosition(0, 0);
        }
    }
}