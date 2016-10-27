using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        public int[] recipe = new int[3] { 0, 0, 0 };
        public string name;
        public decimal startingMoney = 50;
        public decimal money;
        public decimal costPerCup = 0;
        public int drinks;
        public int salesMade;
        public int pitchersMade;
        public decimal moneyMade;
        public Random random;
        public UserInterface display;
        public Stand stand;

        public Player()
        {
            stand = new Stand();
            money = startingMoney;
        }
        //Clears all temporary data
        public void Clear()
        {
            salesMade = 0;
            pitchersMade = 0;
            drinks = 0;
            moneyMade = 0;
        }
        //---------------------------------------------
        public void MakeDrinks()
        {
            if (stand.inventory.lemons.Count() >= recipe[0] && stand.inventory.sugar.Count() >= recipe[1])
            {
                drinks += 12;
                stand.RemoveLemons(recipe[0]);
                stand.RemoveSugar(recipe[1]);
                pitchersMade++;
            }
        }
        public void SellCup()
        {
            drinks -= 1;
            stand.RemoveIce(recipe[2]);
            stand.RemoveCups(1);
            moneyMade += costPerCup;
        }
        //---------------------------------------------
        public void GetLemonadeRecipe()
        {
            string message = "Choose how many lemons per pitcher";
            recipe[0] = GetAmountNeeded(message);
            message = "Choose how cups of sugar per pitcher";
            recipe[1] = GetAmountNeeded(message);
            message = "Choose how ice cubes per cup";
            recipe[2] = GetAmountNeeded(message);
        }
        public int GetAmountNeeded(string message)
        {
            bool exit = false;
            while (!exit)
            {
                display.ClearMiddleDisplay();
                display.ClearLower();
                display.DisplayUpperInformation();
                display.DisplayRequest(message);
                string response = Console.ReadLine();
                try
                {
                    int amount = Convert.ToInt32(response);
                    return amount;
                }
                catch
                {
                    display.DisplayEnterNumberError();
                }
            }
            return 0;
        }
        public void GetCost()
        {
            bool exit = false;
            while (!exit)
            {
                display.ClearMiddleDisplay();
                display.ClearLower();
                display.DisplayUpperInformation();
                display.DisplayRequest("How much would you like to charge per cup of lemonade?");
                string response = Console.ReadLine();
                try
                {
                    decimal amount = Convert.ToDecimal(response);
                    costPerCup = amount;
                    exit = true;
                }
                catch
                {
                    display.DisplayCostNumberError();
                }
            }
        }
        public bool GetCanBuy(int amount, decimal cost)
        {
            return money >= (amount * cost);
        }
    }
}