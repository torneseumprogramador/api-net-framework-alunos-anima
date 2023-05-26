using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiProdutos.Models;
using WebApiProdutos.Models.Interface;

namespace WebApiProdutos.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly IProdutoModel _produtoModel = new ProdutoModel();

        // GET api/produto
        public IEnumerable<ProdutoModel> Get()
        {
            return _produtoModel.BuscarListaProdutos();
        }

        // GET api/produto/5
        public ProdutoModel Get(int id)
        {
            return _produtoModel.BuscarProduto(id);
        }

        // POST api/produto
        public void Post([FromBody] ProdutoModel produto)
        {
            _produtoModel.SalvarProduto(produto);
        }

        // PUT api/produto/5
        public void Put(int id, [FromBody] ProdutoModel value)
        {
            _produtoModel.EditarProduto(id, value);
        }

        // DELETE api/produto/5
        public void Delete(int id)
        {
            _produtoModel.DeletarProduto(id);
        }
    }
}
