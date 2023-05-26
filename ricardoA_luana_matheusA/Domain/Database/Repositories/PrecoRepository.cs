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
    public class PrecoRepository : IPrecoRepository
    {
        string connectionString = ("Data Source=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "reserva.db") + ";Version=3;").Replace("\\UI\\", "\\Database\\");

        public List<PrecoDTO> BuscarPrecos()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                var sql = @"select
                                Id,
                                produto_id,
                                preco,
                                data,
                            from
                                Preco";

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var Precos = new List<PrecoDTO>();
                        while (reader.Read())
                        {
                            var Preco = new PrecoDTO
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ProdutoId = reader["produto_id"].ToString(),
                                Preco = Convert.ToDouble(reader["Preco"].ToString()),
                                Data = Convert.ToDateTime(reader["data"].ToString())
                            };
                            Precos.Add(Preco);
                        }
                        return Precos;
                    }

                }
            }
        }

        public PrecoDTO BuscarPreco(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                var sql = @"select
                                Id,
                                produto_id,
                                preco,
                                data,
                            from
                                Preco
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
                            var Preco = new PrecoDTO
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ProdutoId = reader["produto_id"].ToString(),
                                Preco = Convert.ToDouble(reader["Preco"].ToString()),
                                Data = Convert.ToDateTime(reader["data"].ToString())
                            };
                            return Preco;
                        }
                        return null;
                    }
                }
            }
        }

        public bool InserirPreco(PrecoDTO Preco)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Preco (produto_id, preco, data) VALUES (@produtoId, @preco, @data);";
                    command.Parameters.AddWithValue("@produtoId", Preco.ProdutoId);
                    command.Parameters.AddWithValue("@preco", Preco.Preco);
                    command.Parameters.AddWithValue("@data", Preco.Data);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AtualizarPreco(int id, PrecoDTO Preco)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE Preco
                                            SET produto_id = @produtoId, preco = @preco, data = @data
                                            WHERE id = @id;";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@produtoId", Preco.ProdutoId);
                    command.Parameters.AddWithValue("@preco", Preco.Preco);
                    command.Parameters.AddWithValue("@data", Preco.Data);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool DeletarPreco(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Preco WHERE id = @id;";
                    command.Parameters.AddWithValue("@id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}

