using System.Threading.Tasks;

namespace Bank.Domain.Interface
{
    public interface IBankService
    {
        Task<double> GetTransactionFee();
        Task<double> GetInterestRate();
    }
}