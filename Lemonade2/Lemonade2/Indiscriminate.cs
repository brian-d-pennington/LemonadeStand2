using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Indiscriminate:Customer
    {
        public Indiscriminate()
        {
            
        }

        public override void CustomerTastes(Recipe recipe, Day day)
        {
            if (recipe.lemonBagsPerBatch > 6) // silly filler example
            {
                day.lostCustomers++;
            }
        }

        public override void CustomerWillingessToSpend(Recipe recipe, Day day)
        {
            if (recipe.whatToCharge > 2)
            {
                day.lostCustomers++;
            }
        }
    }
}
