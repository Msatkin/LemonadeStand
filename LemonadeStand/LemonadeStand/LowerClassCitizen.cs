using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class LowerClassCitizen : Customer
    {
        Random random = new Random();
        public LowerClassCitizen()
        {
            money = 4;
            GetMoney();
        }
    }
}
