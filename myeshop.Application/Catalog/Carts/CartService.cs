using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using myeShop.ViewModels.Catalog.Carts;
using myeShop.ViewModels.Common;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace myeshop.Application.Catalog.Carts
{
    public class CartService : ICartService
    {
        
        private readonly IDistributedCache _distributedCache;
        public CartService( IDistributedCache distributedCache)
        {
            //ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1");
            
            //_database = redis.GetDatabase();
            _distributedCache = distributedCache;
        }
       
        public async Task<ApiResult<Cart>> GetById(string key)
        {
            var data = await  _distributedCache.GetStringAsync(key);
            if (data!=null)
                return JsonConvert.DeserializeObject<ApiSuccessResult<Cart>>(data.ToString());
            return JsonConvert.DeserializeObject<ApiErrorResult<Cart>>(data.ToString());
        }

        public async Task<ApiResult<Cart>> Updatecart(String key, Cart request)
        {
            var data = JsonConvert.SerializeObject(request);
            var result = Encoding.UTF8.GetBytes(data);
            var option = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromDays(5))
                .SetAbsoluteExpiration(DateTime.Now.AddDays(6));
              await _distributedCache.SetAsync(key, result, option, default);
            
                return await GetById(key);
           
        }
        public async  Task<ApiResult<bool>> DeleteCart(string key)
        {

             await _distributedCache.RemoveAsync(key);
            return new ApiSuccessResult<bool>();
        }
    }
}
