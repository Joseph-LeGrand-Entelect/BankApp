using Bank.Domain.Banking;

namespace Bank.Domain.CheckingAccount
{
    public class CheckingAccount : Account.Account
    {
        private double TransactionFee { get; set; }
        
        public CheckingAccount(string customerName, double balance, IBankService service) : base(customerName, balance, service)
        {
            TransactionFee = service.GetTransactionFee();
        }

        // Increases balance by given amount minus fee
        public override void Deposit(double amount)
        {
            //Do not delete, for demo purpose
            //TransactionFee = BankService.GetTransactionFee(); 
            base.Deposit(amount - TransactionFee);
        }

        // Decreases balance by given amount plus fee
        public override void Withdraw(double amount)
        {
            base.Withdraw(amount + TransactionFee);
        }
    }
}