using System;
using NUnit.Framework;

namespace Bank.Test
{
    [TestFixture]
    public class CheckingAccountTests: BaseTests
    {
        [TestCase(1100.99, 4.55, 971.44)]
        [Repeat(10)]
        public void Withdraw_WithValidAmount_UpdatesBalance(double beginningBalance, double withdrawalAmount, double expected)
        {
            // Arrange
            CheckingAccount.Balance = beginningBalance;
            
            // Act
            CheckingAccount.Withdraw(withdrawalAmount);
            
            // Assert
            var actual = CheckingAccount.Balance;
            Assert.AreEqual(expected, actual);
        }
        
        //Interesting case, initial input value on checking account
        //Add exception to deposit and withdrawal
        //Make it interactive
        [Test]
        public void Withdraw_WhenAmountIsLessThanZero_ShouldThrowException()
        {
            // Arrange
            var beginningBalance = 11.99;
            var withdrawalAmount = -100.00;

            CheckingAccount.Balance = beginningBalance;
            
            // Act
            TestDelegate act =() => CheckingAccount.Withdraw(withdrawalAmount);

            // Assert
            var exception = Assert.Throws<Exception>(act);
            //The thrown exception can be used for even more detailed assertions.
            Assert.AreEqual("Are you depositing or widthrawing please decide", exception?.Message);
        }
        
        [Test]
        public void Withdraw_WhenAmountIsMoreThanBalance_ShouldThrowException()
        {
            // Arrange
            var beginningBalance = 11.99;
            var withdrawalAmount = 20.00;

            CheckingAccount.Balance = beginningBalance;
            
            // Act
            try
            {
                CheckingAccount.Withdraw(withdrawalAmount);
            }
            catch (Exception e)
            {
                // Assert
                Assert.Contains(e.Message, new[] { "You wish you had that much money in your account, please enter an amount less than or equal your balance" });
            }
        }
        
        //[TestCase(100000, 450, 99425)]
        [TestCase(100000, 450, 100325)]
        public void Deposit_WhenAmountIsMoreThanZero_ShouldUpdateBalance(double beginningBalance, double depositAmount, double expected)
        {
            // Arrange
            CheckingAccount.Balance = beginningBalance;
            
            // Act
            CheckingAccount.Deposit(depositAmount);
            
            // Assert
            var actual = CheckingAccount.Balance;
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(100000, -450)]
        public void Deposit_WhenAmountIsLessThanZero_ShouldThrowException(double beginningBalance, double depositAmount)
        {
            // Arrange
            CheckingAccount.Balance = beginningBalance;
            
            // Act
            TestDelegate act =() => CheckingAccount.Deposit(depositAmount);

            // Assert
            var exception = Assert.Throws<Exception>(act);
            //The thrown exception can be used for even more detailed assertions.
            Assert.AreEqual("We can't be owing you money, please deposit an amount above transaction fee", exception?.Message);
        }
        
        //Interesting case, but it's wrong
        [TestCase(100000, -150)]
        public void Deposit_WhenAmountIsLessThanZero_ShouldThrowException_V2(double beginningBalance, double depositAmount)
        {
            // Arrange
            CheckingAccount.Balance = beginningBalance;
            
            // Act
            TestDelegate act =() => CheckingAccount.Deposit(depositAmount);

            // Assert
            var exception = Assert.Throws<Exception>(act);
            //The thrown exception can be used for even more detailed assertions.
            Assert.AreEqual("We can't be owing you money, please deposit an amount above transaction fee", exception?.Message);
        }
    }
}