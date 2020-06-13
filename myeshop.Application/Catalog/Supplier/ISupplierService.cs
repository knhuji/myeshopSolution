using myeShop.ViewModels.Catalog.Suppliers;
using myeShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myeshop.Application.Catalog.Suppliers
{
    public interface ISupplierService
    {
        Task<ApiResult<int>> Create(SupplierCreateRequest request);
        Task<ApiResult<int>> Update(SupplierUpdateRequest request);
        Task<ApiResult<bool>> Delete(int supplierId);
        Task<ApiResult<SupplierViewModel>> GetById(int supplierId);
        Task<ApiResult<PagedResult<SupplierViewModel>>> GetAllPaging(SuppliersPagingRequest request);
    }
}
