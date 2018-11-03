using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Store
    {
        public int remainingCash;
        public int lemonsToday;
        public int syrupToday;
        public int iceToday;
        public void ShoppingCart(Player player)
        {
            player.GetPlayerAccount();
            Console.WriteLine("You've arrived at the store with $" +player.playersBudget+ ".");
            Console.WriteLine("How many bags of lemons would you like to buy today? A bag is $3.");
            lemonsToday = Int32.Parse(Console.ReadLine());
            Console.WriteLine("How many quarts of syrup? They are $5 each");
            syrupToday = Int32.Parse(Console.ReadLine());
            Console.WriteLine("and how many bags of ice? $2 per bag");
            iceToday = Int32.Parse(Console.ReadLine());
            int tally = (lemonsToday * 3) + (syrupToday * 5) + (iceToday * 2);
            if (player.playersBudget - tally <= 0)
            {
                Console.WriteLine("You don't have enough to make this purchase, would you like to shop again? Y/N");
                string yesNo = Console.ReadLine();
                if (yesNo.ToLower() == "y")
                {
                    ShoppingCart(player);
                }
                else
                {
                    Console.WriteLine("Alright.. I hope you don't run out of supplies.");
                }

            }
            else
            {
                remainingCash = player.playersBudget - tally;
                Console.WriteLine("You spent $" + tally + " at the store and have $" + remainingCash + " left.");
            }
        }
        public void UpdatePlayersBudget(Player player)
        {
            player.budget.AccessPlayerAccount = remainingCash;
        }

        public void UpdatePlayerInventory(Player player)
        {
            player.lemonsFromStore = lemonsToday;
            player.syrupFromStore = syrupToday;
            player.iceFromStore = iceToday;
        }
    }
}
