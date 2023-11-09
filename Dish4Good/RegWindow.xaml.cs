using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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

namespace Dish4Good
{
    /// <summary>
    /// Interaction logic for RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
            myComboBox.Items.Add("penerima");
            myComboBox.Items.Add("donatur");
            conn = new NpgsqlConnection(connstring);
        }
        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dish4good";
        public static NpgsqlCommand cmd;
        private string sql = null;

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                sql = "select * from st_insert(_username,:_password)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_name", UsernameTextBox.Text);
                cmd.Parameters.AddWithValue("_password", PasswordBox.Password);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data User Baru Berhasil Ditambahkan", "Well Done", MessageBoxButton.OK, MessageBoxImage.Information);
                    conn.Close();
                    UsernameTextBox.Text = PasswordBox.Password = null;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show("Error: " + ex.Message, "Register Fail!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Implementasi event handler di sini
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


    }
}
