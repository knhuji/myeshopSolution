using System;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Data.Entities
{
    public class ProductInSupplier
    {
        public int Prod_ID { get; set; }
        public Product Product { get; set; }
        public int Supplier_ID { get; set; }
        public Supplier Supplier { get; set; }
    }
}
