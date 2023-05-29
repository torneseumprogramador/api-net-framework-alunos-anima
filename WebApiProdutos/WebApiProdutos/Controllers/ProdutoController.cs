using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiProdutos.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly ProdutoService _produtoService = new ProdutoService();

        // GET api/produto
        public IEnumerable<ProdutoService> Get()
        {
            return _produtoService.BuscarListaProdutos();
        }

        // GET api/produto/5
        public ProdutoService Get(int id)
        {
            return _produtoService.BuscarProduto(id);
        }

        // POST api/produto
        public HttpResponseMessage Post([FromBody] ProdutoService produto)
        {
             return _produtoService.SalvarProduto(produto);
        }

        // PUT api/produto/5
        public HttpResponseMessage Put(int id, [FromBody] ProdutoService value)
        {
            return _produtoService.EditarProduto(id, value);
        }

        // DELETE api/produto/5
        public HttpResponseMessage Delete(int id)
        {
            return _produtoService.DeletarProduto(id);
        }
    }
}
