

namespace Bank.Domain.SavingsAccount
{
    public class SavingsAccount : Account.Account
    {
        private double InterestRate { get; set; }
        public SavingsAccount(string customerName, double balance) : base(customerName, balance)
        {
            InterestRate = BankService.GetInterestRate();
        }
        
        // Returns the amount earned for "this" saving account
        public double CalculateInterestEarned()
        {
            return InterestRate/100 * Balance;
        }
    }
}