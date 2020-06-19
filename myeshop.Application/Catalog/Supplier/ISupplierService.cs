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
        Task<int> Create(SupplierCreateRequest request);
        Task<int> Update(SupplierUpdateRequest request);
        Task<ApiResult<bool>> Delete(int supplierId);
        Task<ApiResult<SupplierViewModel>> GetById(int SupplierId);
        Task<ApiResult<PagedResult<SupplierViewModel>>> GetAllPaging(SuppliersPagingRequest request);
    }
}
