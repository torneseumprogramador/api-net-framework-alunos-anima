using Repository.Interfaces;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        string connectionString = ("Data Source=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "reserva.db") + ";Version=3;").Replace("\\UI\\", "\\Database\\");

        public List<ProdutoDTO> BuscarProdutos()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                var sql = @"select
                                Id,
                                Nome,
                                Descricao,
                            from
                                produto";

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var produtos = new List<ProdutoDTO>();
                        while (reader.Read())
                        {
                            var produto = new ProdutoDTO
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                Descricao = reader["Descricao"].ToString(),
                            };
                            produtos.Add(produto);
                        }
                        return produtos;
                    }

                }
            }
        }

        public ProdutoDTO BuscarProduto(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                var sql = @"SELECT
                                Id,
                                Nome,
                                Descricao
                            FROM
                                produto
                            WHERE
                                Id = @id";

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var produto = new ProdutoDTO
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                Descricao = reader["Descricao"].ToString(),
                            };
                            return produto;
                        }
                        return null;
                    }
                }
            }
        }

        public bool InserirProduto(ProdutoDTO produto)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO produto (nome, descricao) VALUES (@nome, @descricao);";
                    command.Parameters.AddWithValue("@nome", produto.Nome);
                    command.Parameters.AddWithValue("@descricao", produto.Descricao);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AtualizarProduto(int id, ProdutoDTO produto)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE produto
                                            SET nome = @nome, descricao = @descricao
                                            WHERE id = @id;";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nome", produto.Nome);
                    command.Parameters.AddWithValue("@descricao", produto.Descricao);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool DeletarProduto(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM produto WHERE id = @id;";
                    command.Parameters.AddWithValue("@id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}

