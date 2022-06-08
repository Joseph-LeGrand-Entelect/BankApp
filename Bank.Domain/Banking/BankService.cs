using Bank.Core.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bank.Domain.Banking
{
    public class BankService : IBankService
    {
        private readonly HttpClient _client;
        private HttpResponseMessage _response;
        public BankService()
        {
            _client = new HttpClient();
            _response = null;
        }
        
        public double GetTransactionFee()
        {
            try
            {
                var task = Task.Run(() => _client.GetAsync("https://mocki.io/v1/c9ca6e2b-d811-49d8-8888-d2a2eb0cb447")); 
                task.Wait();
                _response = task.Result;

                var task2 = Task.Run(() => _response.Content.ReadAsStringAsync());
                task2.Wait();
                var responseBody  = task2.Result;
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

        public double GetInterestRate()
        {
            try
            {
                var task = Task.Run(() => _client.GetAsync("https://mocki.io/v1/99b0792d-1f35-4d84-89ba-76bdd929dcf8")); 
                task.Wait();
                _response = task.Result;
                
                var task2 = Task.Run(() => _response.Content.ReadAsStringAsync());
                task2.Wait();
                var responseBody  = task2.Result;
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