using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using myeshop.Data.EF;
using myeshop.Data.Entities;
using myeShop.Utilities.Exceptions;
using myeShop.ViewModels.Catalog.Products;
using myeShop.ViewModels.Common;
using myeshop.Application.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using System.Net.Http.Headers;
using myeShop.ViewModels.Catalog.ProductImages;
using myeshop.Application.Catalog.Products.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace myeshop.Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IStorageService _storageService;

        public ProductService(DataContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }


        public async Task<ApiResult<int>> AddImage(int productId, ProductImageCreateRequest request)
        {
            var productImage = new ProductImage()
            {
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                Prod_ID = productId,
                SortOrder = request.SortOrder
            };

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>(productImage.Prod_ID);
        }

        public async Task<ApiResult<int>> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Prod_Name = request.Prod_Name,
                Price = request.Price,
                Quantity = request.Quantity,
                DateCreate = DateTime.Now,
                Description = request.Description
            };
            //Save image
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.ProductImage.Add(product);
            
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>(product.Prod_ID);
        }
        public async Task<ApiResult<ProductViewModel>> GetById(int productId)
        {
            var product = await _context.ProductImage.FindAsync(productId);
            if (product == null)
            {
                return new ApiErrorResult<ProductViewModel>("Không tìm thấy sản phẩm");
            }
            var productViewModel = new ProductViewModel()
            {
                Prod_ID = product.Prod_ID,
                DateCreate = product.DateCreate,
                Description = product.Description,
                Prod_Name = product.Prod_Name,
                Price = product.Price,

                Status=product.Status,
                Quantity=product.Quantity

            };
            return new ApiSuccessResult<ProductViewModel>(productViewModel);

            
        }
        public async Task<ApiResult<ProductImageViewModel>> GetImageById(int Image_ID)
        {
            var image = await _context.ProductImages.FindAsync(Image_ID);
            var proImageViewModel = new ProductImageViewModel()
            {
                Image_ID = image.Image_ID,
                Prod_ID = image.Prod_ID,
                ImagePath = image.ImagePath,
                Caption = image.Caption,
                IsDefault = image.IsDefault,
                DateCreate = image.DateCreate,
                SortOrder = image.SortOrder,
                FileSize = image.FileSize,
                Product = image.Product,
                DateCreated = image.DateCreated,

            };
            return new ApiSuccessResult<ProductImageViewModel>(proImageViewModel);
        }


        public async Task<ApiResult<bool>> Delete(int productId)
        {
            var product = await _context.ProductImage.FindAsync(productId);
            if (product == null)
            {
                return new ApiErrorResult<bool>("Sản phẩm không tồn tại");
            }

            var images = _context.ProductImages.Where(i => i.Prod_ID == productId);

            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }

            _context.ProductImage.Remove(product);

            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<ProductViewModel>>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from p in _context.ProductImage

                        select new { p };
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
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<ProductViewModel>>(pagedResult);
        }

        public Task<ApiResult<List<ProductImageViewModel>>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<int>> RemoveImage(int imageId)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new MyeshopException($"Cannot find an image with id {imageId}");
            _context.ProductImages.Remove(productImage);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>();
        }

        public async Task<ApiResult<int>> Update(ProductUpdateRequest request)
        {
            var product = await _context.ProductImage.FindAsync(request.Prod_ID);
            if (product == null)
            {
                throw new MyeshopException($"Sản phẩm không tồn tại");
            }

            product.Prod_Name = request.Prod_Name;
            product.Price = request.Price;
            product.Quantity = request.Quantity;
            product.Description = request.Description;
            product.Status = request.Status;

            //Save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.Prod_ID == request.Prod_ID);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>();
        }

        public async Task<ApiResult<int>> UpdateImage(int imageId, ProductImageCreateRequest request)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new MyeshopException($"Cannot find an image with id {imageId}");

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Update(productImage);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>();
        }
        public async Task<ApiResult<bool>> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.ProductImage.FindAsync(productId);
            if (product == null)
            {
                return new ApiErrorResult<bool>("Sản phẩm chưa tồn tại");
            }
            product.Price = newPrice;
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<ProductViewModel>>> GetAllBySupplierID(GetPublicProductPagingRequest request)
        {
            var query = from p in _context.ProductImage
                        join pis in _context.ProductInSuppliers on p.Prod_ID equals pis.Prod_ID
                        join s in _context.Suppliers on pis.Supplier_ID equals s.Supplier_ID
                        select new { p, pis, s };

            if (request.Supplier_ID.HasValue && request.Supplier_ID.Value > 0)
            {
                query = query.Where(p => p.pis.Supplier_ID == request.Supplier_ID);
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
                TotalRecords = totalRow,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<ProductViewModel>>(pagedResult);
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

    }
}
