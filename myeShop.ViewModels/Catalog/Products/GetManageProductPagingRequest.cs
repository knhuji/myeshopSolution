using myeShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeShop.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        //public List<int> Supplier_ID { get; set; }
    }
}
