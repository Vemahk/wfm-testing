using System;
using System.IO;
using System.Net;
using Infrastructure.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Services.Concrete.Helpers
{
    public static class RequestHelper
    {
        public const string ApiUrl = "https://api.warframe.market/v1";

        public static JToken GetItemStatistics(string itemString)
        {
            var uri = new Uri($"{ApiUrl}/items/{itemString.ToSnakeCase()}/statistics");
            var request = WebRequest.Create(uri);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return JToken.ReadFrom(jsonReader);
            }
        }

        public static JToken GetItemOrders(string itemString)
        {
            var uri = new Uri($"{ApiUrl}/items/{itemString.ToSnakeCase()}/orders");
            var request = WebRequest.Create(uri);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return JToken.ReadFrom(jsonReader);
            }
        }
    }
}
