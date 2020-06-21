using myeShop.ViewModels.Catalog.Products;
using myeShop.ViewModels.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace myeshop.AdminApp.Services
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResult<int>> Create(ProductCreateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("/api/Products/", httpContent);
            var Token = await response.Content.ReadAsStringAsync();

           
              //  int t = (int)JsonConvert.DeserializeObject(Token, typeof(int));
                return new ApiSuccessResult<int>();
            

        }

        public async Task<ApiResult<int>> Update(ProductUpdateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PutAsync("/api/Products/", httpContent);
            var Token = await response.Content.ReadAsStringAsync();

            return new ApiSuccessResult<int>();
        }
        public async Task<ApiResult<bool>> Delete(int productId)
        {

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");

            var response = await client.DeleteAsync($"/api/Products/{productId}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<ApiResult<ProductViewModel>> GetById(int ProductId)
        {

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");

            var response = await client.GetAsync($"/api/Products/{ProductId}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<ProductViewModel>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<ProductViewModel>>(body);
        }
        public async Task<ApiResult<PagedResult<ProductViewModel>>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.GetAsync($"/api/Products/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var pros = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<ProductViewModel>>>(body);
            return pros;
        }
    }
}
