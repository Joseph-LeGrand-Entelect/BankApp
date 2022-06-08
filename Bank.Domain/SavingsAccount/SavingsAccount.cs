using Bank.Domain.Banking;

namespace Bank.Domain.SavingsAccount
{
    public class SavingsAccount : Account.Account
    {
        private double InterestRate { get; set; }
        public SavingsAccount(string customerName, double balance, IBankService service) : base(customerName, balance, service)
        {
            InterestRate = service.GetInterestRate();
        }
        
        // Returns the amount earned for "this" saving account
        public double CalculateInterestEarned()
        {
            return InterestRate/100 * Balance;
        }
    }
}