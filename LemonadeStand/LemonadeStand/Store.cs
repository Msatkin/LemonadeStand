using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        Random random;
        Player player;
        UserInterface display;
        int buyAmount;
        int cupsOfSugarPerPound = 3;
        int iceCubesPerBag = 50;
        int cupsPerBag = 10;
        private decimal[] supplyCost = new decimal[4] { 0, 0, 0, 0 };
        private decimal[] defaultSupplyCost = new decimal[4] { .5m, 1m, 3m, 1m };

        public Store(Player player)
        {
            this.player = player;
            random = player.random;
            display = player.display;
            GetTodaysPrices();
        }
        public void SellLemons()
        {
            string message = String.Format("The current cost of lemons is ${0} each.", supplyCost[0]);
            string messageTwo = "How many lemons do you wish to buy?";
            display.DisplayRequest(message, messageTwo);
            if (SellItem(0))
            {
                player.money -= buyAmount * supplyCost[0];
                player.stand.inventory.AddLemons(buyAmount);
            }
            else
            {
                SellLemons();
            }
        }
        public void SellSugar()
        {
            string message = String.Format("Sugar is ${0} per pound. There are {1} cups in each pound.", supplyCost[1],cupsOfSugarPerPound);
            string messageTwo = "How many bags of sugar do you wish to buy?";
            display.DisplayRequest(message, messageTwo);
            if (SellItem(1))
            {
                player.money -= buyAmount * supplyCost[1];
                player.stand.inventory.AddLemons(buyAmount * cupsOfSugarPerPound);
            }
            else
            {
                SellSugar();
            }
        }
        public void SellIce()
        {
            string message = String.Format("Bags of ice cost ${0} and provide you with {1} ice cubes.", supplyCost[2], iceCubesPerBag);
            string messageTwo = "How many bags of ice do you wish to buy?";
            display.DisplayRequest(message, messageTwo);
            if (SellItem(2))
            {
                player.money -= buyAmount * supplyCost[2];
                player.stand.inventory.AddLemons(buyAmount * iceCubesPerBag);
            }
            else
            {
                SellIce();
            }
        }
        public void SellCups()
        {
            string message = String.Format("Packs of cups cost ${0} and provide you with {1} cups.", supplyCost[3], cupsPerBag);
            string messageTwo = "How many cups do you wish to buy?";
            display.DisplayRequest(message, messageTwo);
            if (SellItem(3))
            {
                player.money -= buyAmount * supplyCost[3];
                player.stand.inventory.AddLemons(buyAmount * cupsPerBag);
            }
            else
            {
                SellCups();
            }
        }
        private bool SellItem(int i)
        {
            if (int.TryParse(Console.ReadLine(), out buyAmount))
            {
                if (player.GetCanBuy(buyAmount, supplyCost[i]))
                {
                    return true;
                }
                else
                {
                    display.DisplayNoMoneyError();
                    return false;
                }
            }
            else
            {
                display.DisplayEnterNumberError();
                return false;
            }
        }
        public void GetTodaysPrices()
        {
            for (int i = 0; i < supplyCost.Count(); i++)
            {
                SetTodaysPrices(i);
            }
        }
        private void SetTodaysPrices(int i)
        {
            int choice = random.Next(1, 100);
            if (choice < 5)
            {
                supplyCost[i] *= .7m;
            }
            else if (choice < 15)
            {
                supplyCost[i] *= .8m;
            }
            else if (choice < 35)
            {
                supplyCost[i] *= .9m;
            }
            else if (choice < 65)
            {
                supplyCost[i] *= 1;
            }
            else if (choice < 85)
            {
                supplyCost[i] *= 1.1m;
            }
            else if (choice < 95)
            {
                supplyCost[i] *= 1.2m;
            }
            else
            {
                supplyCost[i] *= 1.3m;
            }
        }
    }

}
