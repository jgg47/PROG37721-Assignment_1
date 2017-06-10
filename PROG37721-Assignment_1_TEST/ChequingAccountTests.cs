using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            var withdrawStatus = chequingAccount.Withdraw(34.5m);

            //Assert
            Assert.AreEqual(WithdrawStatus.Success, withdrawStatus);
            Assert.AreEqual(0, chequingAccount.Balance);
        }

        [TestMethod]
        public void WithdrawTooMuch()
        {
            //Arrange
            var chequingAccount = new ChequingAccount(sampleOwner);
            
            //Act
            var withdrawStatus = chequingAccount.Withdraw(ChequingAccount.OverdraftLimit + 1);

            //Assert
            Assert.AreEqual(WithdrawStatus.InsufficientFunds, withdrawStatus);
        }

        [TestMethod]
        public void WithdrawFromClosedAccount()
        {
            //Arrange
            var chequingAccount = new ChequingAccount(sampleOwner);
            chequingAccount.Close();
            //Act
            var withdrawStatus = chequingAccount.Withdraw(1.0m);

            //Assert
            Assert.AreEqual(WithdrawStatus.ClosedAccountError, withdrawStatus);
        }

        [TestMethod]
        public void WithdrawOverdraftSuccess()
        {
            //Arrange
            var chequingAccount = new ChequingAccount(sampleOwner);
            
            //Act
            var withdrawStatus = chequingAccount.Withdraw(50m);

            //Assert
            Assert.AreEqual(WithdrawStatus.Success, withdrawStatus);
        }

        [TestMethod]
        public void TransferFunds()
        {
            //Arrange
            var transferSrc = new ChequingAccount(sampleOwner);
            var transferDest = new ChequingAccount(sampleOwner);
            transferSrc.Deposit(34.5m);

            //Act
            var transferStatus = transferSrc.TransferFunds(34.5m, transferDest);

            //Assert
            Assert.AreEqual(TransferStatus.Success, transferStatus);
            Assert.AreEqual( 0, transferSrc.Balance);
            Assert.AreEqual(34.5m, transferDest.Balance);

        }
    }
}
