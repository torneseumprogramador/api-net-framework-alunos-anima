using Execricio.NETFramework.CRUD.Data.Repository.Interfaces;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Execricio.NETFramework.CRUD.Data.Repository
{
    public class BaseRepository : IBaseRepository
    {
        public IDbConnection GetConnection(bool open = true)
        {
            string connectionString = GetConnectionString();
            SQLiteConnection sqliteConnection = new SQLiteConnection(connectionString);
            if (open) { sqliteConnection.Open(); }
            return sqliteConnection;
        }

        public bool GetStatusConnection()
        {
            try
            {
                using (IDbConnection connection = GetConnection(open: false))
                {
                    connection.Open();
                    return connection.State == ConnectionState.Open;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string GetConnectionString()
        {
            string caminhoAtual = AppDomain.CurrentDomain.BaseDirectory;
            string caminhoPai = GetBaseDirectory(caminhoAtual, 2);

            string[] arquivosDatabase = Directory.GetFiles(caminhoPai, "*.db");

            if (arquivosDatabase.Length > 0)
                return $"Data Source={arquivosDatabase[0]}";
            else
                throw new FileNotFoundException("Nenhum arquivo .db encontrado no diretório especificado.");
        }

        private string GetBaseDirectory(string path, int level)
        {
            if (level <= 0)
                return path;

            string parentDirectory = Directory.GetParent(path)?.FullName;

            if (parentDirectory == null)
                throw new DirectoryNotFoundException("O diretório pai não foi encontrado.");

            return GetBaseDirectory(parentDirectory, level - 1);
        }

    }
}
