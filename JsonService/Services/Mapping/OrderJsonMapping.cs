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
            TokenNotNull(token);

            var order = new Order
            {
                Quantity = token.Value<int>("quantity"),
                Type = OrderTypeConverter.FromString(token.Value<string>("order_type")),
                Plat = token.Value<int>("platinum"),
                User = Parse<User>(token["user"]),
                Platform = PlatformTypeConverter.FromString(token.Value<string>("platform")),
                Region = token.Value<string>("region"),
                CreatedDate = token.Value<DateTime>("creation_date"),
                LastUpdate = token.Value<DateTime>("last_update"),
                IsVisible = token.Value<bool>("visible"),
                Id = token.Value<string>("id")
            };

            return order;
        }
    }
}