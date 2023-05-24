using ApiCadastroRoupas.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiCadastroRoupas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private readonly Produto _produto;

        public ProdutoController(Produto produto)
        {
            _produto = produto;
        }

        [HttpGet("GetProdutos")]
        public async Task<ProdutoController> GetProdutos()
        {
            return (ProdutoController)await _produto.Produtos();
        }
    }
}