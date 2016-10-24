using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        Random random = new Random();
        float[] tempatureModifier = new float[3] { -0.25f, 0, 0.25f };
        public float GetWeather()
        {
            int weatherType = random.Next(1,2);
            float tempatureLevel = tempatureModifier[random.Next(2)];
            float weather = weatherType + tempatureLevel;
            return weather;
        }
    }
}
