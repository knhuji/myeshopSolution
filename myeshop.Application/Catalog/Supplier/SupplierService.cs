using myeshop.Application.Common;
using myeshop.Data.EF;
using myeShop.ViewModels.Catalog.Suppliers;
using myeShop.ViewModels.Common;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using myeshop.Data.Entities;
using System.Linq;
using myeShop.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace myeshop.Application.Catalog.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private readonly DataContext _context;
        private readonly IStorageService _storageService;

        public SupplierService(DataContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<int> Create(SupplierCreateRequest request)
        {
            var supplier = new Supplier()
            {
                Supplier_Name = request.Supplier_Name,
                Gmail = request.Gmail,
                Address = request.Address,
                Phone = request.Phone
            };
            //Save image
            
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier.Supplier_ID;
        }

        public async Task<ApiResult<bool>> Delete(int supplierId)
        {
            var supplier = await _context.Suppliers.FindAsync(supplierId);
            if (supplier == null)
            {
                return new ApiErrorResult<bool>("Nhà cung cấp không tồn tại");
            }

            var images = _context.Suppliers.Where(i => i.Supplier_ID == supplierId);

            //foreach (var image in images)
            //{
            //    await _storageService.DeleteFileAsync(image.ImagePath);
            //}

            _context.Suppliers.Remove(supplier);

            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

       

        public async Task<ApiResult<int>> Update(SupplierUpdateRequest request)
        {
            var supplier = await _context.Suppliers.FindAsync(request.Supplier_ID);
            if (supplier == null)
            {
                throw new MyeshopException($"Nhà cung cấp không tồn tại");
            }

            supplier.Supplier_Name = request.Supplier_Name;
            supplier.Gmail = request.Gmail;
            supplier.Address = request.Address;
            supplier.Phone = request.Phone;
            supplier.Status = request.Status;

            //Save image
            //if (request.ThumbnailImage != null)
            //{
            //    var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.Prod_ID == request.Prod_ID);
            //    if (thumbnailImage != null)
            //    {
            //        thumbnailImage.FileSize = request.ThumbnailImage.Length;
            //        thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
            //        _context.ProductImages.Update(thumbnailImage);
            //    }
            //}
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>();
        }

        public async Task<ApiResult<SupplierViewModel>> GetById(int supplierId)
        {
            var supplier = await _context.Suppliers.FindAsync(supplierId);
            if(supplier == null)
            {
                return new ApiErrorResult<SupplierViewModel>("Không tìm thấy thương hiệu");
            }

            var supplierViewModel = new SupplierViewModel()
            {
                Supplier_ID = supplier.Supplier_ID,
                Supplier_Name = supplier.Supplier_Name,
                Gmail = supplier.Gmail,
                Address = supplier.Address,
                Phone = supplier.Phone
            };
            return new ApiSuccessResult<SupplierViewModel>(supplierViewModel);
        }
        public async Task<ApiResult<PagedResult<SupplierViewModel>>> GetAllPaging(SuppliersPagingRequest request)
        {
            var query = from s in _context.Suppliers

                        select new { s };
            //if (!string.IsNullOrEmpty(request.Keyword))
            //{
            //    query = query.Where(x => x.p.Prod_Name.Contains(request.Keyword));
            //}
            //if (request.Supplier_ID.Count > 0)
            //{
            //    query = query.Where(p => request.Supplier_ID.Contains(p.pis.Supplier_ID));
            //}

            //Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new SupplierViewModel()
                {
                    Supplier_ID = x.s.Supplier_ID,
                    Supplier_Name = x.s.Supplier_Name,
                    Gmail = x.s.Gmail,
                    Address = x.s.Address,

                    Phone = x.s.Phone,
                    Status = x.s.Status
                }).ToListAsync();

            //Select and projection
            var pagedResult = new PagedResult<SupplierViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<SupplierViewModel>>(pagedResult);
        }
    }
}
