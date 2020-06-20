using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using myeshop.Data.EF;
using myeshop.Data.Entities;
using myeShop.ViewModels.Catalog.Orders;
using myeShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myeshop.Application.Catalog.Orders
{
    public class OrderService : IOrderService
    {
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;

        private readonly IConfiguration _config;
        public OrderService(UserManager<User> userManager,DataContext dataContext ,IConfiguration config)
        {
            _userManager = userManager;
            _context = dataContext;
            _config = config;
        }
        public async Task<ApiResult<string>> Ordercart(string userid, OrderViewModel request)
        {
            var d = _context.Users.Find(userid);
                var order = new Order()
                {
                ShipName = request.ShipName,
                    ShipAddress = request.ShipAddress,
                    ShipEmail = request.ShipEmail,
                    ShipPhoneNumber = request.ShipPhoneNumber,
                    UserId = d.Id
                    
                };
            var a = new OrderDetail();

            foreach (var item in request.Items)
            {

                a.Product_ID = item.Prod_ID;
                a.Quantity = item.Quantity;
                a.Price = item.Price;

            
           var b= _context.ProductImage.Find(a.Product_ID);
            if(b.Quantity>=a.Quantity)
            {
                    b.Quantity = b.Quantity - a.Quantity;
                    _context.OrderDetails.Add(a);
                }

                return new ApiErrorResult<string>("Hết hàng");

            };

            
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            
                return new ApiSuccessResult<string>();
            
        }
    }
}
