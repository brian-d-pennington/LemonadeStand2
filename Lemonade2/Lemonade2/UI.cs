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
        public static string tweakRecipeResponse;
        public static string adjustPrice;
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

        // game setup Console Writes below
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
        public static void DailyWeatherExplainer()
        {
            Console.WriteLine("Ok. So your lemonade stand will take place in the summer on a busy downtown corner,");
            Console.WriteLine("but the temp can vary between 60 and 100 degrees (Milwaukee..). Also, about a 30% ");
            Console.WriteLine("chance of rain to factor in at all times, which will lower customer turnout.");
            System.Threading.Thread.Sleep(2000); // make longer later
        }
        public static void OffToTheStore()
        {
            Console.WriteLine("Now we're off to the store. Just so you know: 1 bag of lemons, 1 quart of syrup, ");
            Console.WriteLine("and one bag of ice make make a basic batch of lemonade that can serve 50 people.");
            Console.WriteLine("On an ideal day you may get up to 160 customers. Running out of supply mid day would");
            Console.WriteLine("not be good.");

            System.Threading.Thread.Sleep(2000); // make longer later
        }

        public static void StartingRecipe(Day day)
        {
            if (day.dayCount == 1)
            {
                Console.WriteLine("So like I said, the default lemonade recipe is 1 part lemons, 1 part sugar, and one part ice");
            }
            
            Console.WriteLine("Do you think you'd like to tweak the recipe? Y/N");
            tweakRecipeResponse = Console.ReadLine();
        }
        public static void ExplainPrice()
        {
            Console.WriteLine("The default price for a cup* of your lemonade is $1. Would you like to test your luck and charge $2, $3, or $4?");
            Console.WriteLine("(don't worry about cup costs and inventory. Turns out you steal them from your real job)");
            Console.WriteLine("Y/N ?");
            adjustPrice = Console.ReadLine();
        }

        public static void UpdatedPrice(Recipe recipe)
        {
            Console.Write("You have the price set at $" + recipe.whatToCharge + ". Would you like to change that? Y/N ");
            adjustPrice = Console.ReadLine();
        }

        public static void OpenLemonadeStand()
        {
            Console.WriteLine("ALRIGHT, " + playerName + ", let's open your Lemonade Stand!!");
        }


        
    }
    
}
