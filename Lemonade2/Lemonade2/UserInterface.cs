using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    static class UserInterface
    {
        public static void DisplayInstructions()
        {
            Console.WriteLine("WELCOME TO LEMONADE STAND");
            Console.WriteLine("-------------------------");
            Console.WriteLine("The goal of this game is to operate a profitable lemonade stand over the course of 7 days..");
            Console.WriteLine("..dealing and responding to different variables such as the weather and customer tastes..");
            Console.WriteLine("Would you like to proceed? type 'Yes' or 'No'");
            string toProceed = Console.ReadLine();
            if (toProceed == "no" || toProceed == "NO" || toProceed == "No")
            {
                Console.WriteLine("Odd, but okay..");
                System.Threading.Thread.Sleep(2000);
                Environment.Exit(0);
            }
            else if (toProceed.ToLower() != "yes")
            {
                Console.WriteLine("Please type more carefully.");
                DisplayInstructions();
            }
            Console.WriteLine("Ok.. let's get started--------------------------------------");
        }
    }
}
