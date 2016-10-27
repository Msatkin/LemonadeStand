using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        public decimal money;
        public int[] tastePreference = new int[3];
        int averageLemonPreference = 6;
        int averageSugarPreference = 4;
        int averageIcePreference = 4;
        public bool tooExpensive = false;
        public bool badTaste = false;
        Random random = new Random();
        int[] recipe;
        decimal cost;

        public void GetMoney()
        {
            int choice = random.Next(1, 100);
            if (choice < 5)
            {
                money *= .7m;
            }
            else if (choice < 15)
            {
                money *= .8m;
            }
            else if (choice < 35)
            {
                money *= .9m;
            }
            else if (choice < 65)
            {
                money *= 1;
            }
            else if (choice < 85)
            {
                money *= 1.1m;
            }
            else if (choice < 95)
            {
                money *= 1.2m;
            }
            else
            {
                money *= 1.3m;
            }
        }
        //Check if sale is made---------------------------------------
        public bool CheckSale(decimal cost, int[] recipe)
        {
            this.cost = cost;
            this.recipe = recipe;
            if (CheckCost() && CheckRecipe())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckCost()
        {
            if (money > cost)
            {
                return true;
            }
            else
            {
                tooExpensive = true;
                return false;
            }
        }
        private bool CheckRecipe()
        {

            if (CheckLemons() && CheckSugar() && CheckIce())
            {
                return true;
            }
            else
            {
                badTaste = true;
                return false;
            }
        }
        public bool CheckLemons()
        {
            return ((recipe[0] - 1 <= tastePreference[0]) || (recipe[0] + 1 >= tastePreference[0]) || (recipe[0] == tastePreference[0]));
        }
        public bool CheckSugar()
        {
            return ((recipe[1] - 1 <= tastePreference[1]) || (recipe[1] + 1 >= tastePreference[1]) || (recipe[1] == tastePreference[1]));
        }
        public bool CheckIce()
        {
            return ((recipe[2] - 1 <= tastePreference[2]) || (recipe[2] + 1 >= tastePreference[2]) || (recipe[2] == tastePreference[2]));
        }
        //Create Taste Preferences------------------------------------
        public void GetTastePreference()
        {
            GetItemPreference(averageLemonPreference);
            GetItemPreference(averageSugarPreference);
            GetItemPreference(averageIcePreference);
        }
        public void GetItemPreference(int average)
        {
            int choice = random.Next(1, 100);
            if (choice < 5)
            {
                tastePreference[0] = average - 3;
            }
            else if (choice < 15)
            {
                tastePreference[0] = average - 2;
            }
            else if (choice < 35)
            {
                tastePreference[0] = average - 1;
            }
            else if (choice < 65)
            {
                tastePreference[0] = average;
            }
            else if (choice < 85)
            {
                tastePreference[0] = average + 1;
            }
            else if (choice < 95)
            {
                tastePreference[0] = average + 2;
            }
            else
            {
                tastePreference[0] = average + 3;
            }
        }
    }
}
