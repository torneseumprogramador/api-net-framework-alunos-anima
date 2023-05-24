using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTabelaPrecos.Controllers
{
    public class TabelaPrecoController : ApiController
    {
        // GET api/TabelaPreco
        public IEnumerable<string> Get()
        {
            return new string[] { "Preço 01", "Preço 02" };
        }

        // GET api/TabelaPreco/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/TabelaPreco
        public void Post([FromBody] string value)
        {
        }

        // PUT api/TabelaPreco/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/TabelaPreco/5
        public void Delete(int id)
        {
        }
    }
}
