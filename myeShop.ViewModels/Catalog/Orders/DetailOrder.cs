using myeshop.Data.Entities;
using myeshop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeShop.ViewModels.Catalog.Orders
{
    public class DetailOrder
    {
        
        public int OrderDetail_ID { set; get; }
        public int Product_ID { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public Order Order { get; set; }

        public Product Product { get; set; }

    }
}
