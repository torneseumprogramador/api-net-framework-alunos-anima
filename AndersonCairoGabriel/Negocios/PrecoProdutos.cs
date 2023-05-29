using Entidades;
using BaseDados.Repositories;
using System.Collections.Generic;

namespace Negocios
{
    public class PrecoProdutos
    {
        private readonly PrecoProdutoRepository _precoProdutoRepository;

        public PrecoProdutos()
        {
            _precoProdutoRepository = new PrecoProdutoRepository();
        }

        public List<PrecoProduto> ListarPrecoProduto()
        {
            return _precoProdutoRepository.Listar();
        }

        public PrecoProduto ObterPrecoProduto(int id)
        {
            return _precoProdutoRepository.ObterPrecoProduto(id);
        }

        public PrecoProduto CadastrarPrecoProduto(PrecoProduto precopProduto)
        {
            return _precoProdutoRepository.Salvar(precopProduto);
        }

        public PrecoProduto AtualizarPrecoProduto(int id, PrecoProduto precopProduto)
        {
            return _precoProdutoRepository.Atualizar(id, precopProduto);
        }

        public void ExcluirPrecoProduto(int id)
        {
            _precoProdutoRepository.ExcluirPrecoProduto(id);
        }
    }
}
