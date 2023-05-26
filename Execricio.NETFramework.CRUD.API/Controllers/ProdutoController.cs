using System.Collections.Generic;
using System.Web.Http;
using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using Execricio.NETFramework.CRUD.Business.Services;
using Execricio.NETFramework.CRUD.Business.Services.Interfaces;

namespace Execricio.NETFramework.CRUD.API.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController()
        {
            _produtoService = ProdutoService.Instance;
        }

        // GET api/produto
        public IEnumerable<ProdutoResponse> Get()
        {
            IEnumerable<ProdutoResponse> produtos = _produtoService.RecuperarProdutos();
            return produtos;
        }

        // GET api/produto/{id}
        public IHttpActionResult Get(int id)
        {
            ProdutoResponse produto = _produtoService.RecuperarProduto(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        // POST api/produto
        public IHttpActionResult Post([FromBody] ProdutoRequest produto)
        {
            return Ok(_produtoService.SalvarProduto(produto));
        }

        // PUT api/produto/{id}
        public IHttpActionResult Put(int id, [FromBody] ProdutoRequest produto)
        {
            if (!_produtoService.AtualizarProduto(id, produto))
                return NotFound();

            return Ok();
        }

        // DELETE api/produto/{id}
        public IHttpActionResult Delete(int id)
        {
            if (!_produtoService.DeletarProduto(id))
                return NotFound();

            return Ok();
        }
    }
}
