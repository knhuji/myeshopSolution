using myeshop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Application.Catalog.Products.Dtos.Manage
{
    public class ProductUpdateRequest
    {
        public int Prod_ID { get; set; }
        public string Prod_Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
