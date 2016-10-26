using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Item
    {
        public virtual Item Clone()
        {
            return (Item)this.MemberwiseClone();
        }
    }
}
