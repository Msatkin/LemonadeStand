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
        Random random = new Random();

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
            if (CheckCost(cost) && CheckRecipe(recipe))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckCost(decimal cost)
        {
            if (money > cost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckRecipe(int[] recipe)
        {

            if (CheckLemons(recipe) && CheckSugar(recipe) && CheckIce(recipe))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckLemons(int[] recipe)
        {
            return ((tastePreference[0] - 1 <= recipe[0]) && (tastePreference[0] + 1 >= recipe[0]));
        }
        private bool CheckSugar(int[] recipe)
        {
            return ((tastePreference[1] - 1 <= recipe[1]) && (tastePreference[1] + 1 >= recipe[1]));
        }
        private bool CheckIce(int[] recipe)
        {
            return ((tastePreference[2] - 1 <= recipe[2]) && (tastePreference[2] + 1 >= recipe[2]));
        }
        //Create Taste Preferences------------------------------------
        public void GetTastePreference()
        {
            GetLemonPreference();
            GetSugarPreference();
            GetIcePreference();
        }
        public void GetLemonPreference()
        {
            int choice = random.Next(1, 100);
            if (choice < 5)
            {
                tastePreference[0] = 3;
            }
            else if (choice < 15)
            {
                tastePreference[0] = 4;
            }
            else if (choice < 35)
            {
                tastePreference[0] = 5;
            }
            else if (choice < 65)
            {
                tastePreference[0] = 6;
            }
            else if (choice < 85)
            {
                tastePreference[0] = 7;
            }
            else if (choice < 95)
            {
                tastePreference[0] = 8;
            }
            else
            {
                tastePreference[0] = 9;
            }
        }
        public void GetSugarPreference()
        {
            int choice = random.Next(1, 100);
            if (choice < 5)
            {
                tastePreference[1] = 1;
            }
            else if (choice < 15)
            {
                tastePreference[1] = 2;
            }
            else if (choice < 35)
            {
                tastePreference[1] = 3;
            }
            else if (choice < 65)
            {
                tastePreference[1] = 4;
            }
            else if (choice < 85)
            {
                tastePreference[1] = 5;
            }
            else if (choice < 95)
            {
                tastePreference[1] = 6;
            }
            else
            {
                tastePreference[1] = 7;
            }
        }
        public void GetIcePreference()
        {
            int choice = random.Next(1, 100);
            if (choice < 5)
            {
                tastePreference[2] = 1;
            }
            else if (choice < 15)
            {
                tastePreference[2] = 2;
            }
            else if (choice < 35)
            {
                tastePreference[2] = 3;
            }
            else if (choice < 65)
            {
                tastePreference[2] = 4;
            }
            else if (choice < 85)
            {
                tastePreference[2] = 5;
            }
            else if (choice < 95)
            {
                tastePreference[2] = 6;
            }
            else
            {
                tastePreference[2] = 7;
            }
        }
    }
}
