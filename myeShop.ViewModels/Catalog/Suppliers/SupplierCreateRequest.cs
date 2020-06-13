using Microsoft.AspNetCore.Http;
using myeshop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeShop.ViewModels.Catalog.Suppliers
{
    public class SupplierCreateRequest
    {
        public int Supplier_ID { get; set; }
        public string Supplier_Name { get; set; }
        public string Gmail { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public Status Status { get; set; }
    }
}
