using myeShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeShop.ViewModels.Catalog.Suppliers
{
    public class SuppliersPagingRequest: PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
