using System.Collections.Generic;
using System.Web.Http;
using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using Execricio.NETFramework.CRUD.Business.Services;
using Execricio.NETFramework.CRUD.Business.Services.Interfaces;

namespace Execricio.NETFramework.CRUD.API.Controllers
{
    [Route("produtos")]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController()
        {
            _produtoService = ProdutoService.Instance;
        }

        [HttpGet]
        public IEnumerable<ProdutoResponse> RecuperarProdutos()
        {
            IEnumerable<ProdutoResponse> produtos = _produtoService.RecuperarProdutos();
            return produtos;
        }

        [HttpGet]
        [Route("produtos/{id}")]
        public IHttpActionResult RecuperarProdutos(int id)
        {
            ProdutoResponse produto = _produtoService.RecuperarProduto(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public IHttpActionResult SalvarProduto([FromBody] ProdutoRequest produto)
        {
            return Ok(_produtoService.SalvarProduto(produto));
        }

        [HttpPost]
        [Route("produtos/{id}")]
        public IHttpActionResult AtualizarProduto(int id, [FromBody] ProdutoRequest produto)
        {
            if (!_produtoService.AtualizarProduto(id, produto))
                return NotFound();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeletarProduto(int id)
        {
            if (!_produtoService.DeletarProduto(id))
                return NotFound();

            return Ok();
        }
    }
}
