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
            UI.ExplainPrice();
            if (UI.adjustPrice.ToLower() == "y")
            {
                recipe.ChargeMore();
            }
            UI.OpenLemonadeStand();
            day.TotalCustomersBasedOnTemp();
            day.TotalCustomersBasedOnRain();
        }

        private void CustomerTypeDayGenerator()
        {
            Random r = new Random();
            int betweenFortyAndSeventy = r.Next(40, 70);
            double percentOfIndiscriminate = betweenFortyAndSeventy * 0.01;
            double indiscriminatePerDayDecimal = day.totalCustomerPool * percentOfIndiscriminate;
            int indiscriminateCustomers = Convert.ToInt32(Math.Round(indiscriminatePerDayDecimal));
            int updatedCustomerPool = Convert.ToInt32(day.totalCustomerPool) - indiscriminateCustomers; 

            Random x = new Random();
            int betweenFortyAndSixty = x.Next(40, 60);
            double percentOfCheapskate = betweenFortyAndSixty * 0.01;
            double cheapskatePerDayDecimal = updatedCustomerPool * percentOfCheapskate;
            int cheapskateCustomers = Convert.ToInt32(Math.Round(cheapskatePerDayDecimal));


        }
    }
}
