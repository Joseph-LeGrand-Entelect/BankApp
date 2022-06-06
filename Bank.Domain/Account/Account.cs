namespace Bank.Domain.Account
{
    public class Account
    {
        // Declare variable for the account balance
        public double Balance { get; set; }
        // Declare variable for the account balance
        public string CustomerName { get; set; }

        // Constructor
        public Account(string customerName, double balance)
        {
            CustomerName = customerName;
            Balance = balance;
        }

        // Increases balance by given amount
        public virtual void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            Balance += amount;
        }

        // Decreases balance by given amount or displays message
        public virtual void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            Balance -= amount;
        }
    }
}