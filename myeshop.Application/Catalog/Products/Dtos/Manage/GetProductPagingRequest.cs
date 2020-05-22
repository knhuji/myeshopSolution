using myeshop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Application.Catalog.Products.Dtos.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> Supplier_IDs { get; set; }
    }
}
