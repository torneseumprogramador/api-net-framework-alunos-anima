using System;
using System.IO;
using System.Data.SQLite;

namespace BaseDados
{
    public class ConectaBase
    {
        public static SQLiteConnection Conexao()
        {
            var src = $"{AppDomain.CurrentDomain.BaseDirectory}database.sqlite";

            //Valida se a base existe;
            if (!File.Exists(src)) SQLiteConnection.CreateFile(src);

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
