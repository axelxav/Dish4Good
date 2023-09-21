using System;
using System.Collections.Generic;
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

namespace Dish4Good
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myComboBox.Items.Add("Pilihan 1");
            myComboBox.Items.Add("Pilihan 2");
            myComboBox.Items.Add("Pilihan 3");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Anda dapat menambahkan logika autentikasi di sini.
            // Misalnya, memeriksa username dan password dengan data yang valid.

            if (username == "user" && password == "password")
            {
                MessageBox.Show("Login berhasil!");
                // Tambahkan logika untuk berpindah ke halaman utama atau menu aplikasi di sini.
            }
            else
            {
                MessageBox.Show("Login gagal. Periksa username dan password Anda.");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            
        }


    }
}
