using Entidades;
using BaseDados.Repositories;
using System.Collections.Generic;
using Entidades.DTOs;
using System.Linq;

namespace Negocios
{
    public class Produtos
    {
        private readonly ProdutoRepository _produtoRepository;
        private readonly PrecoProdutoRepository _precoProdutoRepository;

        public Produtos()
        {
            _produtoRepository = new ProdutoRepository();
            _precoProdutoRepository = new PrecoProdutoRepository();
        }

        public List<Produto> ListarProdutos()
        {
            return _produtoRepository.Listar();
        }

        public ProdutoDto ObterProduto(int id)
        {
            return _produtoRepository.ObterProduto(id);
        }

        public Produto ObterProdutoComPreco(int id)
        {
            Produto produtoCast = new Produto();

            var produto = ObterProduto(id);
            var produtoPrecos = _precoProdutoRepository.ObterPrecoPorProduto(id);

            if(!produto.Id.Equals(0))
            {
                produtoCast.Id = produto.Id;
                produtoCast.Nome = produto.Nome;
                produtoCast.Descricao = produto.Descricao;

                if (produtoPrecos.Any()) produtoCast.Preco = produtoPrecos;
            }

            return produtoCast;
        }

        public List<Produto> ListarProdutosComPreco()
        {
            List<Produto> produtos = new List<Produto>();

            foreach(var produto in ListarProdutos())
            {
                var produtoPrecos = _precoProdutoRepository.ObterPrecoPorProduto(produto.Id);

                Produto produtoCast = new Produto();
                produtoCast.Id = produto.Id;
                produtoCast.Nome = produto.Nome;
                produtoCast.Descricao = produto.Descricao;
                if (produtoPrecos.Any()) produtoCast.Preco = produtoPrecos;

                produtos.Add(produtoCast);
            }

            return produtos;
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
