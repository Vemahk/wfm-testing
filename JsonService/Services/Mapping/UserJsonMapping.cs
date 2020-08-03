using System;
using Domain.Enums;
using Domain.Models.Orders;
using Newtonsoft.Json.Linq;

namespace JsonService.Services.Mapping
{
    public class UserJsonMapping : JsonMapping<User>
    {
        public override User Parse(JToken token)
        {
            TokenNotNull(token);

            var user = new User
            {
                Reputation = token.Value<int>("reputation"),
                ReputationBonus = token.Value<int>("reputation_bonus"),
                Region = token.Value<string>("region"),
                LastSeen = token.Value<DateTime>("last_seen"),
                AvatarUrl = token.Value<string>("avatar"),
                WarframeUserName = token.Value<string>("ingame_name"),
                Status = UserStatusTypeConverter.FromString(token.Value<string>("status")),
                Id = token.Value<string>("id")
            };

            return user;
        }
    }
}