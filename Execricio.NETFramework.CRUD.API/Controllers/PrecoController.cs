using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using Execricio.NETFramework.CRUD.Business.Services.Interfaces;
using Execricio.NETFramework.CRUD.Business.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace Execricio.NETFramework.CRUD.API.Controllers
{
    public class PrecoController : ApiController
    {
        private readonly IPrecoService _precoService;

        public PrecoController()
        {
            _precoService = PrecoService.Instance;
        }

        // GET api/preco
        public IEnumerable<PrecoResponse> Get()
        {
            IEnumerable<PrecoResponse> precos = _precoService.RecuperarPrecos();
            return precos;
        }

        // GET api/preco/{id}
        public IHttpActionResult Get(int id)
        {
            PrecoResponse preco = _precoService.RecuperarPreco(id);
            if (preco == null)
                return NotFound();

            return Ok(preco);
        }

        // POST api/preco
        public IHttpActionResult Post([FromBody] PrecoRequest preco)
        {
            return Ok(_precoService.SalvarPreco(preco));
        }

        // PUT api/preco/{id}
        public IHttpActionResult Put(int id, [FromBody] PrecoRequest preco)
        {
            if (!_precoService.AtualizarPreco(id, preco))
                return NotFound();

            return Ok();
        }

        // DELETE api/preco/{id}
        public IHttpActionResult Delete(int id)
        {
            if (!_precoService.DeletarPreco(id))
                return NotFound();

            return Ok();
        }
    }

}
