using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Domain.Controllers
{
    [RoutePrefix("api/produtos")]
    public class ProdutoController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post(int id)
        {
        }

        [HttpPut]
        [Route("{id}")]
        public void Put(int id)
        {
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
        }
    }
}
