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
            return new ChequingAccount(account1,account2);   
        }

        public override WithdrawStatus Withdraw(decimal requestedAmount)
        {
            if(Status == BankAccountStatus.Closed)
                return WithdrawStatus.ClosedAccountError;
            if(!HasSufficientFunds(requestedAmount))
                return WithdrawStatus.InsufficientFunds;
            if (requestedAmount > Balance && requestedAmount <= Balance + OverdraftLimit)
            {
                Balance = Balance - requestedAmount - OverdraftFee;
            }

            Balance = Balance - requestedAmount;
            return WithdrawStatus.Success;
        }

        public override TransferStatus TransferFunds(decimal transferAmount, BankAccount transferDestination)
        {
            if(Status == BankAccountStatus.Closed || 
               transferDestination.Status == BankAccountStatus.Closed)
                return TransferStatus.ClosedAccountError;
            if (!HasSufficientFunds(transferAmount))
                return TransferStatus.InsufficientFunds;

            Withdraw(transferAmount);
            transferDestination.Deposit(transferAmount);
            return TransferStatus.Success;
        }

        private bool HasSufficientFunds(decimal requestedAmount)
        {
            return requestedAmount <= Balance + OverdraftLimit;
        }

    }
}