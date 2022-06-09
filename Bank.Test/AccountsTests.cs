using System;
using NUnit.Framework;

namespace Bank.Test
{
    [TestFixture]
    public class AccountsTests : BaseTests
    {
        [TestCase(11.99, 4.55, 7.44)]
        public void Withdraw_WithValidAmount_UpdatesBalance(double beginningBalance, double withdrawalAmount, double expected)
        {
            // Arrange
            Account.Balance = beginningBalance;
            
            // Act
            Account.Withdraw(withdrawalAmount);
            
            // Assert
            var actual = Account.Balance;
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Withdraw_WhenAmountIsLessThanZero_ShouldThrowException()
        {
            // Arrange
            const double beginningBalance = 11.99;
            const double withdrawalAmount = -100.00;

            Account.Balance = beginningBalance;
            
            // Act
            TestDelegate act =() => Account.Withdraw(withdrawalAmount);

            // Assert
            var exception = Assert.Throws<Exception>(act);
            //The thrown exception can be used for even more detailed assertions.
            Assert.AreEqual("Are you depositing or widthrawing please decide", exception?.Message);
        }
        
        [Test]
        public void Withdraw_WhenAmountIsMoreThanBalance_ShouldThrowException()
        {
            // Arrange
            const double beginningBalance = 11.99;
            const double withdrawalAmount = 20.00;

            Account.Balance = beginningBalance;
            
            // Act
            try
            {
                Account.Withdraw(withdrawalAmount);
            }
            catch (Exception e)
            {
                // Assert
                Assert.Contains(e.Message, new[] { "You wish you had that much money in your account, please enter an amount less than or equal your balance" });
            }
        }
        
        //[TestCase(100000, 450, 99425)]
        [TestCase(100000, 450, 100450)]
        public void Deposit_WhenAmountIsMoreThanZero_ShouldUpdateBalance(double beginningBalance, double depositAmount, double expected)
        {
            // Arrange
            Account.Balance = beginningBalance;
            
            // Act
            Account.Deposit(depositAmount);
            
            // Assert
            var actual = Account.Balance;
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(100000, -450)]
        public void Deposit_WhenAmountIsMoreThanZero_ShouldThrowException(double beginningBalance, double depositAmount)
        {
            // Arrange
            Account.Balance = beginningBalance;
            
            // Act
            TestDelegate act =() => Account.Deposit(depositAmount);

            // Assert
            var exception = Assert.Throws<Exception>(act);
            //The thrown exception can be used for even more detailed assertions.
            Assert.AreEqual("We can't be owing you money, please deposit an amount above transaction fee", exception?.Message);
        }
    }
}