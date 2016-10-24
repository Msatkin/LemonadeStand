using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class UserInterface
    {
        public string message;
        public bool update = false;
        int screenWidth = 125;
        int screenHeight = 40;
        public void FormatScreen()
        {
            Console.SetWindowSize(screenWidth, screenHeight);
            DrawBorder();
            DisplayGetInput();
        }
        public void DrawBorder()
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
            Console.SetWindowPosition(0, 0);
        }
        public void DisplayGetInput()
        {
            ClearAll();
            for (int i = 1; i < screenWidth - 1; i++)
            {
                Console.SetCursorPosition(i, 30);
                Console.Write("_");
            }
            Console.SetCursorPosition(4, 32);
        }
        public void DisplayScreen()
        {
            bool exit = false;
            while (!exit)
            {
                if (update)
                {
                    Console.Clear();
                    Console.Write(message);
                    update = false;
                }
            }
        }
        public void DisplayWeather(float weather)
        {
            switch (Convert.ToString(weather))
            {
                case ".75":
                    message = "Today's weather is cloudy and cold.";
                    break;
                case "1":
                    message = "Today's weather is cloudy.";
                    break;
                case "1.25":
                    message = "Today's weather is cloudy but hot.";
                    break;
                case "1.75":
                    message = "Today's weather is sunny but cold.";
                    break;
                case "2":
                    message = "Today's weather is sunny.";
                    break;
                case "2.25":
                    message = "Today's weather is sunny and hot.";
                    break;
            }
            update = true;
        }
        public void ClearAll()
        {
            for (int i = 1; i < screenWidth - 1; i++)
            {
                for (int j = 1; j < screenHeight - 1; j++)
                {
                        Console.SetCursorPosition(i, j);
                        Console.Write(" ");
                }
            }
            Console.SetWindowPosition(0, 0);
        }
    }
}
