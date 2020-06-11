using System;
using System.Collections.Generic;
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
    }
}
