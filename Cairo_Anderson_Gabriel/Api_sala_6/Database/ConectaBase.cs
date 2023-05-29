//using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace Api_sala_6.Database
{
    public class ConectaBase
    {
        public static SQLiteConnection Conexao()
        {
            var src = "database.sqlite";

            try
            {
                return new SQLiteConnection($"data source={src};");
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível iniciar a base, {ex}");
            }
        }

    }
}
