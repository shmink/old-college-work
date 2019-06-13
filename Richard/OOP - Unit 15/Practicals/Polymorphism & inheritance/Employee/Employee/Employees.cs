using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employee
{
    class Employees
    {
        public string forename;
        public string surname;
        private string name()
        {
            return forename + " " + surname;
        }
        public virtual decimal Rate(decimal pay)
        {
            return pay;
        }
    }

    class FullTimeEmployees : Employees
    {
        public override decimal Rate(decimal payRate)
        {
            decimal Pay = payRate * 4;
            //base.Rate(pay);
            return Pay;
        }
    }

    class PartTimeEmployees : Employees
    {
        public override decimal Rate(decimal payRate)
        {
            //return base.Rate(pay);
            decimal Pay = payRate * 2;
            return Pay;
        }
    }

    class TemporaryTimeEmployees : Employees
    {
        public override decimal Rate(decimal pay)
        {
            return base.Rate(pay);
        }
    }
}
