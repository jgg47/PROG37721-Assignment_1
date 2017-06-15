using System;

namespace PROG37721_Assignment_1.Models
{
    public class ClosedAccountException : Exception
    {
        public ClosedAccountException() { }

        public ClosedAccountException(string message) : base(message) { }
    }
}