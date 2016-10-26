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
        Store store;
        Random random = new Random();
        Weather weather = new Weather();
        int defaultCustomerAmount = 15;
        public int date;
        float todaysWeather;
        public bool rain = false;
        int badtaste = 0;
        int tooExpensive = 0;
        double population = 0;
        public Day(Player player, UserInterface display)
        {
            this.player = player;
            this.display = display;
            store = new Store(player);
            todaysWeather = weather.GetWeather();
            display.DisplayArt(todaysWeather);
        }
        //---------------------------------------------Phase 1
        public void RunMonrningPhase()
        {
            GetStartOfDayInput();
            RunSalePhase();
        }
        public void OpenShop()
        {
            store.SellLemons();
            store.SellSugar();
            store.SellIce();
            store.SellCups();
        }
        private void GetStartOfDayInput()
        {
            display.DisplayStartOfDayChoices();
            bool exit = false;
            while(!exit)
            {
                exit = ChooseSelection();
            }
        }
        public bool ChooseSelection()
        {
            bool preformAction = display.GetStartDaySelection();
            if (preformAction)
            {
                switch (display.startDaySelection + 1)
                {
                    case 1:
                        display.DisplayWeather(todaysWeather);
                        display.DisplayStartOfDayChoices();
                        break;
                    case 2:
                        OpenShop();
                        display.DisplayStartOfDayChoices();
                        break;
                    case 3:
                        player.GetLemonadeRecipe();
                        display.DisplayStartOfDayChoices();
                        break;
                    case 4:
                        player.GetCost();
                        display.DisplayStartOfDayChoices();
                        break;
                    case 5:
                        return true;
                    case 6:
                        Environment.Exit(0);
                        break;
                }
            }
            return false;
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
                if (player.drinks > 0 && player.stand.inventory.totalInventory[2] >= player.recipe[2] && player.stand.inventory.totalInventory[3] > 0)
                {
                    //Customer is interested
                    bool cupSold = customer.CheckSale(player.costPerCup, player.recipe);
                    if (cupSold)
                    {
                        player.SellCup();
                        player.salesMade++;
                    }
                    else
                    {
                        if (customer.badTaste)
                        {
                            badtaste++;
                        }
                        if (customer.tooExpensive)
                        {
                            tooExpensive++;
                        }
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
            switch(random.Next(3))
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
    }
}