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
            var anyActive = Helpers.EntityHelper.shopDB.Orders.FirstOrDefault(i => i.isActive == true);
            var anyToBuy = Helpers.EntityHelper.shopDB.UsersProducts.Where(i => i.amountMAX > i.amountCurrent);
            if (anyActive != null && anyToBuy!=null)
            {
                foreach (var item in anyToBuy) 
                {

                    if (item.amountCurrent < item.amountMAX)
                    {
                        int toAdd = item.amountMAX - item.amountCurrent;
                        PriductsInOrders priductsInOrders  =  new PriductsInOrders();
                        priductsInOrders.amountInOrder = toAdd;
                        priductsInOrders.idOrder = anyActive.id;
                        priductsInOrders.idProducts = item.idProducts;
                        Helpers.EntityHelper.shopDB.PriductsInOrders.Add(priductsInOrders);
                        
                    }

                }
                anyActive.isActive = false;
                
                foreach (var item in anyToBuy)
                {
                    item.amountCurrent = item.amountMAX;
                    
                }
                Helpers.EntityHelper.shopDB.SaveChanges();
            }
            
            
        }


    }
}
