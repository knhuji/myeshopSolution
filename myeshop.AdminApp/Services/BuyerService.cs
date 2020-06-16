using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using myeShop.ViewModels.Catalog.Carts;
using Newtonsoft.Json;

namespace myeshop.AdminApp.Services
{
    public class BuyerService : IBuyerService
    {
        public Buyer Get(ClaimsPrincipal user)
        {
            return new Buyer
            {
                Id = user.FindFirstValue("sub"),
                FirstName = user.FindFirstValue("firstname"),
                LastName = user.FindFirstValue("lastname"),
                Address = JsonConvert.DeserializeObject<Address>(user.FindFirstValue("address"))
            };
        }
    }
}
