using Microsoft.EntityFrameworkCore;
using ExchangeAPITest.Modelss;

namespace ExchangeAPITest.DataBase
{
    public class ExchangeDb : DbContext
    {
        public ExchangeDb(DbContextOptions<ExchangeDb> options) : base(options)
        {

        }
        public DbSet<CurrencyResponse> Currencys { get; set; }
    }
}
