using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROG37721_Assignment_1.Models;

namespace PROG37721_Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var owner = new AccountOwner();
            owner.Name = "John";
            var savings = new SavingsAccount(owner);
            var savings2 = new SavingsAccount(owner);
            var savings3 = new SavingsAccount(owner);
            var savings4 = new SavingsAccount(owner);



            Console.WriteLine(savings.AccountNumber);
            Console.WriteLine(savings2.AccountNumber);
            Console.WriteLine(savings3.AccountNumber);
            Console.WriteLine(savings4.AccountNumber);

        }
    }
}
