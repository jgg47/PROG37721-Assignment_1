using System;

namespace PROG37721_Assignment_1.Models
{
    public class CombineAccountsException : Exception
    {
        public CombineAccountsException() { }
        public CombineAccountsException(string message) : base(message) { }
    }
}