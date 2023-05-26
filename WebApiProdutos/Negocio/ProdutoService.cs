using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProdutoService
    {
        ProdutoRepository produtoRepository = new ProdutoRepository();

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public IEnumerable<ProdutoService> BuscarListaProdutos()
        {
            return produtoRepository.BuscarListaProdutos<ProdutoService>();
        }

        public ProdutoService BuscarProduto(int produtoId)
        {
            return produtoRepository.BuscarProduto<ProdutoService, int>(produtoId);
        }

        public HttpResponseMessage SalvarProduto(ProdutoService produto)
        {
            return produtoRepository.SalvarProduto<string, ProdutoService>(produto);
        }

        public HttpResponseMessage EditarProduto(int id, ProdutoService produto)
        {
            ProdutoService prod = new ProdutoService()
            {
                Id = id,
                Nome = produto.Nome,
                Descricao = produto.Descricao
            };

            return produtoRepository.EditarProduto<string, ProdutoService>(prod);
        }

        public HttpResponseMessage DeletarProduto(int id)
        {
            return produtoRepository.DeletarProduto(id);
        }

        //public IEnumerable<T> BuscarListaProdutos<T>()
        //{
        //    return produtoRepository.BuscarListaProdutos<T>();
        //}

        //public T BuscaProduto<T, R>(R id)
        //{
        //    return produtoRepository.BuscarProduto<T, R>(id);
        //}

        //public void SalvarProduto<T, R>(R produto)
        //{
        //    produtoRepository.SalvarProduto<T, R>(produto);
        //}

        //public void EditarProduto<T, R>(R produto)
        //{
        //    produtoRepository.EditarProduto<T, R>(produto);
        //}

        //public void DeletarProduto(int id)
        //{
        //    produtoRepository.DeletarProduto(id);
        //}
    }
}