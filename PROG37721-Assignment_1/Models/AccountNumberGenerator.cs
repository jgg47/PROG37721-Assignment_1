using System;
using System.Security.Cryptography;

namespace PROG37721_Assignment_1.Models
{
    public class AccountNumberGenerator
    {
        public static string Generate()
        {
            var randomNumber = new Random();
            var accountNumber = "";
            for (int i = 0; i < 5; i++)
            {
                var digit  = randomNumber.Next(0, 9).ToString();
                accountNumber = accountNumber + digit;
            }
            return accountNumber;
        }
    }
}