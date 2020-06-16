using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using myeshop.AdminApp.Services;
using myeShop.ViewModels.Catalog.Suppliers;

namespace myeshop.AdminApp.Controllers
{
    public class SupplierController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ISupplierApiClient _supplierApiClient;
        public SupplierController(IConfiguration configuration, ISupplierApiClient supplierApiClient)
        {

            _configuration = configuration;
            _supplierApiClient = supplierApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new SuppliersPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _supplierApiClient.GetAllPaging(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _supplierApiClient.GetById(id);
            return View(result.ResultObj);
        }
    }
}