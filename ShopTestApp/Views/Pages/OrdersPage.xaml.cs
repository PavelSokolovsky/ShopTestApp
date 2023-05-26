using ShopTestApp.Models;
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

namespace ShopTestApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        List<Orders> orders = new List<Orders>();
        public OrdersPage()
        {
            InitializeComponent();
            orders = Helpers.EntityHelper.shopDB.Orders.ToList();
            dataGridOrder.ItemsSource = orders.ToList();


        }
    }
}
