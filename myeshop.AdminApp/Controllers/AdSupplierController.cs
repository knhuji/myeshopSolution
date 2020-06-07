using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace myeshop.AdminApp.Controllers
{
    public class AdSupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}