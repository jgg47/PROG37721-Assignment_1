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
            return new SavingsAccount(account1, account2);
        }

        public override WithdrawStatus Withdraw(decimal requestedAmount)
        {
            if(Status == BankAccountStatus.Closed)
                return WithdrawStatus.ClosedAccountError;
            if (!HasSufficientFunds(requestedAmount))
                return WithdrawStatus.InsufficientFunds;

            Balance = Balance - requestedAmount;
            return WithdrawStatus.Success;
        }

        public override TransferStatus TransferFunds(decimal transferAmount, BankAccount transferDestination)
        {
            if(Status == BankAccountStatus.Closed)
                return TransferStatus.ClosedAccountError;
            if (!HasSufficientFunds(transferAmount))
                return TransferStatus.InsufficientFunds;

            Withdraw(transferAmount);
            transferDestination.Deposit(transferAmount);
            return TransferStatus.Success;
        }

        private bool HasSufficientFunds(decimal requestedAmount)
        {
            return requestedAmount <= Balance;
        }
    }
}