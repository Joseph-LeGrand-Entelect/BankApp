using Bank.Domain;

namespace Bank.Domain
{
    public class CheckingAccount : Account
    {
        private double TransactionFee { get; set; }
        
        public CheckingAccount(string customerName, double balance, double transactionFee) : base(customerName, balance)
        {
            TransactionFee = transactionFee;
        }

        // Increases balance by given amount minus fee
        public override void Deposit(double amount)
        {
            base.Deposit(amount - TransactionFee);
        }

        // Decreases balance by given amount plus fee
        public override void Withdraw(double amount)
        {
            base.Withdraw(amount + TransactionFee);
        }
    }
}