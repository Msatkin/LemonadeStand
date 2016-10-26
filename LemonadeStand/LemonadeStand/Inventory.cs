using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        List<Lemon> lemons;
        List<CupofSugar> sugar;
        List<Ice> ice;
        List<Cup> cups;
        public int[] totalInventory = new int[4] { 0, 0, 0, 0 };
        public Inventory()
        {
            lemons = new List<Lemon>();
            sugar = new List<CupofSugar>();
            ice = new List<Ice>();
            cups = new List<Cup>();
        }
        public void AddLemons(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                lemons.Add(new Lemon());
            }
            totalInventory[0] = lemons.Count();
        }
        public void AddSugar(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                sugar.Add(new CupofSugar());
            }
            totalInventory[1] = sugar.Count();
        }
        public void AddIce(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                ice.Add(new Ice());
            }
            totalInventory[2] = ice.Count();
        }
        public void AddCups(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                cups.Add(new Cup());
            }
            totalInventory[3] = cups.Count();
        }
    }
}
