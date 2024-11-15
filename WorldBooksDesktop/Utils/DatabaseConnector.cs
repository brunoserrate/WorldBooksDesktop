using MySql.Data.MySqlClient;

namespace WorldBooksDesktop.Utils
{
    public class DatabaseConnector
    {
        private static DatabaseConnector instance;
        
        private static readonly object padlock = new object();
        private string connectionString;

        private DatabaseConnector(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public static DatabaseConnector Instance(string connectionString)
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseConnector(connectionString);
                    }
                }
            }
            return instance;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public void OpenConnection(MySqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection(MySqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
