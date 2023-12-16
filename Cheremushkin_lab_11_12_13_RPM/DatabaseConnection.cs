using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cheremushkin_lab_11_12_13_RPM
{
    internal class DatabaseConnection
    {
        private readonly SqlConnection connection;
        private readonly string connectionString = @"Data Source=CHEREMUSHKINPC\SQLEXPRESS;Initial Catalog=Cheremushkinae_107d2_RPM;Integrated Security=True";

        public string ServerName => connection.DataSource;
        public string DatabaseName => connection.Database;

        public DatabaseConnection()
        {
            connection = new SqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to database: {ex.Message}");
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to disconnect to database: {ex.Message}");
                return false;
            }
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }

}
