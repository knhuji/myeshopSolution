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
    public class AdSupplierController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ISupplierApiClient _supplierApiClient;
        public AdSupplierController(IConfiguration configuration, ISupplierApiClient supplierApiClient)
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _supplierApiClient.Create(request);
            if (result.IsSuccessed)
            {
                //TempData["result"] = "Thêm mới nhà sản xuất thành công";
                return RedirectToAction("Index");
            }

            //ModelState.AddModelError("", result.Message);
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new SupplierDeleteRequest()
            {
                Supplier_ID = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SupplierDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _supplierApiClient.Delete(request.Supplier_ID);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa nhà sản xuất thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _supplierApiClient.GetById(id);
            if (result.IsSuccessed)
            {
                var s = result.ResultObj;
                var updateRequest = new SupplierUpdateRequest()
                {
                    Supplier_Name = s.Supplier_Name,
                    Gmail = s.Gmail,
                    Address = s.Address,
                    Phone = s.Phone,
                    Status = s.Status,
                    Supplier_ID = id
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SupplierUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _supplierApiClient.Update(request);
            if (result.IsSuccessed)
            {
                //TempData["result"] = "Cập nhật nhà sản xuất thành công";
                return RedirectToAction("Index");
            }

            //ModelState.AddModelError("", result.Message);
            return View(request);
        }

    }
}