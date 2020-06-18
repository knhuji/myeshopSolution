using EasyCaching.Core;
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

        
        private IEasyCachingProvider cachingProvider;
        private IEasyCachingProviderFactory cachingProviderFactory;

        public CartService( IEasyCachingProviderFactory cachingProviderFactory)
        {
           
            this.cachingProviderFactory = cachingProviderFactory;
            cachingProvider = this.cachingProviderFactory.GetCachingProvider("redis1");
        }
        //private readonly IDistributedCache _distributedCache;
        //public CartService(IDistributedCache distributedCache)
        //{
            
        //    _distributedCache = distributedCache;
        //}

        public async Task<ApiResult<Cart>> GetById(string key)
        {
            var data = await cachingProvider.GetAsync<String>(key);
            if (data != null)
                return JsonConvert.DeserializeObject<ApiSuccessResult<Cart>>(data.ToString());
            return JsonConvert.DeserializeObject<ApiErrorResult<Cart>>(data.ToString());
        }

        public async Task<ApiResult<Cart>> Updatecart(String key, Cart request)
        {
            var data = JsonConvert.SerializeObject(request);
           // var result = Encoding.UTF8.GetBytes(data);
            //var option = new DistributedCacheEntryOptions()
            //    .SetSlidingExpiration(TimeSpan.FromDays(5))
            //    .SetAbsoluteExpiration(DateTime.Now.AddDays(6));
            await cachingProvider.SetAsync(key, data, TimeSpan.FromDays(100));

            return await GetById(key);

        }
        public async Task<ApiResult<bool>> DeleteCart(string key)
        {

            await cachingProvider.RemoveAsync(key);
            return new ApiSuccessResult<bool>();
        }
    }
}
