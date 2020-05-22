using myeshop.Application.Catalog.Products.Dtos;
using myeshop.Application.Catalog.Products.Dtos.Public;
using myeshop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myeshop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllBySupplierID(GetProductPagingRequest request);
    }
}
