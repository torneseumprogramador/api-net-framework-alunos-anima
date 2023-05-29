using Execricio.NETFramework.CRUD.Business.Requests;
using Execricio.NETFramework.CRUD.Business.Responses;
using Execricio.NETFramework.CRUD.Business.Services.Interfaces;
using Execricio.NETFramework.CRUD.Business.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace Execricio.NETFramework.CRUD.API.Controllers
{
    [Route("precos")]
    public class PrecoController : ApiController
    {
        private readonly IPrecoService _precoService;

        public PrecoController()
        {
            _precoService = PrecoService.Instance;
        }

        [HttpGet]
        public IEnumerable<PrecoResponse> RecuperarPrecos()
        {
            IEnumerable<PrecoResponse> precos = _precoService.RecuperarPrecos();
            return precos;
        }

        [HttpGet]
        [Route("precos/{id}")]
        public IHttpActionResult RecuperarPreco(int id)
        {
            PrecoResponse preco = _precoService.RecuperarPreco(id);
            if (preco == null)
                return NotFound();

            return Ok(preco);
        }

        [HttpPost]
        public IHttpActionResult SalvarPreco([FromBody] PrecoRequest preco)
        {
            return Ok(_precoService.SalvarPreco(preco));
        }

        [HttpPost]
        [Route("precos/{id}")]
        public IHttpActionResult AtualizarPreco(int id, [FromBody] PrecoRequest preco)
        {
            if (!_precoService.AtualizarPreco(id, preco))
                return NotFound();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeletarPreco(int id)
        {
            if (!_precoService.DeletarPreco(id))
                return NotFound();

            return Ok();
        }
    }

}
