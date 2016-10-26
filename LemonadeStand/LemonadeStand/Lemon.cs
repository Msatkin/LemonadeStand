using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Lemon : Item
    {
        public override Item Clone()
        {
            return (Lemon) this.MemberwiseClone();
        }
    }
}
