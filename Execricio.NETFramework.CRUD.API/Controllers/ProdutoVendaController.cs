using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using Execricio.NETFramework.CRUD.Business.Services;
using Execricio.NETFramework.CRUD.Business.Services.Interfaces;

namespace Execricio.NETFramework.CRUD.API.Controllers
{
    public class ProdutoVendaController : ApiController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoVendaController()
        {
            _produtoService = ProdutoService.Instance;
        }

        // GET api/produtovenda
        public IEnumerable<ProdutoResponse> Get()
        {
            IEnumerable<ProdutoResponse> produtos = _produtoService.RecuperarProdutos(infoPreco: true);
            return produtos;
        }

        // GET api/produtovenda/{id}
        public IHttpActionResult Get(int id)
        {
            ProdutoResponse produto = _produtoService.RecuperarProduto(id: id, infoPreco: true);
            
            if (produto is null)
                return NotFound();

            return Ok(produto);
        }
    }
}
