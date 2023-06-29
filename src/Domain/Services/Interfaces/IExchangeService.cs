namespace Domain.Services.Interfaces
{
    public interface IExchangeService
    {
        void GetRateHistory();
        void GetRate(string baseCurrency, IList<string> symbols);
    }
}
