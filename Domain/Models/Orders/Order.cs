using System;
using Domain.Enums;

namespace Domain.Models.Orders
{
    public class Order
    {
        public int Quantity { get; set; }
        public OrderType Type { get; set; }
        public int Plat { get; set; }
        public User User { get; set; }
        public PlatformType Platform { get; set; }
        public string Region { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsVisible { get; set; }
        public string Id { get; set; }
    }
}
