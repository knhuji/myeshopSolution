using myeShop.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myeshop.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<String> Authenticase(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
