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
        public Customer cheapskateCustomer; //each object
        public Customer indiscriminateCustomer;
        public Customer sugarfiendCustomer;
        public List<Customer> cheapskates = new List<Customer>();
        public List<Customer> indiscriminates = new List<Customer>();
        public List<Customer> sugarfiends = new List<Customer>();
        public Recipe recipe;

        public int cheapskateCustomers; // int value
        public int indiscriminateCustomers;
        public int sugarfiendCustomers;
        public int batches;
        public int dailyTotalPotentialCustomers;


        

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
            BatchesToMake();
            UpdateInventoryAfterBatchesMade();
            UI.OpenLemonadeStand();
            day.TotalCustomersBasedOnTemp();
            day.TotalCustomersBasedOnRain();
            CustomerTypeDayGenerator();
            InstantiateStereotypes();
            for (int i = 0; i < sugarfiends.Count; i++)
            {
                sugarfiends[i].CustomerWillingessToSpend(recipe, day);
                sugarfiends[i].CustomerTastes(recipe, day);
            }
            for (int i = 0; i < indiscriminates.Count; i++)
            {
                indiscriminates[i].CustomerWillingessToSpend(recipe, day);
                indiscriminates[i].CustomerTastes(recipe, day);
            }
            for (int i = 0; i < cheapskates.Count; i++)
            {
                cheapskates[i].CustomerWillingessToSpend(recipe, day);
                cheapskates[i].CustomerTastes(recipe, day);
            }
            CustomersWhoLostInterestToday();
            DidPlayerMakeEnoughLemonade();
            DailyRevenueCalculator();
        }
        
        private void BatchesToMake()
        {
            Console.WriteLine("Finally, how many batches do you want to make today?");
            Console.WriteLine("You cannot exceed the amount of ingredients you have, of course.");
            Console.WriteLine("Also, a batch is only good for an afternoon, considering the melting ice and all.");
            Console.WriteLine("So.. how many batches do you want to make?");
            batches = Int32.Parse(Console.ReadLine());
            if (batches > player.inventory.lemonBags || batches > player.inventory.quartsOfSyrup || batches > player.inventory.bagsOfIce)
            {
                Console.WriteLine("You don't have enough ingredients to make that.");
                BatchesToMake();
            }
        }

        private void UpdateInventoryAfterBatchesMade()
        {
            player.inventory.lemonBags = player.inventory.lemonBags - batches;
            player.inventory.quartsOfSyrup = player.inventory.quartsOfSyrup - batches;
            player.inventory.bagsOfIce = player.inventory.bagsOfIce - batches;
        }
        
        // daily business generators
        private void CustomerTypeDayGenerator()
        {
            Random r = new Random();
            int betweenFortyAndSeventy = r.Next(40, 70);
            double percentOfIndiscriminate = betweenFortyAndSeventy * 0.01;
            double indiscriminatePerDayDecimal = day.totalCustomerPool * percentOfIndiscriminate;
            indiscriminateCustomers = Convert.ToInt32(Math.Round(indiscriminatePerDayDecimal));
            int updatedCustomerPool = Convert.ToInt32(day.totalCustomerPool) - indiscriminateCustomers; 

            Random x = new Random();
            int betweenFortyAndSixty = x.Next(40, 60);
            double percentOfCheapskate = betweenFortyAndSixty * 0.01;
            double cheapskatePerDayDecimal = updatedCustomerPool * percentOfCheapskate;
            cheapskateCustomers = Convert.ToInt32(Math.Round(cheapskatePerDayDecimal));
            int furtherUpdatedCustomerPool = updatedCustomerPool - cheapskateCustomers;

            sugarfiendCustomers = furtherUpdatedCustomerPool;

            dailyTotalPotentialCustomers = sugarfiendCustomers + cheapskateCustomers + indiscriminateCustomers;
            Console.WriteLine("Your customer breakdown for day " + day.dayCount + " is " + indiscriminateCustomers + " indiscriminate customers, " + cheapskateCustomers + " cheapskates, and " + sugarfiendCustomers + " sugarfiends");
            
        }

        private void InstantiateStereotypes()
        {
            for (int i = 0; i < cheapskateCustomers; i++)
            {
                cheapskateCustomer = new Cheapskate();
                cheapskates.Add(cheapskateCustomer);
            }

            for (int i = 0; i < indiscriminateCustomers; i++)
            {
                indiscriminateCustomer = new Indiscriminate();
                indiscriminates.Add(indiscriminateCustomer);
            }

            for (int i = 0; i < sugarfiendCustomers; i++)
            {
                sugarfiendCustomer = new Sugarfiend();
                sugarfiends.Add(sugarfiendCustomer);
            }
        }
        
        private void CustomersWhoLostInterestToday()
        {
            if (day.LostCustomers == 0)
            {
                Console.WriteLine("You didn't turn away any customers. Sounds like you found a crowd pleasing recipe!");
                Console.WriteLine("(just hope it's profitable..)");
            }
            else
            {
                Console.WriteLine("You lost " + day.LostCustomers + " potential customers today. Consider tweaking your recipe or lowering your price.");
                Console.WriteLine("(hint: it's probably evident in the numbers whom you turned away)");
            }
        }

        public void DidPlayerMakeEnoughLemonade()
        {
            int peopleServedPerBatch = batches * 50;
            if (dailyTotalPotentialCustomers > peopleServedPerBatch)
            {
                int turnedAway = dailyTotalPotentialCustomers - peopleServedPerBatch;
                Console.WriteLine("Oh no, you ran out of lemonade and turned away " + turnedAway + " customers.");
            }
        }
        //
        public void DailyRevenueCalculator()
        {
            int customersToday = dailyTotalPotentialCustomers - day.LostCustomers;
            day.dailyRevenue = recipe.whatToCharge * customersToday;
            Console.WriteLine("You brought in $" + day.dailyRevenue + " today.");
        }
    }
}
