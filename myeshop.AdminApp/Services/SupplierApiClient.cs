using myeShop.ViewModels.Catalog.Suppliers;
using myeShop.ViewModels.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace myeshop.AdminApp.Services
{
    public class SupplierApiClient:ISupplierApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SupplierApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResult<int>> Create(SupplierCreateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("/api/Suppliers/", httpContent);
            //var Token = await response.Content.ReadAsStringAsync();
            return new ApiSuccessResult<int>();
        }

        public async Task<ApiResult<int>> Update(SupplierUpdateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PutAsync("/api/Suppliers/", httpContent);
            var Token = await response.Content.ReadAsStringAsync();
            return new ApiSuccessResult<int>();
        }
        public async Task<ApiResult<bool>> Delete(int supplierId)
        {

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");

            var response = await client.DeleteAsync($"/api/Suppliers/{supplierId}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<ApiResult<SupplierViewModel>> GetById(int SupplierId)
        {

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");

            var response = await client.GetAsync($"/api/Suppliers/{SupplierId}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<SupplierViewModel>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<SupplierViewModel>>(body);
        }

        public async Task<ApiResult<PagedResult<SupplierViewModel>>> GetAllPaging(SuppliersPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.GetAsync($"/api/Suppliers/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var supp = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<SupplierViewModel>>>(body);
            return supp;
        }
    }
}
