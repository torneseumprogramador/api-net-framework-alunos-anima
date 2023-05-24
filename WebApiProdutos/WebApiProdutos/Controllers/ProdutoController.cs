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
        // GET api/produto
        public IEnumerable<string> Get()
        {
            return new string[] { "Produto 01", "Produto 02" };
        }

        // GET api/produto/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/produto
        public void Post([FromBody] string value)
        {
        }

        // PUT api/produto/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/produto/5
        public void Delete(int id)
        {
        }
    }
}
