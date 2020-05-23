using myeshop.Application.Catalog.Products.Dtos;
using myeShop.ViewModels.Catalog.Products;
using myeShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myeshop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllBySupplierID(GetPublicProductPagingRequest request);
    }
}
