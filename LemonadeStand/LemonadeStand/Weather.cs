using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Device.Location;

namespace LemonadeStand
{
    class Weather
    {
        Random random = new Random();
        XmlDocument xmlLocation;
        XmlDocument xmlConditions;
        float[] tempatureModifier = new float[3] { -0.25f, 0, 0.25f };
        private string zipCode;
        public string currentWeather;
        public float currentTemperature;
        public bool actualWeather = true;
        public float GetCurrentConditions()
        {
            xmlLocation = new XmlDocument();
            xmlLocation.Load("http://ip-api.com/xml");
            if (!CanGetLocation())
            {
                return GetWeather();
            }
            else
            {
                if (!CanGetWeather())
                {
                    return GetWeather();
                }
            }

            return GetActualWeather();
        }
        private bool CanGetLocation()
        {
            xmlLocation.Load("http://ip-api.com/xml");
            if (xmlLocation.SelectSingleNode("/query/status").InnerText == "fail")
            {
                actualWeather = false;
                return false;
            }
            else
            {
                zipCode = xmlLocation.SelectSingleNode("/query/zip").InnerText;
                return true;
            }
        }
        private bool CanGetWeather()
        {
            xmlConditions = new XmlDocument();
            xmlConditions.Load(String.Format("http://api.wunderground.com/api/c14e53931211628a/geolookup/conditions/q/{0}.xml", zipCode));
            if (xmlConditions.SelectSingleNode("/response/error") == null)
            {
                currentWeather = xmlConditions.SelectSingleNode("/response/current_observation/weather").InnerText;
                string temperatureString = xmlConditions.SelectSingleNode("/response/current_observation/temp_f").InnerText;
                if (!float.TryParse(temperatureString, out currentTemperature))
                {
                    currentTemperature = 75f;
                }
                return true;
            }
            else
            {
                actualWeather = false;
                return false;
            }
        }
        public float GetActualWeather()
        {
            float weather;
            switch(currentWeather.ToLower())
            {
                case "overcast":
                    weather = .75f;
                    break;
                case "clear":
                    weather = 2f;
                    break;
                case "partly cloudy":
                    weather = 1.5f;
                    break;
                case "mostly cloudy":
                    weather = 1;
                    break;
                default:
                    weather = 0f;
                    break;
            }
            float tempature = currentTemperature / 75;
            return weather * tempature;
        }
        public float GetWeather()
        {
            int weatherType = random.Next(1,3);
            float tempatureLevel = tempatureModifier[random.Next(0, 3)];
            float weather = weatherType + tempatureLevel;
            return weather;
        }
    }
}
