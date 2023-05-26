using Service.DTO;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Domain.Controllers
{
    [RoutePrefix("api")]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController()
        {
            _produtoService = new ProdutoService();
        }

        [HttpGet]
        [Route("produtos")]
        public IHttpActionResult BuscarProdutos()
        {
            try
            {
                var produtos = _produtoService.BuscarProdutos();
                return Ok(produtos);
        }
            catch (Exception ex)
            {
                // Tratar erros e retornar uma resposta apropriada
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("produtos/{id}")]
        public IHttpActionResult BuscarProduto(int id)
        {
            try
            {
                var produto = _produtoService.BuscarProduto(id);
                return Ok(produto);
        }
            catch (Exception ex)
            {
                // Tratar erros e retornar uma resposta apropriada
                return InternalServerError(ex);
            }

        }

        [HttpPost]
        [Route("produtos")]
        public IHttpActionResult InserirProduto(ProdutoDTO produto)
        {
            try
            {
                _produtoService.InserirProduto(produto);
                return CreatedAtRoute("DefaultApi", new { id = produto.Id }, produto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("produtos/{id}")]
        public IHttpActionResult AtualizarProduto(int id, ProdutoDTO produto)
        {
            try
            {
                _produtoService.AtualizarProduto(id, produto);
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("produtos/{id}")]
        public IHttpActionResult DeletarProduto(int id)
        {
            try
            {
                _produtoService.DeletarProduto(id);
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
