using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        public List<Lemon> lemons;
        public List<CupofSugar> sugar;
        public List<Ice> ice;
        public List<Cup> cups;
        public Inventory()
        {
            lemons = new List<Lemon>();
            sugar = new List<CupofSugar>();
            ice = new List<Ice>();
            cups = new List<Cup>();
        }
    }
}
