using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        protected T BuscarValor<T>(string sql)
        {
            IDbConnection connection = GetConnection();

            return  connection.QueryFirstOrDefault<T>(sql);
        }

        public HttpResponseMessage SalvarValor<T, R>(string sql, R argument)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    connection.Execute(sql, argument);

                    // Retorna um HttpResponseMessage com o status code 200 OK
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    // Trate o erro e retorne um HttpResponseMessage com o status code apropriado
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent($"Ocorreu um erro: {ex.Message}")
                    };
                }
            }            
        }

        // O método EditarValor é identico ao salvar valor, porém para fins didáticos ele será mantido
        public HttpResponseMessage EditarValor<T, R>(string sql, R argument)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    connection.Execute(sql, argument);

                    // Retorna um HttpResponseMessage com o status code 200 OK
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    // Trate o erro e retorne um HttpResponseMessage com o status code apropriado
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent($"Ocorreu um erro: {ex.Message}")
                    };
                }
            }
        }

        public HttpResponseMessage DeletarValor(string sql)
        {
            using (IDbConnection connection = GetConnection())
            {
                try
                {
                    connection.Execute(sql);
                    // Retorna um HttpResponseMessage com o status code 200 OK
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    // Trate o erro e retorne um HttpResponseMessage com o status code apropriado
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent($"Ocorreu um erro: {ex.Message}")
                    };
                }
            }
        }
    }
}
