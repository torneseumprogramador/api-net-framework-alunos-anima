using Dapper;
using Database;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiProdutos.Models.Interface;

namespace WebApiProdutos.Models
{
    public class ProdutoModel : IProdutoModel
    {
        ProdutoService produtoService = new ProdutoService();

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public IEnumerable<ProdutoModel> BuscarListaProdutos()
        {
            return produtoService.BuscarListaProdutos<ProdutoModel>();
        }

        public ProdutoModel BuscarProduto(int produtoId)
        {
            return produtoService.BuscaProduto<ProdutoModel, int>(produtoId);
        }

        public void SalvarProduto(ProdutoModel produto)
        {
            produtoService.SalvarProduto<string, ProdutoModel>(produto);
        }
    }
}