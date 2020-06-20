using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myeshop.Application.Catalog.Orders;
using myeShop.ViewModels.Catalog.Orders;

namespace myeShop.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("orders/{userid}")]
        [AllowAnonymous]
        public async Task<IActionResult> orders(string userid,[FromBody]OrderViewModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var resultToken = await _orderService.Ordercart(userid,request);
            if (string.IsNullOrEmpty(resultToken.ResultObj))
            {
                return BadRequest(resultToken);
            }
            return Ok(resultToken);
        }
    }
}