using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myeShop.ViewModels.Catalog.Carts
{
    public class Cart
    {
        public Cart() { }

        public Cart(string buyerId)
        {
            Id = buyerId;
        }

        public string Id { get; set; }

        public IEnumerable<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.Price * x.Quantity), 2);
        }
    }
}
