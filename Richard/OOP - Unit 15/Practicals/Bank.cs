using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Bank
    {
        //create a local variable that is only visible to the CLASS
        private decimal amount;

        public decimal Amount
        {
            set
            {
                if (value > 0 && value < 1000001)
                    amount = value;
            }
            get
            {
                return amount;
            }
        }

        //constructor created with no parameters
        public Bank()
        {
            amount = 100000;
        }

        public Bank(decimal sum)
        {
            Amount = sum;
        }

        //API allows a value to be passed to the CLASS
        public void addAmount(decimal sum)
        {
            if (sum > 0 && sum < 1000001)
                amount = sum; //assign passed data to private member
        }

        public decimal Balance()
        {
            return amount; //return private member to caller
        }
    }
}
