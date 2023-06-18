using System.Configuration;

namespace Data.Context
{
    public class DataBaseConfig
    {
        public string ConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GamaApp"].ConnectionString;

            return connectionString;
        }
    }
}

