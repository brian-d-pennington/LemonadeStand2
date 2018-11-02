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
        public int lostCustomers = 0;
        public int dayCount = 0;
        public double totalCustomerPool;
        public int dailyRevenue;

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

        public void TotalCustomersBasedOnTemp() //dependent on Daily variables
        {
            totalCustomerPool = 160;
            if (weather.degreesFahrenheit < 85 && weather.degreesFahrenheit >= 72)
            {
                totalCustomerPool = totalCustomerPool * .8;
            }
            else if (weather.degreesFahrenheit <= 71 )
            {
                totalCustomerPool = totalCustomerPool * .6;
            }
        }

        public void TotalCustomersBasedOnRain()
        {
            if (weather.rainOrNot == true)
            {
                totalCustomerPool = totalCustomerPool * .5; //oof, harsh
            }
        }

        public int LostCustomersReset()
        {
            return lostCustomers = 0;
        }
    }   

}
