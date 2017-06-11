using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace PROG37721_Assignment_1.Models
{
    public abstract class BankAccount
    {
        public static int NumberOfAccounts;
        public static List<string> Accounts = new List<string>(); 
        
        public string AccountNumber { get; }
        public AccountOwner Owner { get; }
        public BankAccountStatus Status { get; private set; }
        public decimal Balance { get; protected set; }

        protected BankAccount(AccountOwner owner)
        {
            AccountNumber = CreateAccountNumber();
            Owner = owner;
            Status = BankAccountStatus.Active;
            NumberOfAccounts++;
            Balance = 0m;
        }

        protected BankAccount(BankAccount account1, BankAccount account2)
        {
            if(account1.Owner.Equals(account2.Owner))
                 throw new NotImplementedException();
            if(account1.AccountNumber.Equals(account2.AccountNumber))
                throw new NotImplementedException();

            Balance = account1.Balance + account2.Balance;
            AccountNumber = CreateAccountNumber();
            Status = BankAccountStatus.Active;
            NumberOfAccounts++;
            Owner = account1.Owner;
            account1.Close();
            account2.Close();
        }

        public DepositStatus Deposit(decimal deposit)
        {
            if (Status == BankAccountStatus.Closed)
                return DepositStatus.ClosedAccountError;
            
            Balance = Balance + deposit;
            return DepositStatus.Success;
        }

        public void Close()
        {
            Balance = 0;
            Status = BankAccountStatus.Closed;
            Owner.Name = Owner.Name + " CLOSED";
            NumberOfAccounts--;
        }

        public abstract TransferStatus TransferFunds(decimal transferAmount, 
                                                     BankAccount transferDestination);
        public abstract WithdrawStatus Withdraw(decimal requestedAmount);

        private string CreateAccountNumber()
        {
            string accountNumber = AccountNumberGenerator.Generate();
            while (Accounts.Contains(accountNumber))
                accountNumber = AccountNumberGenerator.Generate();
            Accounts.Add(accountNumber);
            return accountNumber;
        }
    }
}