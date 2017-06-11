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
        public void NumberOfActiveAccountsTest()
        {
            //Arrange
            AccountOwner sampleAccountOwner = new AccountOwner();
            var mockClass = new Mock<BankAccount>(sampleAccountOwner);
            var mockObject = mockClass.Object;
           
            //Assert
            Assert.AreEqual(1, BankAccount.NumberOfAccounts);
        }

        [TestMethod]
        public void DepositTest()
        {
            //Arrange
            AccountOwner sampleAccountOwner = new AccountOwner();
            var mockClass = new Mock<BankAccount> (sampleAccountOwner);
            var mockObject = mockClass.Object;
            
            //Act
            mockObject.Deposit(34.5m);

            //Assert
            Assert.AreEqual(34.5m, mockObject.Balance);
        }

        [TestMethod]
        public void StatusActiveTest()
        {
            //Arrange
            AccountOwner sampleAccountOwner = new AccountOwner();
            var mockClass = new Mock<BankAccount>(sampleAccountOwner);
            var mockObject = mockClass.Object;

            //Assert
            Assert.AreEqual(BankAccountStatus.Active, mockObject.Status);
        }

        [TestMethod]
        public void CloseTest()
        {
            //Arrange
            AccountOwner sampleAccountOwner = new AccountOwner
            {
                Name = "Test Name"
            };
            var mockClass = new Mock<BankAccount> (sampleAccountOwner);
            var mockObject = mockClass.Object;     
            var numberOfObjects = BankAccount.NumberOfAccounts;
            
            //Act
            mockObject.Close();                             

            //Assert
            Assert.AreEqual(BankAccountStatus.Closed, mockObject.Status);
            Assert.AreEqual("Test Name CLOSED", mockObject.Owner.Name);
            Assert.AreEqual(0, mockObject.Balance);
            Assert.AreEqual(numberOfObjects - 1, BankAccount.NumberOfAccounts);
        }

        [TestMethod]
        public void DepositToClosedAccountTest()
        {
            //Arrange
            AccountOwner sampleAccountOwner = new AccountOwner();
            var mockClass = new Mock<BankAccount>(sampleAccountOwner);
            var mockObject = mockClass.Object;
           
            //Act
            mockObject.Close();
            var depositStatus = mockObject.Deposit(34.5m);

            //Assert
            Assert.AreEqual(DepositStatus.ClosedAccountError, depositStatus);           
        }
    }
}
