using Hugo.Damasceno.Data;
using Hugo.Damasceno.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo.Damasceno.Services.Services
{
    public class EstoqueService
    {
        public static EstoqueDTO CreateEstoque(string produtoId, string preco)
        {
            EstoqueDTO estoque = new()
            {
                Id = GenerateId(),
                ProdutoId = produtoId,
                Preco = preco,
                UltimaAtualizacao = DateTime.Now
            };

            Database<EstoqueDTO> database = new();

            database.Save(estoque);

            return estoque;
        }

        private static string GenerateId()
        {
            return DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
        }
    }
}
