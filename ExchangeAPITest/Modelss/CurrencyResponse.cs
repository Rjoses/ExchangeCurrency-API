using ExchangeAPITest.Modelss.Entitys;

namespace ExchangeAPITest.Modelss
{
    public class CurrencyResponse
    {
        public string TimesTamp { get; set; }
        public bool Sucess { get; set; }
        public string Base { get; set; }
        public Currency Rates { get; set; }
    }
}

