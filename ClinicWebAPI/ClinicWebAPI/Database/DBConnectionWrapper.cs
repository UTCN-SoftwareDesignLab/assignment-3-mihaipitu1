using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicWebAPI.Database
{
    public class DBConnectionWrapper
    {
        private static string server = "localhost";
        private string database;
        private static string uid = "root";
        private static string password = "root";

        private MySqlConnection connection = null;

        public DBConnectionWrapper(string database)
        {
            this.database = database;
            InitializeConnection();
        }

        public void InitializeConnection()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = server;
            conn_string.Database = database;
            conn_string.UserID = uid;
            conn_string.Password = password;

            connection = new MySqlConnection(conn_string.ToString());
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
