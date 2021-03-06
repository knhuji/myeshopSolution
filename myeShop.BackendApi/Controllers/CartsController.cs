﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCaching.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myeshop.Application.Catalog.Carts;
using myeshop.Application.Catalog.Products;
using myeShop.ViewModels.Catalog.Carts;

namespace myeShop.BackendApi.Controllers
{
    [Route("api/[controller]/Redis")]
    [ApiController]
   
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CartsController(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var cart = await _cartService.GetById(id);
            if (!cart.IsSuccessed)
                return BadRequest();
            return Ok(cart.ResultObj);
        }

        [HttpPut]
        public async Task<IActionResult> Updatecart(string id, [FromQuery]Cart request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _cartService.Updatecart(id, request);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _cartService.DeleteCart(id);
            if (!result.IsSuccessed)
                return BadRequest();
            return Ok();
        }
    }
    
}