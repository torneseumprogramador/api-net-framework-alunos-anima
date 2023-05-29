using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiProdutos.Controllers
{
    public class PrecoController : ApiController
    {
        private readonly PrecoService _precoService = new PrecoService();

        // GET api/preco
        public IEnumerable<PrecoService> Get()
        {
            return _precoService.BuscarListaPrecos();
        }

        // GET api/preco/5
        public PrecoService Get(int id)
        {
            return _precoService.BuscarPreco(id);
        }

        // POST api/preco
        public HttpResponseMessage Post([FromBody] PrecoService preco)
        {
             return _precoService.SalvarPreco(preco);
        }

        // PUT api/preco/5
        public HttpResponseMessage Put(int id, [FromBody] PrecoService value)
        {
            return _precoService.EditarPreco(id, value);
        }

        // DELETE api/preco/5
        public HttpResponseMessage Delete(int id)
        {
            return _precoService.DeletarPreco(id);
        }
    }
}
