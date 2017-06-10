using System.Security.AccessControl;

namespace PROG37721_Assignment_1.Models
{
    public abstract class BankAccount
    {
        public static int NumberOfAccounts;

        public AccountOwner Owner { get; set; }
        public BankAccountStatus Status { get; private set; }

        public void Deposit(decimal deposit)
        {
            
        }

        public decimal GetBalance()
        {
            return 0;
        }

        public void Close()
        {
            
        }

        public void TransferFunds(decimal transferAmount, BankAccount transferDestination)
        {
            
        }
    }
}