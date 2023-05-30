using ShopTestApp.Helpers;
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
using System.Windows.Threading;

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
        private DispatcherTimer timer;



        public MyProductsPage()
        {
            InitializeComponent();
            var userID = Helpers.EntityHelper.shopDB.Users.FirstOrDefault(i=>i.login == AuthWindow.userLogin && i.password  == AuthWindow.userPassword);    
            usersProducts = Helpers.EntityHelper.shopDB.UsersProducts.Where(i=>i.idUsers == userID.id).ToList();
            dataGrid.ItemsSource = usersProducts.ToList();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Здесь можно обновить данные, которые отображаются в DataGrid
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

            }
            else
            {
                MessageBox.Show("Продукт с данным штрихкодом не найден");
            } 
        }
    }
}
