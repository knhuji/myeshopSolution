using Microsoft.EntityFrameworkCore;
using myeshop.Application.Catalog.Products.Dtos;
using myeshop.Application.Catalog.Products.Dtos.Manage;
using myeshop.Application.Dtos;
using myeshop.Data.EF;
using myeshop.Data.Entities;
using myeShop.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myeshop.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly DataContext _context;
        public ManageProductService(DataContext context)
        {
            _context = context;
        }
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Prod_Name = request.Prod_Name,
                Price = request.Price,
                Quantity = request.Quantity,
                DateCreate = DateTime.Now,
                Description = request.Description
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new MyeshopException($"Sản phẩm không tồn tại");
            }

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }
        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pis in _context.ProductInSuppliers on p.Prod_ID equals pis.Prod_ID
                        join s in _context.Suppliers on pis.Supplier_ID equals s.Supplier_ID
                        select new {p, pis,s};
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.p.Prod_Name.Contains(request.Keyword));
            }
            if(request.Supplier_IDs.Count > 0)
            {
                query = query.Where(p => request.Supplier_IDs.Contains(p.pis.Supplier_ID));
            }

            //Paging
            int totalRow = await query.CountAsync();
            var data =await query.Skip((request.PageIndex - 1) * request.PageSize)
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

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Prod_ID);
            if (product == null)
            {
                throw new MyeshopException($"Sản phẩm không tồn tại");
            }

            product.Prod_Name = request.Prod_Name;
            product.Quantity = request.Quantity;
            product.Description = request.Description;
            product.Status = request.Status;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new MyeshopException($"Sản phẩm không tồn tại");
            }
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0; // >0 return true
        }
    }
}
