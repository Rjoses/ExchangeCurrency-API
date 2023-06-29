using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class ExchangeService : IExchangeService
    {
        public void GetRate(string baseCurrency, IList<string> symbols)
        {
            throw new NotImplementedException();
        }

        public void GetRateHistory()
        {
            throw new NotImplementedException();
        }
    }
}
