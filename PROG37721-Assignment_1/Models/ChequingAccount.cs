using System;

namespace PROG37721_Assignment_1.Models
{
    public class ChequingAccount : BankAccount
    {
        public static decimal OverdraftLimit { get; private set; }
        public static decimal OverdraftFee { get; set; }

        public ChequingAccount(AccountOwner owner) : base(owner)
        {
            OverdraftLimit = 50.0m;
            OverdraftFee = 5.0m;
        }

        private ChequingAccount(BankAccount account1, BankAccount account2) : base(account1, account2)
        {
            OverdraftLimit = 50.0m;
            OverdraftFee = 5.0m;
        }

        public static ChequingAccount ConsolidateAccounts(BankAccount account1, BankAccount account2)
        {
            if (!(account1.Balance + account2.Balance >= -(OverdraftLimit + OverdraftFee)))
                throw new InsufficientFundsException();
            return new ChequingAccount(account1,account2);   
        }

        public override void Withdraw(decimal requestedAmount)
        {
            if (Status == BankAccountStatus.Closed)
                throw new ClosedAccountException();
            if (!HasSufficientFunds(requestedAmount))
                throw new InsufficientFundsException();
            
            if (RequiresOverdraft(requestedAmount))
                Balance = Balance - (requestedAmount + OverdraftFee);
            else
                Balance = Balance - requestedAmount;
        }

        private bool HasSufficientFunds(decimal requestedAmount)
        {
            return requestedAmount <= Balance + OverdraftLimit;
        }

        private bool RequiresOverdraft(decimal requestedAmount)
        {
            return requestedAmount > Balance && requestedAmount <= Balance + OverdraftLimit;
        }
    }
}