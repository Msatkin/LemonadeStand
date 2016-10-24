using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        Player player;
        Customer customer;
        UserInterface display;
        Random random = new Random();
        Weather weather = new Weather();
        float weatherModifier;
        int defaultCustomerAmount = 25;
        public int date;

        //Phase 1----------------------------------------------------------------
        public void RunPreparationPhase(Player player, UserInterface display)
        {
            this.player = player;
            this.display = display;
            GetWeather();
            OpenShop();
            player.GetLemonadeRecipe();
            player.GetCost();
            RunSalePhase();
        }
        public void GetWeather()
        {
            weatherModifier = weather.GetWeather();
            display.DisplayWeather(weatherModifier);
            Console.ReadLine();
        }
        public void OpenShop()
        {
            player.BuyLemons();
            player.BuySugar();
            player.BuyIce();
            player.BuyCups();
        }

        //Phase 2----------------------------------------------------------------
        public void RunSalePhase()
        {
            double population = GetNumberOfCustomers();
            for (int i = 0; i < population; i++)
            {
                customer = GetCustomerType();
                customer.GetTastePreference();
                //Has enough lemonade
                if (player.drinks == 0)
                {
                    player.MakeDrinks();
                }
                //Has enough materials
                if (player.drinks > 0 && player.totalIce > player.recipe[2] && player.totalCups > 0)
                {
                    //Customer is interested
                    bool cupSold = customer.CheckSale(player.costPerCup, player.recipe);
                    if (cupSold)
                    {
                        player.SellCup();
                        player.salesMade++;
                    }
                }
            }
            RunEndOfDayPhase();
        }
        public void RunEndOfDayPhase()
        {
            Console.Clear();
            Console.WriteLine("Today you made ${0}!", player.moneyMade);
            Console.ReadLine();
            player.money += player.moneyMade;
            player.Clear();
        }
        public double GetNumberOfCustomers()
        {
            return Math.Floor((defaultCustomerAmount * weatherModifier) + date);
        }
        public Customer GetCustomerType()
        {
            switch(random.Next(2))
            {
                case 0:
                    return new LowerClass();

                case 1:
                    return new MiddleClass();

                case 2:
                    return new UpperClass();

                default:
                    return new MiddleClass();
            }
        }

        public bool GetExit()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Exit the game? (Y/N)");
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                        return true;

                    case "n":
                        return false;
                }
            }
            return false;
        }
    }
}