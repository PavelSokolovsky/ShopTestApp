using ShopTestApp.Models;
using ShopTestApp.Views.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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





            var idAuthUser = Helpers.EntityHelper.shopDB.Users.FirstOrDefault(i => i.login == AuthWindow.userLogin && i.password == AuthWindow.userPassword);
            var activeForCheck = Helpers.EntityHelper.shopDB.Orders.FirstOrDefault(i => i.isActive == true);

                if (activeForCheck == null)
                {
                    Orders newOrder = new Orders();
                    newOrder.orderDate = DateTime.Now;
                    newOrder.idUsers = idAuthUser.id;
                    newOrder.isActive = true;
                Helpers.EntityHelper.shopDB.Orders.Add(newOrder);
                Helpers.EntityHelper.shopDB.SaveChanges();
 
                }
            CheckAndCloseOrders();




        }
        public void CheckAndCloseOrders()
        {
            
            

                var isActive = Helpers.EntityHelper.shopDB.Orders.FirstOrDefault(i => i.isActive==true);
                var minValue = Helpers.EntityHelper.shopDB.UsersProducts.FirstOrDefault(i => i.amountCurrent == i.amountMin);
                
                if (minValue != null && isActive != null)
                {
                AddProductsToOrder addProductsToOrder = new AddProductsToOrder();
                addProductsToOrder.AddProduct();

                }
            else
            {
                return;
            }







            //{
            //    DateTime date1 = activeForCheck.orderDate;
            //    DateTime date2 = DateTime.Now;
            //    TimeSpan difference = date2 - date1;
            //    int daysDifference = difference.Days;
            //    if (activeForCheck != null && difference.Days > 7 && shopTestDB.UsersProducts.All(i => i.amountCurrent < i.amountMAX))
            //        {
            //            AddProductsToOrder addProductsToOrder = new AddProductsToOrder();
            //            addProductsToOrder.AddProduct();

            //        }
            //        else if (activeForCheck != null && difference.Days < 7 )

            //        {
            //            AddProductsToOrder addProductsToOrder = new AddProductsToOrder();
            //            addProductsToOrder.AddProduct();

            //        }
            //        else CheckAndCreateOrders();

            //    }









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