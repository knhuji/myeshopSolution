using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace myeshop.AdminApp.Controllers
{
    public class AdOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Handling()
        {
            return View();
        }
    } 
}