using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Cheapskate:Customer
    {
        public Cheapskate()
        {
            
        }

        public override void CustomerTastes(Recipe recipe, Day day)
        {
            if (recipe.lemonBagsPerBatch > 6) // silly filler example
            {
                day.LostCustomers++;
            }
        }

        public override void CustomerWillingessToSpend(Recipe recipe, Day day)
        {
            if (recipe.whatToCharge > 1)
            {
                day.LostCustomers++;
            }
        }
    }
}
