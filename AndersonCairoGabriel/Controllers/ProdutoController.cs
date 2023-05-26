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
        public IHttpActionResult ListarPessoas()
        {
            var produtos = _produtosBusiness.ListarProdutos();
            return Ok(produtos);
        }

        [HttpGet]
        public IHttpActionResult ObterPessoa(int id)
        {
            var produto = _produtosBusiness.ObterProduto(id);

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