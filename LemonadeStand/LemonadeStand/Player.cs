using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        public int[] recipe = new int[3];
        public string name = "null";
        public decimal startingMoney = 20;
        public decimal money = 20;
        public int[] inventory = new int[4] { 0, 0, 0, 0 };
        public decimal costPerCup;
        public int drinks;
        public int salesMade;
        public int pitchersMade;
        private decimal[] supplyCost = new decimal[4] { 0, 0, 0, 0 };
        private decimal[] defaultSupplyCost = new decimal[4] { .5m, 1m, 5m, 5m };
        public decimal moneyMade;
        Random random = new Random();

        //Clears all temporary data at the end of each day
        public void Clear()
        {
            supplyCost[0] = 0;
            supplyCost[1] = 0;
            supplyCost[2] = 0;
            supplyCost[3] = 0;
            salesMade = 0;
            pitchersMade = 0;
            drinks = 0;
            moneyMade = 0;
        }
        //---------------------------------------------
        public void MakeDrinks()
        {
            if (inventory[0] >= recipe[0] && inventory[1] >= recipe[1])
            {
                drinks += 12;
                inventory[0] -= recipe[0];
                inventory[1] -= recipe[1];
                pitchersMade++;
            }
        }
        public void SellCup()
        {
            drinks -= 1;
            inventory[2] -= recipe[2];
            inventory[3] -= 1;
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
                Console.Clear();
                Console.WriteLine(message);
                string response = Console.ReadLine();
                try
                {
                    int amount = Convert.ToInt32(response);
                    return amount;
                }
                catch
                {
                    Console.WriteLine("Please enter a whole number.");
                }
            }
            return 0;
        }
        public void GetCost()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("How much would you like to charge per cup of lemonade?");
                string response = Console.ReadLine();
                try
                {
                    decimal amount = Convert.ToDecimal(response);
                    costPerCup = amount;
                    exit = true;
                }
                catch
                {
                    Console.WriteLine("Please enter a number.");
                }
            }
        }
        //Buy Items------------------------------------
        public void BuyLemons()
        {
            supplyCost[0] = GetItemCost() * defaultSupplyCost[0];
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("The current cost of lemons is ${0}", supplyCost[0]);
                Console.WriteLine("How many lemons do you wish to buy?");
                string response = Console.ReadLine();
                int lemonsBought;
                try
                {
                    lemonsBought = Convert.ToInt32(response);
                    if (lemonsBought * supplyCost[0] <= money)
                    {
                        money -= (lemonsBought * supplyCost[0]);
                        inventory[0] += lemonsBought;
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough money.");
                        Console.ReadLine();
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a number.");
                    Console.ReadLine();
                }
            }
        }
        public void BuySugar()
        {
            supplyCost[1] = GetItemCost() * defaultSupplyCost[1];
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Sugar is ${0} per pound. There are 3 cups in each pound.", supplyCost[1]);
                Console.WriteLine("How many bags of sugar do you wish to buy?");
                string response = Console.ReadLine();
                int sugarBought;
                try
                {
                    sugarBought = Convert.ToInt32(response);
                    if (sugarBought * supplyCost[1] <= money)
                    {
                        money -= (sugarBought * supplyCost[1]);
                        inventory[1] += sugarBought * 3;
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough money.");
                        Console.ReadLine();
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a number.");
                    Console.ReadLine();
                }
            }
        }
        public void BuyIce()
        {
            supplyCost[2] = GetItemCost() * defaultSupplyCost[2];
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Bags of ice cost ${0} and provide you with 50 ice cubes.",supplyCost[2]);
                Console.WriteLine("How many bags of ice do you wish to buy?");
                string response = Console.ReadLine();
                int iceBought;
                try
                {
                    iceBought = Convert.ToInt32(response);
                    if (iceBought * supplyCost[2] <= money)
                    {
                        money -= (iceBought * supplyCost[2]);
                        inventory[2] += iceBought * 50;
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough money.");
                        Console.ReadLine();
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a number.");
                    Console.ReadLine();
                }
            }
        }
        public void BuyCups()
        {
            supplyCost[3] = GetItemCost() * defaultSupplyCost[3];
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Packs of cups cost ${0} and provide you with 50 cups.", supplyCost[3]);
                Console.WriteLine("How many cups do you wish to buy?");
                string response = Console.ReadLine();
                int cupsBought;
                try
                {
                    cupsBought = Convert.ToInt32(response);
                    if (cupsBought * supplyCost[3] <= money)
                    {
                        money -= (cupsBought * supplyCost[3]);
                        inventory[1] += cupsBought * 50;
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough money.");
                        Console.ReadLine();
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a number.");
                    Console.ReadLine();
                }
            }
        }
        //SetItemPrices-------------------------------
        public decimal GetItemCost()
        {
            int choice = random.Next(1, 100);
            if (choice < 5)
            {
                return .7m;
            }
            else if (choice < 15)
            {
                return .8m;
            }
            else if (choice < 35)
            {
                return .9m;
            }
            else if (choice < 65)
            {
                return 1;
            }
            else if (choice < 85)
            {
                return 1.1m;
            }
            else if (choice < 95)
            {
                return 1.2m;
            }
            else
            {
                return 1.3m;
            }
        }
    }
}
