using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Cheapskate:Customer
    {
        public int cheapskatesLoseInterest;

        public override void CustomerTastes(Recipe recipe)
        {
            if (recipe.lemonBagsPerBatch > 6) // silly filler example
            {
                cheapskatesLoseInterest++;
            }
        }

        public override void CustomerWillingessToSpend(Recipe recipe)
        {
            if (recipe.whatToCharge > 1)
            {
                cheapskatesLoseInterest++;
            }
        }
    }
}
