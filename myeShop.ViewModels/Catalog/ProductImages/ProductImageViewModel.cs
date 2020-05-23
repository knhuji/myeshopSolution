using myeshop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeShop.ViewModels.Catalog.ProductImages
{
    public class ProductImageViewModel
    {
        public int Image_ID { get; set; }
        public int Prod_ID { get; set; }
        public string ImagePath { get; set; } //Đường dẫn hình ảnh
        public string Caption { get; set; } //Ghi chú
        public bool IsDefault { get; set; } //Ảnh mặc định
        public DateTime DateCreate { get; set; }
        public int SortOrder { get; set; } //Thứ tự ảnh
        public long FileSize { get; set; } //Kích thước ảnh
        public Product Product { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
