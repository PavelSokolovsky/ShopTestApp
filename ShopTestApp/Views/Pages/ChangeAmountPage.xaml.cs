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
    /// Логика взаимодействия для ChangeAmountPage.xaml
    /// </summary>
    public partial class ChangeAmountPage : Page
    {
        public ChangeAmountPage()
        {
            InitializeComponent();
        }

        private void SaveAmountBtn_Click(object sender, RoutedEventArgs e)
        {
            string barcode = barcodeTextBox.Text;

            UsersProducts productInHome = Helpers.EntityHelper.shopDB.UsersProducts.FirstOrDefault(p => p.Products.barCode == barcode);

            if (productInHome != null)
            {
                productInHome.amountMAX = Convert.ToInt32(maxAmountTextBox.Text);
                productInHome.amountMin = Convert.ToInt32(minAmountTextBox.Text);
                Helpers.EntityHelper.shopDB.SaveChanges();
                MessageBox.Show("Параметры указанного товара были успешно изменены");
               
            }
            else
            {
                MessageBox.Show("Продукт с данным штрихкодом не найден");
            }
        }
    }
}
