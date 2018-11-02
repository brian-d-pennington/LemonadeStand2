using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Sugarfiend:Customer
    {
        public int sugarfiendsLoseInterest;

        public override void CustomerTastes(Recipe recipe)
        {

            if (recipe.syrupPerBatch == recipe.lemonBagsPerBatch)
            {
                sugarfiendsLoseInterest++;
            }
        }

        public override void CustomerWillingessToSpend(Recipe recipe)
        {
            if (recipe.whatToCharge > 3)
            {
                sugarfiendsLoseInterest++;
            }
        }
    }
}
