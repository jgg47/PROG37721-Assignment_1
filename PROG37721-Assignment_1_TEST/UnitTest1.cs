using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PROG37721_Assignment_1;
using PROG37721_Assignment_1.Models;

namespace PROG37721_Assignment_1_TEST
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void DepositTest()
        {
            //Arrange
            var mockClass = new Mock<BankAccount> {CallBase = true};
            var mockObject = mockClass.Object;
            
            //Act
            mockObject.Deposit(34);

            //Assert
            Assert.AreEqual(34.50, mockObject.GetBalance());
        }

        [TestMethod]
        public void StatusActiveTest()
        {
            //Arrange
            var mockClass = new Mock<BankAccount> { CallBase = true };
            var mockObject = mockClass.Object;

           //Assert
            Assert.AreEqual(BankAccountStatus.Active, mockObject.Status);
        }

        [TestMethod]
        public void ClosedTest()
        {
            //Arrange
            var mockClass = new Mock<BankAccount> { CallBase = true };
            var mockObject = mockClass.Object;

            //Assert
            Assert.AreEqual(BankAccountStatus.Active, mockObject.Status);
        }

        [TestMethod]
        public void ActiveAccountsTest()
        {
            //Arrange
            var mockClass = new Mock<BankAccount> { CallBase = true };
            var mockObject = mockClass.Object;
            var mockObject2 = mockClass.Object;

            //Assert
            Assert.AreEqual(2, BankAccount.NumberOfAccounts);
        }

        [TestMethod]
        public void CloseTest()
        {
            //Arrange
            var mockClass = new Mock<BankAccount> { CallBase = true };
            var mockObject = mockClass.Object;
            
            //Act
            mockObject.Close();                             

            //Assert
            Assert.AreEqual(BankAccountStatus.Closed, mockObject.Status);
            Assert.AreEqual("Test Name CLOSED", BankAccount.Owner.Name);
            Assert.AreEqual(0, mockObject.GetBalance());
            Assert.AreEqual(0, BankAccount.NumberOfAccounts);
        }

        [TestMethod]
        public void TransferFundsTest()
        {
            //Arrange
            var mockClass = new Mock<BankAccount> { CallBase = true };
            var transferSrc = mockClass.Object;
            var transferDest = mockClass.Object;

            //Act
            transferSrc.TransferFunds(50, transferDest);

            //Assert
            Assert.AreEqual(50, transferDest.GetBalance());
            Assert.AreEqual(0, transferSrc.GetBalance());
        }

        [TestMethod]
        public void ConstructionTest()
        {
           Assert.AreEqual(1,2);
        }
    }
}
