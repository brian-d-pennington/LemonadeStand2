using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Cheapskate:Customer
    {

        public override void CustomerTastes(Recipe recipe)
        {
            //
        }

        public override void CustomerWillingessToSpend(Recipe recipe)
        {
            if (recipe.whatToCharge > 1)
            {
                customersLoseInterest++;
            }
        }
    }
}
