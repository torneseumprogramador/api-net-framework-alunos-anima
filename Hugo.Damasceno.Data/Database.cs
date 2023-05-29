using Npgsql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Reflection;

namespace Hugo.Damasceno.Data
{
    public class Database<T> where T : new()
    {
        private readonly string _connectionString;

        public Database()
        {
            // Obtendo a string de conexão do arquivo de configuração
            _connectionString = ConfigurationManager.ConnectionStrings["postgresCnn"].ConnectionString;
        }

        public void Save(T entity)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();

            PropertyInfo[] properties = typeof(T).GetProperties();
            List<NpgsqlParameter> parameters = new();

            string tableName = typeof(T).Name;
            string insertSql = $"INSERT INTO {tableName} (";
            string valuesSql = "VALUES (";

            foreach (PropertyInfo property in properties)
            {
                if (!property.CanRead || !property.CanWrite || Attribute.IsDefined(property, typeof(NotMappedAttribute)))
                    continue;

                object value = property.GetValue(entity);
                NpgsqlParameter parameter = new(property.Name, value ?? DBNull.Value);
                parameters.Add(parameter);

                insertSql += $"{property.Name}, ";
                valuesSql += $"@{property.Name}, ";
            }

            insertSql = insertSql.TrimEnd(',', ' ') + ")";
            valuesSql = valuesSql.TrimEnd(',', ' ') + ")";
            string sql = $"{insertSql} {valuesSql}";

            using NpgsqlCommand command = new(sql, connection);

            command.Parameters.AddRange(parameters.ToArray());
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<T> List(string query)
        {
            List<T> results = new();

            using (NpgsqlConnection connection = new(_connectionString))
            {
                using NpgsqlCommand command = new(query, connection);
                connection.Open();
                using NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    T entity = new();

                    PropertyInfo[] properties = typeof(T).GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        if (reader[property.Name] != DBNull.Value)
                        {
                            object value = reader[property.Name];
                            property.SetValue(entity, value);
                        }
                    }

                    results.Add(entity);
                }
                connection.Close();
            }

            return results;
        }

        public void Delete(T entity)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();

            // Obter informações sobre as propriedades do objeto genérico T
            PropertyInfo[] properties = typeof(T).GetProperties();

            // Obter a propriedade que representa a chave primária
            PropertyInfo primaryKeyProperty = properties.FirstOrDefault(p => Attribute.IsDefined(p, typeof(KeyAttribute))) ?? throw new InvalidOperationException("A classe não possui uma propriedade marcada com o atributo [Key].");

            // Obter o valor da chave primária do objeto genérico T
            object primaryKeyValue = primaryKeyProperty.GetValue(entity);

            // Construir a instrução SQL de exclusão
            string tableName = typeof(T).Name;
            string deleteSql = $"DELETE FROM {tableName} WHERE {primaryKeyProperty.Name} = @PrimaryKeyValue";

            // Criar o parâmetro para a chave primária
            NpgsqlParameter primaryKeyParameter = new("PrimaryKeyValue", primaryKeyValue);

            // Executar a instrução SQL
            using NpgsqlCommand command = new(deleteSql, connection);
            command.Parameters.Add(primaryKeyParameter);
            command.ExecuteNonQuery();

            connection.Close();
        }

    }
}