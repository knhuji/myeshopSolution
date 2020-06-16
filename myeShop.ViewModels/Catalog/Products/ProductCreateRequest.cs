using Microsoft.AspNetCore.Http;
using myeshop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeShop.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        //public int Prod_ID { get; set; }
        public string Prod_Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreate { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public IFormFile ThumbnailImage { get; set; }
        
    }
}
