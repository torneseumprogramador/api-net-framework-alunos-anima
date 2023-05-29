using System.Collections.Generic;
using System.Web.Http;
using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using Execricio.NETFramework.CRUD.Business.Services;
using Execricio.NETFramework.CRUD.Business.Services.Interfaces;

namespace Execricio.NETFramework.CRUD.API.Controllers
{
    [Route("produto")]
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
        [Route("produto/{id}")]
        public IHttpActionResult RecuperarProdutos(int id)
        {
            ProdutoResponse produto = _produtoService.RecuperarProduto(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpGet]
        [Route("produto/vendas")]
        public IEnumerable<ProdutoResponse> RecuperarProdutosVendas()
        {
            IEnumerable<ProdutoResponse> produtos = _produtoService.RecuperarProdutos(infoPreco: true);
            return produtos;
        }

        [HttpGet]
        [Route("produto/vendas/{id}")]
        public IHttpActionResult RecuperarProdutoVendas(int id)
        {
            ProdutoResponse produto = _produtoService.RecuperarProduto(id: id, infoPreco: true);

            if (produto is null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public IHttpActionResult SalvarProduto([FromBody] ProdutoRequest produto)
        {
            return Ok(_produtoService.SalvarProduto(produto));
        }

        [HttpPost]
        [Route("produto/{id}")]
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
