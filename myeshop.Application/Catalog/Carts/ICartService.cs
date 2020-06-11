using myeShop.ViewModels.Catalog.Carts;
using myeShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myeshop.Application.Catalog.Carts
{
    public interface ICartService
    {
        Task<ApiResult<Cart>> GetById(String key);
        Task<ApiResult<Cart>> Updatecart(String key, Cart request);
        Task<ApiResult<bool>> DeleteCart(String key);
    }
}
