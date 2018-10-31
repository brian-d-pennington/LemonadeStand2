using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Weather
    {
        public int degreesFahrenheit;
        public int rainChance;
        public bool rainOrNot;

        public void TodaysTemperature()
        {
            Random r = new Random();
            degreesFahrenheit = r.Next(60, 100);
        }
        public void ChanceOfRain()
        {
            Random r = new Random();
            rainChance = r.Next(1, 100);
            if (rainChance <= 30)
            {
                rainOrNot = true;
                Console.WriteLine("Uh oh, rain is in the forecast today.");
            }
            else
            {
                rainOrNot = false;
                Console.WriteLine("Clear skies today!");
            }
        }
    }
}
