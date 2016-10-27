using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Stand
    {
        public Inventory inventory;
        public Stand()
        {
            inventory = new Inventory();
        }
        public void RemoveLemons(int amountToRemove)
        {
            for (int i = 0; i < amountToRemove; i++)
            {
                inventory.lemons.RemoveAt(0);
            }
        }
        public void RemoveSugar(int amountToRemove)
        {
            for (int i = 0; i < amountToRemove; i++)
            {
                inventory.sugar.RemoveAt(0);
            }
        }
        public void RemoveIce(int amountToRemove)
        {
            for (int i = 0; i < amountToRemove; i++)
            {
                inventory.ice.RemoveAt(0);
            }
        }
        public void RemoveCups(int amountToRemove)
        {
            for (int i = 0; i < amountToRemove; i++)
            {
                inventory.cups.RemoveAt(0);
            }
        }
        public void AddLemons(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                inventory.lemons.Add(new Lemon());
            }
        }
        public void AddSugar(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                inventory.sugar.Add(new CupofSugar());
            }
        }
        public void AddIce(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                inventory.ice.Add(new Ice());
            }
        }
        public void AddCups(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                inventory.cups.Add(new Cup());
            }
        }
    }
}
