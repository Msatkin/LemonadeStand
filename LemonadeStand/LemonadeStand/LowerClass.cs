using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class LowerClass : Customer
    {
        Random random = new Random();
        public LowerClass()
        {
            money = 5;
            GetMoney();

        }
    }
}
