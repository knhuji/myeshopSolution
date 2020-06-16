using myeShop.ViewModels.Catalog.Carts;
using myeShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myeshop.AdminApp.Services
{
    public interface ICartApiClient
    {
        Task<Cart> GetCart(Buyer buyer);
        Task<Cart> Updatecart( Cart request);
        Task<ApiResult<bool>> DeleteCart(String key);
        Task AddItemToCart(Buyer buyer, CartItemViewModel cartItem);
        Task<Cart> SetQuantities(Buyer user, Dictionary<string, int> quantities);
    }
}
