using API_Loja_Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API_Loja_Reserva.Controllers
{
    public class ProdutoController : ApiController
    {


        // GET: Produto
        public IEnumerable<ProdutoModel> Get()
        {
            return ProdutoModel.Todos();

        }

        // GET: Produto/Details/5
        public IHttpActionResult Get(int id)
        {

            ProdutoModel produto = ProdutoModel.Buscar(id);
            if (produto == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            return Ok(produto);

        }

        // POST: Produto/Create

        public void Post([FromBody] ProdutoModel produto)
        {
            
             produto.Adicionar();
            
        }

        // PUT: Produto/Create
        public void Put(int id, [FromBody] ProdutoModel produto)
        {

            produto.Atualizar(id);

        }

        public void Delete(int id)
        {
            ProdutoModel.Remover(id);
        }
    }
}
