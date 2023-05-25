using Dapper;
using Database;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiProdutos.Models.Interface;

namespace WebApiProdutos.Models
{
    public class ProdutoModel : ProdutoService, IProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public IEnumerable<ProdutoModel> BuscarListaProdutos()
        {
            return BuscarListaProdutos<ProdutoModel>();
        }

    }
}