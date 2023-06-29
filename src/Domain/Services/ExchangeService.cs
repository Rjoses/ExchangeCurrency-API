using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class ExchangeService : IExchangeService
    {
        //TODO: criar servico no padrao DDD aqui e injetar na controler para usar
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
