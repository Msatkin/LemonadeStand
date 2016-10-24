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
        public string name;
        public decimal money = 20;
        public int totalLemons;
        public int totalCupsofSugar;
        public int totalIce;
        public int totalCups;
        public decimal costPerCup;
        public int drinks;
        public int salesMade;
        public int pitchersMade;
        private decimal lemonCost;
        private decimal sugarCost;
        private decimal iceCost;
        private decimal cupCost;
        decimal defaultLemonCost = .5m;
        decimal defaultSugarCost = 1m;
        decimal defaultIceCost = 5m;
        decimal defaultCupCost = 5m;
        public decimal moneyMade;
        Random random = new Random();

        //Clears all temporary data at the end of each day
        public void Clear()
        {
            lemonCost = 0;
            sugarCost = 0;
            iceCost = 0;
            cupCost = 0;
            salesMade = 0;
            pitchersMade = 0;
            drinks = 0;
            moneyMade = 0;
        }
        //Define Player--------------------------------
        public Player()
        {
            GetName();
        }
        private void GetName()
        {
            Console.Clear();
            Console.WriteLine("Enter your name.");
            name = Console.ReadLine();
        }
        //---------------------------------------------
        public void MakeDrinks()
        {
            if (totalLemons >= recipe[0] && totalCupsofSugar >= recipe[1])
            {
                drinks += 12;
                totalLemons -= recipe[0];
                totalCupsofSugar -= recipe[1];
                pitchersMade++;
            }
        }
        public void SellCup()
        {
            drinks -= 1;
            totalIce -= recipe[2];
            totalCups -= 1;
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
            lemonCost = GetItemCost() * defaultLemonCost;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("The current cost of lemons is ${0}", lemonCost);
                Console.WriteLine("How many lemons do you wish to buy?");
                string response = Console.ReadLine();
                int lemonsBought;
                try
                {
                    lemonsBought = Convert.ToInt32(response);
                    if (lemonsBought * lemonCost <= money)
                    {
                        money -= (lemonsBought * lemonCost);
                        totalLemons += lemonsBought;
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
            sugarCost = GetItemCost() * defaultSugarCost;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Sugar is ${0} per pound. There are 3 cups in each pound.", sugarCost);
                Console.WriteLine("How many bags of sugar do you wish to buy?");
                string response = Console.ReadLine();
                int sugarBought;
                try
                {
                    sugarBought = Convert.ToInt32(response);
                    if (sugarBought * sugarCost <= money)
                    {
                        money -= (sugarBought * sugarCost);
                        totalCupsofSugar += sugarBought * 3;
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
            iceCost = GetItemCost() * defaultIceCost;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Bags of ice cost ${0} and provide you with 50 ice cubes.",iceCost);
                Console.WriteLine("How many bags of ice do you wish to buy?");
                string response = Console.ReadLine();
                int iceBought;
                try
                {
                    iceBought = Convert.ToInt32(response);
                    if (iceBought * iceCost <= money)
                    {
                        money -= (iceBought * iceCost);
                        totalIce += iceBought * 50;
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
            cupCost = GetItemCost() * defaultCupCost;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Packs of cups cost ${0} and provide you with 50 cups.", cupCost);
                Console.WriteLine("How many cups do you wish to buy?");
                string response = Console.ReadLine();
                int cupsBought;
                try
                {
                    cupsBought = Convert.ToInt32(response);
                    if (cupsBought * cupCost <= money)
                    {
                        money -= (cupsBought * cupCost);
                        totalCupsofSugar += cupsBought * 50;
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
