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
        //Essa não é a forma correta de abrir PR, eu vou abrir um disso e nas proximas versoes sempre enviar como PR, lembra que te mostrei como criar uma feature branch, e a partir dela abrir um PR para master, mas analise, o pr que estou abrindo com esses TODO é um exemplo para os proximos.
        private readonly ExchangeDb _exchangeDb;

        public ExchangeController(ExchangeDb exchangeDb)
        {
            // esta architetura está incorreta, pois aqui é a camada de entrada da API, e não pode conter, acesso a banco de dados ou regras de negocio.
            //Deve se criar um servico contendo toda regra de negocio, nele deve ser injetado o exchangeDB que acessa o banco de dados, sempre utilizar o conceito de DDD.
            //Essa arquitetura é minima aceita, depois melhoras separando em camadas que seria o correto, mas isso podemos fazer juntos, mas essa parte de DDD a gente ja fez juntos em outros projetos anteriores, pesquisa sobre o conceito, tenta aplicar e se tiver duvida comenta aqui no mesmo PR
            _exchangeDb = exchangeDb;
        }
        
        // Duvidas se precisa ser gravado no banco ou não//
        //Duvidas se está certa a maneira de pensar//
        
        [HttpGet]
        public async Task<CurrencyResponse> GetAllCurrencys()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://data.fixer.io/api/latest?access_key=147ac5d07434f372ab5ceab67f637ab3&base=EUR&symbols=GBP");

            var jsonstring = await response.Content.ReadAsStringAsync();
            //TODO: Voce está obtendo todos as cotações, não foi esse endpoint q eu disse, eu disse, voce solicita a cotação de uma unica moeda, na documentação tem esse endpoint
            CurrencyResponse jsonObject = JsonConvert.DeserializeObject<CurrencyResponse>(jsonstring);
            //TODO: Alterei o endpoint para o correto acima e retornou esse json/*{"success":true,"timestamp":1687988463,"base":"EUR","date":"2023-06-28","rates":{"GBP":0.863526}}*/

            //Para o mapeamento ser feito correto o jsonObject, que poderia chamar currentRateExchange, se atente aos nomes, jsonObject é muito gererico, o nome tem que corresponder com o que vc armazena na variavel, lembre se é orientacao a objeto e o conceito de objeto se espelha no mundo real.
            return jsonObject;
        }
        
        //Ainda vou implementar essa parte, mas só depois que funconar o GetAll//
        
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetSpecificExchengeCurrancy()
        {
            //O metodo acima deve estar aqui, pois deve receber dois parametros, A moeda base (Euro por exemplo) e uma lista de moedas para qual eu quero a cotacao do dia, essa lista pode vir 1 ou varias moedas dependendo do parametro que eu passar, por exemplo.
            // Input (Base=euro, symbols=BLR,USD, GBP e etc.... existe isso na documentação (https://fixer.io/documentation) da api qualquer duvida pode consultar nela.

            return Ok();
        }
    
    }
}
