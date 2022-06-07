using System.Threading.Tasks;

namespace Bank.Domain.Banking
{
    public interface IBankService
    {
        Task<double> GetTransactionFee();
        Task<double> GetInterestRate();
    }
}