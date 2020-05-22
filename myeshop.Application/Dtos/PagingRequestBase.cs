using System;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Application.Dtos
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; } //vị trí trang - trang số bao nhiêu??
        public int PageSize { get; set; } //kích cỡ trang
    }
}
