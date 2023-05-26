using Entidades;
using BaseDados.Repositories;
using System.Collections.Generic;
using Entidades.DTOs;

namespace Negocios
{
    public class Produtos
    {
        private readonly ProdutoRepository _produtoRepository;

        public Produtos()
        {
            _produtoRepository = new ProdutoRepository();
        }

        public List<Produto> ListarProdutos()
        {
            return _produtoRepository.Listar();
        }

        public ProdutoDto ObterProduto(int id)
        {
            return _produtoRepository.ObterProduto(id);
        }

        public ProdutoDto CadastrarProdutos(ProdutoDto produto)
        {
            return _produtoRepository.Salvar(produto);
        }

        public ProdutoDto AtualizarProduto(int id, ProdutoDto produto) 
        {
            return _produtoRepository.Atualizar(id, produto);
        }

        public void ExcluirProduto(int id)
        {
            _produtoRepository.ExcluirProduto(id);
        }
    }
}
