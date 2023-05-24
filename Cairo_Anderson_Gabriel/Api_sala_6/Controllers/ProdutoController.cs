using Api_sala_6.Business;
using Api_sala_6.Business.DTO;
using Microsoft.AspNetCore.Mvc;
using Api_sala_6.Database.Repositories;

namespace Api_sala_6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository _produtoRepository;

        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public List<Produto> Get()
        {
            return _produtoRepository.Todos();
        }

        [HttpGet("{id:int}")]
        public Produto ObterProduto(int id)
        {
            throw new NotImplementedException();
            //return _produtoRepository.ObterProduto(id);
        }


        [HttpPost]
        public ProdutoDto CadastraProduto(ProdutoDto produto)
        {
            return _produtoRepository.Salvar(produto);
        }


        [HttpPut("{id:int}")]
        public Produto AtualizaProduto(int id, Produto produto)
        {
            throw new NotImplementedException();

            //return _produtoRepository.AtualizarProduto(id, produto);
        }

        [HttpDelete("{id:int}")]
        public Produto ExcluirProduto(int id)
        {
            throw new NotImplementedException();

            //return _produtoRepository.ExcluirProduto(id);
        }
    }
}