using Bank.Core.Model;
using Bank.Domain.Interface;
using Newtonsoft.Json;

namespace Bank.Domain.Service
{
    public class BankService : IBankService
    {
        private readonly HttpClient _client;
        private HttpResponseMessage? _response;
        public BankService()
        {
            _client = new HttpClient();
            _response = null;
        }
        
        public async Task<double> GetTransactionFee()
        {
            try
            {
                _response = await _client.GetAsync("https://mocki.io/v1/c9ca6e2b-d811-49d8-8888-d2a2eb0cb447");
                var responseBody  = await _response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<BankServiceModel>(responseBody);
                if (model != null) return model.TransactionFee;
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<double> GetInterestRate()
        {
            try
            {
                _response = await _client.GetAsync("https://mocki.io/v1/99b0792d-1f35-4d84-89ba-76bdd929dcf8");
                var responseBody  = await _response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<BankServiceModel>(responseBody);
                if (model != null) return model.InterestRate;
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}