using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myeshop.Application.Catalog.Products;
using myeshop.Application.Catalog.Products.Dtos;
using myeShop.ViewModels.Catalog.ProductImages;
using myeShop.ViewModels.Catalog.Products;

namespace myeShop.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       
        private readonly IProductService _productService;

        public ProductsController( IProductService productService)
        {
            _productService = productService;
        }
       
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]GetManageProductPagingRequest request)
        {
            var products = await _productService.GetAllPaging(request);
            return Ok(products);
        }

        [HttpGet("{productId}")]
        //public async Task<IActionResult> GetById(int productId)
        //{
        //    var product = await _productService.GetById(productId);
        //    if (!product.IsSuccessed)
        //        return BadRequest();
        //    return Ok(product.ResultObj);
        //}
        public async Task<IActionResult> GetById(int productId)
        {
            var product = await _productService.GetById(productId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromQuery]ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _productService.Create(request);
            if (!result.IsSuccessed)
                return BadRequest(result);
            var product = await _productService.GetById(result.ResultObj);

            return CreatedAtAction(nameof(GetById), new { id = request }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _productService.Update(request);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);
            if (!result.IsSuccessed)
                return BadRequest();
            return Ok();
        }
        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var result = await _productService.UpdatePrice(productId, newPrice);
            if (!result.IsSuccessed)
                return BadRequest();

            return Ok();
        }

        [HttpGet("{Id}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int Id)
        {
            var image = await _productService.GetById(Id);
            if (image == null)
                return BadRequest("Cannot find product");
            return Ok(image);
        }

        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm]ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.AddImage(productId, request);
            if (!result.IsSuccessed)
                return BadRequest();

            var image = await _productService.GetImageById(result.ResultObj);

            return CreatedAtAction(nameof(GetImageById), new { id = result }, image);
        }

    }
}