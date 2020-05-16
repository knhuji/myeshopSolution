using System;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Data.Entities
{
    public class OrderDetail
    {
        public int OrderDetail_ID { set; get; }
        public int Product_ID { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
