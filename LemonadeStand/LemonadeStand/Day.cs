﻿using System;
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
        int[] customerComplaints = new int[5] { 0, 0, 0, 0, 0 };
        double population = 0;

        public Day(Player player, UserInterface display)
        {
            this.player = player;
            this.display = display;
            display.weather = weather;
            store = new Store(player);
            todaysWeather = weather.GetCurrentConditions();
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
            bool actionChoosen = display.GetStartDaySelection();
            if (actionChoosen)
            {
                return PreformAction();
            }
            return false;
        }
        public bool PreformAction()
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
                if (player.drinks > 0 && player.stand.inventory.ice.Count() >= player.recipe[2] && player.stand.inventory.cups.Count() > 0)
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
                        GetOpinion();
                    }
                }
            }
            RunEndOfDayPhase();
        }
        private void GetOpinion()
        {
            if (customer.badTaste)
            {
                customerComplaints[0]++;
            }
            if (customer.tooExpensive)
            {
                customerComplaints[1]++;
            }
            if (!customer.CheckLemons())
            {
                customerComplaints[2]++;
            }
            if (!customer.CheckSugar())
            {
                customerComplaints[3]++;
            }
            if (!customer.CheckIce())
            {
                customerComplaints[4]++;
            }
        }
        public void RunEndOfDayPhase()
        {
            display.DisplayEndOfDayInformation(customerComplaints);
            player.money += player.moneyMade;
            display.DisplayUpperInformation();
            Console.SetCursorPosition(15, 17);
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