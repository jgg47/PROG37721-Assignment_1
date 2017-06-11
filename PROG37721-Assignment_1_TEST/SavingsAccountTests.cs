using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROG37721_Assignment_1.Models;

namespace PROG37721_Assignment_1_TEST
{
    [TestClass]
    public class SavingsAccountTests
    {
        AccountOwner sampleOwner = new AccountOwner
        {
            Name = "Sample Owner"
        };
        [TestMethod]
        public void Withdraw()
        {
            //Arrange
            var savingsAccount = new SavingsAccount(sampleOwner);
            savingsAccount.Deposit(34.5m);
            
            //Act
            var withdrawStatus = savingsAccount.Withdraw(34.5m);

            //Assert
            Assert.AreEqual(WithdrawStatus.Success, withdrawStatus);
        }

        [TestMethod]
        public void TransferFunds()
        {
            //Arrange
            var transferSrc = new SavingsAccount(sampleOwner);
            var transferDest = new SavingsAccount(sampleOwner);
            transferSrc.Deposit(34.5m);

            //Act
            var transferStatus = transferSrc.TransferFunds(34.5m, transferDest);

            //Assert
            Assert.AreEqual(TransferStatus.Success,transferStatus);
            Assert.AreEqual(0, transferSrc.Balance);
            Assert.AreEqual(34.5m, transferDest.Balance);
        }

        [TestMethod]
        public void TransferTooMuchFunds()
        {
            //Arrange
            var transferSrc = new SavingsAccount(sampleOwner);
            var transferDest = new SavingsAccount(sampleOwner);
           
            //Act
            var transferStatus = transferSrc.TransferFunds(34.5m, transferDest);

            //Assert
            Assert.AreEqual(TransferStatus.InsufficientFunds, transferStatus);
            Assert.AreEqual(0, transferSrc.Balance);
            Assert.AreEqual(0, transferDest.Balance);
        }
        [TestMethod]
        public void TransferClosedFunds()
        {
            //Arrange
            var transferSrc = new SavingsAccount(sampleOwner);
            var transferDest = new SavingsAccount(sampleOwner);
            transferSrc.Close();

            //Act
            var transferStatus = transferSrc.TransferFunds(34.5m, transferDest);

            //Assert
            Assert.AreEqual(TransferStatus.ClosedAccountError, transferStatus);
            Assert.AreEqual(0, transferSrc.Balance);
            Assert.AreEqual(0, transferDest.Balance);
        }
    }
}
