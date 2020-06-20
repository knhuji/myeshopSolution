using DocumentFormat.OpenXml.Office2010.Excel;
using myeshop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myeshop.AdminApp.Models
{
    public class Product
    {
        public int Prod_ID { get; set; }
        public string Prod_Name { get; set; }
        public string id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreate { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public string ImagePath { get; set; }
        public int Supplier_ID { get; set; }
    }
}
