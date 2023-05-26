using ShopTestApp.Views.Pages;
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
using System.Windows.Shapes;

namespace ShopTestApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductsAtHomeWindow.xaml
    /// </summary>
    public partial class ProductsAtHomeWindow : Window
    {
        public static MyProductsPage productAtHomePage = new MyProductsPage();
        public static ChangeAmountPage changeAmountPage = new ChangeAmountPage();
        public static OrdersPage ordersPage = new OrdersPage();
        public ProductsAtHomeWindow()
        {
            InitializeComponent();
        }

        private void MyProducts_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = productAtHomePage;
        }

        private void ChangeAmount_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = changeAmountPage;
        }

        private void OrdersHistory_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = ordersPage;
        }
    }
}
