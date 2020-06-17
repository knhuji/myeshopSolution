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
        
        Task<ApiResult<PagedResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request);
        
        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);
        Task<ApiResult<UserVm>> GetById(Guid id);
        Task<ApiResult<bool>> Delete(Guid id);
        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
    }
}
