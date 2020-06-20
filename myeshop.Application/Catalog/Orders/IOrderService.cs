using myeShop.ViewModels.Catalog.Orders;
using myeShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myeshop.Application.Catalog.Orders
{
    public interface IOrderService
    {
        Task<ApiResult<string>> Ordercart(string userid, OrderViewModel request);
    }
}
