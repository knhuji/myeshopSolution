using myeshop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Application.Catalog.Products.Dtos.Public
{
    public class GetProductPagingRequest : PagingRequestBase
    {
       public int? Supplier_ID { get; set; }
    }
}
