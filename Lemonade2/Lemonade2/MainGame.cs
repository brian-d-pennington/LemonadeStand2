using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class MainGame
    {
        public Player player;
        public Day day;
        public Store store;
        public Customer customer;
        public Recipe recipe;


        

        public MainGame()
        {
            player = new Player();
            day = new Day();
            store = new Store();
            customer = new Customer();
            recipe = new Recipe();
        }

        public void RunGame()
        {
            UI.DisplayInstructions();
            UI.GetPlayerName();
            UI.MoreGameInstructions();
            UI.DailyWeatherExplainer();
            day.YourDailyWeather();
            UI.OffToTheStore();
            store.ShoppingCart(player);
            store.UpdatePlayersBudget(player);
            store.UpdatePlayerInventory(player);
            player.UpdateInventoryClass();
            UI.StartingRecipe();
            if (UI.tweakRecipeResponse.ToLower() == "y")
            {
                recipe.RecipeTweak();
            }
            else if (UI.tweakRecipeResponse.ToLower() != "n")
            {
                Console.WriteLine("please tyype morre crarefullyslijo");
                UI.StartingRecipe();
            }
            else
            {
                Console.WriteLine("Cool. Why overthink it eh?");
            }
            UI.OpenLemonadeStand();
        }
    }
}
