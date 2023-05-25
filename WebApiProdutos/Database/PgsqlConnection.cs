using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class PgsqlConnection
    {
        private static readonly string ConnectionString =
           "Server=localhost;Port=5432;Database=Aula-api;User Id = postgres; Password=postgres;";

        protected IDbConnection GetConnection()
        {
            IDbConnection dbConnection = new NpgsqlConnection(ConnectionString);
            dbConnection.Open();

            return dbConnection;
        }

        public IEnumerable<T> BuscarLista<T>(string sql)
        {
            IDbConnection connection = GetConnection();
            
            IEnumerable<T> result = connection.Query<T>(sql);

            return result;
        }

        public IEnumerable<T> BuscarListaProdutos<T>()
        {
            string sql = @"select * from produto";

            return BuscarLista<T>(sql);
        }
    }
}
