using Microsoft.AspNetCore.Mvc;
using myeshop.AdminApp.Services;
using myeshop.AdminApp.ViewModel;
using myeshop.Application.Catalog.Carts;
using myeShop.ViewModels.Catalog.Carts;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myeshop.AdminApp.ViewComponents
{
    public class Basket : ViewComponent
    {
        private readonly ICartApiClient _cartApiClient;

        public Basket(ICartApiClient cartApiClient)
        {
            _cartApiClient = cartApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(Buyer user)
        {
            var vm = new CartComponentViewModel();

            try
            {
                var cart = await _cartApiClient.GetCart(user);
                vm.ItemsInCart = cart.Items.Count();
                vm.TotalCost = cart.Total();
            }
            catch (BrokenCircuitException)
            {
                ViewBag.IsCartInoperative = true;
            }

            return View(vm);
        }
    }
}
