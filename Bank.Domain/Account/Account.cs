using System;
using Bank.Domain.Banking;

namespace Bank.Domain.Account
{
    public class Account
    {
        // Declare variable for the account balance
        public double Balance { get; set; }
        // Declare variable for the account balance
        public string CustomerName { get; set; }

        protected readonly IBankService BankService;

        // Constructor
        public Account(string customerName, double balance)
        {
            CustomerName = customerName;
            Balance = balance;
            BankService = new BankService();
        }

        // Increases balance by given amount
        public virtual void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new Exception("We can't be owing you money, please deposit a positive amount");
            }
            Balance += amount;
        }

        // Decreases balance by given amount or displays message
        public virtual void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new Exception("You wish you had that much money in your account, please enter an amount less than or equal your balance");
            }

            if (amount < 0)
            {
                throw new Exception("Are you depositing or widthrawing please decide");
            }
            Balance -= amount;
        }
    }
}