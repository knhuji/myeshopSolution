using System;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Data.Entities
{
    public class ProductInSize
    {
        public int Prod_ID { get; set; }
        public Product Product { get; set; }
        public int Size_ID { get; set; }
        public Size Size { get; set; }

    }
}
