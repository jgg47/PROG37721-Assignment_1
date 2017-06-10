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

        public WithdrawStatus Withdraw(decimal requestedAmount)
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
            if (HasSufficientFunds(transferAmount))
            {
                Withdraw(transferAmount);
                transferDestination.Deposit(transferAmount);
                return TransferStatus.Success;
            }
            return TransferStatus.Failure;
        }

        private bool HasSufficientFunds(decimal requestedAmount)
        {
            return requestedAmount <= Balance + OverdraftLimit;
        }

    }
}