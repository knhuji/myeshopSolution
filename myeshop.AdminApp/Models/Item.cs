using myeShop.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myeshop.AdminApp.Models
 
{
    [Serializable]
    public class Item
    {
        
        public ProductViewModel Product { get; set; }

        public int Quantity { get; set; }
    }
}
