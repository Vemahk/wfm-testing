using System;
using Domain.Enums;
using Domain.Models.Orders;
using Newtonsoft.Json.Linq;

namespace JsonService.Services.Mapping
{
    public class OrderJsonMapping : JsonMapping<Order>
    {
        public OrderJsonMapping()
        {
        }

        public override Order Parse(JToken token)
        {
            var order = new Order
            {
                Quantity = token.Value<int>("quantity"),
                Type = token.Value<OrderType>("order_type"),
                Plat = token.Value<int>("platinum")

            };

            return order;
        }
    }
}