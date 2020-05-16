using System;
using myeshop.Data.Enums;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Data.Entities
{
    public class Promotion
    {
        public int Promotion_ID { get; set; }
        public string Promotion_Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool ApplyForAll { get; set; }
        public int? DiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string ProductIds { get; set; }
        public string ProductSupplierIds { get; set; }
        public Status Status { get; set; }
    }
}
