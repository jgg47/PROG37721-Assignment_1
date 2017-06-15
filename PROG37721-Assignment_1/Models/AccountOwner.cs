using System;

namespace PROG37721_Assignment_1.Models
{
    public class AccountOwner
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public AccountOwner()
        {
        }

        public AccountOwner(AccountOwner copy)
        {
            Name = copy.Name;
            Email = copy.Email;
            PhoneNumber = copy.PhoneNumber;
        }

        public override bool Equals(object obj)
        {
            var accountOwner = obj as AccountOwner;

            if (accountOwner == null )
                return false;

            if (!Name.Equals(accountOwner.Name))
                return false;
            if (!Email.Equals(accountOwner.Email))
                return false;
            if (!PhoneNumber.Equals(accountOwner.PhoneNumber))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();
        }
    }
}