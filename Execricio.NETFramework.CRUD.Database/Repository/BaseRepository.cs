using Execricio.NETFramework.CRUD.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Execricio.NETFramework.CRUD.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private string _connectionString = "Data Source=ReservaDatabase.db;Version=3;";
        private SQLiteConnection _sqliteConnection;

        public SQLiteConnection GetConnection()
        {
            _sqliteConnection = new SQLiteConnection(_connectionString);
            _sqliteConnection.Open();
            return _sqliteConnection;
        }

        public bool GetStatusConnection()
        {
            try
            {
                using (GetConnection())
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Salvar(T entity)
        {
            using (var connection = GetConnection())
            {
                string tableName = NomeTabela();
                string columnNames = NomeColunas(entity);
                string parameterNames = NomeParametros(entity);

                string query = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";

                using (var command = new SQLiteCommand(query, connection))
                {
                    AdicionarParametros(command, entity);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public IEnumerable<T> Recuperar()
        {
            using (var connection = GetConnection())
            {
                string tableName = NomeTabela();
                string query = $"SELECT * FROM {tableName}";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return MapearObjeto(reader);
                        }
                    }
                }
            }
        }

        public T Recuperar(int id)
        {
            using (var connection = GetConnection())
            {
                string tableName = NomeTabela();
                string query = $"SELECT * FROM {tableName} WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearObjeto(reader);
                        }
                    }
                }
            }

            return null;
        }

        public bool Atualizar(T entity)
        {
            using (var connection = GetConnection())
            {
                string tableName = NomeTabela();
                string columnNames = NomeColunas(entity, excluirId: true);
                string query = $"UPDATE {tableName} SET {columnNames} WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    AdicionarParametros(command, entity);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Deletar(int id)
        {
            using (var connection = GetConnection())
            {
                string tableName = NomeTabela();
                string query = $"DELETE FROM {tableName} WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        private string NomeTabela()
        {
            return typeof(T).ToString().Replace("Model", string.Empty);
        }

        private string NomeColunas(T entity, bool excluirId = false)
        {
            var properties = typeof(T).GetProperties();
            if (excluirId)
            {
                properties = properties.Where(p => p.Name != "Id").ToArray();
            }

            return string.Join(", ", properties.Select(p => p.Name));
        }

        private string NomeParametros(T entity)
        {
            var properties = typeof(T).GetProperties();
            return string.Join(", ", properties.Select(p => $"@{p.Name}"));
        }

        private void AdicionarParametros(SQLiteCommand command, T entity)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(entity));
            }
        }

        private T MapearObjeto(SQLiteDataReader reader)
        {
            var entity = Activator.CreateInstance<T>();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (reader[property.Name] != DBNull.Value)
                {
                    property.SetValue(entity, reader[property.Name]);
                }
            }

            return entity;
        }

        public void Dispose()
        {
            _sqliteConnection?.Dispose();
        }
    }
}
