using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace ApiCadastroRoupas.Connection
{
    public abstract class BaseConnection
    {
        protected abstract IDbConnection GetConnection();

        public async Task<IEnumerable<T>> BuscarLista<T>(string sql)
        {
            using IDbConnection connection = GetConnection();
            IEnumerable<T> result;

            return await connection.QueryAsync<T>(sql);
        }
    }

    public class PgsqlBaseRepository : BaseConnection
    {
        protected readonly ILogger _logger;
        protected PgsqlBaseRepository(ILogger logger)
        {
            _logger = logger;
        }
        private static readonly string ConnectionString = 
            "Server=localhost;Port=5432;Database=gama_net;User Id = postgres; Password=123456;";

        protected override IDbConnection GetConnection()
        {
            IDbConnection dbConnection;

            dbConnection = new NpgsqlConnection(ConnectionString);
            dbConnection.Open();

            return dbConnection;
        }

    }
}
