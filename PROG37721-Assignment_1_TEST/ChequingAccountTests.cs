using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PROG37721_Assignment_1;
using PROG37721_Assignment_1.Models;

namespace PROG37721_Assignment_1_TEST
{
    [TestClass]
    public class ChequingAccountTests
    {
        AccountOwner sampleOwner = new AccountOwner
        {
            Name = "Sample Account"
        };
        [TestMethod]
        public void Withdraw()
        {
            //Arrange
            var chequingAccount = new ChequingAccount(sampleOwner);
            chequingAccount.Deposit(34.5m);
            
            //Act
            chequingAccount.Withdraw(34.5m);

            //Assert
            Assert.AreEqual(0, chequingAccount.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void WithdrawTooMuch()
        {
            //Arrange
            var chequingAccount = new ChequingAccount(sampleOwner);
            
            //Act
            chequingAccount.Withdraw(ChequingAccount.OverdraftLimit + 1);

            //Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ClosedAccountException))]
        public void WithdrawFromClosedAccount()
        {
            //Arrange
            var chequingAccount = new ChequingAccount(sampleOwner);
            chequingAccount.Close();
            //Act
            chequingAccount.Withdraw(1.0m);

            //Assert
            Assert.Fail();
        }

        [TestMethod]
        public void WithdrawOverdraftSuccess()
        {
            //Arrange
            var chequingAccount = new ChequingAccount(sampleOwner);
            
            //Act
            chequingAccount.Withdraw(50m);

            //Assert
            Assert.AreEqual(-55m, chequingAccount.Balance);
        }

        [TestMethod]
        public void TransferFunds()
        {
            //Arrange
            var transferSrc = new ChequingAccount(sampleOwner);
            var transferDest = new ChequingAccount(sampleOwner);
            transferSrc.Deposit(34.5m);

            //Act
            transferSrc.TransferFunds(34.5m, transferDest);

            //Assert
            Assert.AreEqual( 0, transferSrc.Balance);
            Assert.AreEqual(34.5m, transferDest.Balance);

        }

        [TestMethod]
        [ExpectedException(typeof(ClosedAccountException))]
        public void TransferClosedFunds()
        {
            //Arrange
            var transferSrc = new ChequingAccount(sampleOwner);
            var transferDest = new ChequingAccount(sampleOwner);
            transferSrc.Close();

            //Act
            transferSrc.TransferFunds(34.5m, transferDest);

            //Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void TransferTooMuchFunds()
        {
            //Arrange
            var transferSrc = new ChequingAccount(sampleOwner);
            var transferDest = new ChequingAccount(sampleOwner);
            
            //Act
            transferSrc.TransferFunds(55.5m, transferDest);

            //Assert
            Assert.Fail();
        }
        [TestMethod]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void CombineTooLittleFunds()
        {
            //Arrange
            var transferSrc = new ChequingAccount(sampleOwner);
            var transferDest = new ChequingAccount(sampleOwner);
            transferDest.Withdraw(50m);
            transferSrc.Withdraw(50m);
            //Act
            ChequingAccount.ConsolidateAccounts(transferSrc, transferDest);


            //Assert
            Assert.Fail();
        }
    }
}
