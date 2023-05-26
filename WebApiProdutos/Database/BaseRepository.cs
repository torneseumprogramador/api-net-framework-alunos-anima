using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class BaseRepository
    {
        private static readonly string ConnectionString =
           "Server=localhost;Port=5432;Database=Aula-api;User Id = postgres; Password=postgres;";

        protected IDbConnection GetConnection()
        {
            IDbConnection dbConnection = new NpgsqlConnection(ConnectionString);
            dbConnection.Open();

            return dbConnection;
        }

        protected IEnumerable<T> BuscarLista<T>(string sql)
        {
            IDbConnection connection = GetConnection();

            IEnumerable<T> result = connection.Query<T>(sql);

            return result;
        }

        protected T BuscarValor<T, R>(string sql, R argument)
        {
            IDbConnection connection = GetConnection();

            return  connection.QueryFirstOrDefault<T>(sql, argument);
        }

        public void SalvarValor<T, R>(string sql, R argument)
        {
            IDbConnection connection = GetConnection();
            
            connection.Execute(sql, argument);
        }

    }
}
