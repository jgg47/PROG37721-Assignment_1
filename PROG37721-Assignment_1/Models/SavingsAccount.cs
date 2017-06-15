using System;

namespace PROG37721_Assignment_1.Models
{
    public class SavingsAccount : BankAccount
    {
        public decimal InterestRate
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public SavingsAccount(AccountOwner owner) : base(owner)
        {}
        private SavingsAccount(BankAccount account1, BankAccount account2) : base(account1, account2)
        {}

        public static SavingsAccount ConsolidateAccounts(BankAccount account1, BankAccount account2)
        {
            if(!(account1.Balance + account2.Balance >= 0))
                throw new InsufficientFundsException();
            return new SavingsAccount(account1, account2);
        }

        public override void Withdraw(decimal requestedAmount)
        {
            if(Status == BankAccountStatus.Closed)
                throw new ClosedAccountException();
            if (!HasSufficientFunds(requestedAmount))
                throw new InsufficientFundsException();
            Balance = Balance - requestedAmount;
        }

        private bool HasSufficientFunds(decimal requestedAmount)
        {
            return requestedAmount <= Balance;
        }
    }
}