using Moq;
using NUnit.Framework;

namespace Bank.Test
{
    public class CheckingAccountMockTests : BaseTests
    {
        [TestCase(1100.99, 4.55, 1096.44)]
        public void Withdraw_WithValidAmount_UpdatesBalance(double beginningBalance, double withdrawalAmount, double expected)
        {
            // Arrange
            CheckingAccountMock.Balance = beginningBalance;
            
            // Act
            CheckingAccountMock.Withdraw(withdrawalAmount);
           
            // Assert
            BankServiceMock.Verify(service => service.GetTransactionFee(), Times.Exactly(1));
            var actual = CheckingAccountMock.Balance;
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(100000, 450, 100450)]
        public void Deposit_WhenAmountIsMoreThanZero_ShouldUpdateBalance(double beginningBalance, double depositAmount, double expected)
        {
            // Arrange
            CheckingAccountMock.Balance = beginningBalance;
            
            // Act
            CheckingAccountMock.Deposit(depositAmount);
            
            // Assert
            BankServiceMock.Verify(service => service.GetTransactionFee(), Times.Exactly(1));
            var actual = CheckingAccountMock.Balance;
            Assert.AreEqual(expected, actual);
        }
    }
}