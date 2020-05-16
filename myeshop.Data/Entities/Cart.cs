using System;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Data.Entities
{
    public class Cart
    {
        public int Cart_ID { set; get; }
        public int Product_ID { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public Guid UserId { get; set; }

        public Product Product { get; set; }

        public DateTime DateCreated { get; set; }

        public User User { get; set; }
    }
}
