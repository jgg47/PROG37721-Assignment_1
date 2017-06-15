using System;
using System.Reflection;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
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
        public void ConstructorOwnerArgTest()
        {
            //Arrange
            AccountOwner sampleAccountOwner = new AccountOwner();
            var mockClass = new Mock<BankAccount>(sampleAccountOwner);
            var mockObject = mockClass.Object;

            //Assert
            Assert.AreEqual(BankAccountStatus.Active, mockObject.Status);
            Assert.AreEqual(0, mockObject.Balance);
            Assert.AreEqual(sampleAccountOwner, mockObject.Owner);
            Assert.AreEqual(1, BankAccount.NumberOfAccounts);
            Assert.IsNotNull(mockObject.AccountNumber);
        }

        [TestMethod]
        public void Constructor2AccountsTest()
        {
            //Arrange
            AccountOwner sampleAccountOwner = new AccountOwner()
            {
                Name = "Constructor Test",
                Email ="Test@email.com",
                PhoneNumber = "1111111111"
            };
            AccountOwner sampleAccountOwnerCopy = new AccountOwner()
            {
                Name = "Constructor Test",
                Email = "Test@email.com",
                PhoneNumber = "1111111111"
            };
            AccountOwner finalAccountOwner = new AccountOwner()
            {
                Name = "Constructor Test",
                Email = "Test@email.com",
                PhoneNumber = "1111111111"
            };
            var mockClass = new Mock<BankAccount>(sampleAccountOwner);
            var mockClass2 = new Mock<BankAccount>(sampleAccountOwnerCopy);
            var mockObject = mockClass.Object;
            var mockObject2 = mockClass2.Object;
            var numberOfAccounts = BankAccount.NumberOfAccounts;
            
            //Act
            var mockClassCombined = new Mock<BankAccount>(mockObject, mockObject2);
            var combinedObject = mockClassCombined.Object;

            //Assert
            Assert.AreEqual(BankAccountStatus.Active, combinedObject.Status);
            Assert.AreEqual(0, combinedObject.Balance);
            Assert.AreEqual(finalAccountOwner, combinedObject.Owner);
            Assert.AreEqual(numberOfAccounts-1, BankAccount.NumberOfAccounts);
            Assert.IsNotNull(combinedObject.AccountNumber);
            Assert.AreEqual("Constructor Test CLOSED", mockObject.Owner.Name);
            Assert.AreEqual("Constructor Test CLOSED", mockObject2.Owner.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(TargetInvocationException))]
        public void Constructor2AccountsTest_OwnersNotEqual()
        {
            //Arrange
            AccountOwner sampleAccountOwner = new AccountOwner()
            {
                Name = "Constructor Test",
                Email = "Test@email.com",
                PhoneNumber = "1111111111"
            };
            AccountOwner sampleAccountOwnerCopy = new AccountOwner()
            {
                Name = "lak;sdjf Test",
                Email = "asdfcom",
                PhoneNumber = "asdf"
            };
           
            var mockClass = new Mock<BankAccount>(sampleAccountOwner);
            var mockClass2 = new Mock<BankAccount>(sampleAccountOwnerCopy);
            var mockObject = mockClass.Object;
            var mockObject2 = mockClass2.Object;

            //Act
           var mockClassCombined = new Mock<BankAccount>(mockObject, mockObject2);
           var combinedObject = mockClassCombined.Object;
           
           //Assert
           Assert.Fail();
           
        }

        [TestMethod]
        [ExpectedException(typeof(TargetInvocationException))]
        public void Constructor2AccountsTest_SameAccountNumber()
        {
            //Arrange
            AccountOwner sampleAccountOwner = new AccountOwner()
            {
                Name = "Constructor Test",
                Email = "Test@email.com",
                PhoneNumber = "1111111111"
            };
           
            var mockClass = new Mock<BankAccount>(sampleAccountOwner);
            var mockObject = mockClass.Object;
           
            //Act
            var mockClassCombined = new Mock<BankAccount>(mockObject, mockObject);
            var combinedObject = mockClassCombined.Object;

            //Assert
            Assert.Fail();

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
        [ExpectedException(typeof(ClosedAccountException))]
        public void DepositToClosedAccountTest()
        {
            //Arrange
            AccountOwner sampleAccountOwner = new AccountOwner();
            var mockClass = new Mock<BankAccount>(sampleAccountOwner);
            var mockObject = mockClass.Object;
           
            //Act
            mockObject.Close();
            mockObject.Deposit(34.5m);

            //Assert
            Assert.Fail();          
        }
    }
}
