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
    [System.Web.Mvc.RoutePrefix("api/preco")]
    public class PrecoController : ApiController
    {

        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Post(Preco preco)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO precos (id_produto, valor) VALUES (@id_produto, @valor)";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_produto", preco.IdProduto);
                command.Parameters.AddWithValue("@valor", preco.Valor);
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
    }
}