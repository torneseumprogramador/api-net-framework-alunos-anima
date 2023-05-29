using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Npgsql;

namespace API_Loja_Reserva.Models
{
    public class PrecoModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public virtual ProdutoModel Produto { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
        
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;


        public void Adicionar()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();


                string sql = "INSERT INTO loja_preco_produtos (produto_id, preco, data) VALUES (@idProduto, @preco, @data)";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idProduto", Produto.Id);
                    command.Parameters.AddWithValue("@preco", this.Preco);
                    command.Parameters.AddWithValue("@data", this.Data);


                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine("Número de linhas afetadas: " + rowsAffected);

                }


            }


        }

        public static List<PrecoModel> Todos()
        {
            List<PrecoModel> precos = new List<PrecoModel>();

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "SELECT id, produto_id, preco, data FROM loja_preco_produtos";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PrecoModel preco = new PrecoModel();
                            preco.Id = reader.GetInt32(0);
                            preco.Produto = new ProdutoModel{ Id = reader.GetInt32(1) };
                            preco.Preco = reader.GetDecimal(2);
                            preco.Data = reader.GetDateTime(3);

                            precos.Add(preco);
                        }
                    }
                }
            }

            return precos;

        }
        public static PrecoModel Buscar(int Id)
        {
            PrecoModel preco = null;

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "SELECT id, produto_id, preco, data FROM loja_preco_produtos WHERE id = @id ";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            preco = new PrecoModel();
                            preco.Id = reader.GetInt32(0);
                            preco.Produto = new ProdutoModel { Id = reader.GetInt32(1) };
                            preco.Preco = reader.GetDecimal(2);
                            preco.Data = reader.GetDateTime(3);

                        }
                    }
                }
            }

            return preco;




        }

        public void Atualizar(int produtoId)
        {


            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "UPDATE loja_preco_produtos SET  preco=@preco, data=@data WHERE produto_id=@id";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@preco", this.Preco);
                    command.Parameters.AddWithValue("@id", produtoId);
                    command.Parameters.AddWithValue("@data", this.Data);

                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine("Número de linhas afetadas: " + rowsAffected);
                }
            }
        }

        public static void Remover(int produtoId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "DELETE FROM loja_preco_produtos WHERE produto_id=@id";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {

                    command.Parameters.AddWithValue("@id", produtoId);

                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine("Número de linhas afetadas: " + rowsAffected);
                }
            }
        }


    }
}