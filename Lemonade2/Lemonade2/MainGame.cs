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
            InitialInstructions();
            for (int j = 0; j < 7; j++) //game loop
            {

                day.YourDailyWeather();
                if (day.dayCount == 1)
                {
                    UI.OffToTheStore();
                }
                PlayerGoesToStore();
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
                recipe.RecipeRatioReminder();
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
                UpdateAccountAtEndOfDay();
                player.DisplayInventory();
                day.LostCustomersReset();
                ResetCustomerListsForNewDay();
                
            } // close 7 day for loop
            GameFinale();
        }


        private void InitialInstructions()
        {
            UI.DisplayInstructions();
            UI.GetPlayerName();
            UI.MoreGameInstructions();
            UI.DailyWeatherExplainer();
        }

        private void PlayerGoesToStore()
        {
            store.ShoppingCart(player);
            store.UpdatePlayersBudget(player);
            store.UpdatePlayerInventory(player);
        }
        private void BatchesToMake()
        {
            Console.WriteLine("Finally, how many batches do you want to make today?");
            Console.WriteLine("You cannot exceed the amount of ingredients you have, of course.");
            Console.WriteLine("Also, a batch is only good for an afternoon, considering the melting ice and all.");
            Console.WriteLine("So.. how many batches do you want to make?");
            batches = Int32.Parse(Console.ReadLine());
            BatchesCannotExceedInventory();
        }

        private void BatchesCannotExceedInventory()
        {
            if (batches > player.inventory.lemonBags || batches > player.inventory.quartsOfSyrup || batches > player.inventory.bagsOfIce)
            {
                Console.WriteLine("You don't have enough ingredients to make that.");
                BatchesToMake();
            }
        }

        private void UpdateInventoryAfterBatchesMade()
        {
            player.inventory.lemonBags = player.inventory.lemonBags - (batches * recipe.lemonBagsPerBatch);
            if (player.inventory.lemonBags < 0)
            {
                Console.WriteLine("Oops. You didn't plan well and ran out of ingredients. You will have to make less batches today.");
                batches -= 1;
                UpdateInventoryAfterBatchesMade();
            }
            player.inventory.quartsOfSyrup = player.inventory.quartsOfSyrup - (batches * recipe.syrupPerBatch);
            if (player.inventory.quartsOfSyrup < 0)
            {
                Console.WriteLine("Oops. You didn't plan well and ran out of ingredients. You will have to make less batches today.");
                batches -= 1;
                UpdateInventoryAfterBatchesMade();
            }
            player.inventory.bagsOfIce = player.inventory.bagsOfIce - (batches * recipe.icePerBatch);
            if (player.inventory.bagsOfIce < 0)
            {
                Console.WriteLine("Oops. You didn't plan well and ran out of ingredients. You will have to make less batches today.");
                batches -= 1;
                UpdateInventoryAfterBatchesMade();
            }
        }
        // daily business conditions generators
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
                // cheapskateCustomer = new Cheapskate();
                cheapskates.Add(new Cheapskate());
            }

            for (int i = 0; i < indiscriminateCustomers; i++)
            {
                // indiscriminateCustomer = new Indiscriminate();
                indiscriminates.Add(new Indiscriminate());
            }

            for (int i = 0; i < sugarfiendCustomers; i++)
            {
                // sugarfiendCustomer = new Sugarfiend();
                sugarfiends.Add(new Sugarfiend());
            }
        }
        
        private void CustomersWhoLostInterestToday()
        {
            if (day.lostCustomers == 0)
            {
                Console.WriteLine("You didn't turn away any customers. Sounds like you found a crowd pleasing recipe!");
                Console.WriteLine("(just hope it's profitable..)");
            }
            else
            {
                Console.WriteLine("You lost " + day.lostCustomers + " potential customers today. Consider tweaking your recipe or lowering your price.");
                Console.WriteLine("(hint: it's probably evident in the numbers whom you turned away)");
            }
        }

        private void DidPlayerMakeEnoughLemonade()
        {
            int peopleServedPerBatch = batches * 50;
            if (dailyTotalPotentialCustomers > peopleServedPerBatch)
            {
                int turnedAway = dailyTotalPotentialCustomers - peopleServedPerBatch;
                Console.WriteLine("Oh no, you ran out of lemonade and turned away " + turnedAway + " customers.");
            }
        }
        //
        private void DailyRevenueCalculator()
        {
            int customersToday = dailyTotalPotentialCustomers - day.lostCustomers;
            day.dailyRevenue = recipe.whatToCharge * customersToday;
            Console.WriteLine("You brought in $" + day.dailyRevenue + " today.");
        }

        private void UpdateAccountAtEndOfDay()
        {
            player.budget.AccessPlayerAccount = player.budget.AccessPlayerAccount + day.dailyRevenue;
            Console.WriteLine("You have $" + player.budget.AccessPlayerAccount + " at the end of " + day.dayCount + "!");
        }

        private void ResetCustomerListsForNewDay()
        {
            cheapskates = new List<Customer>();
            indiscriminates = new List<Customer>();
            sugarfiends = new List<Customer>();
        }

        private void GameFinale()
        {
            Console.WriteLine("Congratulations, " + UI.playerName + ", you have completed a week at your lemonade stand!");
            Console.WriteLine("You started the week with $50 and ended with $" + player.budget.AccessPlayerAccount );
        }
    }
}
