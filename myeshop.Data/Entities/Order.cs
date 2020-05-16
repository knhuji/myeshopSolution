using System;
using myeshop.Data.Enums;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Data.Entities
{
    public class Order
    {
        public int Order_ID { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public OrderStatus Status { set; get; }

        public List<OrderDetail> OrderDetails { get; set; }

        public User User { get; set; }
    }
}
