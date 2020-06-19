using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myeshop.AdminApp.Services;
using myeShop.ViewModels.Catalog.Carts;
using myeShop.ViewModels.Catalog.Products;
using Polly.CircuitBreaker;

namespace myeshop.AdminApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartApiClient _cartApiClient;
        private readonly IBuyerService _buyerService;

        public CartController(ICartApiClient cartApiClient, IBuyerService buyerService)
        {
            _cartApiClient = cartApiClient;
            _buyerService = buyerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Dictionary<string, int> quantities, string action)
        {
            if (action == "[ Checkout ]")
            {
                return RedirectToAction("Create", "Order");
            }

            try
            {
                var user = _buyerService.Get(HttpContext.User);
                var cart = await _cartApiClient.SetQuantities(user, quantities);
                var vm = await _cartApiClient.Updatecart(cart);
            }
            catch (BrokenCircuitException)
            {
                HandleBrokenCircuitException();
            }

            return View();
        }

        public async Task<IActionResult> AddToCart(ProductViewModel product)
        {
            var cartItem = new CartItemViewModel
            {
                Id = Guid.NewGuid().ToString(),
                Prod_ID = product.Prod_ID,
                Prod_Name = product.Prod_Name,
                Price = product.Price,
                Quantity = 1,
                //PictureUri = movie.PictureUri
            };

            var buyer = _buyerService.Get(User);

            await _cartApiClient.AddItemToCart(buyer, cartItem);

            return RedirectToAction("Index", "Home");
        }
        private void HandleBrokenCircuitException()
        {
            TempData["BasketInoperativeMsg"] = "cart Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
        }

    }
}