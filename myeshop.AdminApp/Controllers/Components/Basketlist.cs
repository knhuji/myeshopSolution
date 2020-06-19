using Microsoft.AspNetCore.Mvc;
using myeshop.AdminApp.Services;
using myeShop.ViewModels.Catalog.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myeshop.AdminApp.ViewComponents
{
    public class BasketList : ViewComponent
    {
        private readonly ICartApiClient _cartApiClient;

        public BasketList(ICartApiClient cartApiClient)
        {
            _cartApiClient = cartApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(Buyer user)
        {
            var cart = await _cartApiClient.GetCart(user);

            return View(cart);
        }
    }
}
