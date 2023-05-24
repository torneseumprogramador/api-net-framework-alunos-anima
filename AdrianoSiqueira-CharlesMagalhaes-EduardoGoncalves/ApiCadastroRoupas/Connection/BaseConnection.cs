using Dapper;
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

    public class PgsqlConnection : BaseConnection
    {
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
