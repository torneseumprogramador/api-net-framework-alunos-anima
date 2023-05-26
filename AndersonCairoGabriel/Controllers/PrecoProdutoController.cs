using Entidades;
using Entidades.DTOs;
using Negocios;
using System.Net;
using System.Web.Http;

namespace AndersonCairoGabriel.Controllers
{
    public class PrecoProdutoController : ApiController
    {
        private readonly PrecoProdutos _precoProdutoBusiness;

        public PrecoProdutoController()
        {
            _precoProdutoBusiness = new PrecoProdutos();
        }

        [HttpGet]
        public IHttpActionResult ListarPessoas()
        {
            var produtos = _precoProdutoBusiness.ListarPrecoProduto();
            return Ok(produtos);
        }

        [HttpGet]
        public IHttpActionResult ObterPrecoProduto(int id)
        {
            var produto = _precoProdutoBusiness.ObterPrecoProduto(id);

            return Ok(produto);
        }


        [HttpPost]
        public IHttpActionResult CadastrarProduto([FromBody] PrecoProduto precoProduto)
        {
            var novoProduto = _precoProdutoBusiness.CadastrarPrecoProduto(precoProduto);
            return Ok(novoProduto);
        }

        [HttpPut]
        public IHttpActionResult AtualizarProduto(int id, [FromBody] PrecoProduto precoProduto)
        {
            var produtoAtualizado = _precoProdutoBusiness.AtualizarPrecoProduto(id, precoProduto);
            return Ok(produtoAtualizado);
        }

        [HttpDelete]
        public IHttpActionResult ExluirProduto(int id)
        {
            _precoProdutoBusiness.ExcluirPrecoProduto(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}