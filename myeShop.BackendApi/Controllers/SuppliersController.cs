using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myeshop.Application.Catalog.Suppliers;
using myeShop.ViewModels.Catalog.Suppliers;

namespace myeShop.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]SuppliersPagingRequest request)
        {
            var suppliers = await _supplierService.GetAllPaging(request);
            return Ok(suppliers);
        }

        [HttpGet("{supplierId}")]
        public async Task<IActionResult> GetById(int supplierId)
        {
            var supplier = await _supplierService.GetById(supplierId);
            if (supplier == null)
                return BadRequest("Cannot find supplier");
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _supplierService.Create(request);
            if (result == 0)
                return BadRequest();
            var supplier = await _supplierService.GetById(result);
            
            return CreatedAtAction(nameof(GetById), new { id = result }, supplier);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]SupplierUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _supplierService.Update(request);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _supplierService.Delete(id);
            if (!result.IsSuccessed)
                return BadRequest();
            return Ok();
        }
    }
}