using ShopTestApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        

        private void dataGridOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridOrder.SelectedItem is Orders orders)
            {
                int orderId = orders.id;
                var productsInfo = Helpers.EntityHelper.shopDB.PriductsInOrders.Where(i => i.idOrder == orderId).ToList();
                dataGridProducts.ItemsSource = productsInfo;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = (DateTime)datePicker.SelectedDate;

            var filteredOrders = Helpers.EntityHelper.shopDB.Orders.Where(i => DbFunctions.TruncateTime(i.orderDate) == DbFunctions.TruncateTime(selectedDate)).ToList();

            dataGridOrder.ItemsSource = filteredOrders;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = DateTime.Now.Date;
        }
    }
}
