using Bank.Domain.Account;
using Bank.Domain.Banking;
using Bank.Domain.CheckingAccount;
using Moq;
using NUnit.Framework;

namespace Bank.Test
{
    [TestFixture]
    public class BaseTests
    {
        protected Mock<IBankService> BankServiceMock;
        protected IBankService BankService;
        protected CheckingAccount CheckingAccount;
        protected Account Account;
        protected CheckingAccount CheckingAccountMock;

        private const string CustomerName = "Mrs Jackson";
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Code here would be executed only once before the first test.
            BankService = new BankService();
            Account = new Account(CustomerName, 0.0, BankService);
            CheckingAccount = new CheckingAccount(CustomerName, 0.0, BankService);
            
            //Mocks
            BankServiceMock = new Mock<IBankService>();
            BankServiceMock.Setup(service => service.GetInterestRate()).Returns(0);
            BankServiceMock.Setup(service => service.GetTransactionFee()).Returns(0);
            CheckingAccountMock = new CheckingAccount(CustomerName, 0.0, BankServiceMock.Object);

        }

        [SetUp]
        public void Setup()
        {
            /*_bankService = new BankService();
            Account = new Account(CustomerName, 0.0, _bankService);
            CheckingAccount = new CheckingAccount(CustomerName, 0.0, _bankService);
            
            //Mocks
            BankServiceMock = new Mock<IBankService>();
            BankServiceMock.Setup(service => service.GetInterestRate()).Returns(0);
            BankServiceMock.Setup(service => service.GetTransactionFee()).Returns(0);
            CheckingAccountMock = new CheckingAccount(CustomerName, 0.0, BankServiceMock.Object);*/
        }
        
        [TearDown]
        public void TearDown()
        {
            /*BankServiceMock = null;
            _bankService = null;*/
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Code here would be executed only once after the last test.
            BankServiceMock = null;
            BankService = null;
        }
    }
}