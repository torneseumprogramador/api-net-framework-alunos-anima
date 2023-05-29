using API_Loja_Reserva.Models;
using API_Loja_Reserva.Requests;
using API_Loja_Reserva.Services;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;


namespace API_Loja_Reserva.Controllers
{
    public class PrecoController : ApiController
    {


        // GET: Produto
        public IEnumerable<PrecoModel> Get()
        {
            return PrecoModel.Todos();

        }

        // GET: Produto/Details/5
        public IHttpActionResult Get(int id)
        {

            PrecoModel preco = PrecoModel.Buscar(id);
            if (preco == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            return Ok(preco);

        }

        // POST: Produto/Create

        public void Post([FromBody] PrecoPostRequest preco)
        {

            PrecoService.AdicionarPreco(preco);


        }

        // PUT: Produto/Create
        public void Put(int id, [FromBody] PrecoModel preco)
        {

            preco.Atualizar(id);

        }

        public void Delete(int id)
        {
            PrecoModel.Remover(id);
        }
    }
}
