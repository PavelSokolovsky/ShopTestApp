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
    public  class AddProductsToOrder
    { 
        public void AddProduct()
        {
            AuthWindow authWindow = new AuthWindow();
            var anyActiveOrder = Helpers.EntityHelper.shopDB.Orders.FirstOrDefault(i => i.isActive == true);
            var userForOrder = 1;
            if (anyActiveOrder != null )
            {
                PriductsInOrders newProductInOrder = new PriductsInOrders();
                newProductInOrder.idProducts = 1;
                newProductInOrder.idOrder = 1;
                newProductInOrder.amountInOrder = 1;
                Helpers.EntityHelper.shopDB.PriductsInOrders.Add(newProductInOrder);
                Helpers.EntityHelper.shopDB.SaveChanges();
                
            }
        }

        
    }
}
