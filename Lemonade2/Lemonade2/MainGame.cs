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


        

        public MainGame()
        {
            player = new Player();
            day = new Day();
            store = new Store();
            customer = new Customer();
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
        }
    }
}
