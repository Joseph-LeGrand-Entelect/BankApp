namespace Bank.Domain.Banking
{
    public interface IBankService
    {
        double GetTransactionFee();
        double GetInterestRate();
    }
}