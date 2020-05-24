using myeShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Application.Catalog.Products.Dtos
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
       public int? Supplier_ID { get; set; }
    }
}
