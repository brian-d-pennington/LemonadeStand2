using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Player
    {
        public Inventory inventory;
        public Budget budget;

        public int playersBudget;
        public int lemonsFromStore;
        public int syrupFromStore;
        public int iceFromStore;

        public Player()
        {
            inventory = new Inventory();
            budget = new Budget();

        }
        public void GetPlayerAccount()
        {
            playersBudget = budget.AccessPlayerAccount;
        }

        public void UpdateInventoryClass()
        {
            inventory.lemonBags = inventory.lemonBags + lemonsFromStore;
            inventory.quartsOfSyrup = inventory.quartsOfSyrup + syrupFromStore;
            inventory.bagsOfIce = inventory.bagsOfIce + iceFromStore;
        }

        public void DisplayInventory() //after 1 day of play
        {
            Console.WriteLine("You have " + inventory.lemonBags + " bags of lemons, " + inventory.quartsOfSyrup + " quarts of syrup, and " + inventory.bagsOfIce + " bags of ice");
        }
    }
}
