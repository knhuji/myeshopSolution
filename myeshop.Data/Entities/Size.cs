using System;
using myeshop.Data.Enums;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Data.Entities
{
    public class Size
    {
        public int Size_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public List<ProductInSize> ProductInSizes { get; set; }
    }
}
