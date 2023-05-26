using Negocios;
using System.Net;
using Entidades.DTOs;
using System.Web.Http;

namespace AndersonCairoGabriel.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly Produtos _produtosBusiness;

        public ProdutoController()
        {
            _produtosBusiness = new Produtos();
        }

        [HttpGet]
        public IHttpActionResult ListarProdutos()
        {
            var produtos = _produtosBusiness.ListarProdutos();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("api/produto/precos")]
        public IHttpActionResult ListarProdutosComPreco()
        {
            return Ok(_produtosBusiness.ListarProdutosComPreco());
        }

        [HttpGet]
        [Route("api/produto/{id:int}")]
        public IHttpActionResult ObterProduto(int id)
        {
            var produto = _produtosBusiness.ObterProduto(id);

            return Ok(produto);
        }

        [HttpGet]
        [Route("api/produto/preco/{id:int}")]
        public IHttpActionResult ObterProdutoComPreco(int id)
        {
            var produto = _produtosBusiness.ObterProdutoComPreco(id);

            return Ok(produto);
        }

        [HttpPost]
        public IHttpActionResult CadastrarProduto([FromBody] ProdutoDto produto)
        {
            var novoProduto = _produtosBusiness.CadastrarProdutos(produto);
            return Ok(novoProduto);
        }

        [HttpPut]
        public IHttpActionResult AtualizarProduto(int id, [FromBody] ProdutoDto produto)
        {
            var produtoAtualizado = _produtosBusiness.AtualizarProduto(id, produto);
            return Ok(produtoAtualizado);
        }

        [HttpDelete]
        public IHttpActionResult ExluirProduto(int id)
        {
            _produtosBusiness.ExcluirProduto(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}