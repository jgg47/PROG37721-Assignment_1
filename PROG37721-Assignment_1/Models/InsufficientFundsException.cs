using System;
using System.Runtime.Serialization;

namespace PROG37721_Assignment_1
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() { }

        public InsufficientFundsException(string message) : base(message) { }
    }
}