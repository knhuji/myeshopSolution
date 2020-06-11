using System;
using System.Collections.Generic;
using System.Text;

namespace myeShop.ViewModels.Catalog.Carts
{
    public class CartItemViewModel
    {
        public string Id { get; set; }
        public int Prod_ID { get; set; }
        public string Prod_Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
