using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Budget
    {
        private int playerBankAccount = 50;

        public int AccessPlayerAccount
        {
            get
            {
                return playerBankAccount;
            }
            set
            {
                playerBankAccount = value;
            }
        }

        public Budget()
        {

        }
    }
}
