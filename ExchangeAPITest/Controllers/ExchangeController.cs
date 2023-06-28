using ExchangeAPITest.DataBase;
using ExchangeAPITest.Modelss;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExchangeAPITest.Controllers
{
    [Route("api/v1/exchange")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly ExchangeDb _exchangeDb;

        public ExchangeController(ExchangeDb exchangeDb)
        {
            _exchangeDb = exchangeDb;
        }

        [HttpGet]
        public async Task<CurrencyResponse> GetAllCurrencys()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://data.fixer.io/api/latest?access_key=147ac5d07434f372ab5ceab67f637ab3");


            var jsonstring = await response.Content.ReadAsStringAsync();

            CurrencyResponse jsonObject = JsonConvert.DeserializeObject<CurrencyResponse>(jsonstring);

            return jsonObject;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetSpecificExchengeCurrancy()
        {
            
            return Ok();
        }
    
    }
}