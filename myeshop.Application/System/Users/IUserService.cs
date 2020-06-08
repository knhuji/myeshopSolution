using myeShop.ViewModels.Common;
using myeShop.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myeshop.Application.System.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);
        Task<ApiResult<bool>> Register(RegisterRequest request);
        //Task<ApiResult<PagedResult<UserVm>>> GetUserPaging(GetUserPagingRequest request);
        
    }
}
