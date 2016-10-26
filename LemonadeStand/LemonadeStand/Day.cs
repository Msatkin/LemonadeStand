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
        int defaultCustomerAmount = 15;
        public int date;
        float todaysWeather;
        int badtaste = 0;
        int tooExpensive = 0;
        double population = 0;

        //---------------------------------------------Phase 1
        public void RunPreparationPhase(Player player, UserInterface display)
        {
            this.player = player;
            this.display = display;
            todaysWeather = weather.GetWeather();
            bool exit = false;
            while (!exit)
            {
                display.DisplayStartOfDayChoices();
                switch(Console.ReadLine())
                {
                    case "1":
                        display.DisplayWeather(todaysWeather);
                        break;
                    case "2":
                        OpenShop();
                        break;
                    case "3":
                        player.GetLemonadeRecipe();
                        break;
                    case "4":
                        player.GetCost();
                        break;
                    case "5":
                        exit = true;
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                }
            }
            RunSalePhase();
        }
        public void OpenShop()
        {
            player.BuyLemons();
            player.BuySugar();
            player.BuyIce();
            player.BuyCups();
        }
        //---------------------------------------------Phase 2
        public void RunSalePhase()
        {
            population = GetNumberOfCustomers();
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
                if (player.drinks > 0 && player.inventory[2] >= player.recipe[2] && player.inventory[3] > 0)
                {
                    //Customer is interested
                    bool cupSold = customer.CheckSale(player.costPerCup, player.recipe);
                    if (cupSold)
                    {
                        player.SellCup();
                        player.salesMade++;
                    }
                    else if (customer.badTaste)
                    {
                        badtaste++;
                    }
                    else if (customer.tooExpensive)
                    {
                        tooExpensive++;
                    }
                }
            }
            RunEndOfDayPhase();
        }
        public void RunEndOfDayPhase()
        {
            display.DisplayEndOfDayInformation(tooExpensive, badtaste);
            player.money += player.moneyMade;
            display.DisplayUpperInformation();
            Console.ReadLine();
            player.Clear();
        }
        public double GetNumberOfCustomers()
        {
            return Math.Floor((defaultCustomerAmount * todaysWeather) + date);
        }
        public Customer GetCustomerType()
        {
            switch(random.Next(2))
            {
                case 0:
                    return new LowerClassCitizen();

                case 1:
                    return new MiddleClassCitizen();

                case 2:
                    return new UpperClassCitizen();

                default:
                    return new MiddleClassCitizen();
            }
        }
        //---------------------------------------------Exit
    }
}