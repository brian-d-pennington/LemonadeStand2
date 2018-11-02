using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    abstract class Customer
    {
        


        public Customer()
        {

        }

        public abstract void CustomerWillingessToSpend(Recipe recipe, Day day);

        public abstract void CustomerTastes(Recipe recipe, Day day);
        
    }
}
