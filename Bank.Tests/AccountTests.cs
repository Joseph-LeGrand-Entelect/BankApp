using System;
using Bank.Domain.Account;
using Xunit;

namespace Bank.Tests
{
    public class AccountTests
    {
        [Theory]
        [InlineData(11.99, 4.55, 7.44)]
        public void Withdraw_WithValidAmount_UpdatesBalance(double beginningBalance, double withdrawalAmount, double expected)
        {
            // Arrange
            var account = new Account("Mr. Bryan Walton", beginningBalance);
            
            // Act
            account.Withdraw(withdrawalAmount);
            
            // Assert
            var actual = account.Balance;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenAmountIsLessThanZero_ShouldThrowException()
        {
            // Arrange
            var beginningBalance = 11.99;
            var withdrawalAmount = -100.00;

            var account = new Account("Mr. Bryan Walton", beginningBalance);
            
            // Act
            Action act =() => account.Withdraw(withdrawalAmount);

            // Assert
            var exception = Assert.Throws<Exception>(act);
            //The thrown exception can be used for even more detailed assertions.
            Assert.Equal("Are you depositing or widthrawing please decide", exception.Message);
        }
        
        [Fact]
        public void Withdraw_WhenAmountIsMoreThanBalance_ShouldThrowException()
        {
            // Arrange
            var beginningBalance = 11.99;
            var withdrawalAmount = 20.00;

            var account = new Account("Mr. Bryan Walton", beginningBalance);
            
            // Act
            try
            {
                account.Withdraw(withdrawalAmount);
            }
            catch (Exception e)
            {
                // Assert
                Assert.Contains(e.Message, "You wish you had that much money in your account, please enter an amount less than or equal your balance");
            }
        }
    }
}