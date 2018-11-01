using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Indiscriminate:Customer
    {

    

        public override void CustomerTastes(Recipe recipe)
        {
            if (recipe.lemonBagsPerBatch > 6) // silly filler example
            {
                customersLoseInterest++;
            }
        }

        public override void CustomerWillingessToSpend(Recipe recipe)
        {
            if (recipe.whatToCharge > 2)
            {
                customersLoseInterest++;
            }
        }
    }
}
