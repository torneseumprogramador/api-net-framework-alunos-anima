using Repository.Interfaces;
using Repository.Repository;
using Service.DTO;
using Service.Services.Interfaces;
using System.Collections.Generic;

namespace Service.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly I

        public ProdutoService()
        {
            _produtoRepository = new ProdutoRepository();
        }

        public List<ProdutoDTO> BuscarProdutos()
        {
            var produtos = _produtoRepository.BuscarProdutos();
            return produtos;
        }

        public ProdutoDTO BuscarProduto(int id)
        {
            var produto = _produtoRepository.BuscarProduto(id);
            return produto;
        }

        public bool InserirProduto(ProdutoDTO produto)
        {
            bool insercaoSucesso = _produtoRepository.InserirProduto(produto);
            return insercaoSucesso;
        }

        public bool AtualizarProduto(int id, ProdutoDTO produto)
        {
            bool atualizacaoSucesso = _produtoRepository.AtualizarProduto(id, produto);
            return atualizacaoSucesso;
        }

        public bool DeletarProduto(int id)
        {
            bool exclusaoSucesso = _produtoRepository.DeletarProduto(id);
            return exclusaoSucesso;
        }
    }
}
