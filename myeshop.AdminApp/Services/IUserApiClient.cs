using myeShop.ViewModels.Common;
using myeShop.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myeshop.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticase(LoginRequest request);
        Task<ApiResult<string>> Register(RegisterRequest request);
    }
}
