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

        public int dayCount = 1;

        public Day()
        {
            weather = new Weather();
        }

        public void DayCounter()
        {
            dayCount++;
        }

        public void TodaysWeather()
        {

        }
    }   

}
