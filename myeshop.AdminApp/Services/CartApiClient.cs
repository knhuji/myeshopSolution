using DocumentFormat.OpenXml.Office.CustomUI;
using myeShop.ViewModels.Catalog.Carts;
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
    public class CartApiClient:ICartApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CartApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Cart> GetCart(Buyer buyer)
        {
            var json = JsonConvert.SerializeObject(buyer);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.GetAsync("/api/Carts");
           
            //if (response.IsSuccessStatusCode)
                return new Cart { Id = buyer.Id };

            //return JsonConvert.DeserializeObject<ApiErrorResult<Cart>>(Token);
        }
        public async Task<Cart> Updatecart(Cart request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PutAsync("/api/Carts/", httpContent);
            var Token = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Cart>(Token);

            return JsonConvert.DeserializeObject<Cart>(Token);
        }

        public async Task<ApiResult<bool>> DeleteCart(String key)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");

            var response = await client.DeleteAsync($"/api/Carts/{key}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task AddItemToCart(Buyer buyer, CartItemViewModel cartItem)
        {
            var cart = await GetCart(buyer);
            var itemFound = cart.Items.Find(x => x.Prod_ID == cartItem.Prod_ID);

            if (itemFound == null)
            {
                cart.Items.Add(cartItem);
            }
            else
            {
                itemFound.Quantity++;
            }

            await Updatecart(cart);
        }

        public async Task<Cart> SetQuantities(Buyer user, Dictionary<string, int> quantities)
        {
            var basket = await GetCart(user);

            basket.Items.ForEach(x =>
            {
                if (quantities.TryGetValue(x.Id, out var quantity))
                {
                    x.Quantity = quantity;
                }
            });

            return basket;
        }
    }
}
