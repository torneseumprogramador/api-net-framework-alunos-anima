using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Npgsql;

namespace API_Loja_Reserva.Models
{
    public class ProdutoModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;


        public void Adicionar()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();


                string sql = "INSERT INTO loja_produtos (nome, descricao) VALUES (@nome, @descricao)";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nome", this.Nome);
                    command.Parameters.AddWithValue("@descricao", this.Descricao);


                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine("Número de linhas afetadas: " + rowsAffected);

                }


            }


        }

        public static List<ProdutoModel> Todos()
        {
            List<ProdutoModel> produtos = new List<ProdutoModel>();

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "SELECT id, nome, descricao FROM loja_produtos";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProdutoModel produto = new ProdutoModel();
                            produto.Id = reader.GetInt32(0);
                            produto.Nome = reader.GetString(1);
                            produto.Descricao = reader.GetString(2);





                            produtos.Add(produto);
                        }
                    }
                }
            }

            return produtos;

        }
        public static ProdutoModel Buscar(int Id)
        {
            ProdutoModel produto = null;

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "SELECT id, nome, descricao FROM loja_produtos WHERE id = @id ";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produto = new ProdutoModel();

                            produto.Id = reader.GetInt32(0);
                            produto.Nome = reader.GetString(1);
                            produto.Descricao = reader.GetString(2);


                        }
                    }
                }
            }

            return produto;




        }

        public void Atualizar(int produtoId)
        {


            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "UPDATE loja_produtos SET  nome=@nome, descricao=@descricao WHERE id=@id";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nome", Nome);
                    command.Parameters.AddWithValue("@descricao", Descricao);
                    command.Parameters.AddWithValue("@id", produtoId);

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

                string sql = "DELETE FROM loja_produtos WHERE id=@id";

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