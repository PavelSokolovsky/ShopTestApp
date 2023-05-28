using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTestApp.Helpers
{
    internal class TotalOrder
    {
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public TotalOrder(int clientId, int productId, DateTime orderDate, int quantity)
        {
            ClientId = clientId;
            ProductId = productId;
            OrderDate = orderDate;
            Quantity = quantity;
        }
    }
}
