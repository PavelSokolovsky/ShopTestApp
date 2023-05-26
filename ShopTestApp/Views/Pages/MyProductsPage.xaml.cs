using ShopTestApp.Models;
using ShopTestApp.Views.Windows;
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
    /// Логика взаимодействия для MyProductsPage.xaml
    /// </summary>
    public partial class MyProductsPage : Page
    {   
        List<UsersProducts> usersProducts = new List<UsersProducts>();
        public Orders orders = new Orders();
        public static UsersProducts products = new UsersProducts();


        public MyProductsPage()
        {
            InitializeComponent();

            usersProducts = Helpers.EntityHelper.shopDB.UsersProducts.ToList();
            dataGrid.ItemsSource = usersProducts.ToList(); 
        }
           public int needToBuy = products.amountMAX - products.amountMin;


        private void ScanBtn_Click(object sender, RoutedEventArgs e)
        {   
            // Скан использованного товара
            string barcode = txtBoxBarcode.Text;

            UsersProducts productInHome = Helpers.EntityHelper.shopDB.UsersProducts.FirstOrDefault(p => p.Products.barCode == barcode);

            if (productInHome != null)
            {
                productInHome.amountCurrent--;
                Helpers.EntityHelper.shopDB.SaveChanges();
                dataGrid.ItemsSource = Helpers.EntityHelper.shopDB.Products.ToList();
                usersProducts = Helpers.EntityHelper.shopDB.UsersProducts.ToList();
                dataGrid.ItemsSource = usersProducts.ToList();

                // Генерация заказа
                if (productInHome.amountCurrent == productInHome.amountMin) 
                {
                    orders.idUsers = 1;
                    orders.idProducts = 1;
                    orders.amounInOrder = needToBuy;
                    orders.orderDate = DateTime.Now;
                }
            }
            else
            {
                MessageBox.Show("Продукт с данным штрихкодом не найден");
            } 
        }
    }
}
