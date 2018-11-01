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
        public abstract void CustomerTempPreference();

        public abstract void DoesCustomerCareAboutRain();

        public abstract void CustomerWillingessToSpend();

        public abstract void CustomerTastes();
        
    }
}
