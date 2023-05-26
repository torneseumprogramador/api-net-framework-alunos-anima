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
        public List<ProdutoDTO> BuscarProdutos()
        {
            return _produtoService.BuscarProdutos();
        }

        [HttpGet]
        [Route("produtos/{id}")]
        public ProdutoDTO BuscarProduto(int id)
        {
            return _produtoService.BuscarProduto(id);
        }

        [HttpPost]
        [Route("produtos")]
        public string InserirProduto(ProdutoDTO produto)
        {
            var result = _produtoService.InserirProduto(produto);
            
            if(result == true)
            {
                return "Produto cadastrado com sucesso!";
            }
            else
            {
                return "Erro ao cadastrar produto!";
            }
        }

        [HttpPut]
        [Route("produtos/{id}")]
        public string AtualizarProduto(int id, ProdutoDTO produto)
        {
            var result = _produtoService.AtualizarProduto(id, produto);

            if (result == true)
            {
                return "Produto atualizado com sucesso!";
            }
            else
            {
                return "Erro ao atualizar produto!";
            }
        }

        [HttpDelete]
        [Route("produtos/{id}")]
        public string DeletarProduto(int id)
        {
            var result = _produtoService.DeletarProduto(id);

            if (result == true)
            {
                return "Produto deletado com sucesso!";
            }
            else
            {
                return "Erro ao deletar produto!";
            }
        }
    }
}
