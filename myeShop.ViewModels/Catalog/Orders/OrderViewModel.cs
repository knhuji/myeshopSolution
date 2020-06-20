using myeshop.Data.Entities;
using myeshop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace myeShop.ViewModels.Catalog.Orders
{
    public class OrderViewModel
    {
        public int Order_ID { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public OrderStatus Status { set; get; }

        public IList<ItemOrder> Items { get; set; } = new List<ItemOrder>();

        public User User { get; set; }
    }
}
