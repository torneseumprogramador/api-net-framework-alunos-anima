using Entidades;
using System.Data.SQLite;
using System.Collections.Generic;
using Entidades.DTOs;
using System;

namespace BaseDados.Repositories
{
    public class ProdutoRepository
    {
        public ProdutoDto ObterProduto(int id)
        {
            ProdutoDto produto = new ProdutoDto();

            string sql = "SELECT * FROM produtos prod WHERE prod.Id = @Id";

            using (var conexao = ConectaBase.Conexao())
            {
                conexao.Open();

                using (var command = new SQLiteCommand(sql, conexao))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader.StepCount < 1) return produto;

                                produto.Id = (int)reader["Id"];
                                produto.Nome = reader["Nome"].ToString();
                                produto.Descricao = reader["Descricao"].ToString();

                                return produto;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Houve um problema ao ler da base: {ex}");
                    }
                }
            }

            return produto;
        }


        public List<Produto> Listar()
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

        public ProdutoDto Atualizar(int id, ProdutoDto produto)
        {
            string sql = @"
                UPDATE produtos
                SET 
                    Nome = @Nome, 
                    Descricao = @Descricao, 
                WHERE 
                    Id = @Id
            ";

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

            return produto;
        }

        public void ExcluirProduto(int id)
        {
            string sql = "DELETE FROM produtos WHERE Id = @Id";

            using (var conexao = ConectaBase.Conexao())
            {
                conexao.Open();

                using (var command = new SQLiteCommand(sql, conexao))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }

                // Apaga os preços vínculados ao produto.
                sql = "DELETE FROM precoproduto WHERE idproduto = @Id";

                using (var command = new SQLiteCommand(sql, conexao))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
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
