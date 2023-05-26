using Execricio.NETFramework.CRUD.Business.Services.Interfaces;
using Execricio.NETFramework.CRUD.Business.Services;
using System.Collections.Generic;

namespace Execricio.NETFramework.CRUD.Testes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProdutoService produtoService = ProdutoService.Instance;
            IEnumerable<Business.Responses.ProdutoResponse> testeProdutoService = produtoService.RecuperarProdutos();

            IPrecoService precoService = PrecoService.Instance;
            IEnumerable<Business.Responses.PrecoResponse> testePrecoService = precoService.RecuperarPrecos();
        }
    }
}
