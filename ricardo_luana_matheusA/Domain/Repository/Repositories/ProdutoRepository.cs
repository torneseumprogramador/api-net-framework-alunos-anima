using Service.DTO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ProdutoRepository 
    {
        string connectionString = "Data Source=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "reserva.db") + ";Version=3;";

        public List<ProdutoDTO> BuscarUsuarios()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sql = @"select pro.id Id ,pro.nome Nome, pro.descricao Descricao, pre.preco Valor, max(pre.data) Data
                          from produto pro join preco pre on pre.produto_id = pro.id";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var produtos = new List<ProdutoDTO>();
                        while (reader.Read())
                        {
                            ProdutoDTO produto = new ProdutoDTO
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                Descricao = reader["Descricao"].ToString(),
                                Valor = Convert.ToDouble(reader["Valor"]),
                                Data = Convert.ToDateTime(reader["Data"].ToString())
                            };
                            produtos.Add(produto);
                            // Fazer o que deseja com os dados lidos
                        }
                        return produtos;
                    }

                }
            }
        }

        //public UsuarioResponse ValidarUsuario(LoginModel login)
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        string sql = "SELECT * FROM Usuario WHERE Login = @login AND Senha = @senha";
        //        connection.Open();

        //        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
        //        {
        //            command.Parameters.AddWithValue("@login", login.Login);
        //            command.Parameters.AddWithValue("@senha", login.Senha);

        //            using (SQLiteDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    UsuarioModel cliente = new UsuarioModel
        //                    {
        //                        Id = Convert.ToInt32(reader["Id"]),
        //                        Nome = reader["Nome"].ToString(),
        //                        Login = reader["Login"].ToString(),
        //                        Email = reader["Email"].ToString(),
        //                        Senha = reader["Senha"].ToString()
        //                    };

        //                    return new UsuarioResponse()
        //                    {
        //                        Mensagem = "Login validado com sucesso!",
        //                        Usuario = cliente
        //                    };
        //                }
        //                else
        //                {
        //                    return new UsuarioResponse()
        //                    {
        //                        Mensagem = "Erro ao validar o usuário!",
        //                        Usuario = new UsuarioModel(),
        //                        Sucesso = false
        //                    };
        //                }
        //            }
        //        }
        //    }
        //}


        //public void AtualizarUsuario()
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SQLiteCommand command = new SQLiteCommand(connection))
        //        {
        //            command.CommandText = "update Usuario set Nome = @nome, Login = @login, Email = @email, Senha = @senha";
        //            command.Parameters.AddWithValue("@nome", Nome);
        //            command.Parameters.AddWithValue("@login", Login);
        //            command.Parameters.AddWithValue("@email", Email);
        //            command.Parameters.AddWithValue("@senha", Senha);

        //        }
        //    }
        //}

        //public bool InserirUsuario(CadastroModel usuario)
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SQLiteCommand command = new SQLiteCommand(connection))
        //        {
        //            command.CommandText = "insert into Usuario (Nome, Login, Email, Senha) VALUES (@nome, @login, @email, @senha)";
        //            command.Parameters.AddWithValue("@nome", usuario.Nome);
        //            command.Parameters.AddWithValue("@login", usuario.Login);
        //            command.Parameters.AddWithValue("@email", usuario.Email);
        //            command.Parameters.AddWithValue("@senha", usuario.Senha);

        //            var linhasAtualizadas = command.ExecuteNonQuery();

        //            if (linhasAtualizadas > 0)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //}
    }
}
