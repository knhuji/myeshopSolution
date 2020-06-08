using myeshop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Data.Entities
{
    public class Product
    {
        public int Prod_ID { get; set; }
        public string Prod_Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreate { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public List<ProductInSupplier> ProductInSuppliers { get; set; }
        public List<ProductInSize> ProductInSizes { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Cart> Carts { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        
    }
}
