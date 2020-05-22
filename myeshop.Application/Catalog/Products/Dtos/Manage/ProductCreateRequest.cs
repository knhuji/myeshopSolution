using myeshop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Application.Catalog.Products.Dtos.Manage
{
    public class ProductCreateRequest
    {
        public string Prod_Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreate { get; set; }
        public string Description { get; set; }
    }
}
