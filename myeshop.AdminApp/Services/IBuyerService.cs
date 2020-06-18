using myeShop.ViewModels.Catalog.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace myeshop.AdminApp.Services
{
    public interface IBuyerService
    {
        Buyer Get(ClaimsPrincipal user);
    }
}
