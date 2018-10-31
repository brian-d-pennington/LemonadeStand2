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
        public Recipe recipe;
        public Budget budget;

        public int playersBudget;

        public Player()
        {
            inventory = new Inventory();
            recipe = new Recipe();
            budget = new Budget();

        }
        public void GetPlayerAccount()
        {
            playersBudget = budget.AccessPlayerAccount;
        }
    }
}
