using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using myeshop.AdminApp.Services;
using myeShop.ViewModels.Catalog.Products;

namespace myeshop.AdminApp.Controllers
{
    public class AdProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        public AdProductController(IConfiguration configuration, IProductApiClient productApiClient)
        {

            _configuration = configuration;
            _productApiClient = productApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _productApiClient.GetAllPaging(request);
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
            var result = await _productApiClient.GetById(id);
            return View(result.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.Create(request);
            if (result.IsSuccessed)
            {

                return RedirectToAction("Index");
            }

            //ModelState.AddModelError("", result.Message);
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new ProductDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.Delete(request.Id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa người dùng thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _productApiClient.GetById(id);
            if (result.IsSuccessed)
            {
                var pro = result.ResultObj;
                var updateRequest = new ProductUpdateRequest()
                {
                    Prod_Name = pro.Prod_Name,
                    Description = pro.Description,
                    Price = pro.Price,
                    Quantity = pro.Quantity,
                    Status = pro.Status,
                    Prod_ID = id
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _productApiClient.Update(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("",result.Message);
            return View();
        }
    }
}