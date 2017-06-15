using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROG37721_Assignment_1;
using PROG37721_Assignment_1.Models;

namespace PROG37721_Assignment_1_TEST
{
    [TestClass]
    public class SavingsAccountTests
    {
        AccountOwner sampleOwner = new AccountOwner
        {
            Name = "Sample Owner",
            Email = "test",
            PhoneNumber = "11111"
        };
        [TestMethod]
        public void Withdraw()
        {
            //Arrange
            var savingsAccount = new SavingsAccount(sampleOwner);
            savingsAccount.Deposit(34.5m);
            
            //Act
            savingsAccount.Withdraw(34.5m);

            //Assert
            Assert.AreEqual(0, savingsAccount.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void WithdrawTooMuch()
        {
            //Arrange
            var savingsAccount = new SavingsAccount(sampleOwner);
           
            //Act
            savingsAccount.Withdraw(34.5m);

            //Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ClosedAccountException))]
        public void WithdrawFromClosed()
        {
            //Arrange
            var savingsAccount = new SavingsAccount(sampleOwner);
            savingsAccount.Close();
            //Act
            savingsAccount.Withdraw(34.5m);

            //Assert
            Assert.Fail();
        }

        [TestMethod]
        public void TransferFunds()
        {
            //Arrange
            var transferSrc = new SavingsAccount(sampleOwner);
            var transferDest = new SavingsAccount(sampleOwner);
            transferSrc.Deposit(34.5m);

            //Act
            transferSrc.TransferFunds(34.5m, transferDest);

            //Assert
            Assert.AreEqual(0, transferSrc.Balance);
            Assert.AreEqual(34.5m, transferDest.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void TransferTooMuchFunds()
        {
            //Arrange
            var transferSrc = new SavingsAccount(sampleOwner);
            var transferDest = new SavingsAccount(sampleOwner);
           
            //Act
            transferSrc.TransferFunds(34.5m, transferDest);

            //Assert
            Assert.Fail();
        }
        [TestMethod]
        [ExpectedException(typeof(ClosedAccountException))]
        public void TransferClosedFunds()
        {
            //Arrange
            var transferSrc = new SavingsAccount(sampleOwner);
            var transferDest = new SavingsAccount(sampleOwner);
            transferSrc.Close();

            //Act
            transferSrc.TransferFunds(34.5m, transferDest);

            //Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void CombineFromNegativeChequingAccount()
        {
            //Arrange
            var chequingAccount = new ChequingAccount(sampleOwner);
            var savingsAccount = new SavingsAccount(sampleOwner);
            chequingAccount.Withdraw(10.0m);

            //Act
            var newAccount = SavingsAccount.ConsolidateAccounts(chequingAccount, savingsAccount);

            //Assert
            Assert.Fail();
        }
    }
}
