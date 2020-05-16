using myeshop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Data.Entities
{
    public class Supplier
    {
        public int Supplier_ID { get; set; }
        public string Supplier_Name { get; set; }
        public string Gmail { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public Status Status { get; set; }
        public List<ProductInSupplier> ProductInSuppliers { get; set; }
    }
}
