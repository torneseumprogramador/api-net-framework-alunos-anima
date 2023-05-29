using Hugo.Damasceno.Data;
using Hugo.Damasceno.Services.Dto;

namespace Hugo.Damasceno.Services.Services
{
    public class ProdutoService
    {
        public static ProdutoDTO CreateProduto(string nome, string descricao)
        {
            ProdutoDTO produto = new()
            {
                ProdutoId = GenerateId(),
                Nome = nome,
                Descricao = descricao
            };

            Database<ProdutoDTO> database = new();

            database.Save(produto);

            return produto;
        }

        private static string GenerateId()
        {
            return DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
        }
    }
}
