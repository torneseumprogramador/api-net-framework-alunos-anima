using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using joao_felipe_juliano_framework_api.Models;
using MySqlX.XDevAPI;
using Npgsql;

namespace joao_felipe_juliano_framework_api.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        //private readonly MeuContexto _context;

        //public ProdutoController()
        //{
        //    _context = new MeuContexto();
        //}
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        [System.Web.Mvc.HttpGet]
        public IHttpActionResult Get()
        {
            // Exemplo de consulta ao banco de dados
            //var produtos = _context.Produtos.ToList();
            List<Produto> produtos = new List<Produto>();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Nome, Descricao FROM produtos";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
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
                connection.Close();
            }

            return Ok(produtos);
        }

        [System.Web.Mvc.HttpGet]
        public IHttpActionResult Get(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Nome, Descricao FROM produtos WHERE Id = @id";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Produto produto = new Produto
                    {
                        Id = (int)reader["Id"],
                        Nome = reader["Nome"].ToString(),
                        Descricao = reader["Descricao"].ToString()
                    };

                    connection.Close();
                    return Ok(produto);
                }

                connection.Close();
                return NotFound();
            }
        }

        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Post(Produto produto)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO produtos (Nome, Descricao) VALUES (@nome, @descricao)";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@nome", produto.Nome);
                command.Parameters.AddWithValue("@descricao", produto.Descricao);
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Falha ao inserir o produto.");
                }
            }
        }

        [System.Web.Mvc.HttpPut]
        public IHttpActionResult Put(int id, Produto produto)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE produtos SET Nome = @nome, Descricao = @descricao WHERE Id = @id";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@nome", produto.Nome);
                command.Parameters.AddWithValue("@descricao", produto.Descricao);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [System.Web.Mvc.HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM produtos WHERE Id = @id";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
