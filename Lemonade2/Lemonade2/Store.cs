using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Store
    {

        public void ShoppingCart(Player player)
        {
            Console.WriteLine("You currently have $" +player.playersBudget+ ".");
        }
    }
}
