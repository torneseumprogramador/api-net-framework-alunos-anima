using Data.Model;
using Data.Repository;
using System.Collections.Generic;

namespace Negocio.Service
{
    public class PrecoService
    {
        PrecoRepository precoRepository = new PrecoRepository();
        public Preco BuscaPreco(int id)
        {
            return precoRepository.BuscaPreco(id);
        }
        public Preco BuscaPrecoPorIdProduto(int id)
        {
            return precoRepository.BuscaPrecoPorIdProduto(id);
        }
        public void CriarPreco(Preco preco)
        {
            precoRepository.CriarPreco(preco);
        }

        public List<Preco> BuscaPrecos()
        {
            return precoRepository.BuscaPrecos();
        }
        public void DeletaPreco(int id)
        {
            precoRepository.DeletaPreco(id);
        }
    }
}
