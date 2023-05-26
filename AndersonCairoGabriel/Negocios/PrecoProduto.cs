using System;

namespace Negocios
{
    public class PrecoProduto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ProdutoId { get; set; }
        public double Preco { get; set; }
        public DateTime Cadastro { get; set; }
    }
}
