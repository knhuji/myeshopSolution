﻿using myeshop.Application.Catalog.Products.Dtos;
using myeShop.ViewModels.Catalog.ProductImages;
using myeShop.ViewModels.Catalog.Products;
using myeShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myeshop.AdminApp.Services
{
    public interface IProductApiClient
    {
        Task<ApiResult<string>> Create(ProductCreateRequest request);
        Task<ApiResult<int>> Update(ProductUpdateRequest request);
        Task<ApiResult<bool>> Delete(int productId);
        Task<ApiResult<ProductViewModel>> GetById(int ProductId);
        //Task<ApiResult<bool>> UpdatePrice(int productId, decimal newPrice);
        //Task<List<ProductViewModel>> GetAll();
        Task<ApiResult<PagedResult<ProductViewModel>>> GetAllPaging(GetManageProductPagingRequest request);
        //Task<ApiResult<ProductImageViewModel>> GetImageById(int Image_ID);
        //Task<ApiResult<int>> AddImage(int productId, ProductImageCreateRequest request);
        //Task<ApiResult<int>> RemoveImage(int imageId);
        //Task<ApiResult<int>> UpdateImage(int imageId, ProductImageCreateRequest request);
        //Task<ApiResult<List<ProductImageViewModel>>> GetListImage(int productId);
        //Task<ApiResult<PagedResult<ProductViewModel>>> GetAllBySupplierID(GetPublicProductPagingRequest request);

    }
}
