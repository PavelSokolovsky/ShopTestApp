using ShopTestApp.Helpers;
using ShopTestApp.Models;
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
        public AuthWindow authWindow = new AuthWindow();
        private MakeOrder makeOrder;
        private System.Timers.Timer timer;
        public ProductsAtHomeWindow()
        {
            InitializeComponent();
            
            this.Loaded += ProductsAtHomeWindow_Loaded;

        }
        private void ProductsAtHomeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            makeOrder = new MakeOrder();

            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                makeOrder.CheckAndCreateOrders();
            });
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

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            
                
                authWindow.Show();
                this.Close();
            
        }
    }
}
