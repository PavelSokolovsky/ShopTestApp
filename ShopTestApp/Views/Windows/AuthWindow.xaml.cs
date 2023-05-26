using ShopTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace ShopTestApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    { 
        public static ProductsAtHomeWindow productsAtHomeWindow = new ProductsAtHomeWindow();
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var auth = Helpers.EntityHelper.shopDB.Users.Where(i => i.login == txtLogin.Text && i.password == txtPassword.Password).ToList();
            if (auth.Count>0)
            {
                MessageBox.Show("Вы успешно вошли");
                productsAtHomeWindow.Show();
                this.Close();
            }
            else MessageBox.Show("Пользователь не найден");
        }
    }
}
