using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Recipe
    {
        public int lemonBagsPerBatch = 1;
        public int syrupPerBatch = 1;
        public int icePerBatch = 1;
        public int whatToCharge = 1;

        public Recipe()
        {

        }

        public void RecipeTweak()
        {
            Console.WriteLine("Add one part lemons? Y/N");
            string addLemon = Console.ReadLine();
            if (addLemon.ToLower() == "y")
            {
                lemonBagsPerBatch++;
                Console.WriteLine("One part lemon added.");
            }
            else if (addLemon.ToLower() == "n")
            {
                Console.WriteLine("How about subtract one part lemon? Y/N");
                string subtractLemon = Console.ReadLine();
                if (subtractLemon.ToLower() == "y")
                {
                    Console.WriteLine("One part lemon taken away.");
                    lemonBagsPerBatch--;
                }
            }

            Console.WriteLine("Add one part syrup? Y/N (not gonna let you go beyond one more, for public health concerns..");
            string addSyrup = Console.ReadLine();
            if (addSyrup.ToLower() == "y")
            {
                syrupPerBatch++;
                Console.WriteLine("One part syrup added.");
            }
            else if (addSyrup.ToLower() == "n")
            {
                Console.WriteLine("How about subtract one part syrup? Y/N");
                string subtractSyrup = Console.ReadLine();
                if (subtractSyrup.ToLower() == "y")
                {
                    Console.WriteLine("One part syrup lowered.");
                    syrupPerBatch--;
                }
            }
            Console.WriteLine("Add one more part ice? Not a bad idea on scorching days.. Y/N");
            string addIce = Console.ReadLine();
            if (addIce.ToLower() == "y")
            {
                icePerBatch++;
                Console.WriteLine("One part ice added.");
            }
            else if (addIce.ToLower() == "n")
            {
                Console.WriteLine("How about subtract one part ice? Y/N");
                string subtractIce = Console.ReadLine();
                if (subtractIce.ToLower() == "y")
                {
                    Console.WriteLine("One part ice removed.");
                    icePerBatch--;
                }
            }
        }

        public void DisplayTweakedRecipe(Day day)
        {
            if (day.dayCount != 1)
            {
                Console.WriteLine("As of now your recipe is now" + lemonBagsPerBatch + " part lemon, " + syrupPerBatch + " part syrup, and " + icePerBatch + " part ice.");
            }

        }

        public void RecipeRatioReminder()
        {
            Console.WriteLine("Now your recipe is " + lemonBagsPerBatch + " part(s) lemon, " + syrupPerBatch + " part(s) syrup, and " + icePerBatch + " part(s) ice.");
        }

        public void ChargeMore()
        {
            Console.WriteLine("Ok.. would you like to charge $2, $3, or $4? Beyond $2 is pushing it but you're the boss..");
            Console.WriteLine("enter 2, 3, or 4.");
            whatToCharge = Int32.Parse(Console.ReadLine());
            if (whatToCharge == 2 || whatToCharge == 3 || whatToCharge == 4)
            {
                Console.WriteLine("Alright, your lemonade will cost $" + whatToCharge + ".");
            }
            else
            {
                Console.WriteLine("Not a valid entry. Try again.");
                ChargeMore();
            }
        }

        
    }
}
