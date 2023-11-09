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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dish4Good
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myComboBox.Items.Add("Penerima");
            myComboBox.Items.Add("Donatur");
        }
        private NpgsqlConnection conn;
        string connstring ="Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dish4good";

        public void MainWindow_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Anda dapat menambahkan logika autentikasi di sini.
            // Misalnya, memeriksa username dan password dengan data yang valid.

            //if (username == "user" && password == "password")
            //{
            //    MessageBox.Show("Login berhasil!");
            //    // Tambahkan logika untuk berpindah ke halaman utama atau menu aplikasi di sini.
            //}
            //else
            //{
            //    MessageBox.Show("Login gagal. Periksa username dan password Anda.");
            //}

            // Membuat instance window Register.xaml
            donaturDash donatur = new donaturDash();

            // Menetapkan window Register.xaml sebagai halaman navigasi
            donatur.Show();

            // Menutup window saat ini (MainWindow.xaml) jika diperlukan
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();
            this.Close();
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            donaturDash donatur = new donaturDash();

            donatur.Show();
            this.Close();
        }
    }
}
