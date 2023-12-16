using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cheremushkin_lab_11_12_13_RPM
{
    public partial class ConnectionForm : Window
    {
        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            DatabaseConnection connection = new DatabaseConnection();
        }


        private void ConnectionBtn_Click(object sender, RoutedEventArgs e)
        {
            DatabaseConnection connection = new DatabaseConnection();
            if (!connection.OpenConnection())
                return;
            MessageBox.Show("Вы подключились к серверу: " + connection.ServerName + "\nВы подключились к базе данных: " + connection.DatabaseName);
            connection.CloseConnection();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }
    }
}
