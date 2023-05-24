using ApiCadastroRoupas.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ApiCadastroRoupas.Connection;

namespace ApiCadastroRoupas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly BaseConnection _produtoRepository;

        public async Task<IEnumerable<Produto>> Produtos()
        {
            string sql = @"SELECT * FROM PRODUTO";

            return (IEnumerable<Produto>)await _produtoRepository.BuscarLista<IEnumerable<Produto>>(sql);
        }   

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProdutos")]
        public async Task<IEnumerable<Produto>> Get()
        {
            return await Produtos();
        }
    }
}