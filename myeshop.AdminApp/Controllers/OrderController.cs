using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myeshop.AdminApp.Services;
using myeShop.ViewModels.Catalog.Carts;
using myeShop.ViewModels.Catalog.Orders;
using myeShop.ViewModels.Catalog.Products;

namespace myeshop.AdminApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;
        public OrderController(IOrder order)
        {
            _order = order;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("checkout/{id}")]
        public async Task<IActionResult> Checkout(int id)
        {
            List<CartItemViewModel> cart = CartSession.GetObjectFromJson<List<CartItemViewModel>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Price * item.Quantity);
            var order = new OrderViewModel();
            foreach(var item in cart)
            {
                order.Items.Add(new ItemOrder
                {
                    Prod_ID=item.Prod_ID,
                    Prod_Name=item.Prod_Name,
                    ImagePath=item.ImagePath,
                    Quantity=item.Quantity,
                    Price=item.Price
                });
            }

            //var user = CartSession.GetUser(HttpContext.Session,"Token");
            //string iduser = user.UserName;
            //var result = await _order.Ordercart(iduser, order);
            //if (result.IsSuccessed)
            //{
            //    CartSession.SetObjectAsJson(HttpContext.Session, "cart", cart);
            //    cart.Clear();
            //    return RedirectToAction("Index");
            //}
            //ModelState.AddModelError("", result.Message);
            return View();
        }
    }
}