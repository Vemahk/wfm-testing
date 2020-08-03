using System;
using Domain.Enums;

namespace Domain.Models.Orders
{
    public class Order : BaseWfmObject
    {
        public int Quantity { get; set; }            //quantity
        public OrderType Type { get; set; }          //order_type
        public int Plat { get; set; }                //platinum
        public User User { get; set; }               //user
        public PlatformType Platform { get; set; }   //platform
        public string Region { get; set; }           //region
        public DateTime CreatedDate { get; set; }    //creation_date
        public DateTime LastUpdate { get; set; }     //last_update
        public bool IsVisible { get; set; }          //visible
    }
}
