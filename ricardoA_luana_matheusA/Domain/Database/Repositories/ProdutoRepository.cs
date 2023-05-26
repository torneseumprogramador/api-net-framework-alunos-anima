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
                                pro.id Id,
                                pro.nome Nome,
                                pro.descricao Descricao,
                                pre.preco Valor,
                                pre.data Data
                            from
                                produto pro
                            join preco pre on
                                pre.produto_id = pro.id
                            group by pro.id , pro.nome, pro.descricao
                            having max(pre.data)";

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
                                Valor = Convert.ToDouble(reader["Valor"]),
                                Data = Convert.ToDateTime(reader["Data"].ToString())
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
                                pro.id AS Id,
                                pro.nome AS Nome,
                                pro.descricao AS Descricao,
                                pre.preco AS Valor,
                                pre.data AS Data
                            FROM
                                produto pro
                            JOIN
                                preco pre ON pre.produto_id = pro.id
                            WHERE
                                pro.id = @id";

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
                                Valor = Convert.ToDouble(reader["Valor"]),
                                Data = Convert.ToDateTime(reader["Data"].ToString())
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
                    command.CommandText = @"INSERT INTO produto (nome, descricao) VALUES (@nome, @descricao);
                                            INSERT INTO preco (produto_id, preco, data) VALUES (last_insert_rowid(), @valor, datetime('now', 'localtime'));";
                    command.Parameters.AddWithValue("@nome", produto.Nome);
                    command.Parameters.AddWithValue("@descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@valor", produto.Valor);

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
                                            WHERE id = @id;
                                            UPDATE preco
                                            SET preco = @valor, data = datetime('now', 'localtime')
                                            WHERE produto_id = @id;";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nome", produto.Nome);
                    command.Parameters.AddWithValue("@descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@valor", produto.Valor);

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
                    command.CommandText = @"DELETE FROM produto WHERE id = @id;
                                        DELETE FROM preco WHERE produto_id = @id;";
                    command.Parameters.AddWithValue("@id", id);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}

