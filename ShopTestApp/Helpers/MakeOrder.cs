using ShopTestApp.Models;
using ShopTestApp.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopTestApp.Helpers
{
    public class MakeOrder
    {
        public void CheckAndCreateOrders()
        {   
            AuthWindow authWindow = new AuthWindow();
            var minValue = Helpers.EntityHelper.shopDB.UsersProducts.FirstOrDefault(i => i.amountMin <= i.amountCurrent);
            var idAuthUser = 1;
            var active = Helpers.EntityHelper.shopDB.Orders.FirstOrDefault(i => i.isActive == true);
            if (active != null)
            {
                MessageBox.Show("Имеется активный зака. Уточните информацию на странице Заказы");
                
            }
            else
            {
                if (minValue.amountMin <= minValue.amountCurrent)
                {
                    Orders newOrder = new Orders();
                    newOrder.orderDate = DateTime.Now;
                    newOrder.idUsers = idAuthUser;
                    newOrder.isActive = true;
                    Helpers.EntityHelper.shopDB.Orders.Add(newOrder);
                    Helpers.EntityHelper.shopDB.SaveChanges();
                    MessageBox.Show("Только что был создан активный заказ");
                }
                else MessageBox.Show("затычка");
            }





        }
    }
}










//UsersProducts products = new UsersProducts();
//public void GenerateOrder()
//{
//    AuthWindow authWindow = new AuthWindow();
//    int maxValue = products.amountMAX;
//    int curValue = products.amountCurrent;
//    int minValue = products.amountMin;
//    int difference = products.amountMAX - curValue;
//    var idAuthUser = Helpers.EntityHelper.shopDB.Users.FirstOrDefault(i => i.login == authWindow.userLogin && i.password == authWindow.userPassword);
//    if (difference == minValue && idAuthUser != null)
//    {
//        Orders newOrder = new Orders();
//        newOrder.orderDate = DateTime.Now;
//        newOrder.idUsers = idAuthUser.id;
//        Helpers.EntityHelper.shopDB.Orders.Add(newOrder);
//        Helpers.EntityHelper.shopDB.SaveChanges();


//    }
//}