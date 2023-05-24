using Api_sala_6.Business;
using Api_sala_6.Business.DTO;
using Api_sala_6.Database.Interface;
using System.Data.SQLite;

namespace Api_sala_6.Database.Repositories
{
    public class ProdutoRepository : IRepositoryBase
    {

        public  List<Produto> Todos()
        {
            List<Produto> produtos = new List<Produto>();

            using (SQLiteConnection conexao = ConectaBase.Conexao())
            {
                string query = "SELECT Id, Nome, Descricao FROM produtos";

                conexao.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, conexao))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto
                            {
                                Id = (int)reader["Id"],
                                Nome = reader["Nome"].ToString(),
                                Descricao = reader["Descricao"].ToString()
                            };

                            produtos.Add(produto);
                        }
                    }
                }
            }
            return produtos;
        }

        
        public ProdutoDto Salvar(ProdutoDto produto)
        {
            using (SQLiteConnection connection = ConectaBase.Conexao())
            {
                string sql = "INSERT INTO produtos (Id, Nome, Descricao) VALUES (@Id, @Nome, @Descricao)";

                produto.Id = ObterId();

                using (var conexao = ConectaBase.Conexao())
                {
                    conexao.Open();

                    using (var command = new SQLiteCommand(sql, conexao))
                    {
                        command.Parameters.AddWithValue("@Id", produto.Id);
                        command.Parameters.AddWithValue("@Nome", produto.Nome);
                        command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                        command.ExecuteNonQuery();
                    }
                }
            }
            return produto;
        }
        
        
        public static int ObterId()
        {
            string sql = "SELECT MAX(id) FROM produtos";
            using (var conexao = ConectaBase.Conexao())
            {
                conexao.Open();
                using (var command = new SQLiteCommand(sql, conexao))
                {
                    try
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader[0].GetType() != typeof(DBNull))
                                {
                                    return Convert.ToInt32(reader[0]) + 1;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Houve um problema ao ler da base: {ex}");
                    }
                }
            }
            return 1;
        }
    }
}
