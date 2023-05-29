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
    public class PrecoService
    {
        PrecoRepository precoRepository = new PrecoRepository();

        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public double PrecoProduto { get; set; }
        public DateTime Data { get; set; }

        public IEnumerable<PrecoService> BuscarListaPrecos()
        {
            return precoRepository.BuscarListaPrecos<PrecoService>();
        }

        public PrecoService BuscarPreco(int precoId)
        {
            return precoRepository.BuscarPreco<PrecoService, int>(precoId);
        }

        public HttpResponseMessage SalvarPreco(PrecoService preco)
        {
            return precoRepository.SalvarPreco<string, PrecoService>(preco);
        }

        public HttpResponseMessage EditarPreco(int id, PrecoService preco)
        {
            PrecoService prod = new PrecoService()
            {
                Id = id,
                ProdutoId = preco.ProdutoId,
                PrecoProduto = preco.PrecoProduto,
                Data = preco.Data
            };

            return precoRepository.EditarPreco<string, PrecoService>(prod);
        }

        public HttpResponseMessage DeletarPreco(int id)
        {
            return precoRepository.DeletarPreco(id);
        }
    }
}