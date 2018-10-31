using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    static class UI
    {
        public static string playerName;
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
        public static void GetPlayerName()
        {
            Console.WriteLine("Please enter your name: ");
            playerName = Console.ReadLine();
            Console.WriteLine("Welcome to " + playerName + "'s Lemonade Stand!");
        }
        public static void MoreGameInstructions()
        {
            Console.WriteLine("This game will be 7 days long. The goal for you is to make money or at least not go broke.");
            Console.WriteLine("For each day you will be presented with the weather so you can guess what sales will be like that day.");
            Console.WriteLine("From there you will go to the store and stock up on ingredients. You will be given $50 to start..");
            Console.WriteLine("but no ingredients at the beginning. You will also be able to tweak your recipe along the way..");
            Console.WriteLine("as you might find certain ratios lead to better sales.");
            System.Threading.Thread.Sleep(2000); // make longer later
        }
    }
}
