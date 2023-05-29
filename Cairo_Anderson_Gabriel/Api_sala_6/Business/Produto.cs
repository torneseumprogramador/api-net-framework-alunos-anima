namespace Api_sala_6.Business
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<PrecoProduto> Preco { get; set; }
    }
}
