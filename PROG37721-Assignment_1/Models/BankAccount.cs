using System.Security.AccessControl;

namespace PROG37721_Assignment_1.Models
{
    public abstract class BankAccount
    {
        public static int NumberOfAccounts;

        public AccountOwner Owner { get; private set; }
        public BankAccountStatus Status { get; private set; }
        public decimal Balance { get; private set; }

        public BankAccount(AccountOwner owner)
        {
            Owner = owner;
            Status = BankAccountStatus.Active;
            NumberOfAccounts++;
            Balance = 0m;
        }

        public void Deposit(decimal deposit)
        {
            Balance = Balance + deposit;
        }

        public decimal GetBalance()
        {
            return 0;
        }

        public void Close()
        {
            Balance = 0;
            Status = BankAccountStatus.Closed;
            Owner.Name = Owner.Name + " CLOSED";
            NumberOfAccounts--;
        }

        public void TransferFunds(decimal transferAmount, BankAccount transferDestination)
        {
            
        }
    }
}