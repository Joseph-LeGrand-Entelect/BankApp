using System.Threading.Tasks;

namespace BankApp.Interface
{
    public interface IBankService
    {
        Task<double> GetTransactionFee();
        Task<double> GetInterestRate();
    }
}