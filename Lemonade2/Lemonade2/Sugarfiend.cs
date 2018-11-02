using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Sugarfiend:Customer
    {
        public Sugarfiend()
        {
            
        }

        public override void CustomerTastes(Recipe recipe, Day day)
        {

            if (recipe.syrupPerBatch == recipe.lemonBagsPerBatch)
            {
                day.lostCustomers++;
            }
        }

        public override void CustomerWillingessToSpend(Recipe recipe, Day day)
        {
            if (recipe.whatToCharge > 3)
            {
                day.lostCustomers++;
            }
        }
    }
}
