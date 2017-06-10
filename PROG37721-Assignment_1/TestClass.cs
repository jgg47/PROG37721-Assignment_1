using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG37721_Assignment_1
{
    public abstract class TestClass2
    {
        public static int NumberOfAccounts;

        public void IncrementNumberOfAccounts()
        {
            NumberOfAccounts++;
        }

        public abstract void Drive();
    }
}
