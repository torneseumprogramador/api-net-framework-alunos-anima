using Execricio.NETFramework.CRUD.Data.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execricio.NETFramework.CRUD.Data.Repository.Interfaces.Sqlite
{
    public interface IProdutoRepository
    {
        bool SalvarProduto(ProdutoArgument produto);
        bool AtualizarProduto(ProdutoArgument produto);
        bool DeletarProduto(int id);
        ProdutoArgument RecuperarProduto(int id);
        IEnumerable<ProdutoArgument> RecuperarProdutos();
    }
}
