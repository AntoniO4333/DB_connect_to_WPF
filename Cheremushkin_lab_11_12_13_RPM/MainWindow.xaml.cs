using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cheremushkin_lab_11_12_13_RPM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainForm_Load;
        }

        private void MainForm_Load(object sender, RoutedEventArgs e)
        {
            AddTables();
        }

        private void AddTables()
        {
            DatabaseConnection connection = new DatabaseConnection();

            if (!connection.OpenConnection())
                return;

            try
            {
                DataTable schema = connection.GetConnection().GetSchema("Tables");

                foreach (DataRow table in schema.Rows)
                {
                    comboBox1.Items.Add(table["TABLE_NAME"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fail: {ex.Message}");
            }
            finally
            {
                connection.CloseConnection();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ConnectionForm connectionForm = new ConnectionForm();
            connectionForm.Show();
            this.Close();
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DatabaseConnection connection = new DatabaseConnection();

            if (!connection.OpenConnection())
                return;

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable data = new DataTable();

                string query = $"SELECT * FROM {comboBox1.SelectedItem}";

                SqlCommand command = new SqlCommand(query, connection.GetConnection());

                adapter.SelectCommand = command;
                adapter.Fill(data);

                dataGridView1.ItemsSource = data.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fail: {ex.Message}");
            }
            finally
            {
                connection.CloseConnection();
            }
        }
    }

}
