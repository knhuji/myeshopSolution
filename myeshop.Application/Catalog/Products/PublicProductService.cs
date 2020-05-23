using myeshop.Data.EF;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myeShop.ViewModels.Common;
using myeShop.ViewModels.Catalog.Products;
using myeshop.Application.Catalog.Products.Dtos;

namespace myeshop.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly DataContext _context;
        public PublicProductService(DataContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<ProductViewModel>> GetAllBySupplierID(GetPublicProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pis in _context.ProductInSuppliers on p.Prod_ID equals pis.Prod_ID
                        join s in _context.Suppliers on pis.Supplier_ID equals s.Supplier_ID
                        select new { p, pis, s };

            if (request.Supplier_ID.HasValue && request.Supplier_ID.Value>0)
            {
                query = query.Where(p=>p.pis.Supplier_ID == request.Supplier_ID);
            }

            //Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Prod_ID = x.p.Prod_ID,
                    Prod_Name = x.p.Prod_Name,
                    DateCreate = x.p.DateCreate,
                    Description = x.p.Description,
                    Price = x.p.Price,
                    Quantity = x.p.Quantity,
                    Status = x.p.Status
                }).ToListAsync();

            //Select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }
    }
}
