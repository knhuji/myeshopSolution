using myeShop.ViewModels.Catalog.Orders;
using myeShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myeshop.AdminApp.Services
{
    public interface IOrder
    {
        Task<ApiResult<string>> Ordercart(string userid,OrderViewModel request);
    }
}
