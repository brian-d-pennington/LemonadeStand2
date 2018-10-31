using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Day
    {
        public Weather weather;

        public int dayCount = 0;

        public Day()
        {
            weather = new Weather();
        }

        public void DayCounter()
        {
            dayCount++;
            Console.Write("On day " + dayCount + ", ");
        }

        public void YourDailyWeather()
        {
            DayCounter();
            weather.TodaysTemperature();
            weather.ChanceOfRain();
        }
    }   

}
