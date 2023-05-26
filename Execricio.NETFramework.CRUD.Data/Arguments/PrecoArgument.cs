
namespace Execricio.NETFramework.CRUD.Data.Arguments
{
    public class PrecoArgument
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public decimal Preco { get; set; }
        public string Data { get; set; }
        public bool Ativo { get; set; }
    }
}
