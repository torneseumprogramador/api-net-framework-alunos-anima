using System;
using Entidades;
using Entidades.DTOs;
using System.Data.SQLite;
using System.Collections.Generic;

namespace BaseDados.Repositories
{
    public class PrecoProdutoRepository
    {
        public PrecoProduto ObterPrecoProduto(int id)
        {
            PrecoProduto precoProduto = new PrecoProduto();

            string sql = "SELECT * FROM precoproduto prod WHERE prod.Id = @Id";

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
                                if (reader.StepCount < 1) return precoProduto;

                                precoProduto.Id = (int)reader["Id"];
                                precoProduto.Titulo = reader["Titulo"].ToString();

                                precoProduto.ProdutoId = (int)reader["IdProduto"];
                                precoProduto.Preco = (double)reader["Preco"];
                                precoProduto.Cadastro = DateTime.Parse(reader["Cadastro"].ToString());
                                return precoProduto;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Houve um problema ao ler da base: {ex}");
                    }
                }
            }

            return precoProduto;
        }


        public List<PrecoProduto> Listar()
        {
            List<PrecoProduto> precoProdutos = new List<PrecoProduto>();

            using (SQLiteConnection conexao = ConectaBase.Conexao())
            {
                string query = "SELECT Id, Titulo, Preco, IdProduto, Cadastro FROM precoproduto";
                conexao.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, conexao))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PrecoProduto precoProduto = new PrecoProduto
                            {
                                Id = (int)reader["Id"],
                                Titulo = reader["Titulo"].ToString(),
                                ProdutoId = (int)reader["IdProduto"],
                                Preco = (double)reader["Preco"],
                                Cadastro = DateTime.Parse(reader["Cadastro"].ToString())
                            };

                            precoProdutos.Add(precoProduto);
                        }
                    }
                }
            }
            return precoProdutos;
        }

        public PrecoProduto Salvar(PrecoProduto precoProduto)
        {
            using (SQLiteConnection connection = ConectaBase.Conexao())
            {
                string sql = "INSERT INTO precoproduto (Id, Titulo, IdProduto, Preco, Cadastro) VALUES (@Id, @Titulo, @IdProduto, @Preco, @Cadastro)";

                precoProduto.Id = ObterId();
                precoProduto.Cadastro = DateTime.Now;

                using (var conexao = ConectaBase.Conexao())
                {
                    conexao.Open();

                    using (var command = new SQLiteCommand(sql, conexao))
                    {
                        command.Parameters.AddWithValue("@Id", precoProduto.Id);
                        command.Parameters.AddWithValue("@Titulo", precoProduto.Titulo);
                        command.Parameters.AddWithValue("@IdProduto", precoProduto.ProdutoId);
                        command.Parameters.AddWithValue("@Preco", precoProduto.Preco);
                        command.Parameters.AddWithValue("@Cadastro", precoProduto.Cadastro);
                        command.ExecuteNonQuery();
                    }
                }
            }
            return precoProduto;
        }

        public PrecoProduto Atualizar(int id, PrecoProduto precoProduto)
        {
            string sql = @"
                UPDATE precoproduto
                SET 
                    Titulo = @Titulo,
                    IdProduto = @IdProduto,
                    Preco = @Preco
                WHERE 
                    Id = @Id
            ";

            using (var conexao = ConectaBase.Conexao())
            {
                conexao.Open();
                using (var command = new SQLiteCommand(sql, conexao))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Titulo", precoProduto.Titulo);
                    command.Parameters.AddWithValue("@IdProduto", precoProduto.ProdutoId);
                    command.Parameters.AddWithValue("@Preco", precoProduto.Preco);
                    command.ExecuteNonQuery();
                }
            }

            return precoProduto;
        }

        public void ExcluirPrecoProduto(int id)
        {
            string sql = "DELETE FROM precoproduto WHERE Id = @Id";

            using (var conexao = ConectaBase.Conexao())
            {
                conexao.Open();

                using (var command = new SQLiteCommand(sql, conexao))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static int ObterId()
        {
            string sql = "SELECT MAX(id) FROM precoproduto";
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
